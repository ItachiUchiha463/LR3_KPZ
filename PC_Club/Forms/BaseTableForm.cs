using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace PC_Club.Forms
{
    public partial class BaseTableForm : Form
    {
        private DataTable _table;
        private Action _save;
        private readonly Dictionary<string, DataTable> _lookups = new Dictionary<string, DataTable>();
        private readonly Dictionary<string, string> _captions = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _textCols = new Dictionary<string, string>();
        private readonly HashSet<string> _hidden = new HashSet<string>();
        private readonly HashSet<string> _withTime = new HashSet<string>();
        private readonly List<string> _conditions = new List<string>();

        private RecordEditor _editor;
        private DataRow _newRow;
        private DataRow _shownRow;
        private bool _dirty;
        private bool _switching;
        private string _lastSearchKey = "";

        public BaseTableForm()
        {
            InitializeComponent();
            dgv.DataError += dgv_DataError;
            dgv.Sorted += (s, ev) => ClearHighlight();
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            bindingSource1.ListChanged += (s, ev) => UpdateCounter();
            FormClosing += BaseTableForm_FormClosing;
        }

        private string Field
        {
            get { return cbField.SelectedValue as string ?? ""; }
        }

        private string SearchField
        {
            get { return cbSearchField.SelectedValue as string ?? ""; }
        }

        protected void Bind(DataTable table, Action save, params string[] searchFields)
        {
            _table = table;
            _save = save;
            bindingSource1.DataSource = table;

            dgv.AutoGenerateColumns = true;
            dgv.DataSource = bindingSource1;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn c in dgv.Columns)
                c.HeaderText = Captions.Get(table.TableName, c.Name);
            foreach (DataColumn col in table.Columns)
                _captions[col.ColumnName] = Captions.Get(table.TableName, col.ColumnName);

            var fields = new DataTable();
            fields.Columns.Add("field", typeof(string));
            fields.Columns.Add("caption", typeof(string));

            if (searchFields.Length > 0)
            {
                foreach (string f in searchFields)
                    fields.Rows.Add(f, Captions.Get(table.TableName, f));
            }
            else
            {
                foreach (DataColumn col in table.Columns)
                    fields.Rows.Add(col.ColumnName, Captions.Get(table.TableName, col.ColumnName));
            }

            cbField.DataSource = fields;
            cbField.DisplayMember = "caption";
            cbField.ValueMember = "field";
            if (fields.Rows.Count > 0) cbField.SelectedIndex = 0;

            cbSearchField.DataSource = new DataView(fields);
            cbSearchField.DisplayMember = "caption";
            cbSearchField.ValueMember = "field";
            if (fields.Rows.Count > 0) cbSearchField.SelectedIndex = 0;

            if (cbOp.SelectedIndex < 0) cbOp.SelectedIndex = 0;
            UpdateCounter();
        }

        protected void AddLookup(string columnName, DataTable source, string header)
        {
            _lookups[columnName] = source;
            _captions[columnName] = header;

            string textCol = columnName + "_txt";
            _textCols[columnName] = textCol;
            if (!_table.Columns.Contains(textCol))
                _table.Columns.Add(textCol, typeof(string));
            _hidden.Add(textCol);
            FillLookupText();

            var fields = cbField.DataSource as DataTable;
            if (fields != null)
            {
                foreach (DataRow r in fields.Select("field = '" + columnName + "'"))
                {
                    r["field"] = textCol;
                    r["caption"] = header;
                }
            }

            ApplyLookupColumns();
        }

        private void FillLookupText()
        {
            foreach (var pair in _lookups)
            {
                var map = new Dictionary<string, string>();
                foreach (DataRow r in pair.Value.Rows)
                    if (r["id"] != DBNull.Value)
                        map[Convert.ToString(r["id"])] = Convert.ToString(r["text"]);

                string fk = pair.Key;
                string tc = _textCols[fk];

                foreach (DataRow row in _table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    string s = "";
                    if (row[fk] != DBNull.Value)
                        map.TryGetValue(Convert.ToString(row[fk]), out s);
                    row[tc] = s ?? "";
                }
            }
            _table.AcceptChanges();
        }

        private void ApplyLookupColumns()
        {
            foreach (var pair in _lookups)
            {
                string name = pair.Key;
                var existing = dgv.Columns[name];
                if (existing is DataGridViewComboBoxColumn) continue;

                var combo = new DataGridViewComboBoxColumn
                {
                    Name = name,
                    DataPropertyName = name,
                    HeaderText = _captions[name],
                    DataSource = pair.Value,
                    DisplayMember = "text",
                    ValueMember = "id",
                    DisplayStyleForCurrentCellOnly = false,
                    FlatStyle = FlatStyle.Flat
                };

                if (existing != null)
                {
                    int index = existing.Index;
                    dgv.Columns.Remove(existing);
                    dgv.Columns.Insert(index, combo);
                }
                else dgv.Columns.Add(combo);
            }

            foreach (string t in _textCols.Values)
                if (dgv.Columns[t] != null) dgv.Columns[t].Visible = false;

            foreach (DataGridViewColumn c in dgv.Columns)
                if (_captions.ContainsKey(c.Name)) c.HeaderText = _captions[c.Name];
        }

        protected void HideInEditor(params string[] columns)
        {
            foreach (string c in columns) _hidden.Add(c);
        }

        protected void ShowTimeIn(params string[] columns)
        {
            foreach (string c in columns) _withTime.Add(c);
        }

        protected void SetReadOnly(bool readOnly)
        {
            btnAdd.Visible = !readOnly;
            btnDelete.Visible = !readOnly;
            panelEdit.Visible = !readOnly;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _editor = new RecordEditor(panelFields, _table, _lookups, _captions, _hidden, _withTime);
            _editor.Changed += (s, ev) => SetDirty(true);

            bool readOnly = !CurrentUser.CanEdit(GetType().Name);
            SetReadOnly(readOnly);
            if (readOnly) Text += " (тільки перегляд)";

            ShowCurrent();
            UpdateCounter();
            FitFormToGrid();
        }

        private void FitFormToGrid()
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int total = dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0;
            foreach (DataGridViewColumn c in dgv.Columns)
                if (c.Visible) total += c.Width;
            total += SystemInformation.VerticalScrollBarWidth + 4;

            int extra = total - dgv.ClientSize.Width;
            int maxWidth = Screen.FromControl(this).WorkingArea.Width;
            int newWidth = Math.Min(Width + extra, maxWidth);

            if (TopLevel && newWidth > Width)
            {
                Width = newWidth;
                CenterToScreen();
            }

            if (total <= dgv.ClientSize.Width)
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetDirty(bool value)
        {
            _dirty = value;
            string title = _newRow != null ? "Новий запис" : "Редагування запису";
            lblEditTitle.Text = value ? title + " (є зміни)" : title;
            btnSaveRecord.UseVisualStyleBackColor = !value;
            btnSaveRecord.BackColor = value ? Color.LightGreen : SystemColors.Control;
        }

        private void ShowCurrent()
        {
            if (_editor == null) return;

            var current = bindingSource1.Current as DataRowView;
            if (current == null)
            {
                StartNew();
                return;
            }

            _newRow = null;
            _shownRow = current.Row;
            _editor.Show(current.Row);
            SetDirty(false);
        }

        private void StartNew()
        {
            _newRow = _table.NewRow();
            _shownRow = null;
            _editor.Show(_newRow);
            SetDirty(false);
            _editor.FocusFirst();
        }

        private bool ConfirmLeave()
        {
            if (!_dirty) return true;

            var answer = MessageBox.Show("У панелі редагування є незбережені зміни. Зберегти їх?",
                                         "Незбережені зміни",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (answer == DialogResult.Cancel) return false;
            if (answer == DialogResult.No)
            {
                SetDirty(false);
                return true;
            }

            _switching = true;
            try { return SaveRecord(); }
            finally { _switching = false; }
        }

        private int IndexOfRow(DataRow row)
        {
            if (row == null) return -1;
            for (int i = 0; i < bindingSource1.Count; i++)
                if (((DataRowView)bindingSource1[i]).Row == row) return i;
            return -1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (_switching || _editor == null) return;

            if (!ConfirmLeave())
            {
                int index = IndexOfRow(_shownRow);
                if (index >= 0)
                {
                    _switching = true;
                    bindingSource1.Position = index;
                    _switching = false;
                }
                return;
            }

            ShowCurrent();
        }

        private void BaseTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmLeave()) e.Cancel = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_editor == null || !ConfirmLeave()) return;
            StartNew();
        }

        private void btnCancelRecord_Click(object sender, EventArgs e)
        {
            ShowCurrent();
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            bool ok;
            _switching = true;
            try { ok = SaveRecord(); }
            finally { _switching = false; }

            if (ok) ShowCurrent();
        }

        private bool SaveRecord()
        {
            if (_editor == null) return false;

            if (_newRow != null)
            {
                string error = _editor.Apply(_newRow);
                if (error != null)
                {
                    MessageBox.Show(error, "Перевірте поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                try
                {
                    _table.Rows.Add(_newRow);
                }
                catch (ConstraintException)
                {
                    MessageBox.Show("Такий запис уже існує", "Дублікат");
                    return false;
                }

                if (!TrySave())
                {
                    _newRow = _table.NewRow();
                    return false;
                }

                if (_table.PrimaryKey.Length > 0)
                {
                    int pos = bindingSource1.Find(_table.PrimaryKey[0].ColumnName, _newRow[_table.PrimaryKey[0]]);
                    if (pos >= 0) bindingSource1.Position = pos;
                }
                _newRow = null;
                return true;
            }

            if (_shownRow == null) return false;

            string err = _editor.Apply(_shownRow);
            if (err != null)
            {
                MessageBox.Show(err, "Перевірте поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return TrySave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_newRow != null)
            {
                ShowCurrent();
                return;
            }

            var current = bindingSource1.Current as DataRowView;
            if (current == null) return;

            var answer = MessageBox.Show("Видалити вибраний запис?", "Підтвердження",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            _switching = true;
            try
            {
                SetDirty(false);
                current.Row.Delete();
                TrySave();
            }
            finally
            {
                _switching = false;
            }
            ShowCurrent();
        }

        private bool TrySave()
        {
            try
            {
                _save?.Invoke();
                FillLookupText();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Errors.Friendly(ex), "Не вдалося зберегти",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _table.RejectChanges();
                foreach (DataRow r in _table.Rows) r.ClearErrors();
                return false;
            }
        }

        private void UpdateCounter()
        {
            if (_table == null) return;

            int total = _table.Select().Length;
            int shown = bindingSource1.Count;
            lblCount.Text = shown == total
                ? "Записів: " + total
                : "Записів: " + shown + " з " + total + " (застосовано фільтр)";
        }

        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            ClearHighlight();
            lblFound.Text = "";
            if (Field != "") bindingSource1.Sort = Field + " ASC";
        }

        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            ClearHighlight();
            lblFound.Text = "";
            if (Field != "") bindingSource1.Sort = Field + " DESC";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (Field == "") return;

            string text = txtValue.Text.Trim();
            if (text == "")
            {
                MessageBox.Show("Введіть значення для умови");
                return;
            }

            string expr;
            try
            {
                expr = FilterCondition.Build(_table.Columns[Field], cbOp.Text, text);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                MessageBox.Show("Значення не відповідає типу поля «" + cbField.Text + "»");
                return;
            }

            _conditions.Add(expr);
            lstConditions.Items.Add(cbField.Text + " " + cbOp.Text + " " + text);

            try
            {
                ApplyFilter();
                txtValue.Clear();
            }
            catch (Exception ex)
            {
                _conditions.RemoveAt(_conditions.Count - 1);
                lstConditions.Items.RemoveAt(lstConditions.Items.Count - 1);
                ApplyFilter();
                MessageBox.Show(ex.Message, "Помилка фільтра");
            }
        }

        private void btnRemoveCond_Click(object sender, EventArgs e)
        {
            int i = lstConditions.SelectedIndex;
            if (i < 0) return;

            _conditions.RemoveAt(i);
            lstConditions.Items.RemoveAt(i);
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            ClearHighlight();
            lblFound.Text = "";

            if (_conditions.Count == 0)
            {
                bindingSource1.RemoveFilter();
                return;
            }

            bindingSource1.Filter = "(" + string.Join(") AND (", _conditions) + ")";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _conditions.Clear();
            lstConditions.Items.Clear();
            bindingSource1.RemoveFilter();
            bindingSource1.RemoveSort();
            txtValue.Clear();
            txtSearch.Clear();
            ClearHighlight();
            lblFound.Text = "";
            _lastSearchKey = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string field = SearchField;
            string text = txtSearch.Text.Trim();
            if (field == "" || text == "") return;

            string key = field + "|" + text;
            bool newSearch = key != _lastSearchKey;
            _lastSearchKey = key;

            var matches = new List<int>();
            for (int i = 0; i < bindingSource1.Count; i++)
            {
                var row = (DataRowView)bindingSource1[i];
                string value = Convert.ToString(row[field]);
                if (value.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                    matches.Add(i);
            }

            if (matches.Count == 0)
            {
                ClearHighlight();
                lblFound.Text = "Збігів: 0";
                MessageBox.Show("Нічого не знайдено");
                return;
            }

            int target;
            if (newSearch)
            {
                target = TryFindExact(field, text);
                if (target < 0) target = matches[0];
            }
            else
            {
                int k = matches.FindIndex(i => i > bindingSource1.Position);
                target = k >= 0 ? matches[k] : matches[0];
            }

            Highlight(matches);
            bindingSource1.Position = target;

            int number = Math.Max(1, matches.IndexOf(target) + 1);
            lblFound.Text = matches.Count == 1
                ? "Збігів: 1"
                : "Збігів: " + matches.Count + " (поточний " + number + ")";
        }

        private int TryFindExact(string field, string text)
        {
            if (_textCols.ContainsValue(field)) return -1;
            try
            {
                object key = Convert.ChangeType(text, _table.Columns[field].DataType);
                return bindingSource1.Find(field, key);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void Highlight(List<int> rows)
        {
            ClearHighlight();
            foreach (int i in rows)
                dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void ClearHighlight()
        {
            foreach (DataGridViewRow r in dgv.Rows)
                r.DefaultCellStyle.BackColor = Color.Empty;
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Некоректне значення в полі");
            e.ThrowException = false;
        }

        private void menuSortAsc_Click(object sender, EventArgs e) { btnSortAsc_Click(sender, e); }
        private void menuSortDesc_Click(object sender, EventArgs e) { btnSortDesc_Click(sender, e); }
        private void menuFilter_Click(object sender, EventArgs e) { btnFilter_Click(sender, e); }
        private void menuFind_Click(object sender, EventArgs e) { btnFind_Click(sender, e); }
        private void menuReset_Click(object sender, EventArgs e) { btnReset_Click(sender, e); }
    }
}
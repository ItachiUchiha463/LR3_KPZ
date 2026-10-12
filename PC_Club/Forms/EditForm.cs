using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    public class EditForm : Form
    {
        private readonly DataTable _table;
        private readonly DataRow _row;
        private readonly Dictionary<string, string> _captions;
        private readonly Dictionary<string, Control> _controls = new Dictionary<string, Control>();
        private readonly List<Action> _afterLoad = new List<Action>();
        private readonly HashSet<string> _withTime;
        public EditForm(string title, DataTable table, DataRow row,
                        Dictionary<string, DataTable> lookups,
                        Dictionary<string, string> captions,
                        HashSet<string> hidden,
                        HashSet<string> withTime)

        {
            _table = table;
            _row = row;
            _captions = captions;
            _withTime = withTime;
            Text = title;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                Padding = new Padding(15, 15, 15, 5)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260));

            foreach (DataColumn col in table.Columns)
            {
                if (col.AutoIncrement || hidden.Contains(col.ColumnName)) continue;

                var label = new Label
                {
                    Text = Caption(col.ColumnName) + (col.AllowDBNull ? "" : " *"),
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Margin = new Padding(3, 8, 10, 8)
                };

                Control input = CreateInput(col, lookups);
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                input.Margin = new Padding(3, 5, 3, 5);

                layout.Controls.Add(label);
                layout.Controls.Add(input);
                _controls[col.ColumnName] = input;
            }

            var btnOk = new Button { Text = "Зберегти", Width = 100 };
            var btnCancel = new Button { Text = "Скасувати", Width = 100, DialogResult = DialogResult.Cancel };
            btnOk.Click += btnOk_Click;

            var buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 50,
                Padding = new Padding(10)
            };
            buttons.Controls.Add(btnCancel);
            buttons.Controls.Add(btnOk);

            Controls.Add(layout);
            Controls.Add(buttons);
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            layout.PerformLayout();
            Size pref = layout.GetPreferredSize(Size.Empty);
            ClientSize = new Size(pref.Width, pref.Height + buttons.Height);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (var action in _afterLoad) action();
        }

        private string Caption(string columnName)
        {
            return _captions.ContainsKey(columnName) ? _captions[columnName] : columnName;
        }

        private Control CreateInput(DataColumn col, Dictionary<string, DataTable> lookups)
        {
            object current = _row[col];
            bool isNull = current == DBNull.Value;

            if (lookups.ContainsKey(col.ColumnName))
            {
                DataTable source = lookups[col.ColumnName];
                var combo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDown,
                    AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                    AutoCompleteSource = AutoCompleteSource.ListItems,
                    DisplayMember = "text",
                    ValueMember = "id"
                };
                combo.DataSource = new DataView(source);
                _afterLoad.Add(() => combo.SelectedIndex = FindIndex(source, current));
                return combo;
            }

            if (col.DataType == typeof(DateTime))
            {
                bool withTime = _withTime.Contains(col.ColumnName);
                var dtp = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = withTime ? "dd.MM.yyyy HH:mm" : "dd.MM.yyyy",
                    ShowCheckBox = col.AllowDBNull
                };
                if (!isNull) dtp.Value = (DateTime)current;
                else if (col.AllowDBNull) dtp.Checked = false;
                else dtp.Value = DateTime.Now;
                return dtp;
            }

            if (col.DataType == typeof(bool))
            {
                return new CheckBox { Checked = !isNull && (bool)current };
            }

            var tb = new TextBox();
            if (col.DataType == typeof(string) && col.MaxLength > 0) tb.MaxLength = col.MaxLength;
            if (!isNull) tb.Text = Convert.ToString(current, CultureInfo.CurrentCulture);
            return tb;
        }

        private static int FindIndex(DataTable lookup, object value)
        {
            for (int i = 0; i < lookup.Rows.Count; i++)
            {
                object id = lookup.Rows[i]["id"];
                if (id == DBNull.Value && value == DBNull.Value) return i;
                if (id != DBNull.Value && value != DBNull.Value &&
                    Convert.ToInt32(id) == Convert.ToInt32(value)) return i;
            }
            return -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, object>();

            try
            {
                foreach (var pair in _controls)
                    values[pair.Key] = ReadValue(_table.Columns[pair.Key], pair.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Перевірте поля");
                return;
            }

            _row.BeginEdit();
            try
            {
                foreach (var pair in values)
                    _row[pair.Key] = pair.Value;
                _row.EndEdit();
            }
            catch (ConstraintException)
            {
                _row.CancelEdit();
                MessageBox.Show("Такий запис уже існує", "Дублікат");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private object ReadValue(DataColumn col, Control c)
        {
            string caption = Caption(col.ColumnName);

            if (c is ComboBox combo)
            {
                DataRowView item = combo.SelectedItem as DataRowView;

                if (item == null && combo.Text.Trim() != "")
                {
                    int i = combo.FindStringExact(combo.Text.Trim());
                    if (i >= 0) item = combo.Items[i] as DataRowView;
                }

                if (item == null)
                {
                    if (combo.Text.Trim() == "" && col.AllowDBNull) return DBNull.Value;
                    throw new Exception("Виберіть значення зі списку в полі «" + caption + "»");
                }

                if (item["id"] == DBNull.Value && !col.AllowDBNull)
                    throw new Exception("Виберіть значення зі списку в полі «" + caption + "»");

                return item["id"];
            }

            if (c is DateTimePicker dtp)
            {
                if (dtp.ShowCheckBox && !dtp.Checked) return DBNull.Value;
                DateTime v = dtp.Value;
                return new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0);
            }

            if (c is CheckBox cb) return cb.Checked;

            string text = ((TextBox)c).Text.Trim();
            if (text == "")
            {
                if (!col.AllowDBNull)
                    throw new Exception("Заповніть поле «" + caption + "»");
                return DBNull.Value;
            }
            if (col.DataType == typeof(string)) return text;

            try
            {
                return Convert.ChangeType(text.Replace(',', '.'), col.DataType, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new Exception("Поле «" + caption + "» має неправильний формат");
            }
        }
    }
}
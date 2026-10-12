using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    // Універсальна форма запиту: поля параметрів будуються з опису QueryDef,
    // запит виконується через SqlCommand з параметрами, результат показується в DataGridView
    public class QueryForm : Form
    {
        // Дозволені оператори порівняння: лише вони можуть потрапити в текст запиту
        private static readonly string[] Operators = { "=", "<", ">", "<=", ">=", "<>" };

        private readonly QueryDef _q;
        private readonly Dictionary<string, Control> _inputs = new Dictionary<string, Control>();
        private readonly List<Action> _lookupDefaults = new List<Action>();

        private readonly DataGridView _grid = new DataGridView();
        private readonly TextBox _sqlBox = new TextBox();
        private readonly ToolStripStatusLabel _count = new ToolStripStatusLabel();
        private readonly Button _btnRun = new Button();

        public QueryForm(QueryDef q)
        {
            _q = q;
            Text = q.Code + ". " + q.Title;
            Font = new Font("Segoe UI", 9.5f);
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(1050, 650);
            MinimumSize = new Size(700, 450);
            BuildUi();
        }

        // ---------- Побудова інтерфейсу ----------

        private void BuildUi()
        {
            // Порядок додавання важливий для Dock: спочатку те, що заповнює решту,
            // потім нижні панелі, потім верхні (останнім додається найвища)

            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.RowHeadersVisible = false;
            _grid.BackgroundColor = Color.White;
            _grid.CellFormatting += Grid_CellFormatting;
            Controls.Add(_grid);

            _sqlBox.Dock = DockStyle.Bottom;
            _sqlBox.Height = 160;
            _sqlBox.Multiline = true;
            _sqlBox.ReadOnly = true;
            _sqlBox.WordWrap = false;
            _sqlBox.ScrollBars = ScrollBars.Both;
            _sqlBox.Font = new Font("Consolas", 9.5f);
            _sqlBox.Visible = false;
            Controls.Add(_sqlBox);

            var status = new StatusStrip();
            _count.Text = "Рядків: 0";
            status.Items.Add(_count);
            Controls.Add(status);

            // Параметри
            var paramsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                Padding = new Padding(8, 4, 8, 8)
            };

            foreach (QueryParam p in _q.Params)
            {
                if (p.Kind == ParamKind.CurrentClient) continue;   // поля немає

                Control input = CreateInput(p);
                _inputs[p.Name] = input;
                paramsPanel.Controls.Add(WithCaption(p.Caption, input, p.Width));
            }

            _btnRun.Text = _q.IsAction ? "Виконати" : "Знайти";
            _btnRun.Width = 110;
            _btnRun.Height = 30;
            _btnRun.Margin = new Padding(6, 21, 3, 3);
            _btnRun.Click += (s, e) => Run();
            paramsPanel.Controls.Add(_btnRun);
            AcceptButton = _btnRun;

            var showSql = new CheckBox
            {
                Text = "Показати SQL",
                AutoSize = true,
                Margin = new Padding(12, 27, 3, 3)
            };
            showSql.CheckedChanged += (s, e) => _sqlBox.Visible = showSql.Checked;
            paramsPanel.Controls.Add(showSql);

            Controls.Add(paramsPanel);

            // Шапка: назва й пояснення запиту
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 78,
                Padding = new Padding(12, 8, 12, 4),
                BackColor = Color.White
            };
            var lblDesc = new Label
            {
                Dock = DockStyle.Fill,
                Text = _q.Description ?? "",
                ForeColor = Color.DimGray
            };
            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 30,
                Text = _q.Code + ". " + _q.Title + (_q.IsAction ? "   (запит на зміну даних)" : ""),
                Font = new Font("Segoe UI", 13f, FontStyle.Bold)
            };
            header.Controls.Add(lblDesc);
            header.Controls.Add(lblTitle);
            Controls.Add(header);
        }

        // Підпис над полем
        private Control WithCaption(string caption, Control input, int width)
        {
            int captionWidth = TextRenderer.MeasureText(caption, Font).Width + 4;
            int w = Math.Max(width, captionWidth);

            var box = new Panel { Width = w, Height = 52, Margin = new Padding(3, 3, 10, 3) };
            var label = new Label { Text = caption, AutoSize = true, Location = new Point(0, 0) };
            input.Location = new Point(0, 22);
            input.Width = width;
            box.Controls.Add(label);
            box.Controls.Add(input);
            return box;
        }

        private Control CreateInput(QueryParam p)
        {
            object def = p.Default != null ? p.Default() : null;

            switch (p.Kind)
            {
                case ParamKind.Int:
                case ParamKind.Decimal:
                    {
                        var num = new NumericUpDown
                        {
                            Minimum = p.Min,
                            Maximum = p.Max,
                            DecimalPlaces = p.Kind == ParamKind.Decimal ? 2 : 0,
                            ThousandsSeparator = true,
                            TextAlign = HorizontalAlignment.Right
                        };
                        if (def != null)
                            num.Value = Math.Min(p.Max, Math.Max(p.Min, Convert.ToDecimal(def)));
                        return num;
                    }

                case ParamKind.Date:
                case ParamKind.OptionalDate:
                    {
                        var dtp = new DateTimePicker { Format = DateTimePickerFormat.Short };
                        if (p.Kind == ParamKind.OptionalDate)
                        {
                            dtp.ShowCheckBox = true;
                            dtp.Checked = false;
                        }
                        if (def != null) dtp.Value = Convert.ToDateTime(def);
                        return dtp;
                    }

                case ParamKind.Phone:
                    return new MaskedTextBox
                    {
                        Mask = "(000) 000-00-00",
                        TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    };

                case ParamKind.Lookup:
                    {
                        var combo = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDown,
                            AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                            AutoCompleteSource = AutoCompleteSource.ListItems,
                            DisplayMember = "text",
                            ValueMember = "id"
                        };
                        combo.DataSource = LoadLookup(p);

                        // вибір за замовчуванням ставиться, коли форма вже показана
                        _lookupDefaults.Add(() =>
                        {
                            if (def != null) combo.SelectedValue = def;
                            else if (p.AllOption) combo.SelectedIndex = 0;
                            else combo.SelectedIndex = -1;
                            if (combo.SelectedIndex < 0) combo.Text = "";
                        });
                        return combo;
                    }

                case ParamKind.Choice:
                    {
                        var combo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
                        combo.Items.AddRange(p.Choices);
                        combo.SelectedIndex = 0;
                        if (def != null) combo.SelectedItem = Convert.ToString(def);
                        return combo;
                    }

                case ParamKind.Operator:
                    {
                        var combo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
                        combo.Items.AddRange(Operators);
                        combo.SelectedItem = def != null ? Convert.ToString(def) : "=";
                        return combo;
                    }

                default:
                    return new TextBox { Text = def != null ? Convert.ToString(def) : "" };
            }
        }

        // Список для Lookup (за потреби з пунктом «Усі»)
        private static DataTable LoadLookup(QueryParam p)
        {
            DataTable t;
            try
            {
                t = p.Source();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Errors.Friendly(ex), "Не вдалося завантажити список «" + p.Caption + "»");
                t = new DataTable();
                t.Columns.Add("id", typeof(int));
                t.Columns.Add("text", typeof(string));
            }

            if (p.AllOption)
            {
                DataRow all = t.NewRow();
                all["id"] = 0;
                all["text"] = "Усі";
                t.Rows.InsertAt(all, 0);
            }
            return t;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (Action apply in _lookupDefaults) apply();
            if (_q.AutoRun) Run();
        }

        // ---------- Збирання значень параметрів ----------

        private bool Fail(Control c, string message)
        {
            MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (c != null) c.Focus();
            return false;
        }

        // values: ім'я параметра → значення; ops: ім'я заглушки → оператор
        private bool Collect(out Dictionary<string, object> values, out Dictionary<string, string> ops)
        {
            values = new Dictionary<string, object>();
            ops = new Dictionary<string, string>();

            foreach (QueryParam p in _q.Params)
            {
                if (p.Kind == ParamKind.CurrentClient)
                {
                    if (CurrentUser.ClientId == null)
                        return Fail(null, "Цей запит доступний лише клієнту, який увійшов під своїм обліковим записом.");
                    values[p.Name] = CurrentUser.ClientId.Value;
                    continue;
                }

                Control c = _inputs[p.Name];
                switch (p.Kind)
                {
                    case ParamKind.Int:
                        values[p.Name] = (int)((NumericUpDown)c).Value;
                        break;

                    case ParamKind.Decimal:
                        values[p.Name] = ((NumericUpDown)c).Value;
                        break;

                    case ParamKind.Date:
                        values[p.Name] = ((DateTimePicker)c).Value.Date;
                        break;

                    case ParamKind.OptionalDate:
                        {
                            var dtp = (DateTimePicker)c;
                            values[p.Name] = dtp.Checked ? (object)dtp.Value.Date : DBNull.Value;
                            break;
                        }

                    case ParamKind.Phone:
                        {
                            var mtb = (MaskedTextBox)c;
                            if (mtb.Text == "")
                            {
                                if (p.Required) return Fail(c, "Заповніть поле «" + p.Caption + "».");
                                values[p.Name] = DBNull.Value;
                            }
                            else if (!mtb.MaskCompleted)
                                return Fail(c, "Поле «" + p.Caption + "» має містити 10 цифр.");
                            else
                                values[p.Name] = mtb.Text;     // без маски: лише цифри
                            break;
                        }

                    case ParamKind.Lookup:
                        {
                            var combo = (ComboBox)c;
                            object v = combo.SelectedValue;

                            // якщо значення набрали вручну, шукаємо його у списку за точним збігом
                            if (v == null && combo.Text.Trim() != "")
                            {
                                int i = combo.FindStringExact(combo.Text.Trim());
                                if (i >= 0)
                                {
                                    combo.SelectedIndex = i;
                                    v = combo.SelectedValue;
                                }
                            }

                            if (v == null || v == DBNull.Value)
                            {
                                if (p.Required) return Fail(c, "Виберіть значення зі списку в полі «" + p.Caption + "».");
                                values[p.Name] = DBNull.Value;
                            }
                            else values[p.Name] = Convert.ToInt32(v);
                            break;
                        }

                    case ParamKind.Choice:
                        values[p.Name] = ((ComboBox)c).Text;
                        break;

                    case ParamKind.Operator:
                        {
                            string op = ((ComboBox)c).Text;
                            if (!Operators.Contains(op)) return Fail(c, "Виберіть оператор порівняння зі списку.");
                            ops[p.Name] = op;
                            break;
                        }

                    default:
                        {
                            string text = c.Text.Trim();
                            if (text == "" && p.Required) return Fail(c, "Заповніть поле «" + p.Caption + "».");
                            values[p.Name] = text;
                            break;
                        }
                }
            }
            return true;
        }

        // Підставляє оператори порівняння замість заглушок {name}
        private static string Prepare(string sql, Dictionary<string, string> ops)
        {
            foreach (var pair in ops)
                sql = sql.Replace("{" + pair.Key + "}", pair.Value);
            return sql;
        }

        // Нові об'єкти параметрів для кожної команди (один SqlParameter не можна додати у дві команди)
        private static SqlParameter[] MakeParams(Dictionary<string, object> values)
        {
            return values.Select(v => Db.P("@" + v.Key, v.Value)).ToArray();
        }

        // ---------- Виконання ----------

        private void Run()
        {
            Dictionary<string, object> values;
            Dictionary<string, string> ops;
            if (!Collect(out values, out ops)) return;

            ShowSql(Prepare(_q.Sql, ops), values);

            try
            {
                if (_q.IsAction)
                {
                    RunAction(values, ops);
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    ShowTable(Db.GetTable(Prepare(_q.Sql, ops), MakeParams(values)));
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(Errors.Friendly(ex), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // INSERT / UPDATE / DELETE: попередній перегляд → підтвердження → виконання → результат
        private void RunAction(Dictionary<string, object> values, Dictionary<string, string> ops)
        {
            int previewCount = 0;

            if (_q.PreviewSql != null)
            {
                DataTable preview = Db.GetTable(Prepare(_q.PreviewSql, ops), MakeParams(values));
                ShowTable(preview);
                previewCount = preview.Rows.Count;

                if (previewCount == 0)
                {
                    MessageBox.Show("Немає записів, які відповідають умові. Нічого не змінено.", Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string confirm = string.Format(_q.ConfirmText ?? "Виконати запит?", previewCount);
            if (MessageBox.Show(confirm, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            int affected = Db.Execute(Prepare(_q.Sql, ops), MakeParams(values));
            Cursor = Cursors.Default;

            if (affected == 0 && _q.ZeroText != null)
                MessageBox.Show(_q.ZeroText, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(string.Format(_q.SuccessText ?? "Виконано. Змінено записів: {0}.", affected, previewCount),
                                Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_q.ResultSql != null)
                ShowTable(Db.GetTable(Prepare(_q.ResultSql, ops), MakeParams(values)));
            else if (_q.PreviewSql != null)
                ShowTable(Db.GetTable(Prepare(_q.PreviewSql, ops), MakeParams(values)));
        }

        // ---------- Показ результату ----------

        private void ShowTable(DataTable table)
        {
            _grid.DataSource = table;

            foreach (DataGridViewColumn c in _grid.Columns)
            {
                string name = c.DataPropertyName;
                if (_q.CaptionsFrom != null) c.HeaderText = Captions.Get(_q.CaptionsFrom, name);
                if (_q.HiddenColumns.Contains(name)) c.Visible = false;

                if (!table.Columns.Contains(name)) continue;
                Type t = table.Columns[name].DataType;

                if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
                {
                    c.DefaultCellStyle.Format = "N2";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (t == typeof(int) || t == typeof(long) || t == typeof(short))
                {
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (t == typeof(DateTime))
                {
                    c.DefaultCellStyle.Format = HasTime(table, name) ? "dd.MM.yyyy HH:mm" : "dd.MM.yyyy";
                }
            }

            _count.Text = "Рядків: " + table.Rows.Count;
        }

        // Чи є в колонці дат значення з часом (інакше показуємо лише дату)
        private static bool HasTime(DataTable table, string column)
        {
            foreach (DataRow r in table.Rows)
            {
                object v = r[column];
                if (v != DBNull.Value && ((DateTime)v).TimeOfDay != TimeSpan.Zero) return true;
            }
            return false;
        }

        private string CellText(DataGridViewRow row, string column)
        {
            if (!_grid.Columns.Contains(column)) return "";
            return Convert.ToString(row.Cells[column].Value);
        }

        // Підсвічування: проблемні рядки рожеві, вільні ПК зелені, від'ємні суми червоним
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = _grid.Rows[e.RowIndex];

            string mark = CellText(row, "Увага") + CellText(row, "Стан");
            if (mark == "Не вистачає" || mark == "Несправний")
                e.CellStyle.BackColor = Color.MistyRose;
            else if (mark == "Вільний")
                e.CellStyle.BackColor = Color.Honeydew;

            if (e.Value is decimal && (decimal)e.Value < 0)
                e.CellStyle.ForeColor = Color.Firebrick;
        }

        // Текст виконаного запиту зі значеннями параметрів (для звіту й перевірки)
        private void ShowSql(string sql, Dictionary<string, object> values)
        {
            var sb = new StringBuilder();
            sb.AppendLine(sql.Replace("\r\n", "\n").Replace("\n", "\r\n").Trim());

            if (values.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("-- Параметри:");
                foreach (var v in values)
                    sb.AppendLine("--   @" + v.Key + " = " + FormatValue(v.Value));
            }
            _sqlBox.Text = sb.ToString();
        }

        private static string FormatValue(object v)
        {
            if (v == null || v == DBNull.Value) return "NULL";
            if (v is DateTime) return ((DateTime)v).ToString("dd.MM.yyyy");
            if (v is string) return "'" + v + "'";
            return Convert.ToString(v, CultureInfo.InvariantCulture);
        }
    }
}
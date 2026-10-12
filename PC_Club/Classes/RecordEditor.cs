using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    public class RecordEditor
    {
        private readonly DataTable _table;
        private readonly Dictionary<string, DataTable> _lookups;
        private readonly Dictionary<string, string> _captions;
        private readonly HashSet<string> _withTime;
        private readonly Dictionary<string, Control> _controls = new Dictionary<string, Control>();
        private readonly List<string> _order = new List<string>();
        private bool _loading;

        public event EventHandler Changed;

        public RecordEditor(Panel host, DataTable table,
                            Dictionary<string, DataTable> lookups,
                            Dictionary<string, string> captions,
                            HashSet<string> hidden,
                            HashSet<string> withTime)
        {
            _table = table;
            _lookups = lookups;
            _captions = captions;
            _withTime = withTime;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                Padding = new Padding(10, 5, 10, 5)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            int tab = 0;
            foreach (DataColumn col in table.Columns)
            {
                if (col.AutoIncrement || hidden.Contains(col.ColumnName)) continue;

                var label = new Label
                {
                    Text = Caption(col.ColumnName) + (col.AllowDBNull ? "" : " *"),
                    AutoSize = true,
                    TabStop = false,
                    Margin = new Padding(3, 8, 3, 2)
                };

                Control input = CreateInput(col);
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                input.Margin = new Padding(3, 0, 3, 3);
                input.TabIndex = tab++;

                layout.Controls.Add(label);
                layout.Controls.Add(input);
                _controls[col.ColumnName] = input;
                _order.Add(col.ColumnName);
            }

            host.Controls.Clear();
            host.Controls.Add(layout);
        }

        private string Caption(string columnName)
        {
            return _captions.ContainsKey(columnName) ? _captions[columnName] : columnName;
        }

        private void OnChanged(object sender, EventArgs e)
        {
            if (!_loading && Changed != null) Changed(this, EventArgs.Empty);
        }

        private static bool IsInteger(Type t)
        {
            return t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(byte);
        }

        private static bool IsDecimal(Type t)
        {
            return t == typeof(decimal) || t == typeof(double) || t == typeof(float);
        }

        private static void KeepDigitsOnly(TextBox tb, bool allowSeparator)
        {
            tb.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar)) return;
                if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
                if (allowSeparator && (e.KeyChar == ',' || e.KeyChar == '.') &&
                    tb.Text.IndexOfAny(new[] { ',', '.' }) < 0) return;
                e.Handled = true;
            };
        }

        private static string DigitsOf(string text)
        {
            var sb = new System.Text.StringBuilder();
            foreach (char ch in text)
                if (ch >= '0' && ch <= '9') sb.Append(ch);
            return sb.ToString();
        }

        private Control CreateInput(DataColumn col)
        {
            string name = col.ColumnName;

            if (_lookups.ContainsKey(name))
            {
                var combo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDown,
                    AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                    AutoCompleteSource = AutoCompleteSource.ListItems,
                    DisplayMember = "text",
                    ValueMember = "id",
                    DataSource = new DataView(_lookups[name])
                };
                combo.SelectedIndexChanged += OnChanged;
                combo.TextChanged += OnChanged;
                return combo;
            }

            if (col.DataType == typeof(DateTime))
            {
                var dtp = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = _withTime.Contains(name) ? "dd.MM.yyyy HH:mm" : "dd.MM.yyyy",
                    ShowCheckBox = col.AllowDBNull
                };
                dtp.ValueChanged += OnChanged;
                return dtp;
            }

            if (col.DataType == typeof(bool))
            {
                var cb = new CheckBox();
                cb.CheckedChanged += OnChanged;
                return cb;
            }

            if (name == "phone")
            {
                var mtb = new MaskedTextBox
                {
                    Mask = "(000) 000-00-00",
                    TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                };
                mtb.TextChanged += OnChanged;
                return mtb;
            }

            var tb = new TextBox();
            if (col.DataType == typeof(string) && col.MaxLength > 0) tb.MaxLength = col.MaxLength;

            if (IsInteger(col.DataType))
            {
                tb.MaxLength = 9;
                tb.TextAlign = HorizontalAlignment.Right;
                KeepDigitsOnly(tb, false);
            }
            else if (IsDecimal(col.DataType))
            {
                tb.MaxLength = 9;
                tb.TextAlign = HorizontalAlignment.Right;
                KeepDigitsOnly(tb, true);
            }

            tb.TextChanged += OnChanged;
            return tb;
        }

        private static int FindIndex(DataTable lookup, object value)
        {
            for (int i = 0; i < lookup.Rows.Count; i++)
            {
                object id = lookup.Rows[i]["id"];
                if (id == DBNull.Value && value == DBNull.Value) return i;
                if (id != DBNull.Value && value != DBNull.Value &&
                    Convert.ToString(id) == Convert.ToString(value)) return i;
            }
            return -1;
        }

        public void Show(DataRow row)
        {
            _loading = true;
            try
            {
                foreach (var pair in _controls)
                {
                    object value = row[pair.Key];
                    bool isNull = value == DBNull.Value;
                    Control c = pair.Value;

                    if (c is ComboBox)
                    {
                        var combo = (ComboBox)c;
                        int index = FindIndex(_lookups[pair.Key], value);
                        combo.SelectedIndex = index;
                        if (index < 0) combo.Text = "";
                    }
                    else if (c is DateTimePicker)
                    {
                        var dtp = (DateTimePicker)c;
                        if (isNull)
                        {
                            if (dtp.ShowCheckBox) dtp.Checked = false;
                            else dtp.Value = DateTime.Now;
                        }
                        else
                        {
                            dtp.Value = (DateTime)value;
                            if (dtp.ShowCheckBox) dtp.Checked = true;
                        }
                    }
                    else if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = !isNull && (bool)value;
                    }
                    else if (c is MaskedTextBox)
                    {
                        ((MaskedTextBox)c).Text = isNull ? "" : DigitsOf(Convert.ToString(value));
                    }
                    else
                    {
                        ((TextBox)c).Text = isNull ? "" : Convert.ToString(value, CultureInfo.CurrentCulture);
                    }
                }
            }
            finally
            {
                _loading = false;
            }
        }

        public void FocusFirst()
        {
            if (_order.Count == 0) return;
            Control c = _controls[_order[0]];
            c.Select();
            var tb = c as TextBoxBase;
            if (tb != null) tb.SelectAll();
        }

        public string Apply(DataRow row)
        {
            var values = new Dictionary<string, object>();
            try
            {
                foreach (var pair in _controls)
                    values[pair.Key] = ReadValue(_table.Columns[pair.Key], pair.Value);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            row.BeginEdit();
            try
            {
                foreach (var pair in values)
                    row[pair.Key] = pair.Value;
                row.EndEdit();
            }
            catch (ConstraintException)
            {
                row.CancelEdit();
                return "Такий запис уже існує";
            }
            catch (Exception ex)
            {
                row.CancelEdit();
                return ex.Message;
            }
            return null;
        }

        private object ReadValue(DataColumn col, Control c)
        {
            string caption = Caption(col.ColumnName);

            if (c is ComboBox)
            {
                var combo = (ComboBox)c;
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

            if (c is DateTimePicker)
            {
                var dtp = (DateTimePicker)c;
                if (dtp.ShowCheckBox && !dtp.Checked) return DBNull.Value;
                DateTime v = dtp.Value;
                return _withTime.Contains(col.ColumnName)
                    ? new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0)
                    : v.Date;
            }

            if (c is CheckBox) return ((CheckBox)c).Checked;

            if (c is MaskedTextBox)
            {
                var mtb = (MaskedTextBox)c;
                string digits = mtb.Text;
                if (digits == "")
                {
                    if (!col.AllowDBNull) throw new Exception("Заповніть поле «" + caption + "»");
                    return DBNull.Value;
                }
                if (!mtb.MaskCompleted)
                    throw new Exception("Поле «" + caption + "» має містити 10 цифр");
                return digits;
            }

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
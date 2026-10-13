using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PC_Club
{
    public static class TableExport
    {
        private const int ExcelFormatXlsx = 51;

        private class Column
        {
            public DataGridViewColumn Grid;
            public string Header;
            public bool IsNumber;
            public bool IsMoney;
            public bool IsDate;
            public bool WithTime;
        }

        private static bool IsNumeric(Type t)
        {
            return t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(byte)
                || t == typeof(decimal) || t == typeof(double) || t == typeof(float);
        }

        private static List<Column> Columns(DataGridView grid)
        {
            var result = new List<Column>();
            foreach (DataGridViewColumn c in grid.Columns.Cast<DataGridViewColumn>().OrderBy(c => c.DisplayIndex))
            {
                if (!c.Visible) continue;
                Type t = Nullable.GetUnderlyingType(c.ValueType ?? typeof(string)) ?? c.ValueType ?? typeof(string);
                bool lookup = c is DataGridViewComboBoxColumn;
                var col = new Column { Grid = c, Header = c.HeaderText.Replace("\n", " ") };
                if (!lookup)
                {
                    col.IsNumber = IsNumeric(t);
                    col.IsMoney = t == typeof(decimal) || t == typeof(double) || t == typeof(float);
                    col.IsDate = t == typeof(DateTime);
                    col.WithTime = col.IsDate && (c.DefaultCellStyle.Format ?? "").Contains("HH");
                }
                result.Add(col);
            }
            return result;
        }

        private static IEnumerable<DataGridViewRow> Rows(DataGridView grid)
        {
            return grid.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow && r.Visible);
        }

        private static string Text(DataGridViewRow row, Column col)
        {
            object v = row.Cells[col.Grid.Index].FormattedValue;
            string s = v == null ? "" : Convert.ToString(v);
            return s.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
        }

        private static object Value(DataGridViewRow row, Column col)
        {
            object v = row.Cells[col.Grid.Index].Value;
            if (v == null || v == DBNull.Value) return null;
            if (col.IsDate) return Convert.ToDateTime(v).ToOADate();
            if (col.IsNumber) return Convert.ToDouble(v);
            return Text(row, col);
        }

        public static void SaveExcel(DataGridView grid, string title, string path)
        {
            List<Column> cols = Columns(grid);
            List<DataGridViewRow> rows = Rows(grid).ToList();
            int headerRow = 4;

            var data = new object[rows.Count + 1, cols.Count];
            for (int c = 0; c < cols.Count; c++) data[0, c] = cols[c].Header;
            for (int r = 0; r < rows.Count; r++)
                for (int c = 0; c < cols.Count; c++)
                    data[r + 1, c] = Value(rows[r], cols[c]);

            Type type = Type.GetTypeFromProgID("Excel.Application");
            if (type == null)
                throw new InvalidOperationException("Microsoft Excel не встановлено: вивантажити таблицю неможливо.");

            dynamic app = Activator.CreateInstance(type);
            dynamic book = null;
            try
            {
                app.Visible = false;
                app.DisplayAlerts = false;
                book = app.Workbooks.Add();
                dynamic sheet = book.Worksheets[1];
                sheet.Name = "Дані";

                sheet.Cells[1, 1].Value2 = title;
                sheet.Cells[1, 1].Font.Bold = true;
                sheet.Cells[1, 1].Font.Size = 14;
                sheet.Cells[2, 1].Value2 = "Сформовано: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") +
                                           "    Рядків: " + rows.Count;

                for (int c = 0; c < cols.Count; c++)
                {
                    if (rows.Count == 0) break;
                    dynamic column = sheet.Range[sheet.Cells[headerRow + 1, c + 1], sheet.Cells[headerRow + rows.Count, c + 1]];
                    if (cols[c].IsDate) column.NumberFormat = cols[c].WithTime ? "dd.mm.yyyy hh:mm" : "dd.mm.yyyy";
                    else if (cols[c].IsMoney) column.NumberFormat = "#,##0.00";
                    else if (cols[c].IsNumber) column.NumberFormat = "0";
                    else column.NumberFormat = "@";
                }

                dynamic all = sheet.Range[sheet.Cells[headerRow, 1], sheet.Cells[headerRow + rows.Count, cols.Count]];
                all.Value2 = data;
                all.Borders.LineStyle = 1;

                dynamic header = sheet.Range[sheet.Cells[headerRow, 1], sheet.Cells[headerRow, cols.Count]];
                header.Font.Bold = true;
                header.Interior.Color = 15132390;
                header.WrapText = true;

                sheet.Columns.AutoFit();
                try
                {
                    sheet.Activate();
                    sheet.Rows[headerRow + 1].Select();
                    app.ActiveWindow.FreezePanes = true;
                    sheet.Cells[1, 1].Select();
                }
                catch (Exception) { }

                if (File.Exists(path)) File.Delete(path);
                book.SaveAs(path, ExcelFormatXlsx);
            }
            finally
            {
                if (book != null)
                {
                    try { book.Close(false); } catch { }
                    try { Marshal.FinalReleaseComObject(book); } catch { }
                }
                try { app.Quit(); } catch { }
                try { Marshal.FinalReleaseComObject(app); } catch { }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public static void SaveWord(DataGridView grid, string title, string path)
        {
            List<Column> cols = Columns(grid);
            List<DataGridViewRow> rows = Rows(grid).ToList();
            var cells = rows.Select(r => cols.Select(c => Text(r, c)).ToArray()).ToList();

            using (var doc = new WordDocument())
            {
                doc.Line(title, bold: true, size: 14);
                doc.Line("Сформовано: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "    Рядків: " + rows.Count);
                doc.Empty();
                doc.Table(cols.Select(c => c.Header).ToArray(), cells, cols.Select(c => c.IsNumber).ToArray());
                doc.Save(path);
            }
        }

        public static void Export(IWin32Window owner, DataGridView grid, string title, bool excel)
        {
            if (Rows(grid).Count() == 0)
            {
                MessageBox.Show(owner, "Таблиця порожня: вивантажувати нічого.", title);
                return;
            }

            string safeTitle = string.Concat(title.Select(ch => Path.GetInvalidFileNameChars().Contains(ch) ? '_' : ch));
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = excel ? "Вивантажити в Excel" : "Вивантажити в Word";
                dialog.Filter = excel ? "Книга Excel (*.xlsx)|*.xlsx" : "Документ Word (*.docx)|*.docx|Документ PDF (*.pdf)|*.pdf";
                dialog.FileName = safeTitle + "_" + DateTime.Now.ToString("yyyy-MM-dd") + (excel ? ".xlsx" : ".docx");
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog(owner) != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (excel) SaveExcel(grid, title, dialog.FileName);
                    else SaveWord(grid, title, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(owner, Errors.Friendly(ex), dialog.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}

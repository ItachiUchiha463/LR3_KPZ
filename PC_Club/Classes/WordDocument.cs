using System;
using System.IO;

namespace PC_Club
{
    public sealed class WordDocument : IDisposable
    {
        private const int AlignLeft = 0;
        private const int AlignCenter = 1;
        private const int TabRight = 2;
        private const int FormatDocx = 16;
        private const int FormatPdf = 17;

        private dynamic _app;
        private dynamic _doc;
        private readonly float _tabPosition;

        public WordDocument(double pageWidthCm, double marginCm)
        {
            Type type = Type.GetTypeFromProgID("Word.Application");

            _app = Activator.CreateInstance(type);
            _app.Visible = false;
            _app.DisplayAlerts = 0;
            _doc = _app.Documents.Add();

            _doc.PageSetup.PageWidth = _app.CentimetersToPoints((float)pageWidthCm);
            _doc.PageSetup.LeftMargin = _app.CentimetersToPoints((float)marginCm);
            _doc.PageSetup.RightMargin = _app.CentimetersToPoints((float)marginCm);
            _doc.PageSetup.TopMargin = _app.CentimetersToPoints((float)marginCm);
            _doc.PageSetup.BottomMargin = _app.CentimetersToPoints((float)marginCm);
            _tabPosition = _app.CentimetersToPoints((float)(pageWidthCm - 2 * marginCm));

            _doc.Content.Font.Name = "Consolas";
            _doc.Content.Font.Size = 9;
            _doc.Content.ParagraphFormat.SpaceAfter = 0;
            _doc.Content.ParagraphFormat.SpaceBefore = 0;
        }

        public WordDocument()
        {
            Type type = Type.GetTypeFromProgID("Word.Application");
            if (type == null)
                throw new InvalidOperationException("Microsoft Word не встановлено: сформувати документ неможливо.");

            _app = Activator.CreateInstance(type);
            _app.Visible = false;
            _app.DisplayAlerts = 0;
            _doc = _app.Documents.Add();

            _doc.PageSetup.Orientation = 1;
            _doc.PageSetup.LeftMargin = _app.CentimetersToPoints(1.5f);
            _doc.PageSetup.RightMargin = _app.CentimetersToPoints(1.5f);
            _doc.PageSetup.TopMargin = _app.CentimetersToPoints(1.5f);
            _doc.PageSetup.BottomMargin = _app.CentimetersToPoints(1.5f);
            _tabPosition = _doc.PageSetup.PageWidth - _doc.PageSetup.LeftMargin - _doc.PageSetup.RightMargin;

            _doc.Content.Font.Name = "Arial";
            _doc.Content.Font.Size = 9;
            _doc.Content.ParagraphFormat.SpaceAfter = 0;
            _doc.Content.ParagraphFormat.SpaceBefore = 0;
        }

        public void Table(string[] headers, System.Collections.Generic.List<string[]> rows, bool[] alignRight)
        {
            var text = new System.Text.StringBuilder();
            text.Append(string.Join("\t", headers));
            foreach (string[] row in rows)
                text.Append('\r').Append(string.Join("\t", row));

            int start = _doc.Content.End - 1;
            _doc.Content.InsertAfter(text.ToString());
            dynamic range = _doc.Range(start, _doc.Content.End - 1);
            dynamic table = range.ConvertToTable(1, rows.Count + 1, headers.Length);

            table.Range.Font.Size = 8;
            table.Range.Font.Bold = 0;
            table.Borders.Enable = 1;
            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].HeadingFormat = -1;
            table.Rows[1].Shading.BackgroundPatternColor = 15132390;
            for (int i = 0; i < headers.Length; i++)
            {
                if (!alignRight[i]) continue;
                table.Columns[i + 1].Select();
                _app.Selection.ParagraphFormat.Alignment = 2;
            }
            table.AutoFitBehavior(1);
            table.AutoFitBehavior(2);
        }

        private void Write(string text, bool bold, float size, int alignment, bool tab)
        {
            dynamic p = _doc.Content.Paragraphs.Add();
            p.Range.Text = text;
            p.Range.Font.Bold = bold ? 1 : 0;
            p.Range.Font.Size = size;
            p.Format.Alignment = alignment;
            p.TabStops.ClearAll();
            if (tab) p.TabStops.Add(_tabPosition, TabRight);
            p.Range.InsertParagraphAfter();
        }

        public void Line(string text, bool bold = false, float size = 9, bool center = false)
        {
            Write(text, bold, size, center ? AlignCenter : AlignLeft, false);
        }

        public void Pair(string label, string value, bool bold = false, float size = 9)
        {
            Write(label + "\t" + value, bold, size, AlignLeft, true);
        }

        public void Separator()
        {
            Line(new string('-', 40), center: true);
        }

        public void Empty()
        {
            Line("");
        }

        public void Save(string path)
        {
            bool pdf = string.Equals(Path.GetExtension(path), ".pdf", StringComparison.OrdinalIgnoreCase);
            if (File.Exists(path)) File.Delete(path);
            _doc.SaveAs2(path, pdf ? FormatPdf : FormatDocx);
        }

        public void Dispose()
        {
            try { _doc.Close(0); } catch { }
            _doc = null;
            try { _app.Quit(0); } catch { }
            _app = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

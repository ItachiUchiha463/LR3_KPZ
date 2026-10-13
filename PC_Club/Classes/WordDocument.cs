using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PC_Club
{
    public sealed class WordDocument : IDisposable
    {
        private const int AlignLeft = 0;
        private const int AlignCenter = 1;
        private const int TabRight = 2;
        private const int FormatDocx = 16;
        private const int FormatPdf = 17;

        private readonly dynamic _app;
        private readonly dynamic _doc;
        private readonly float _tabPosition;

        public WordDocument(double pageWidthCm, double marginCm)
        {
            Type type = Type.GetTypeFromProgID("Word.Application");
            if (type == null)
                throw new InvalidOperationException("Microsoft Word не встановлено: сформувати документ неможливо.");

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
            try { _app.Quit(0); } catch { }
            try { Marshal.FinalReleaseComObject(_doc); } catch { }
            try { Marshal.FinalReleaseComObject(_app); } catch { }
        }
    }
}

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PC_Club
{
    public static class Receipts
    {
        private const double PaperWidthCm = 8;
        private const double MarginCm = 0.4;

        private static string Money(object value)
        {
            return Convert.ToDecimal(value).ToString("N2") + " грн";
        }

        private static string Date(object value)
        {
            return Convert.ToDateTime(value).ToString("dd.MM.yyyy HH:mm");
        }

        private static void Header(WordDocument doc, string title, string number)
        {
            doc.Line("ПК КЛУБ", bold: true, size: 14, center: true);
            doc.Line("комп'ютерний клуб", center: true);
            doc.Separator();
            doc.Line(title + " № " + number, bold: true, size: 11, center: true);
            doc.Line("Сформовано: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"), center: true);
            doc.Separator();
        }

        public static void SaveSessionReceipt(int sessionId, string path)
        {
            DataTable t = Db.GetTable(@"
SELECT d.session_id, d.client, d.phone, d.computer, d.tariff, d.discount_percent, d.game, d.employee,
       d.price_per_hour, d.started_at, d.ended_at, d.minutes, d.total_price, c.balance
FROM v_SessionDetails d
JOIN Client c ON c.client_id = d.client_id
WHERE d.session_id = @id;", Db.P("@id", sessionId));

            if (t.Rows.Count == 0) throw new InvalidOperationException("Сесію не знайдено.");
            DataRow r = t.Rows[0];
            if (r["total_price"] == DBNull.Value)
                throw new InvalidOperationException("Сесія ще триває: чек можна сформувати після її завершення.");

            int minutes = Convert.ToInt32(r["minutes"]);
            decimal full = Math.Round(Convert.ToDecimal(r["price_per_hour"]) * minutes / 60m, 2);
            decimal total = Convert.ToDecimal(r["total_price"]);

            using (var doc = new WordDocument(PaperWidthCm, MarginCm))
            {
                Header(doc, "ЧЕК", "S-" + sessionId.ToString("000000"));
                doc.Pair("Клієнт:", Convert.ToString(r["client"]));
                doc.Pair("Телефон:", Convert.ToString(r["phone"]));
                doc.Pair("Комп'ютер:", Convert.ToString(r["computer"]));
                doc.Pair("Тариф:", Convert.ToString(r["tariff"]));
                doc.Pair("Гра:", Convert.ToString(r["game"]));
                doc.Separator();
                doc.Pair("Початок:", Date(r["started_at"]));
                doc.Pair("Завершення:", Date(r["ended_at"]));
                doc.Pair("Тривалість:", (minutes / 60) + " год " + (minutes % 60) + " хв");
                doc.Separator();
                doc.Pair("Ціна години:", Money(r["price_per_hour"]));
                doc.Pair("Вартість без знижки:", Money(full));
                doc.Pair("Знижка (" + r["discount_percent"] + " %):", Money(full - total));
                doc.Empty();
                doc.Pair("ДО СПЛАТИ:", Money(total), bold: true, size: 12);
                doc.Separator();
                doc.Pair("Залишок на рахунку:", Money(r["balance"]));
                doc.Pair("Касир:", Convert.ToString(r["employee"]));
                doc.Separator();
                doc.Line("Дякуємо, що граєте з нами!", center: true);
                doc.Save(path);
            }
        }

        public static void SaveDepositReceipt(int depositId, string path)
        {
            DataTable t = Db.GetTable(@"
SELECT d.deposit_id, d.paid_at, d.client, c.phone, d.employee, d.method, d.amount, c.balance
FROM v_DepositDetails d
JOIN Client c ON c.client_id = d.client_id
WHERE d.deposit_id = @id;", Db.P("@id", depositId));

            if (t.Rows.Count == 0) throw new InvalidOperationException("Поповнення не знайдено.");
            DataRow r = t.Rows[0];

            using (var doc = new WordDocument(PaperWidthCm, MarginCm))
            {
                Header(doc, "КВИТАНЦІЯ", "D-" + depositId.ToString("000000"));
                doc.Line("Поповнення ігрового рахунку", center: true);
                doc.Separator();
                doc.Pair("Клієнт:", Convert.ToString(r["client"]));
                doc.Pair("Телефон:", Convert.ToString(r["phone"]));
                doc.Pair("Дата оплати:", Date(r["paid_at"]));
                doc.Pair("Спосіб оплати:", Convert.ToString(r["method"]));
                doc.Empty();
                doc.Pair("ЗАРАХОВАНО:", Money(r["amount"]), bold: true, size: 12);
                doc.Separator();
                doc.Pair("Баланс рахунку:", Money(r["balance"]));
                doc.Pair("Прийняв:", Convert.ToString(r["employee"]));
                doc.Separator();
                doc.Line("Дякуємо, що граєте з нами!", center: true);
                doc.Save(path);
            }
        }

        public static void Print(IWin32Window owner, string kind, int id, bool pdf)
        {
            string prefix = kind == "deposit" ? "Квитанція_D-" : "Чек_S-";
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = pdf ? "Зберегти у PDF" : "Зберегти у Word";
                dialog.Filter = pdf ? "Документ PDF (*.pdf)|*.pdf" : "Документ Word (*.docx)|*.docx";
                dialog.FileName = prefix + id.ToString("000000") + (pdf ? ".pdf" : ".docx");
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog(owner) != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (kind == "deposit") SaveDepositReceipt(id, dialog.FileName);
                    else SaveSessionReceipt(id, dialog.FileName);
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

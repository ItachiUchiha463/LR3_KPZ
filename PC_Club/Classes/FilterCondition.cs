using System;
using System.Data;
using System.Globalization;

namespace PC_Club
{
    public static class FilterCondition
    {
        public static readonly string[] Operators = { "містить", ">", "<", "=" };

        public static string Build(DataColumn column, string op, string text)
        {
            string field = "[" + column.ColumnName.Replace("]", "\\]") + "]";
            Type t = column.DataType;
            string safe = text.Replace("'", "''");

            if (t == typeof(string))
            {
                if (op == "містить") return field + " LIKE '%" + safe + "%'";
                return field + " " + op + " '" + safe + "'";
            }

            if (op == "містить")
                return "Convert(" + field + ", 'System.String') LIKE '%" + safe + "%'";

            if (t == typeof(DateTime))
            {
                DateTime d = DateTime.Parse(text, CultureInfo.CurrentCulture);
                if (op == "=")
                    return "(" + field + " >= " + DateLiteral(d.Date) + " AND " + field + " < " + DateLiteral(d.Date.AddDays(1)) + ")";
                return field + " " + op + " " + DateLiteral(d);
            }

            decimal n = decimal.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
            return field + " " + op + " " + n.ToString(CultureInfo.InvariantCulture);
        }

        private static string DateLiteral(DateTime d)
        {
            return "#" + d.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture) + "#";
        }
    }
}

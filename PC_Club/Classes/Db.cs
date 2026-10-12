using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PC_Club
{
    // Виконання SQL-запитів з параметрами
    public static class Db
    {
        public static string ConnectionString
        {
            get { return Properties.Settings.Default.PCClubConnectionString; }
        }

        // Параметр запиту; null перетворюється на NULL у базі
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        // SELECT: повертає таблицю з результатом
        public static DataTable GetTable(string sql, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parameters);
                var table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        // INSERT / UPDATE / DELETE: повертає кількість змінених рядків
        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parameters);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // SHA-256 у вигляді hex, як у базі: CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', ...), 2)
        public static string Hash(string text)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }
    }
}
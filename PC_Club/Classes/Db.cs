using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PC_Club
{
    public static class Db
    {
        private static string _baseConnectionString;

        public static string ConnectionString
        {
            get { return Properties.Settings.Default.PCClubConnectionString; }
        }

        public static void SetUser(string login)
        {
            if (_baseConnectionString == null) _baseConnectionString = ConnectionString;
            var builder = new SqlConnectionStringBuilder(_baseConnectionString) { ApplicationName = "PC_Club:" + login };
            Properties.Settings.Default["PCClubConnectionString"] = builder.ConnectionString;
        }

        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

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

        public static DataTable GetTableFromProcedure(string name, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(name, con) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parameters);
                var table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static object ExecuteProcedure(string name, SqlParameter output, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(name, con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddRange(parameters);
                if (output != null)
                {
                    output.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(output);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                return output != null ? output.Value : null;
            }
        }

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
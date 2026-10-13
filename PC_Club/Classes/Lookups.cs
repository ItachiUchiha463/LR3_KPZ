using System;
using System.Data;
using PC_Club.PCClubDataSetTableAdapters;

namespace PC_Club
{
    public static class Lookups
    {
        private static DataTable Make()
        {
            var t = new DataTable();
            t.Columns.Add("id", typeof(int));
            t.Columns.Add("text", typeof(string));
            return t;
        }

        public static DataTable Halls()
        {
            var ds = new PCClubDataSet();
            new HallTableAdapter().Fill(ds.Hall);
            var t = Make();
            foreach (DataRow r in ds.Hall.Rows)
                t.Rows.Add(r["hall_id"], r["name"]);
            return t;
        }

        public static DataTable Genres()
        {
            var ds = new PCClubDataSet();
            new GenreTableAdapter().Fill(ds.Genre);
            var t = Make();
            foreach (DataRow r in ds.Genre.Rows)
                t.Rows.Add(r["genre_id"], r["name"]);
            return t;
        }

        public static DataTable Tariffs()
        {
            var ds = new PCClubDataSet();
            new TariffTableAdapter().Fill(ds.Tariff);
            var t = Make();
            foreach (DataRow r in ds.Tariff.Rows)
                t.Rows.Add(r["tariff_id"], r["name"]);
            return t;
        }

        public static DataTable Clients()
        {
            var ds = new PCClubDataSet();
            new ClientTableAdapter().Fill(ds.Client);
            var t = Make();
            foreach (DataRow r in ds.Client.Rows)
                t.Rows.Add(r["client_id"], r["last_name"] + " " + r["first_name"]);
            return t;
        }

        public static DataTable Employees()
        {
            var ds = new PCClubDataSet();
            new EmployeeTableAdapter().Fill(ds.Employee);
            var t = Make();
            foreach (DataRow r in ds.Employee.Rows)
                t.Rows.Add(r["employee_id"], r["last_name"] + " " + r["first_name"]);
            return t;
        }

        public static DataTable Games()
        {
            var ds = new PCClubDataSet();
            new GameTableAdapter().Fill(ds.Game);
            var t = Make();
            t.Rows.Add(DBNull.Value, "—");
            foreach (DataRow r in ds.Game.Rows)
                t.Rows.Add(r["game_id"], r["title"]);
            return t;
        }

        public static DataTable Computers()
        {
            var ds = new PCClubDataSet();
            new HallTableAdapter().Fill(ds.Hall);
            new ComputerTableAdapter().Fill(ds.Computer);
            var t = Make();
            foreach (DataRow r in ds.Computer.Rows)
            {
                var h = ds.Hall.Select("hall_id = " + r["hall_id"]);
                string hall = h.Length > 0 ? h[0]["name"].ToString() : "?";
                t.Rows.Add(r["computer_id"], hall + " #" + r["number"]);
            }
            return t;
        }
        public static DataTable GamesOnly()
        {
            var ds = new PCClubDataSet();
            new GameTableAdapter().Fill(ds.Game);
            var t = Make();
            foreach (DataRow r in ds.Game.Rows)
                t.Rows.Add(r["game_id"], r["title"]);
            return t;
        }

        public static DataTable FreeComputers()
        {
            return Db.GetTable(@"
SELECT computer_id AS id,
       hall + N' #' + CAST(number AS NVARCHAR(10)) + N' (' + ISNULL(gpu, N'—') + N', '
            + CAST(CAST(price_per_hour AS INT) AS NVARCHAR(10)) + N' грн/год)' AS text
FROM v_FreeComputers
ORDER BY hall, number;");
        }

        public static DataTable ActiveSessions()
        {
            return Db.GetTable(@"
SELECT session_id AS id,
       computer + N' — ' + client AS text
FROM v_ActiveSessions
ORDER BY computer;");
        }

        public static DataTable PayMethods()
        {
            var t = new DataTable();
            t.Columns.Add("id", typeof(string));
            t.Columns.Add("text", typeof(string));
            t.Rows.Add("Готівка", "Готівка");
            t.Rows.Add("Картка", "Картка");
            return t;
        }

        public static DataTable ComputerStatuses()
        {
            var t = new DataTable();
            t.Columns.Add("id", typeof(string));
            t.Columns.Add("text", typeof(string));
            t.Rows.Add("Справний", "Справний");
            t.Rows.Add("Несправний", "Несправний");
            return t;
        }
    }
}
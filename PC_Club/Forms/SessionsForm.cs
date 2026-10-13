using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PC_Club.PCClubDataSetTableAdapters;
namespace PC_Club.Forms
{
    public partial class SessionsForm : PC_Club.Forms.BaseTableForm
    {
        public SessionsForm()
        {
            InitializeComponent();
        }

        private void SessionsForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new SessionTableAdapter();
            adapter.Fill(ds.Session);
            Bind(ds.Session, () => adapter.Update(ds.Session));
            ShowTimeIn("started_at", "ended_at");
            AddLookup("client_id", Lookups.Clients(), "Клієнт");
            AddLookup("computer_id", Lookups.Computers(), "Комп'ютер");
            AddLookup("employee_id", Lookups.Employees(), "Працівник");
            AddLookup("tariff_id", Lookups.Tariffs(), "Тариф");
            AddLookup("game_id", Lookups.Games(), "Гра");
        }

    }
}

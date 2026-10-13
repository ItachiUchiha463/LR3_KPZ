using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PC_Club.PCClubDataSetTableAdapters;
namespace PC_Club.Forms
{
    public partial class ClientsForm : PC_Club.Forms.BaseTableForm
    {
        public ClientsForm()
        {
            InitializeComponent();
        }
        private void ClientsForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new ClientTableAdapter();

            Bind(ds.Client, () => adapter.Fill(ds.Client), () => adapter.Update(ds.Client),
     "last_name", "first_name", "phone", "balance", "birth_date", "registered_at");
            HideInEditor("user_id", "balance");
            dgv.Columns["user_id"].Visible = false;
        }
    }
}

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
        private readonly PCClubDataSet _ds = new PCClubDataSet();
        private readonly ClientTableAdapter _adapter = new ClientTableAdapter();

        public ClientsForm()
        {
            InitializeComponent();
            panelLowBalance.BringToFront();
            dgv.BringToFront();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            _adapter.Fill(_ds.Client);

            Bind(_ds.Client, () => _adapter.Update(_ds.Client),
     "last_name", "first_name", "phone", "balance", "birth_date", "registered_at");
            HideInEditor("user_id");
            dgv.Columns["user_id"].Visible = false;
        }

        private void btnLowBalance_Click(object sender, EventArgs e)
        {
            if (Reload(() => _adapter.FillByLowBalance(_ds.Client, nudLimit.Value)))
                Text = "Клієнти з балансом менше " + nudLimit.Value.ToString("N2") + " грн";
        }

        private void btnAllClients_Click(object sender, EventArgs e)
        {
            if (Reload(() => _adapter.Fill(_ds.Client)))
                Text = "Клієнти";
        }
    }
}

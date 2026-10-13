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
    public partial class DepositsForm : PC_Club.Forms.BaseTableForm
    {
        public DepositsForm()
        {
            InitializeComponent();
        }

        private void DepositsForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new DepositTableAdapter();
            Bind(ds.Deposit, () => adapter.Fill(ds.Deposit), () => adapter.Update(ds.Deposit));
            ShowTimeIn("paid_at");
            AddLookup("client_id", Lookups.Clients, "Клієнт");
            AddLookup("employee_id", Lookups.Employees, "Працівник");

            AddRowAction("Квитанція (Word)", r => Receipts.Print(this, "deposit", Convert.ToInt32(r["deposit_id"]), false));
            AddRowAction("Квитанція (PDF)", r => Receipts.Print(this, "deposit", Convert.ToInt32(r["deposit_id"]), true));
        }
    }
}

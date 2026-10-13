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
    public partial class ComputersForm : PC_Club.Forms.BaseTableForm
    {
        public ComputersForm()
        {
            InitializeComponent();
        }

        private void ComputersForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new ComputerTableAdapter();
            Bind(ds.Computer, () => adapter.Fill(ds.Computer), () => adapter.Update(ds.Computer));
            AddLookup("hall_id", Lookups.Halls, "Зал");
            AddLookup("status", Lookups.ComputerStatuses, "Статус");
        }
    }
}

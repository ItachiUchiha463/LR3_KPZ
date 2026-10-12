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
    public partial class HallsForm : PC_Club.Forms.BaseTableForm
    {
        public HallsForm()
        {
            InitializeComponent();
        }

        private void HallsForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new HallTableAdapter();
            adapter.Fill(ds.Hall);
            Bind(ds.Hall, () => adapter.Update(ds.Hall));
        }
    }
}

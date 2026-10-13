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
    public partial class TariffsForm : PC_Club.Forms.BaseTableForm
    {
        public TariffsForm()
        {
            InitializeComponent();
        }

        private void TariffsForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new TariffTableAdapter();
            Bind(ds.Tariff, () => adapter.Fill(ds.Tariff), () => adapter.Update(ds.Tariff));
        }
    }
}

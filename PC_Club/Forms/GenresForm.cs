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
    public partial class GenresForm : PC_Club.Forms.BaseTableForm
    {
        public GenresForm()
        {
            InitializeComponent();
        }

        private void GenresForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new GenreTableAdapter();
            adapter.Fill(ds.Genre);
            Bind(ds.Genre, () => adapter.Update(ds.Genre));
        }
    }
}

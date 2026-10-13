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
    public partial class GamesForm : PC_Club.Forms.BaseTableForm
    {
        public GamesForm()
        {
            InitializeComponent();
        }

        private void GamesForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new GameTableAdapter();
            Bind(ds.Game, () => adapter.Fill(ds.Game), () => adapter.Update(ds.Game));
            AddLookup("genre_id", Lookups.Genres, "Жанр");
        }

    }
}

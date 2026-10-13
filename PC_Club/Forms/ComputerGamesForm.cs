using System;
using PC_Club.PCClubDataSetTableAdapters;

namespace PC_Club.Forms
{
    public partial class ComputerGamesForm : BaseTableForm
    {
        public ComputerGamesForm()
        {
            InitializeComponent();
        }

        private void ComputerGamesForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new ComputerGameTableAdapter();
            Bind(ds.ComputerGame, () => adapter.Fill(ds.ComputerGame), () => adapter.Update(ds.ComputerGame));

            AddLookup("computer_id", Lookups.Computers, "Комп'ютер");
            AddLookup("game_id", Lookups.GamesOnly, "Гра");
        }
    }
}
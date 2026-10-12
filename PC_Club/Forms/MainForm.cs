using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
namespace PC_Club.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyRole();
        }

        private void btnClients_Click(object sender, EventArgs e) { new ClientsForm().ShowDialog(); }
        private void btnSessions_Click(object sender, EventArgs e) { new SessionsForm().ShowDialog(); }
        private void btnDeposits_Click(object sender, EventArgs e) { new DepositsForm().ShowDialog(); }
        private void btnComputers_Click(object sender, EventArgs e) { new ComputersForm().ShowDialog(); }
        private void btnHalls_Click(object sender, EventArgs e) { new HallsForm().ShowDialog(); }
        private void btnGames_Click(object sender, EventArgs e) { new GamesForm().ShowDialog(); }
        private void btnGenres_Click(object sender, EventArgs e) { new GenresForm().ShowDialog(); }
        private void btnTariffs_Click(object sender, EventArgs e) { new TariffsForm().ShowDialog(); }
        private void btnEmployees_Click(object sender, EventArgs e) { new EmployeeForm().ShowDialog(); }
        private void залиToolStripMenuItem_Click(object sender, EventArgs e){ btnHalls_Click(sender, e); }
        private void компютериToolStripMenuItem_Click(object sender, EventArgs e){ btnComputers_Click(sender, e); }
        private void ігриToolStripMenuItem_Click(object sender, EventArgs e) {btnGames_Click(sender, e);}
        private void жанриToolStripMenuItem_Click(object sender, EventArgs e){btnGenres_Click(sender, e); }
        private void тарифиToolStripMenuItem_Click(object sender, EventArgs e) {btnTariffs_Click(sender, e); }
        private void клієнтиToolStripMenuItem_Click(object sender, EventArgs e) { btnClients_Click(sender, e); }
        private void працівникиToolStripMenuItem_Click(object sender, EventArgs e) { btnEmployees_Click(sender, e);}
        private void сесіїToolStripMenuItem_Click(object sender, EventArgs e) { btnSessions_Click(sender, e); }
        private void поповненняToolStripMenuItem_Click(object sender, EventArgs e) { btnDeposits_Click(sender, e);}
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e) { Close();}

        private void btnComputerGames_Click(object sender, EventArgs e) { new ComputerGamesForm().ShowDialog(); }

        private void ігриНаПКToolStripMenuItem_Click(object sender, EventArgs e) { btnComputerGames_Click(sender, e); }

        private void ApplyRole()
        {
            lblRole.Text = CurrentUser.DisplayName + " · " + CurrentUser.RoleName;
            CheckControls(Controls);
            CheckMenu(menuMain.Items);
            BuildQueriesMenu();
        }
        private void CheckControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Button && c.Tag != null)
                    c.Visible = CurrentUser.CanOpen(c.Tag.ToString());
                CheckControls(c.Controls);
            }
        }
        private ToolStripMenuItem _queriesMenu;

        // Меню «Запити» для поточної ролі
        private void BuildQueriesMenu()
        {
            MenuStrip strip = Controls.OfType<MenuStrip>().FirstOrDefault();
            if (strip == null) return;

            if (_queriesMenu != null) strip.Items.Remove(_queriesMenu);
            _queriesMenu = new ToolStripMenuItem("Запити");

            foreach (QueryDef q in QueryCatalog.ForRole(CurrentUser.Role))
            {
                QueryDef def = q;
                var item = new ToolStripMenuItem(def.Code + ". " + def.Title);
                item.Click += (s, e) => new QueryForm(def).Show(this);
                _queriesMenu.DropDownItems.Add(item);
            }

            // перед «Вихід», якщо він останній
            strip.Items.Insert(Math.Max(0, strip.Items.Count - 1), _queriesMenu);
        }   
        private void CheckMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Tag != null)
                    item.Available = CurrentUser.CanOpen(item.Tag.ToString());

                var menu = item as ToolStripMenuItem;
                if (menu != null && menu.DropDownItems.Count > 0)
                {
                    CheckMenu(menu.DropDownItems);

                    bool any = false;
                    foreach (ToolStripItem child in menu.DropDownItems)
                        if (child.Available) any = true;
                    menu.Available = any;
                }
            }
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            using (var login = new LoginForm())
            {
                if (login.ShowDialog(this) == DialogResult.OK)
                    ApplyRole();
            }
        }
    }
}

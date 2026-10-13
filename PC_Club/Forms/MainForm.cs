using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    public partial class MainForm : Form
    {
        private List<NavItem> _items = new List<NavItem>();
        private readonly Dictionary<string, TabPage> _open = new Dictionary<string, TabPage>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Користувач: " + CurrentUser.DisplayName + " (" + CurrentUser.RoleName + ")";
            if (CurrentUser.Role == UserRole.User)
            {
                gbState.Text = "Мій рахунок";
                tabState.Text = "Мій рахунок";
            }

            _items = Nav.ItemsForCurrentUser();
            BuildTree();
        }

        private void BuildTree()
        {
            string filter = txtSearch.Text.Trim();

            tree.BeginUpdate();
            tree.Nodes.Clear();
            foreach (string section in Nav.SectionOrder)
            {
                var matches = _items.Where(i => i.Section == section &&
                    (filter == "" || i.Title.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0)).ToList();
                if (matches.Count == 0) continue;

                TreeNode sectionNode = tree.Nodes.Add(section);
                sectionNode.NodeFont = new System.Drawing.Font(tree.Font, System.Drawing.FontStyle.Bold);
                sectionNode.Text = section;
                foreach (NavItem item in matches)
                    sectionNode.Nodes.Add(new TreeNode(item.Title) { Tag = item });
            }
            tree.ExpandAll();
            if (tree.Nodes.Count > 0) tree.Nodes[0].EnsureVisible();
            tree.EndUpdate();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuildTree();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TreeNode first = tree.Nodes.Cast<TreeNode>().SelectMany(n => n.Nodes.Cast<TreeNode>()).FirstOrDefault();
                if (first != null) Open((NavItem)first.Tag);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down && tree.Nodes.Count > 0)
            {
                tree.Focus();
                tree.SelectedNode = tree.Nodes[0].Nodes.Count > 0 ? tree.Nodes[0].Nodes[0] : tree.Nodes[0];
                e.SuppressKeyPress = true;
            }
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Tag is NavItem)
                Open((NavItem)e.Node.Tag);
        }

        private void tree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tree.SelectedNode != null && tree.SelectedNode.Tag is NavItem)
            {
                Open((NavItem)tree.SelectedNode.Tag);
                e.SuppressKeyPress = true;
            }
        }

        private void Open(NavItem item)
        {
            TabPage page;
            if (_open.TryGetValue(item.Id, out page))
            {
                tabs.SelectedTab = page;
                return;
            }

            Form form = Nav.CreateForm(item);
            if (form == null) return;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            page = new TabPage(item.Title) { Tag = form };
            page.Controls.Add(form);
            _open[item.Id] = page;
            form.TextChanged += (s, e) => page.Text = form.Text;
            form.FormClosed += (s, e) =>
            {
                _open.Remove(item.Id);
                tabs.TabPages.Remove(page);
                page.Dispose();
            };

            tabs.TabPages.Add(page);
            tabs.SelectedTab = page;
            form.Show();
        }

        private bool CloseTab(TabPage page)
        {
            if (page == null || page == tabState) return true;
            var form = page.Tag as Form;
            if (form == null) return true;
            form.Close();
            return form.IsDisposed || !tabs.TabPages.Contains(page);
        }

        private TabPage TabAt(System.Drawing.Point location)
        {
            for (int i = 0; i < tabs.TabCount; i++)
                if (tabs.GetTabRect(i).Contains(location)) return tabs.TabPages[i];
            return null;
        }

        private TabPage _menuPage;

        private void tabs_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) CloseTab(TabAt(e.Location));
        }

        private void menuTab_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _menuPage = TabAt(tabs.PointToClient(Cursor.Position));
            if (_menuPage == null) { e.Cancel = true; return; }
            menuTabClose.Enabled = _menuPage != tabState;
        }

        private void menuTabClose_Click(object sender, EventArgs e)
        {
            CloseTab(_menuPage);
        }

        private void menuTabCloseOthers_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabs.TabPages.Cast<TabPage>().ToList())
                if (page != _menuPage && !CloseTab(page)) break;
        }

        private void menuCloseTab_Click(object sender, EventArgs e)
        {
            CloseTab(tabs.SelectedTab);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in tabs.TabPages.Cast<TabPage>().ToList())
            {
                if (!CloseTab(page))
                {
                    tabs.SelectedTab = page;
                    e.Cancel = true;
                    Nav.LogoutRequested = false;
                    return;
                }
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == null) return;
            if (tabs.SelectedTab == tabState) RefreshStats();

            var table = tabs.SelectedTab.Tag as BaseTableForm;
            if (table != null) table.ReloadData(false);

            var query = tabs.SelectedTab.Tag as QueryForm;
            if (query != null) query.RefreshData();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabState) RefreshStats();
        }

        private void RefreshStats()
        {
            try
            {
                switch (CurrentUser.Role)
                {
                    case UserRole.Admin: ShowAdminStats(); break;
                    case UserRole.Manager: ShowManagerStats(); break;
                    default: ShowClientStats(); break;
                }
            }
            catch (Exception ex)
            {
                lblStat1.Text = "Не вдалося отримати дані: " + Errors.Friendly(ex);
                lblStat2.Text = lblStat3.Text = lblStat4.Text = "";
            }
        }

        private static string Money(object value)
        {
            return Convert.ToDecimal(value).ToString("N2") + " грн";
        }

        private void ShowAdminStats()
        {
            DataRow r = Db.GetTable(@"
SELECT (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= CAST(GETDATE() AS DATE))                     AS today,
       (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= DATEADD(DAY, -30, CAST(GETDATE() AS DATE))) AS month,
       (SELECT COUNT(*) FROM v_ActiveSessions)                          AS playing,
       (SELECT COUNT(*) FROM Client)                                    AS clients;").Rows[0];

            lblStat1.Text = "Виручка сьогодні: " + Money(r["today"]);
            lblStat2.Text = "За 30 днів: " + Money(r["month"]);
            lblStat3.Text = "Зараз грає: " + r["playing"];
            lblStat4.Text = "Клієнтів: " + r["clients"];
        }

        private void ShowManagerStats()
        {
            DataRow r = Db.GetTable(@"
SELECT (SELECT COUNT(*) FROM v_ActiveSessions)                               AS playing,
       (SELECT COUNT(*) FROM v_FreeComputers)                                AS free_pc,
       (SELECT COUNT(*) FROM v_ActiveSessions WHERE balance < current_price) AS low,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= CAST(GETDATE() AS DATE))                           AS today_deposits;").Rows[0];

            lblStat1.Text = "Зараз грає: " + r["playing"];
            lblStat2.Text = "Вільних ПК: " + r["free_pc"];
            lblStat3.Text = "Не вистачає балансу: " + r["low"];
            lblStat4.Text = "Поповнення сьогодні: " + Money(r["today_deposits"]);
        }

        private void ShowClientStats()
        {
            if (CurrentUser.ClientId == null) return;

            DataTable t = Db.GetTable(@"
SELECT c.balance,
       (SELECT COUNT(*) FROM Session s WHERE s.client_id = c.client_id)                      AS sessions,
       (SELECT ISNULL(SUM(s.total_price), 0) FROM Session s WHERE s.client_id = c.client_id) AS spent,
       (SELECT ISNULL(SUM(d.amount), 0) FROM Deposit d WHERE d.client_id = c.client_id)      AS deposited
FROM Client c
WHERE c.client_id = @client_id;", Db.P("@client_id", CurrentUser.ClientId.Value));

            if (t.Rows.Count == 0) return;
            DataRow r = t.Rows[0];
            lblStat1.Text = "Баланс: " + Money(r["balance"]);
            lblStat2.Text = "Сесій: " + r["sessions"];
            lblStat3.Text = "Витрачено: " + Money(r["spent"]);
            lblStat4.Text = "Поповнено: " + Money(r["deposited"]);
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Nav.Logout(this);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

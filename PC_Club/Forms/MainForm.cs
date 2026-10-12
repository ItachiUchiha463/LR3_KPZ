using System;
using System.Data;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Користувач: " + CurrentUser.DisplayName + " (" + CurrentUser.RoleName + ")";
            if (CurrentUser.Role == UserRole.User) gbState.Text = "Мій рахунок";
            Nav.Prepare(panelBody);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            int height = panelBody.Padding.Vertical;
            foreach (Control c in panelBody.Controls)
                if (c.Visible) height += c.Height;

            ClientSize = new System.Drawing.Size(ClientSize.Width,
                                                 height + menuMain.Height + statusMain.Height);
            CenterToScreen();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            RefreshStats();
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

        private void OpenByTag_Click(object sender, EventArgs e)
        {
            Nav.Open(this, sender);
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

using System;
using System.Data;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    // Головне вікно адміністратора: звіти, керування, робота зміни, усі таблиці
    public partial class AdminMainForm : Form
    {
        private readonly ToolTip _tip = new ToolTip();

        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            Nav.FillHeader(panelHeader, lblUser);
            Nav.Prepare(this, _tip);
        }

        private void AdminMainForm_Activated(object sender, EventArgs e)
        {
            RefreshStats();
        }

        // Підсумки для власника
        private void RefreshStats()
        {
            try
            {
                DataRow r = Db.GetTable(@"
SELECT (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= CAST(GETDATE() AS DATE))                     AS today,
       (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= DATEADD(DAY, -30, CAST(GETDATE() AS DATE))) AS month,
       (SELECT COUNT(*) FROM v_ActiveSessions)                          AS playing,
       (SELECT COUNT(*) FROM Client)                                    AS clients;").Rows[0];

                lblToday.Text = "Виручка сьогодні: " + Convert.ToDecimal(r["today"]).ToString("N2") + " грн";
                lblMonth.Text = "За 30 днів: " + Convert.ToDecimal(r["month"]).ToString("N2") + " грн";
                lblPlaying.Text = "Зараз грає: " + r["playing"];
                lblClients.Text = "Клієнтів: " + r["clients"];
            }
            catch (Exception ex)
            {
                lblToday.Text = "Виручка сьогодні: —";
                _tip.SetToolTip(lblToday, Errors.Friendly(ex));
            }
        }

        // Спільний обробник для всіх кнопок-плиток (що відкрити, задано у Tag)
        private void Tile_Click(object sender, EventArgs e)
        {
            Nav.Open(this, sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Nav.Logout(this);
        }
    }
}
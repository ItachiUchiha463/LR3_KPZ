using System;
using System.Data;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    // Головне вікно менеджера: робота зміни, операції, таблиці
    public partial class ManagerMainForm : Form
    {
        private readonly ToolTip _tip = new ToolTip();

        public ManagerMainForm()
        {
            InitializeComponent();
        }

        private void ManagerMainForm_Load(object sender, EventArgs e)
        {
            Nav.FillHeader(panelHeader, lblUser);
            Nav.Prepare(this, _tip);
        }

        private void ManagerMainForm_Activated(object sender, EventArgs e)
        {
            RefreshStats();
        }

        // Стан клубу зараз (підзапити до відображень)
        private void RefreshStats()
        {
            try
            {
                DataRow r = Db.GetTable(@"
SELECT (SELECT COUNT(*) FROM v_ActiveSessions)                               AS playing,
       (SELECT COUNT(*) FROM v_FreeComputers)                                AS free_pc,
       (SELECT COUNT(*) FROM v_ActiveSessions WHERE balance < current_price) AS low,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= CAST(GETDATE() AS DATE))                           AS today_deposits;").Rows[0];

                lblPlaying.Text = "Зараз грає: " + r["playing"];
                lblFree.Text = "Вільних ПК: " + r["free_pc"];
                lblLow.Text = "Не вистачає балансу: " + r["low"];
                lblTodayDeposits.Text = "Поповнення сьогодні: " +
                                        Convert.ToDecimal(r["today_deposits"]).ToString("N2") + " грн";
            }
            catch (Exception ex)
            {
                lblPlaying.Text = "Зараз грає: —";
                _tip.SetToolTip(lblPlaying, Errors.Friendly(ex));
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
using System;
using System.Data;
using System.Windows.Forms;

namespace PC_Club.Forms
{
    // Головне вікно клієнта: запити про клуб і власні дані
    public partial class ClientMainForm : Form
    {
        private readonly ToolTip _tip = new ToolTip();

        public ClientMainForm()
        {
            InitializeComponent();
        }

        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            Nav.FillHeader(panelHeader, lblUser);
            Nav.Prepare(this, _tip);
        }

        // Оновлюється щоразу, коли повертаєшся у вікно
        private void ClientMainForm_Activated(object sender, EventArgs e)
        {
            RefreshAccount();
        }

        // Ш1: баланс і підсумки клієнта
        private void RefreshAccount()
        {
            if (CurrentUser.ClientId == null) return;
            try
            {
                DataTable t = Db.GetTable(@"
SELECT c.balance,
       (SELECT COUNT(*) FROM Session s WHERE s.client_id = c.client_id)                      AS sessions,
       (SELECT ISNULL(SUM(s.total_price), 0) FROM Session s WHERE s.client_id = c.client_id) AS spent,
       (SELECT ISNULL(SUM(d.amount), 0) FROM Deposit d WHERE d.client_id = c.client_id)      AS deposited
FROM Client c
WHERE c.client_id = @client_id;", Db.P("@client_id", CurrentUser.ClientId.Value));

                if (t.Rows.Count == 0) return;
                DataRow r = t.Rows[0];
                lblBalance.Text = "Баланс: " + Convert.ToDecimal(r["balance"]).ToString("N2") + " грн";
                lblSessions.Text = "Сесій: " + r["sessions"];
                lblSpent.Text = "Витрачено: " + Convert.ToDecimal(r["spent"]).ToString("N2") + " грн";
                lblDeposited.Text = "Поповнено: " + Convert.ToDecimal(r["deposited"]).ToString("N2") + " грн";
            }
            catch (Exception ex)
            {
                lblBalance.Text = "Баланс: —";
                _tip.SetToolTip(lblBalance, Errors.Friendly(ex));
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
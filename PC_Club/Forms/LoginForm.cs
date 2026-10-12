using System;
using System.Data;
using System.Windows.Forms;
namespace PC_Club.Forms
{
    public partial class LoginForm : Form
    {
        // Л1: перевірка логіна й пароля, роль і власник облікового запису
        private const string LoginSql = @"
SELECT ua.user_id,
       r.name                            AS role_name,
       e.employee_id,
       e.last_name + N' ' + e.first_name AS employee_name,
       c.client_id,
       c.last_name + N' ' + c.first_name AS client_name
FROM UserAccount ua
JOIN Role r          ON r.role_id = ua.role_id
LEFT JOIN Employee e ON e.user_id = ua.user_id
LEFT JOIN Client c   ON c.user_id = ua.user_id
WHERE ua.login = @login
  AND ua.password_hash = @hash;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            if (login == "" || txtPass.Text == "")
            {
                MessageBox.Show("Введіть логін і пароль", "Вхід");
                return;
            }

            DataTable result;
            try
            {
                result = Db.GetTable(LoginSql,
                                     Db.P("@login", login),
                                     Db.P("@hash", Db.Hash(txtPass.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Errors.Friendly(ex), "Вхід", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Невірний логін або пароль", "Вхід",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            CurrentUser.SignIn(result.Rows[0], login);
            DialogResult = DialogResult.OK;
        }
    }
}
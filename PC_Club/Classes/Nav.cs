using System;
using System.Linq;
using System.Windows.Forms;
using PC_Club.Forms;

namespace PC_Club
{
    // Спільна логіка трьох головних вікон: яке вікно відкрити після входу,
    // відкриття запитів і таблиць за кнопками, перевірка доступу, вихід з облікового запису.
    //
    // Кнопки у вікнах налаштовуються в дизайнері властивістю Tag:
    //   "Q:U1"           відкрити запит U1 з каталогу QueryCatalog
    //   "F:ClientsForm"  відкрити табличну форму з ЛР3
    public static class Nav
    {
        // true, якщо вікно закрили кнопкою «Вийти» (потрібно знову показати вхід)
        public static bool LogoutRequested;

        // Головне вікно для ролі, яка увійшла
        public static Form CreateMainForm()
        {
            switch (CurrentUser.Role)
            {
                case UserRole.Admin: return new AdminMainForm();
                case UserRole.Manager: return new ManagerMainForm();
                default: return new ClientMainForm();
            }
        }

        public static void Logout(Form window)
        {
            LogoutRequested = true;
            window.Close();
        }

        // Шапка вікна: колір ролі й ім'я користувача
        public static void FillHeader(Control header, Label userLabel)
        {
            header.BackColor = CurrentUser.RoleColor;
            userLabel.Text = CurrentUser.DisplayName + " · " + CurrentUser.RoleName;
        }

        // Спільний обробник для всіх кнопок з Tag
        public static void Open(Form owner, object sender)
        {
            var c = sender as Control;
            string tag = c != null ? c.Tag as string : null;
            if (tag == null || tag.Length < 3) return;

            string key = tag.Substring(2);
            if (tag.StartsWith("Q:")) OpenQuery(owner, key);
            else if (tag.StartsWith("F:")) OpenTable(owner, key);
        }

        public static void OpenQuery(Form owner, string code)
        {
            QueryDef q = QueryCatalog.Get(code);
            if (q == null)
            {
                MessageBox.Show("Запит " + code + " не знайдено в каталозі.", "Запит");
                return;
            }
            if (!q.Roles.Contains(CurrentUser.Role))
            {
                MessageBox.Show("Цей запит недоступний для ролі «" + CurrentUser.RoleName + "».", "Запит");
                return;
            }
            new QueryForm(q).Show(owner);
        }

        public static void OpenTable(Form owner, string formName)
        {
            if (!CurrentUser.CanOpen(formName))
            {
                MessageBox.Show("Ця таблиця недоступна для ролі «" + CurrentUser.RoleName + "».", "Дані");
                return;
            }

            // якщо форма вже відкрита, виводимо її наперед замість створення копії
            Form existing = Application.OpenForms.Cast<Form>()
                                       .FirstOrDefault(f => f.GetType().Name == formName);
            if (existing != null)
            {
                if (existing.WindowState == FormWindowState.Minimized)
                    existing.WindowState = FormWindowState.Normal;
                existing.Activate();
                return;
            }

            Form form = CreateTableForm(formName);
            if (form == null)
            {
                MessageBox.Show("Форму " + formName + " не знайдено.", "Дані");
                return;
            }
            form.Show(owner);
        }

        private static Form CreateTableForm(string name)
        {
            switch (name)
            {
                case "ClientsForm": return new ClientsForm();
                case "EmployeeForm": return new EmployeeForm();
                case "HallsForm": return new HallsForm();
                case "ComputersForm": return new ComputersForm();
                case "GenresForm": return new GenresForm();
                case "GamesForm": return new GamesForm();
                case "TariffsForm": return new TariffsForm();
                case "SessionsForm": return new SessionsForm();
                case "DepositsForm": return new DepositsForm();
                case "ComputerGamesForm": return new ComputerGamesForm();
                default: return null;
            }
        }

        // Для всіх кнопок з Tag: підказка з описом і приховування того, що ролі недоступне
        public static void Prepare(Control root, ToolTip tip)
        {
            foreach (Control c in root.Controls)
            {
                string tag = c.Tag as string;
                if (c is Button && tag != null && tag.Length > 2)
                {
                    string key = tag.Substring(2);

                    if (tag.StartsWith("Q:"))
                    {
                        QueryDef q = QueryCatalog.Get(key);
                        c.Visible = q != null && q.Roles.Contains(CurrentUser.Role);
                        if (q != null) tip.SetToolTip(c, q.Code + ". " + q.Description);
                    }
                    else if (tag.StartsWith("F:"))
                    {
                        c.Visible = CurrentUser.CanOpen(key);
                        tip.SetToolTip(c, "Режим: " + CurrentUser.AccessMode(key));
                    }
                }
                Prepare(c, tip);
            }
        }
    }
}
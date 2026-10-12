using System;
using System.Linq;
using System.Windows.Forms;
using PC_Club.Forms;

namespace PC_Club
{
    public static class Nav
    {
        public static bool LogoutRequested;

        public static Form CreateMainForm()
        {
            return new MainForm();
        }

        public static void Logout(Form window)
        {
            LogoutRequested = true;
            window.Close();
        }

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

        public static void Prepare(Control root)
        {
            bool hasButtons;
            Prepare(root, out hasButtons);
        }

        private static bool Prepare(Control parent, out bool hasButtons)
        {
            bool anyVisible = false;
            hasButtons = false;

            foreach (Control c in parent.Controls)
            {
                string tag = c.Tag as string;
                if (c is Button && tag != null && tag.Length > 2)
                {
                    string key = tag.Substring(2);
                    bool show = tag.StartsWith("Q:")
                        ? QueryCatalog.Get(key) != null && QueryCatalog.Get(key).Roles.Contains(CurrentUser.Role)
                        : CurrentUser.CanOpen(key);

                    c.Visible = show;
                    hasButtons = true;
                    anyVisible |= show;
                }
                else if (c.HasChildren)
                {
                    bool childHasButtons;
                    bool childVisible = Prepare(c, out childHasButtons);
                    if (childHasButtons)
                    {
                        hasButtons = true;
                        anyVisible |= childVisible;
                        if (c is GroupBox) c.Visible = childVisible;
                    }
                }
            }
            return anyVisible;
        }
    }
}

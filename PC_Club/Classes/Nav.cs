using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PC_Club.Forms;

namespace PC_Club
{
    public enum NavKind { Query, Report, Table }

    public class NavItem
    {
        public NavKind Kind;
        public string Key;
        public string Title;
        public string Section;

        public string Id
        {
            get { return Kind + ":" + Key; }
        }
    }

    public static class Nav
    {
        public const string ReportSection = "Звіти";
        public const string DataSection = "Дані";

        public static readonly string[] SectionOrder =
        {
            QueryCatalog.ShiftSection, QueryCatalog.ClubSection, ReportSection, QueryCatalog.AdminSection, DataSection
        };

        private static readonly string[,] Tables =
        {
            { "ClientsForm", "Клієнти" },
            { "SessionsForm", "Сесії" },
            { "DepositsForm", "Поповнення" },
            { "EmployeeForm", "Працівники" },
            { "HallsForm", "Зали" },
            { "ComputersForm", "Комп'ютери" },
            { "GenresForm", "Жанри" },
            { "GamesForm", "Ігри" },
            { "TariffsForm", "Тарифи" },
            { "ComputerGamesForm", "Ігри на ПК" }
        };

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

        public static List<NavItem> ItemsForCurrentUser()
        {
            var items = new List<NavItem>();

            foreach (QueryDef q in QueryCatalog.All.Where(q => q.Roles.Contains(CurrentUser.Role)))
                items.Add(new NavItem { Kind = NavKind.Query, Key = q.Code, Title = q.Title, Section = q.Section });

            foreach (ReportDef r in ReportCatalog.All.Where(r => r.Roles.Contains(CurrentUser.Role)))
                items.Add(new NavItem { Kind = NavKind.Report, Key = r.Code, Title = r.Title, Section = ReportSection });

            for (int i = 0; i < Tables.GetLength(0); i++)
                if (CurrentUser.CanOpen(Tables[i, 0]))
                    items.Add(new NavItem { Kind = NavKind.Table, Key = Tables[i, 0], Title = Tables[i, 1], Section = DataSection });

            return items;
        }

        public static Form CreateForm(NavItem item)
        {
            switch (item.Kind)
            {
                case NavKind.Query:
                    QueryDef q = QueryCatalog.Get(item.Key);
                    if (q == null || !q.Roles.Contains(CurrentUser.Role)) return Denied();
                    return new QueryForm(q);

                case NavKind.Report:
                    ReportDef r = ReportCatalog.Get(item.Key);
                    if (r == null || !r.Roles.Contains(CurrentUser.Role)) return Denied();
                    return new ReportForm(r);

                default:
                    if (!CurrentUser.CanOpen(item.Key)) return Denied();
                    return CreateTableForm(item.Key);
            }
        }

        private static Form Denied()
        {
            MessageBox.Show("Недоступно для ролі «" + CurrentUser.RoleName + "».", "Доступ");
            return null;
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
    }
}

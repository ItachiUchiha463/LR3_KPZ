using System;
using System.Data;
using System.Drawing;
using System.Linq;

namespace PC_Club
{
    public enum UserRole { Admin, Manager, User }

    // Поточний користувач: хто увійшов і що йому дозволено
    public static class CurrentUser
    {
        public static UserRole Role = UserRole.User;
        public static int UserId;
        public static int? EmployeeId;     // для адміністратора й менеджера
        public static int? ClientId;       // для клієнта
        public static string Login = "";
        public static string DisplayName = "";

        // Заповнюється з результату запиту входу
        public static void SignIn(DataRow r, string login)
        {
            UserId = Convert.ToInt32(r["user_id"]);
            Role = RoleFromDb(Convert.ToString(r["role_name"]));
            EmployeeId = r["employee_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["employee_id"]);
            ClientId = r["client_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["client_id"]);
            Login = login;

            if (r["employee_name"] != DBNull.Value) DisplayName = Convert.ToString(r["employee_name"]);
            else if (r["client_name"] != DBNull.Value) DisplayName = Convert.ToString(r["client_name"]);
            else DisplayName = login;
        }

        private static UserRole RoleFromDb(string name)
        {
            switch (name)
            {
                case "Адміністратор":
                case "Admin":
                    return UserRole.Admin;
                case "Менеджер":
                case "Manager":
                    return UserRole.Manager;
                default:
                    return UserRole.User;
            }
        }

        public static string RoleName
        {
            get
            {
                switch (Role)
                {
                    case UserRole.Admin: return "Адміністратор";
                    case UserRole.Manager: return "Менеджер";
                    default: return "Клієнт";
                }
            }
        }

        // Колір ролі: шапка головного вікна і рядок стану таблиць
        public static Color RoleColor
        {
            get
            {
                switch (Role)
                {
                    case UserRole.Admin: return Color.FromArgb(165, 50, 50);
                    case UserRole.Manager: return Color.FromArgb(40, 90, 160);
                    default: return Color.FromArgb(40, 130, 90);
                }
            }
        }

        public static string Rights
        {
            get
            {
                switch (Role)
                {
                    case UserRole.Admin: return "Повний доступ: перегляд і редагування всіх даних, звіти";
                    case UserRole.Manager: return "Робота зміни: клієнти, сесії, поповнення";
                    default: return "Перегляд клубу і власних даних";
                }
            }
        }

        // Що редагує менеджер
        private static readonly string[] ManagerEdit =
            { "ClientsForm", "SessionsForm", "DepositsForm" };

        public static bool CanOpen(string form)
        {
            return Role != UserRole.User;
        }

        public static bool CanEdit(string form)
        {
            if (Role == UserRole.Admin) return true;
            if (Role == UserRole.Manager) return ManagerEdit.Contains(form);
            return false;
        }

        public static string AccessMode(string form)
        {
            if (CanEdit(form)) return "редагування";
            if (CanOpen(form)) return "перегляд";
            return "немає доступу";
        }
    }
} 
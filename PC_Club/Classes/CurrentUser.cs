using System;
using System.Data;
using System.Linq;

namespace PC_Club
{
    public enum UserRole { Admin, Manager, User }

    public static class CurrentUser
    {
        public static UserRole Role = UserRole.User;
        public static int UserId;
        public static int? EmployeeId;
        public static int? ClientId;
        public static string Login = "";
        public static string DisplayName = "";

        public static void SignIn(DataRow r, string login)
        {
            UserId = Convert.ToInt32(r["user_id"]);
            Role = RoleFromDb(Convert.ToString(r["role_name"]));
            EmployeeId = r["employee_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["employee_id"]);
            ClientId = r["client_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["client_id"]);
            Login = login;
            Db.SetUser(login);

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
    }
}
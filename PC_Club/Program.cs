using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_Club.Forms;
namespace PC_Club
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }

                Nav.LogoutRequested = false;
                Application.Run(Nav.CreateMainForm());

                if (!Nav.LogoutRequested) return;
            }
        }
    }
}

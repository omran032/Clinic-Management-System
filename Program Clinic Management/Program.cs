using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Program_Clinic_Management.Admin;
using Program_Clinic_Management.Login;
using Program_Clinic_Management.Manage_Users;
using Program_Clinic_Management.Persons.UI;
using Program_Clinic_Management.Settings.Backup;
using Program_Clinic_Management.Settings.Logs;
using Program_Clinic_Management.Visits;

namespace Program_Clinic_Management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new FrmLogin());


          // Application.Run(new FrmLogs());
         //   Application.Run(new FrmDashboardAdmin());

            // Application.Run(new FrmAddVisit());

            //   Application.Run(new FrmBackupDB());

            //Application.Run(new FrmAdd_UpdatePerson(FrmAdd_UpdatePerson.Mode.Add));
            // Application.Run(new FrmDisplayInfoPerson());
        }
    }
}

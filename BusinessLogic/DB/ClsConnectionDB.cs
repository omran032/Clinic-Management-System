using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ClsConnectionDB
    {
        public static string DatabaseName = "ClinicSystemDB";



        #region **** في المستندات _ مسار القاعدة عند تثبيت التطبيق من ملف التثبيت   ****

        // يتصل بالوكال 2025

        public static string connectionString =
            $@"Data Source=(LocalDB)\LocalDB2025;
    AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Clinic Management\Database\ClinicSystemDB.mdf;
    Integrated Security=True;
    Connect Timeout=30;";


        #endregion



        #region exe مسار القاعدة(  بجانب )) ملف 

        //  public static  string connectionString =
        //@"Data Source=(LocalDB)\MSSQLLocalDB;
        //AttachDbFilename=" +
        //  AppDomain.CurrentDomain.BaseDirectory +
        //  $@"{DatabaseName}.mdf;
        //Integrated Security=True;
        //Connect Timeout=30;";









        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ClsConnectionDB
    {
        public static string DatabaseName = "ClinicSystemDB";

        #region  مسار القاعدة(  بجانب )) ملف exe

     public static  string connectionString =
      @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=" +
        AppDomain.CurrentDomain.BaseDirectory +
        $@"{DatabaseName}.mdf;
      Integrated Security=True;
      Connect Timeout=30;";

        #endregion


    }
}

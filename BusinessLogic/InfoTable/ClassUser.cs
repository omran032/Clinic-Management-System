using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassUser
    {

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Role  { get; set; }

        public ClassPerson PersonInfo { get; set; }

        // معلومات اذا كان طبيب
        public ClassDoctor DoctorInfo { get; set; } 

        public static ClassUser UserInfo {  get; set; } // معلومات ثابتة


    }
}

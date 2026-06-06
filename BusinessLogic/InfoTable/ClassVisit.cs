using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassVisit
    {
        public int VisitID { get; set; }

        public ClassPatients PatientsInfo { get; set; }

        public ClassVisitType VisitTypeInfo { get; set; }

        public DateTime VisitDate { get; set; }

 
        public string Visit_Notes { get; set; }

        public ClassDoctor DoctorInfo { get; set; }



        /// <summary>
        /// ClassVisit إلى كائن DataTable تحويل صف من  
        ///  مع معلومات الشخص
        /// </summary>
        public static ClassVisit GetInfoVisitInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassVisit VisitInfo = new ClassVisit()
            {
                VisitID = Convert.ToInt32(row["VisitId"]),
                VisitDate = Convert.ToDateTime(row["VisitDate"]),
                Visit_Notes = row["VisitNotes"]?.ToString(),

                PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, RowIndex),
                VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, RowIndex)

            };

            VisitInfo.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

            // معلومات الدكتور ما عبيتا

            return VisitInfo;
        }

    }
}

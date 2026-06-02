using BusinessLogic.CMD_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassPatients
    {
       public int PatientID { get; set; }

        public ClassPerson PersonInfo { get; set; }
    
        public string MedicalNotes { get; set; }     // ملاحظات طبية

        public string FirstVisitDate { get; set; }  // تاريخ الزيارة الأولى

        public string ChronicDiseases { get; set; }  // الأمراض المزمنة

        public string Allergies { get; set; }   // الحساسية

        public string Notes { get; set; }



        public int ComplianceScore { get; set; } // درجة الامتثال

        public string StatusComplianceScore
        {
            get
            {
                if (ComplianceScore <= 20)
                    return "غير ملتزم نهائياً";

                else if (ComplianceScore <= 40)
                    return "التزام ضعيف";

                else if (ComplianceScore <= 60)
                    return "التزام متوسط";

                else if (ComplianceScore <= 80)
                    return "التزام جيد";

                else  //   ( ComplianceScore <= 100 )
                    return "التزام ممتاز";
            }
        }

        #region  شرح درجة الامتثال

        // كل موعد حضره + 10

        //كل موعد غاب عنه -15

        //كل زيارة متابعة + 5

        //كل تأخير -5

        //////////////////////////////////

        //0 – 20	مريض غير ملتزم نهائياً
        //20 – 40	التزام ضعيف
        //40 – 60	التزام متوسط
        //60 – 80	التزام جيد
        //80 – 100	التزام ممتاز

        ///////////////////////
        
        // عندما يكون المريض جديد
        // 50 = يكون قيمة الالتزام تلقائيا    

        #endregion


        /// <summary>
        /// تحويل صف من DataTable إلى كائن ClassPatients مع معلومات الشخص
        /// </summary>
        public static ClassPatients GetInfoPatientInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassPatients patient = new ClassPatients()
            {
                PatientID = Convert.ToInt32(row["ID Patiient"]),
                MedicalNotes = row["MedicalNotes"]?.ToString(),
                FirstVisitDate = row["FirstVisitDate"]?.ToString(),
                ChronicDiseases = row["ChronicDiseases"]?.ToString(),
                Allergies = row["Allergies"]?.ToString(),
                Notes = row["Notes"]?.ToString(),
                ComplianceScore = Convert.ToInt32(row["ComplianceScore"])
            };

            // تعبئة معلومات الشخص
            patient.PersonInfo = new ClassPerson();
            patient.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

            return patient;
        }

    }
}

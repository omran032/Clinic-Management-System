using BusinessLogic.CMD_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


        /// <summary>
        /// تجلب معلومات الشخص والمريض بكويري واحدة فقط، 
        /// وتعيد كائن ClassPatients جاهز للاستخدام حتى لو لم يكن الشخص مريضاً بعد.
        /// </summary>
        public static ClassPatients GetPatientByPersonId(int personId)
        {
            ClassPatients patient = new ClassPatients();

            string query = @"
        SELECT 
            p.PersonId,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt,

            pa.PatientId,
            pa.MedicalNotes,
            pa.FirstVisitDate,
            pa.ChronicDiseases,
            pa.Allergies,
            pa.Notes,
            pa.ComplianceScore

        FROM Persons p
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        WHERE p.PersonId = @PersonId
    ";

            var parameters = new Dictionary<string, object>
    {
        { "@PersonId", personId }
    };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null; // الشخص غير موجود نهائياً

            DataRow row = dt.Rows[0];

            // تعبئة معلومات الشخص داخل ClassPerson
            patient.PersonInfo = new ClassPerson
            {
                PersonID = Convert.ToInt32(row["PersonId"]),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Gender = row["Gender"].ToString(),
                BirthDate = row["BirthDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["BirthDate"]),
                Phone = row["Phone"].ToString(),
                Address = row["Address"].ToString(),
                CreatedAt = row["CreatedAt"] == DBNull.Value ? "" : row["CreatedAt"].ToString(),
                UpdatedAt = row["UpdatedAt"] == DBNull.Value ? "" : row["UpdatedAt"].ToString()
            };

            // إذا الشخص ليس مريضاً بعد (PatientId = NULL)
            if (row["PatientId"] == DBNull.Value)
            {
                patient.PatientID = 0; // يعني ليس مريضاً بعد
                patient.MedicalNotes = "";
                patient.FirstVisitDate = "";
                patient.ChronicDiseases = "";
                patient.Allergies = "";
                patient.Notes = "";
                patient.ComplianceScore = 50; // المريض الجديد يبدأ بـ 50

                return patient;
            }

            // تعبئة معلومات المريض
            patient.PatientID = Convert.ToInt32(row["PatientId"]);
            patient.MedicalNotes = row["MedicalNotes"].ToString();
            patient.FirstVisitDate = row["FirstVisitDate"].ToString();
            patient.ChronicDiseases = row["ChronicDiseases"].ToString();
            patient.Allergies = row["Allergies"].ToString();
            patient.Notes = row["Notes"].ToString();

            patient.ComplianceScore = row["ComplianceScore"] == DBNull.Value
                                      ? 50
                                      : Convert.ToInt32(row["ComplianceScore"]);

            return patient;
        }

    }
}

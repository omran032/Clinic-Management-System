using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TablePatients
    {

        /// <summary>
        /// PatientID إحضار معلومات الشخص التابع لمريض معيّن عبر 
        /// ترجع DataTable يحتوي بيانات الشخص.
        /// </summary>
        public static DataTable GetPersonByPatientID(int patientId)
        {
            string query = @"SELECT 
                    P.PersonId,
                    P.FirstName,
                    P.LastName,
                    P.Gender,
                    P.BirthDate,
                    P.Phone,
                    P.Address,
                    P.CreatedAt,
                    P.UpdatedAt
                        FROM Persons P
                        INNER JOIN Patients PT ON P.PersonId = PT.PersonId
                        WHERE PT.PatientId = @PatientId";
        
    

            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@PatientId", patientId }
                };

            return ClassCommands.ShowData(query, parameters);
        }

        /// <summary>
        /// إحضار جميع المرضى مع معلومات الشخص المرتبط بكل مريض
        /// ترجع DataTable تحتوي بيانات المرضى + بيانات الشخص.
        /// </summary>
        public static DataTable GetAllPatientsWithPersonInfo()
        {
            string query = @"
        SELECT 
            PT.PatientId as [ID Patiient],
            PT.PersonId   ,

            -- بيانات الشخص
            P.FirstName,
            P.LastName,
            P.Gender,
            P.BirthDate,
            P.Phone,
            P.Address,
            P.CreatedAt,
            P.UpdatedAt,

            -- بيانات المريض
            PT.MedicalNotes,
            PT.FirstVisitDate,
            PT.ChronicDiseases,
            PT.Allergies,
            PT.Notes,
            PT.ComplianceScore

        FROM Patients PT
        INNER JOIN Persons P ON PT.PersonId = P.PersonId
        ORDER BY PT.PatientId DESC
    ";

            return ClassCommands.ShowData(query);
        }



        /// <summary>
        /// حذف مريض عبر PatientID باستخدام استعلام واحد فقط.
        /// يرجع:
        /// -1 = المريض مرتبط ولا يمكن حذفه
        ///  0 = المريض غير موجود
        ///  1 = تم الحذف بنجاح
        /// </summary>
        public static int DeletePatientByID(int patientId)
        {

            string query = @"DECLARE @PersonId INT = (SELECT PersonId FROM Patients WHERE PatientId = @PatientId);

        IF (@PersonId IS NULL)
        BEGIN
            SELECT 0 AS Result; 
            RETURN;
        END
        -- التحقق من وجود ارتابط
        DECLARE @Links INT = (
            (SELECT COUNT(*) FROM Visits WHERE PersonId = @PersonId) +
            (SELECT COUNT(*) FROM Appointments WHERE PersonId = @PersonId) +
            (SELECT COUNT(*) FROM Payments WHERE PersonId = @PersonId)
        );

        IF (@Links > 0)
        BEGIN
            SELECT -1 AS Result; 
            RETURN;
        END
             -- اذا مافي ارتباط ...سيتم الحذف
        DELETE FROM Patients WHERE PatientId = @PatientId;

        SELECT 1 AS Result;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@PatientId", patientId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            // رسائل حسب النتيجة
            if (result == -1)
            {
                MessageBox.Show("لا يمكن حذف المريض لأنه مرتبط بزيارات أو مواعيد أو مدفوعات.",
                    "عملية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 0)
            {
                MessageBox.Show("لم يتم العثور على المريض.",
                    "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == 1)
            {
                MessageBox.Show("تم حذف المريض بنجاح.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result;
        }


        /// <summary>
        /// التحقق إذا كان الشخص مسجلاً مسبقاً كمريض.
        ///  true إذا موجود،__
        /// false إذا غير موجود.
        /// </summary>
        public static bool IsPersonAlreadyPatient(int personId)
        {
            string query = @" SELECT COUNT(*) AS Cnt
                    FROM Patients
                    WHERE PersonId = @PersonId";
    
            var parameters = new Dictionary<string, object>()
            {
                { "@PersonId", personId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int count = Convert.ToInt32(dt.Rows[0]["Cnt"]);

            return count > 0;
        }


        /// <summary>
        /// إضافة مريض جديد باستخدام PersonId جاهز.
        /// ترجع:
        /// -1 = الشخص موجود مسبقاً كمريض
        ///  0 = فشل الإضافة
        ///  PatientId = عند نجاح الإضافة
        /// </summary>
        public static int AddPatientOnly(ClassPatients PatientsInfo)
        {
            string query = @"
        DECLARE @Exists INT = (
            SELECT COUNT(*) FROM Patients WHERE PersonId = @PersonId );

        IF (@Exists > 0)
        BEGIN
            SELECT -1 AS Result; -- الشخص موجود مسبقاً
            RETURN;
        END
                                -- تنفيذ الاضافة
        INSERT INTO Patients 
        (PersonId, MedicalNotes, FirstVisitDate, ChronicDiseases, Allergies, Notes, ComplianceScore)
        VALUES
        (@PersonId, @MedicalNotes, @FirstVisitDate, @ChronicDiseases, @Allergies, @Notes, 50);

        SELECT SCOPE_IDENTITY() AS Result; -- إرجاع PatientId الجديد ";
    

            var parameters = new Dictionary<string, object>()
            {
                { "@PersonId", PatientsInfo.PersonInfo.PersonID },
                { "@MedicalNotes", PatientsInfo.MedicalNotes },
                { "@FirstVisitDate", DateTime.Now.ToString("yyyy-MM-dd") },
                { "@ChronicDiseases", PatientsInfo.ChronicDiseases },
                { "@Allergies", PatientsInfo.Allergies },
                { "@Notes", PatientsInfo.Notes }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            // رسائل حسب النتيجة
            if (result == -1)
            {
                MessageBox.Show("هذا الشخص مسجّل مسبقاً كمريض.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 0)
            {
                MessageBox.Show("فشل في إضافة المريض.",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("تمت إضافة المريض بنجاح.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result; // ارجاع معرف المريض
        }


        /// <summary>
        /// تعديل بيانات المريض من جدول Patients فقط.
        /// يمنع ربط PersonID بشخص مرتبط بمريض آخر.
        /// </summary>
        public static bool UpdatePatient(ClassPatients P)
        {
            string query = @" -- التحقق من وجود الشخص مسبقاً
    IF EXISTS (
        SELECT 1 FROM Patients
        WHERE PersonID = @PersonID AND PatientID <> @PatientID
              )
    BEGIN
        SELECT 'LinkedToAnother' AS Result;
    END
    ELSE
    BEGIN
        UPDATE Patients SET
            PersonID = @PersonID,
            MedicalNotes = @MedicalNotes,
            FirstVisitDate = @FirstVisitDate,
            ChronicDiseases = @ChronicDiseases,
            Allergies = @Allergies,
            Notes = @Notes
        WHERE PatientID = @PatientID;

        SELECT 'Updated' AS Result;
    END
    ";

            var parameters = new Dictionary<string, object>()
    {
        { "@PatientID", P.PatientID },
        { "@PersonID", P.PersonInfo.PersonID },
        { "@MedicalNotes", P.MedicalNotes },
        { "@FirstVisitDate", P.FirstVisitDate },
        { "@ChronicDiseases", P.ChronicDiseases },
        { "@Allergies", P.Allergies },
        { "@Notes", P.Notes }
    };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                string result = dt.Rows[0]["Result"].ToString();

                if (result == "LinkedToAnother")
                {
                    MessageBox.Show("لا يمكن ربط هذا المريض بهذا الشخص لأنه مرتبط بمريض آخر.",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (result == "Updated")
                {
                    MessageBox.Show("تم تعديل بيانات المريض بنجاح.",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }

            return false;
        }


        
        // //////////////////////////////////////////    Feltter    ////////////////////////////////////////////





        public enum PatientFilterType
        {
            PatientID,
            PersonID,
            PersonName,
            Phone,
            All
        }
        /// <summary>
        /// إحضار بيانات المرضى مع بيانات الشخص المرتبط بهم مع خيارات فلترة متعددة.
        /// </summary>
        public static DataTable FeltterPatient(PatientFilterType filterType, string value = "")
        {
            try
            {
                string query = @"
    SELECT 
        P.PatientID as [ID Patiient],
        P.PersonID,
        PR.FirstName,
        PR.LastName,
        (PR.FirstName + ' ' + PR.LastName) AS FullName,
        PR.Gender,
        PR.BirthDate,
        PR.Phone,
        PR.CreatedAt,
        PR.UpdatedAt,
        PR.Address,
                         -- بيانات المريض
        P.MedicalNotes,
        P.FirstVisitDate,
        P.ChronicDiseases,
        P.Allergies,
        P.Notes,
        P.ComplianceScore
    FROM Patients P
    INNER JOIN Persons PR ON PR.PersonID = P.PersonID
    WHERE 1 = 1
    ";

                var parameters = new Dictionary<string, object>();

                switch (filterType)
                {
                    case PatientFilterType.PatientID:
                        query += " AND P.PatientID = @PatientID";
                        parameters.Add("@PatientID", Convert.ToInt32(value));
                        break;

                    case PatientFilterType.PersonID:
                        query += " AND P.PersonID = @PersonID";
                        parameters.Add("@PersonID", Convert.ToInt32(value));
                        break;

                    case PatientFilterType.PersonName:
                        query += " AND (PR.FirstName LIKE @Name OR PR.LastName LIKE @Name OR (PR.FirstName + ' ' + PR.LastName) LIKE @Name)";
                        parameters.Add("@Name", "%" + value + "%");
                        break;

                    case PatientFilterType.Phone:
                        query += " AND PR.Phone LIKE @Phone";
                        parameters.Add("@Phone", "%" + value + "%");
                        break;

                    case PatientFilterType.All:
                        // لا نضيف أي شرط
                        break;
                }

                return ClassCommands.ShowData(query, parameters);
            }
            catch
            {
                MessageBox.Show("مشكلة في عملية الفلترة ....أعد المحاولة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }




        // //////////////////////////////////////////     ////////////////////////////////////////////


        /// <summary>
        /// تحديث درجة التزام المريض بناءً على حالة الموعد
        /// بكويري واحدة فقط مع ضبط الحد الأعلى والأدنى.
        /// </summary>
        public static void UpdateComplianceByAppointmentStatus(int personId, string appointmentStatus)
        {
            int scoreChange = 0;

            switch (appointmentStatus)
            {
                case "Completed": scoreChange = +10; break;
                case "Absent": scoreChange = -15; break;
                case "FollowUp": scoreChange = +5; break;
                case "Delayed": scoreChange = -5; break;
                default: scoreChange = 0; break;
            }

            string query = @"
        UPDATE Patients
        SET ComplianceScore =
            CASE 
                WHEN ComplianceScore IS NULL 
                    THEN 
                        CASE 
                            WHEN 50 + @ScoreChange > 100 THEN 100
                            WHEN 50 + @ScoreChange < 0 THEN 0
                            ELSE 50 + @ScoreChange
                        END

                ELSE 
                    CASE 
                        WHEN ComplianceScore + @ScoreChange > 100 THEN 100
                        WHEN ComplianceScore + @ScoreChange < 0 THEN 0
                        ELSE ComplianceScore + @ScoreChange
                    END
            END
        WHERE PersonId = @PersonId;
    ";

            var parameters = new Dictionary<string, object>
            {
                { "@ScoreChange", scoreChange },
                { "@PersonId", personId }
            };

            ClassCommands.ExecuteQuery(query, parameters);
        }








    }
}

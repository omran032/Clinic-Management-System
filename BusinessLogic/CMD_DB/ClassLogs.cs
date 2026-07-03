using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic
{
    public class ClassLogs
    {

      
         



        /// <summary>
        /// Logs تسجيل العمليات في جدول 
        /// </summary>
        /// <param name="userId"> معرف المستخدم</param>
        /// <param name="action">نوع العملية</param>
        /// <param name="tableName">الجدول الذي تم اجراء عليه العملية</param>
        /// <param name="recordId">معرف الصف الذي اجري عيه العملية</param>
        /// <param name="details">وصف الحدث</param>
        public static void AddLog(int userId, string action, string tableName,int recordId, string details = "")
        {
            using (SqlConnection con = new SqlConnection(ClsConnectionDB.connectionString))
            {
                string query = @"
            INSERT INTO Logs (UserId, Action, Timestamp, RecordID, Details, DateTime)
            VALUES (@UserId, @Action, GETDATE(), @RecordID, @Details, GETDATE())";
        

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@RecordID", recordId);
                cmd.Parameters.AddWithValue("@Details", details);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }




        /// <summary>
        ///Logs ارجاع اخر عملية نسخ احتياطي للقاعدة من جدول 
        /// </summary>
        /// <returns></returns>
        public static string GetLastBackupDate()
        {
            string query = @"
        SELECT TOP 1 Timestamp 
        FROM Logs
        WHERE Action = 'DatabaseBackup'
        ORDER BY Timestamp DESC";

            using (SqlConnection con = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                var result = cmd.ExecuteScalar();

                if (result == null)
                    return "لا يوجد نسخة مسجلة";

                DateTime lastBackup = Convert.ToDateTime(result);
                TimeSpan diff = DateTime.Now - lastBackup;

                return $"{diff.Days} يوم / {diff.Hours} ساعة / {diff.Minutes} دقيقة";
            }
        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
 

        /// <summary>
        /// جلب سجل العمليات مع معلومات المستخدم والشخص.
        /// يمكن الفلترة حسب نوع العملية أو المستخدم أو الاثنين.
        /// إذا لم يتم تمرير أي فلترة → يرجع كل السجلات.
        /// </summary>
        public static DataTable GetAllLogsWithUserInfo(string actionFilter = null, int? userIdFilter = null)
        {
            string query = @"
    SELECT 
        L.LogId,
        L.UserId,
        L.Action,
        L.RecordID,
        L.Details,
        L.Timestamp,

        U.Username AS UserLoginName,
        U.PersonId AS PersonID,

        P.FirstName + ' ' + P.LastName AS PersonFullName

    FROM Logs L
    LEFT JOIN Users U ON L.UserId = U.UserId
    LEFT JOIN Persons P ON U.PersonId = P.PersonId
    WHERE 1 = 1
    ";

            // بناء الفلاتر ديناميكياً
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(actionFilter))
            {
                query += " AND L.Action = @Action ";
                parameters.Add("@Action", actionFilter);
            }

            if (userIdFilter.HasValue)
            {
                query += " AND L.UserId = @UserId ";
                parameters.Add("@UserId", userIdFilter.Value);
            }

            // ترتيب من الأحدث إلى الأقدم
            query += " ORDER BY L.Timestamp DESC ";

            return ClassCommands.ShowData(query, parameters);
        }





        /// <summary>
        /// إرجاع سجلات الـ Logs الخاصة بمستخدم معيّن فقط
        /// مع معلومات المستخدم والشخص
        /// مرتبة من الأقدم إلى الأحدث
        /// </summary>
        public static DataTable GetLogsByUser(int userId)
        {
            string query = @"
        SELECT 
            L.LogID,
            L.UserID,
            L.Action,
            L.TableName,
            L.RecordID,
            L.Description,
            L.Timestamp,

            U.UserName AS UserLoginName,
            U.IDPerson AS PersonID,

            P.FirstName + ' ' + P.LastName AS PersonFullName

        FROM Logs L
        LEFT JOIN Users U ON L.UserID = U.UserID
        LEFT JOIN Persons P ON U.IDPerson = P.PersonID

        WHERE L.UserID = @UserID

        ORDER BY L.Timestamp ASC ";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@UserID", userId }
            };

            return ClassCommands.ShowData(query, parameters);
        }



        /// <summary>
        /// إرجاع سجلات الـ Logs الخاصة بعملية معيّنة فقط
        /// مع معلومات المستخدم والشخص
        /// مرتبة من الأقدم إلى الأحدث
        /// </summary>
        public static DataTable GetLogsByAction(LogAction action)
        {
            string query = @"
        SELECT 
            L.LogID,
            L.UserID,
            L.Action,
            L.TableName,
            L.RecordID,
            L.Description,
            L.Timestamp,

            U.UserName AS UserLoginName,
            U.IDPerson AS PersonID,

            P.FirstName + ' ' + P.LastName AS PersonFullName

        FROM Logs L
        LEFT JOIN Users U ON L.UserID = U.UserID
        LEFT JOIN Persons P ON U.IDPerson = P.PersonID

        WHERE L.Action = @Action

        ORDER BY L.Timestamp ASC
    ";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
    {
        { "@Action", action.ToString() }
    };

            return ClassCommands.ShowData(query, parameters);
        }


        /// <summary>
        /// إرجاع سجلات الـ Logs بتاريخ معيّن فقط (بدون مقارنة الوقت)
        /// مع معلومات المستخدم والشخص
        /// مرتبة من الأقدم إلى الأحدث
        /// </summary>
        public static DataTable GetLogsByDate(DateTime date)
        {
            string query = @"
        SELECT 
            L.LogID,
            L.UserID,
            L.Action,
            L.TableName,
            L.RecordID,
            L.Description,
            L.Timestamp,

            U.UserName AS UserLoginName,
            U.IDPerson AS PersonID,

            P.FirstName + ' ' + P.LastName AS PersonFullName

        FROM Logs L
        LEFT JOIN Users U ON L.UserID = U.UserID
        LEFT JOIN Persons P ON U.IDPerson = P.PersonID

        WHERE CAST(L.Timestamp AS DATE) = @Date

        ORDER BY L.Timestamp ASC";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@Date", date.Date }
            };

            return ClassCommands.ShowData(query, parameters);
        }





        /// <summary>
        /// تعبئة الكومبوكس بجميع قيم الـ Enum LogAction
        /// </summary>
        public static void FillComboWithLogActions(ComboBox combo)
        {
            combo.Items.Clear(); // تنظيف العناصر القديمة

            foreach (var action in Enum.GetValues(typeof(LogAction)))
            {
                combo.Items.Add(action);
            }

            combo.SelectedIndex = -1; // عدم اختيار أي عنصر افتراضياً
        }



        public enum LogAction
        {
            Login,
            Logout,
            ForgotPassword,
            DatabaseBackup,

            AddPerson,
            UpdatePerson,
            DeletePerson,

            AddDoctor,
            UpdateDoctor,
            DeleteDoctor,

            AddPatient,
            UpdatePatient,
            DeletePatient,

            AddAppointment,
            UpdateAppointment,
            DeleteAppointment,

            AddVisit,
            UpdateVisit,
            DeleteVisit,

            AddPayment,
            UpdatePayment,
            DeletePayment,

            AddUser,
            UpdateUser,
            DeleteUser
        }


        /// <summary>
        /// تسجيل أي عملية داخل النظام
        /// </summary>
        public static void Log(LogAction action, string tableName, int recordId, string details)
        {
            string query = @"
        INSERT INTO Logs (UserId, Action, Timestamp, RecordID, Details)
        VALUES (@UserId, @Action, GETDATE(), @RecordID, @Details) ";

            var parameters = new Dictionary<string, object>
            {
                { "@UserId", ClassUser.UserInfo.UserID },
                { "@Action", action.ToString() },
                { "@RecordID", recordId },
                { "@Details", details }
            };

            ClassCommands.ExecuteTransaction(query, parameters);
        }










    }
}

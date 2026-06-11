using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ClassLogs
    {

        public enum LogAction
        {
            Login,
            Logout,
            Add,
            Update,
            Delete,
            ForgotPassword,
            ChangeStatus,
            DatabaseBackup
        }
         



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
        /// إرجاع جميع سجلات الـ Logs مع معلومات المستخدم والشخص
        /// مرتبة من الأقدم إلى الأحدث
        /// </summary>
        public static DataTable GetAllLogsWithUserInfo()
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

        ORDER BY L.Timestamp ASC ";

            return ClassCommands.ShowData(query);
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

    }
}

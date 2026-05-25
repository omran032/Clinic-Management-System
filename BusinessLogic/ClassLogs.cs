using System;
using System.Collections.Generic;
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
            ChangeStatus
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


    }
}

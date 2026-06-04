using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TableDoctors
    {

        public enum DoctorFilterType
        {
            All,
            DoctorId,
            PersonId,
            Name,
            Specialization
        }

        /// <summary>
        /// فلترة الأطباء حسب النوع المطلوب:
        /// All - DoctorId - PersonId - Name (Contains) - Specialization
        /// </summary>
        public static DataTable DesplayAnd_FilterDoctors(DoctorFilterType filterType, string value ="")
        {
            string query = @"
        SELECT 
            d.DoctorId as [Doctor ID], 
            d.Notes AS DoctorNotes,

            s.SpecializationId,
            s.Name AS [Specialization Name],

            p.PersonId,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt

        FROM Doctors d
        INNER JOIN Persons p ON d.PersonId = p.PersonId
        INNER JOIN Specializations s ON d.SpecializationId = s.SpecializationId
        WHERE 1 = 1
    ";

            var parameters = new Dictionary<string, object>();

            switch (filterType)
            {
                case DoctorFilterType.All:
                    // لا نضيف أي شرط
                    break;

                case DoctorFilterType.DoctorId:
                    query += " AND d.DoctorId = @Value";
                    parameters.Add("@Value", Convert.ToInt32(value));
                    break;

                case DoctorFilterType.PersonId:
                    query += " AND p.PersonId = @Value";
                    parameters.Add("@Value", Convert.ToInt32(value));
                    break;

                case DoctorFilterType.Name:
                    query += " AND (p.FirstName + ' ' + p.LastName) LIKE '%' + @Value + '%'";
                    parameters.Add("@Value", value);
                    break;

                case DoctorFilterType.Specialization:
                    query += " AND s.Name LIKE '%' + @Value + '%'";
                    parameters.Add("@Value", value);
                    break;
            }

            query += " ORDER BY p.FirstName, p.LastName";

            return ClassCommands.ShowData(query, parameters);
        }


        /// <summary>
        /// حذف طبيب بعد التحقق من عدم وجود أي ارتباطات.
        /// ترجع:
        /// -1 = الطبيب مرتبط ولا يمكن حذفه
        ///  0 = فشل الحذف
        ///  1 = تم الحذف بنجاح
        /// </summary>
        public static int DeleteDoctor(int doctorId)
        {
            string query = @"
        DECLARE @Linked INT = (
            SELECT 
                (SELECT COUNT(*) FROM Appointments WHERE DoctorId = @DoctorId) +
                (SELECT COUNT(*) FROM Visits WHERE DoctorId = @DoctorId)
        );

        IF (@Linked > 0)
        BEGIN
            SELECT -1 AS Result; -- الطبيب مرتبط
            RETURN;
        END

        DELETE FROM Doctors WHERE DoctorId = @DoctorId;

        IF (@@ROWCOUNT > 0)
            SELECT 1 AS Result;  -- تم الحذف
        ELSE
            SELECT 0 AS Result;  -- لم يتم الحذف ";
    

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            // رسائل حسب الحالة
            if (result == -1)
                MessageBox.Show("لا يمكن حذف الطبيب لأنه مرتبط بسجلات (مواعيد أو زيارات).", "عملية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (result == 1)
                MessageBox.Show("تم حذف الطبيب بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("فشل في حذف الطبيب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return result;
        }



        /// <summary>
        /// التحقق إذا كان الشخص مسجلاً مسبقاً كطبيب.
        /// ترجع true إذا موجود،
        /// false إذا غير موجود.
        /// </summary>
        public static bool IsPersonDoctor(int personId)
        {
            string query = @" SELECT COUNT(*) AS Cnt
                FROM Doctors
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
        /// إضافة طبيب جديد بعد التحقق من عدم وجوده مسبقاً.
        /// ترجع:
        /// -1 = الشخص مسجل مسبقاً كطبيب
        ///  0 = فشل الإضافة
        ///  DoctorId = عند نجاح الإضافة
        /// </summary>
        public static int AddDoctor(ClassDoctor doctorInfo)
        {
            string query = @"
        -- التحقق إذا الشخص مسجل كطبيب مسبقاً
        DECLARE @Exists INT = (   SELECT COUNT(*) FROM Doctors WHERE PersonId = @PersonId   );

        IF (@Exists > 0)
        BEGIN
            SELECT -1 AS Result; -- الشخص موجود مسبقاً
            RETURN;
        END

        -- إضافة الطبيب
        INSERT INTO Doctors (PersonId, SpecializationId, Notes)
        VALUES (@PersonId, @SpecializationId, @Notes);

        SELECT SCOPE_IDENTITY() AS Result; -- DoctorId الجديد ";
    

            var parameters = new Dictionary<string, object>()
            {
                { "@PersonId", doctorInfo.PersonInfo.PersonID },
                { "@SpecializationId", doctorInfo.SprcializationID },
                { "@Notes", doctorInfo.Notes }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            // رسائل حسب الحالة
            if (result == -1)
                MessageBox.Show("هذا الشخص مسجّل مسبقاً كطبيب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (result == 0)
                MessageBox.Show("فشل في إضافة الطبيب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
                MessageBox.Show("تمت إضافة الطبيب بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }


        /// <summary>
        /// تعديل بيانات طبيب.
        /// التحقق:
        /// - إذا كان PersonId الجديد مرتبط بطبيب آخر → يمنع التعديل
        /// - إذا كان نفس الشخص → يسمح
        /// ترجع:
        /// -1 = الشخص الجديد مرتبط بطبيب آخر
        ///  0 = فشل التعديل
        ///  1 = تم التعديل بنجاح
        /// </summary>
        public static int UpdateDoctor(ClassDoctor doctorInfo, int originalPersonId)
        {
            string query = @"
        -- إذا كان الشخص الجديد نفسه القديم → مسموح
        IF (@NewPersonId = @OldPersonId)
        BEGIN
            UPDATE Doctors
            SET 
                SpecializationId = @SpecializationId,
                Notes = @Notes
            WHERE DoctorId = @DoctorId;

            IF (@@ROWCOUNT > 0)
                SELECT 1 AS Result;
            ELSE
                SELECT 0 AS Result;

            RETURN;
        END

        -- إذا كان الشخص الجديد مختلف → تحقق إذا مسجل كطبيب
        DECLARE @Exists INT = (
            SELECT COUNT(*) FROM Doctors WHERE PersonId = @NewPersonId  );

        IF (@Exists > 0)
        BEGIN
            SELECT -1 AS Result; -- الشخص الجديد مرتبط بطبيب آخر
            RETURN;
        END

        -- تنفيذ التعديل
        UPDATE Doctors
        SET 
            PersonId = @NewPersonId,
            SpecializationId = @SpecializationId,
            Notes = @Notes
        WHERE DoctorId = @DoctorId;

        IF (@@ROWCOUNT > 0)
            SELECT 1 AS Result;
        ELSE
            SELECT 0 AS Result;";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorInfo.DoctorID },
                { "@NewPersonId", doctorInfo.PersonInfo.PersonID },
                { "@OldPersonId", originalPersonId },
                { "@SpecializationId", doctorInfo.SprcializationID },
                { "@Notes", doctorInfo.Notes }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);
            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            // رسائل حسب الحالة
            if (result == -1)
            {
                MessageBox.Show("لا يمكن ربط الطبيب بهذا الشخص لأنه مسجّل مسبقاً كطبيب.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 1)
            {
                MessageBox.Show("تم تعديل بيانات الطبيب بنجاح.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("فشل في تعديل بيانات الطبيب.",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }




















    }
}

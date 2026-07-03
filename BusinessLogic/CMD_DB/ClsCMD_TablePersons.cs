using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TablePersons
    {
        /// <summary>
        /// جلب بيانات شخص حسب الـ ID من جدول Persons
        /// وتجميع الاسم من FirstName و LastName.
        /// </summary>
        public static ClassPerson GetPersonByID(int personID)
        {
            string query = @"
        SELECT PersonID, FirstName, LastName, Gender, BirthDate, Phone, Address, CreatedAt, UpdatedAt
        FROM Persons
        WHERE PersonID = @PersonID";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@PersonID", personID }
                };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            // نقل البيانات من الجدول ل الأوبجكت
            ClassPerson person = ClassPerson.SaveDataInObj(dt);

            return person;
        }



        public enum AllOrSome
        {
            All,
            Some,
        }

        /// <summary>
        /// ارجاع جدول معلومات الاشخاص 
        /// بعض المعلومات أو كلها
        /// </summary>
        public static DataTable GetInfoPersons(AllOrSome allOrSome = AllOrSome.Some)
          {
            string query = "";  
            if (allOrSome == AllOrSome.Some)
            {
                  query = @"SELECT PersonID, FirstName, LastName, Gender, BirthDate, Phone FROM Persons";
            }
            else
            {
                query = @"SELECT PersonID, FirstName, LastName, Gender, BirthDate, Phone, Address, CreatedAt, UpdatedAt FROM Persons";
            }
           
            return ClassCommands.ShowData(query);
         }



    public enum PersonFilterType
        {
            All,
            ID,
            FullName,
            NationalNumber
        }


        /// <summary>
        /// فلترة الأشخاص حسب النوع المطلوب (ID - الاسم - الرقم الوطني - عرض الكل)
        /// وتدعم البحث بطريقة Contains وليس تطابق كامل.
        /// </summary>
        public static DataTable FilterPersons(PersonFilterType filterType, string value)
        {
            string query = "";

            switch (filterType)
            {
                case PersonFilterType.All:
                    query = "SELECT PersonID, FirstName, LastName, Gender, BirthDate, Phone FROM Persons";
                    break;

                case PersonFilterType.ID:
                    query = "SELECT * FROM Persons WHERE PersonID = @Value";
                    break;

                case PersonFilterType.FullName:
                    query = @"
                SELECT * FROM Persons 
                WHERE FirstName LIKE '%' + @Value + '%'
                   OR LastName LIKE '%' + @Value + '%'
                   OR (FirstName + ' ' + LastName) LIKE '%' + @Value + '%'";
                    break;

                case PersonFilterType.NationalNumber:
                    query = "SELECT * FROM Persons WHERE National_Number LIKE '%' + @Value + '%'";
                    break;
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@Value", value }
                };
            return ClassCommands.ShowData(query, parameters);
        }


        /// <summary>
        /// مثود حذف شخص 
        /// </summary>
        public static void DeletePerson(int personID)
        {
            string query = @"
        -- التحقق من الارتباطات
        DECLARE @Links INT = (
            SELECT 
                (SELECT COUNT(*) FROM Users WHERE PersonId = @ID) +
                (SELECT COUNT(*) FROM Patients WHERE PersonId = @ID) +
                (SELECT COUNT(*) FROM Doctors WHERE PersonId = @ID) +
                (SELECT COUNT(*) FROM Appointments WHERE PersonId = @ID) +
                (SELECT COUNT(*) FROM Visits WHERE PersonId = @ID) +
                (SELECT COUNT(*) FROM Payments WHERE PersonId = @ID)
        );

        -- إذا في ارتباطات .... رجّع -1
        IF (@Links > 0)
        BEGIN
            SELECT -1 AS Result;
            RETURN;
        END

        -- إذا ما في ارتباطات ..... احذف
        DELETE FROM Persons WHERE PersonId = @ID;

        -- رجّع 1 للدلالة على النجاح
        SELECT 1 AS Result;";
    

            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@ID", personID }
                };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            int result = Convert.ToInt32(dt.Rows[0]["Result"]);

            if (result == -1) // اذا مرتبط
            {
                MessageBox.Show("لا يمكن حذف هذا الشخص لأنه مرتبط بسجلات أخرى.", "عملية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 1) // اذا سنغل ...هاهاها
            {
                MessageBox.Show("تم حذف الشخص بنجاح.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("حدث خطأ غير متوقع أثناء الحذف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// تعديل بيانات شخص موجود في جدول Persons
        /// </summary>
        public static void UpdatePerson(ClassPerson person)
        {
            string query = @"
        UPDATE Persons
        SET 
            FirstName = @FirstName,
            LastName  = @LastName,
            Gender    = @Gender,
            BirthDate = @BirthDate,
            Phone     = @Phone,
            Address   = @Address,
            UpdatedAt = GETDATE()
        WHERE PersonId = @PersonId ";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@PersonId", person.PersonID },
                { "@FirstName", person.FirstName },
                { "@LastName", person.LastName },
                { "@Gender", person.Gender },
                { "@BirthDate", person.BirthDate },
                { "@Phone", person.Phone },
                { "@Address", person.Address }
            };
 
            if (  ClassCommands.ExecuteQuery(query, parameters))
            {
               MessageBox.Show("تم تعديل بيانات الشخص بنجاح.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClassLogs.AddLog(ClassUser.UserInfo.UserID, "AddPerson", "Persons", person.PersonID , "إضافة شخص جديد");   // تسجيل العمل في Log
            }
            else
                MessageBox.Show("لم يتم تعديل بيانات الشخص.", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Persons إضافة شخص جديد إلى جدول 
        /// </summary>
        public static int AddPerson(ClassPerson person)
        {
            string query = @"INSERT INTO Persons
                (FirstName, LastName, Gender, BirthDate, Phone, Address, CreatedAt, UpdatedAt)
                VALUES
                    (@FirstName, @LastName, @Gender, @BirthDate, @Phone, @Address, GETDATE(), GETDATE());

                    SELECT SCOPE_IDENTITY();";
    

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@FirstName", person.FirstName },
                { "@LastName",  person.LastName },
                { "@Gender",    person.Gender },
                { "@BirthDate", person.BirthDate },
                { "@Phone",     person.Phone },
                { "@Address",   person.Address }
            };

            int newID = ClassCommands.ExecuteScalar(query, parameters);

            if (newID > 0)
            {
                MessageBox.Show("تمت إضافة الشخص بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClassLogs.AddLog(ClassUser.UserInfo.UserID, "AddPerson", "Persons", newID , "إضافة شخص جديد");   // تسجيل العمل في Log
            }
            else
                MessageBox.Show("فشل إضافة الشخص.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return newID;
        }




    }
}

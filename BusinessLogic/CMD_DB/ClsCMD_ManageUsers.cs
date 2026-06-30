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
    public class ClsCMD_ManageUsers
    {


        /// <summary>
        /// تعبئة ComboBox بالصلاحيات من جدول Roles.
        /// يعرض اسم الصلاحية ويخزن RoleId.
        /// </summary>
        public static void LoadRoles(ComboBox combo)
        {
            string query = "SELECT RoleId, RoleName FROM Roles ORDER BY RoleName ASC";

            DataTable dt = ClassCommands.ShowData(query);

            combo.DataSource = dt;
            combo.DisplayMember = "RoleName";   // يظهر اسم الصلاحية
            combo.ValueMember = "RoleId";       // يخزن ID داخلياً
            combo.SelectedIndex = -1;
        }



        /// <summary>
        /// إرجاع صلاحية الشخص إذا كان مسجل كمستخدم.
        /// إذا غير مسجل → يرجع null.
        /// </summary>
        public static string GetUserRoleByPersonId(int personId)
        {
            string query = @"
        SELECT R.RoleName
        FROM Users U
        INNER JOIN Roles R ON U.RoleId = R.RoleId
        WHERE U.PersonId = @PersonId  ";


            var parameters = new Dictionary<string, object>
            {
                { "@PersonId", personId }
            };

            object result = ClassCommands.ExecuteScalarObject(query, parameters);

            return result == null ? null : result.ToString();
        }



        /// <summary>
        /// إرجاع جدول المستخدمين مع المعلومات اللازمة لواجهة User Management.
        /// </summary>
        public static DataTable GetUsersForManagement()
        {
            string query = @"
        SELECT 
            U.UserId,
            (P.FirstName + ' ' + P.LastName) AS FullName,
            U.Username,
            R.RoleName AS Role,
            CASE 
                WHEN U.IsActive = 1 THEN 'Active'
                ELSE 'Inactive'
            END AS Status,
            D.DoctorId
        FROM Users U
        LEFT JOIN Persons P ON U.PersonId = P.PersonId
        LEFT JOIN Roles R ON U.RoleId = R.RoleId
        LEFT JOIN Doctors D ON U.PersonId = D.PersonId
        ORDER BY U.UserId ASC; ";

            return ClassCommands.ShowData(query);
        }




        /// <summary>
        /// جلب معلومات مستخدم كاملة ضمن Object من نوع ClassUser
        /// يرجع معلومات المستخدم + الشخص + معلومات الطبيب إذا كان طبيباً
        /// </summary>
        public static ClassUser GetUserInfo(int userId)
        {
            string query = @"
    SELECT 
        -- جدول المستخدمين
        u.UserId,
        u.Username,
        r.RoleName,
        u.RoleId,
        u.PersonId,
        u.IsActive,

        -- جدول الأشخاص
        p.PersonID,
        p.FirstName,
        p.LastName,
        p.Gender,
        p.BirthDate,
        p.Phone,
        p.Address,
        p.CreatedAt,
        p.UpdatedAt,

        -- جدول الأطباء (قد يكون فارغ)
        d.DoctorID,
        d.SpecializationId,
        s.Name AS SpecializationName,
        d.Notes AS DoctorNotes

    FROM Users u
    INNER JOIN Persons p 
        ON u.PersonId = p.PersonID
    INNER JOIN Roles r
        ON u.RoleId = r.RoleId

    LEFT JOIN Doctors d
        ON d.PersonId = u.PersonId

    LEFT JOIN Specializations s
        ON d.SpecializationId = s.SpecializationId

    WHERE u.UserId = @UserId
    ";

            var parameters = new Dictionary<string, object>()
    {
        { "@UserId", userId }
    };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            // تعبئة معلومات الشخص
            ClassPerson person = ClassPerson.SaveDataInObj(dt);

            // تعبئة معلومات المستخدم
            ClassUser user = new ClassUser()
            {
                UserID = Convert.ToInt32(row["UserId"]),
                UserName = row["Username"]?.ToString(),
                Role = row["RoleName"]?.ToString(),
                PersonInfo = person,
                IsActive = Convert.ToBoolean(row["IsActive"])
            };

            // إذا كان طبيب → عبّي معلومات الطبيب
            if (row["DoctorID"] != DBNull.Value)
            {
                ClassDoctor doctor = new ClassDoctor()
                {
                    DoctorID = Convert.ToInt32(row["DoctorID"]),
                    SprcializationID = Convert.ToInt32(row["SpecializationId"]),
                    SprcializationName = row["SpecializationName"]?.ToString(),
                    Notes = row["DoctorNotes"]?.ToString(),

                    // نفس معلومات الشخص بدون تكرار
                    PersonInfo = person
                };

                user.DoctorInfo = doctor;
            }
            else
            {
                user.DoctorInfo = null;
            }

            return user;
        }






        /// <summary>
        /// إضافة مستخدم جديد + إذا كان طبيب يتم إضافته لجدول Doctors.
        /// يتم التنفيذ ضمن Transaction واحدة.
        /// </summary>
        public static bool AddUser(int personId, string username, string password, int roleId, int specializationId = 0)
        {
            string query = @"
BEGIN TRY
    BEGIN TRANSACTION;

    -- إضافة المستخدم
    INSERT INTO Users (PersonId, Username, Password, RoleId, IsActive)
    VALUES (@PersonId, @Username, @Password, @RoleId, 1);

    -- إذا كانت الصلاحية طبيب → أضفه لجدول Doctors
    IF EXISTS (SELECT 1 FROM Roles WHERE RoleId = @RoleId AND LOWER(RoleName) = 'doctor')
    BEGIN
        INSERT INTO Doctors (PersonId, SpecializationId)
        VALUES (@PersonId, @SpecializationId);
    END

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
";

            var parameters = new Dictionary<string, object>
            {
                { "@PersonId", personId },
                { "@Username", username },
                { "@Password", password },
                { "@RoleId", roleId },
                { "@SpecializationId", specializationId }
            };

            try
            {
                // ترجع نتيجة العملية 
                return ClassCommands.ExecuteQuery(query, parameters);
            }
            catch
            {
                return false;
            }
        }





        /// <summary>
        /// تعديل بيانات المستخدم.
        /// يتم تحديث: الشخص المرتبط، كلمة المرور، الصلاحية، الحالة.
        /// وإذا كان طبيب → يتم تحديث بياناته أيضاً (PersonId + SpecializationId).
        /// التنفيذ يتم ضمن Transaction واحدة.
        /// </summary>
        public static bool UpdateUser( int userId, int newPersonId,string username, string password, int roleId, bool isActive,int specializationId = 0)
        {
            string query = @"
BEGIN TRY
    BEGIN TRANSACTION;

    ---------------------------------------------------------
    -- 1) تحديث بيانات المستخدم في جدول Users
    ---------------------------------------------------------
    UPDATE Users
    SET 
        PersonId = @NewPersonId,
        Username = @Username,
        Password = @Password,
        RoleId = @RoleId,
        IsActive = @IsActive
    WHERE UserId = @UserId;

    ---------------------------------------------------------
    -- 2) إذا كانت الصلاحية Doctor → تحديث بيانات الطبيب
    ---------------------------------------------------------
    IF EXISTS (SELECT 1 FROM Roles WHERE RoleId = @RoleId AND LOWER(RoleName) = 'doctor')
    BEGIN
        -- إذا الطبيب موجود مسبقاً → عدّل بياناته
        IF EXISTS (SELECT 1 FROM Doctors WHERE PersonId = @OldPersonId)
        BEGIN
            UPDATE Doctors
            SET 
                PersonId = @NewPersonId,
                SpecializationId = @SpecializationId
            WHERE PersonId = @OldPersonId;
        END
        ELSE
        BEGIN
            -- إذا لم يكن موجوداً → أضفه
            INSERT INTO Doctors (PersonId, SpecializationId)
            VALUES (@NewPersonId, @SpecializationId);
        END
    END
    ELSE
    BEGIN
        ---------------------------------------------------------
        -- 3) إذا لم تعد الصلاحية Doctor → احذف الطبيب من جدول Doctors
        ---------------------------------------------------------
        DELETE FROM Doctors WHERE PersonId = @OldPersonId;
    END

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
";

            var parameters = new Dictionary<string, object>
    {
        { "@UserId", userId },
        { "@NewPersonId", newPersonId },
        { "@OldPersonId", GetOldPersonId(userId) }, // نجيب الشخص القديم
        { "@Username", username },
        { "@Password", password },
        { "@RoleId", roleId },
        { "@IsActive", isActive ? 1 : 0 },
        { "@SpecializationId", specializationId }
    };

            try
            {
                return ClassCommands.ExecuteQuery(query, parameters);
                
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// معرفة معرف الطبيب القديم للشخص المرتبط به
        /// </summary>
        public static int GetOldPersonId(int userId)
        {
            string query = "SELECT PersonId FROM Users WHERE UserId = @UserId";

            var parameters = new Dictionary<string, object>
            {
                { "@UserId", userId }
            };

            return Convert.ToInt32(ClassCommands.ExecuteScalar(query, parameters));
        }





    }
}

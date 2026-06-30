using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DB
{
    public class ClassLoginUser
    {


        /// <summary>
        /// التحقق من وجود المستخدم وارجاع الصلاحية
        /// </summary>
        /// <returns>    ارجاع نوع المستخدم    الصلاحية  </returns>
        public static string GetUserRole(string username, string password)
        {
            // تشفير كلمة المرور
            password = HashPasswordSHA256(password);

            string roleName = null;

            using (SqlConnection con = new SqlConnection(ClsConnectionDB.connectionString))
            {
                string query = @"
            SELECT 
                U.UserId,
                U.Username,
                R.RoleName,
                P.PersonId,
                P.FirstName , 
                P.LastName  ,
                P.Gender,
                P.BirthDate,
                P.Phone,
                P.Address,
                P.CreatedAt,
                P.UpdatedAt
            FROM Users U
            INNER JOIN Roles R ON U.RoleId = R.RoleId
            INNER JOIN Persons P ON U.PersonId = P.PersonId
            WHERE U.Username = @Username 
              AND U.Password = @Password 
              AND U.IsActive = 1
        ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // 1) تعبئة بيانات المستخدم الأساسية
                    ClassUser.UserInfo = new ClassUser
                    {
                        UserID = Convert.ToInt32(dr["UserId"]),
                        UserName = dr["Username"].ToString(),
                        Role = dr["RoleName"].ToString(),
                        PersonInfo = new ClassPerson
                        {
                            PersonID = Convert.ToInt32(dr["PersonId"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            BirthDate = Convert.ToDateTime( dr["BirthDate"] ),
                            Phone = dr["Phone"].ToString(),
                            Address = dr["Address"].ToString(),
                            CreatedAt = dr["CreatedAt"].ToString(),
                            UpdatedAt = dr["UpdatedAt"].ToString()
                        }
                    };

                    roleName = dr["RoleName"].ToString();
                }
                else
                {
                    return null; // المستخدم غير موجود
                }

                dr.Close();

                // 2) إذا كان المستخدم طبيب → نجيب بيانات الطبيب
                if (roleName == "Doctor")
                {
                    string doctorQuery = @"
                SELECT D.DoctorId, S.Name AS Specialization
                FROM Doctors D
                INNER JOIN Specializations S ON D.SpecializationId = S.SpecializationId
                WHERE D.PersonId = @PersonId
            ";

                    SqlCommand cmdDoctor = new SqlCommand(doctorQuery, con);
                    cmdDoctor.Parameters.AddWithValue("@PersonId", ClassUser.UserInfo.PersonInfo.PersonID);

                    SqlDataReader dr2 = cmdDoctor.ExecuteReader();

                    if (dr2.Read())
                    {
                        ClassUser.UserInfo.DoctorInfo = new ClassDoctor
                        {
                            DoctorID = Convert.ToInt32(dr2["DoctorId"]),
                            SprcializationName = dr2["Specialization"].ToString()
                        };
                    }
                    else
                    {
                        ClassUser.UserInfo.DoctorInfo = null; // مو طبيب
                    }

                    dr2.Close();
                }
                else
                {
                    ClassUser.UserInfo.DoctorInfo = null; // مو طبيب
                }
            }

            return roleName;
        }

        /// <summary>
        /// هذه الدالة تقوم بتشفير كلمة المرور باستخدام خوارزمية SHA256
        /// وترجع القيمة المشفرة على شكل نص HEX بطول 64 حرف.
        /// تستخدم عند تخزين كلمات المرور أو التحقق منها أثناء تسجيل الدخول  .
        /// </summary>
        public static string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // HEX
                }

                return builder.ToString();
            }
        }

    }
}

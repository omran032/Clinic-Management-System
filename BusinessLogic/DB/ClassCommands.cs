using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic
{
   public  class ClassCommands
    {

        


        ////-----////-----////-----////////-----////////-----////////-----////////-----////
        ////-----////-----////-----////////-----////////-----////////-----////////-----////



        /// <summary>
        /// عرض البيانات
        /// </summary>
        /// <param name="query">الاستعلام</param>
        /// <returns></returns>
        public static DataTable ShowData(string query)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString)) throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");
            // إنشاء الاتصال
            using (SqlConnection connection = new SqlConnection(ClsConnectionDB.connectionString))
            {
                // إنشاء الأمر
                SqlCommand command = new SqlCommand(query, connection);

                // إنشاء محول البيانات
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // إنشاء الجدول وتعبئته
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }



        /// <summary>
        ///  عرض البيانات
        /// </summary>
        /// <param name="query">نص الاستعلام  </param>
        /// <param name="parameters"> قائمة المعاملات (Dictionary) </param>
        /// <returns> جدول بيانات (DataTable)  </returns>
        public static DataTable ShowData(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");

            // إنشاء الاتصال
            using (SqlConnection connection = new SqlConnection(ClsConnectionDB.connectionString))
            {
                // إنشاء الأمر
                SqlCommand command = new SqlCommand(query, connection);

                // ربط الباراميترات بالاستعلام
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                // إنشاء محول البيانات
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // إنشاء الجدول وتعبئته
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }



        /// <summary>
        /// التحقق من وجود المستخدم
        /// </summary>
        /// <param name="query"> استعلام </param>
        /// <param name="parameters"> بيانات المستخدم للتحقق </param>
        /// <returns></returns>
        public static bool Login(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // إضافة الباراميترات من الدكشنري
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows; // ✅ يرجع true إذا في صف، false إذا لا
                }
            }
        }




        /// <summary>
        /// عرض قيمة واحدة العمود
        /// </summary>
        /// <param name="query">الاستعلام</param>
        /// <returns></returns>
        public static dynamic ShowValue(string query)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString)) throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");
            using (SqlConnection connection = new SqlConnection(ClsConnectionDB.connectionString))
            {
               // MessageBox.Show(ClsConnectionDB.connectionString);
                connection.Open(); // مهم تفتح الاتصال قبل التنفيذ
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {                   
                    return 0;                                         
                }

                return   result;
            }
        }

        /// <summary>
        /// Scalar تنفيذ استعلام  .
        /// (Dictionary) مع دعم الباراميترات .
        /// ترجع قيمة واحدة فقط.
        /// </summary>
        public static dynamic ShowValue(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowValue.");

            using (SqlConnection connection = new SqlConnection(ClsConnectionDB.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // إضافة الباراميترات
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return result;
            }
        }


        /// <summary>
        /// تاكد من وجود نتيجة من الاستعلام
        /// </summary>
        /// <returns> اذا مافي نتيجة false  اذا في نتيجة و   true برجع   </returns>
        public static bool IsExists(string query  )
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString)) throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");
            using (SqlConnection connection = new SqlConnection( ClsConnectionDB.connectionString))
            {
                connection.Open(); // مهم تفتح الاتصال قبل التنفيذ
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                bool isExists = result != null && result != DBNull.Value;

                return isExists;
            }
        }

        /// <summary>
        /// تأكد من وجود نتيجة من الاستعلام مع دعم البارامترات
        /// </summary>
        /// <param name="query">نص الاستعلام SQL</param>
        /// <param name="parameters">قائمة البارامترات (Dictionary) التي تربط أسماء الباراميترات بالقيم</param>
        /// <returns>إذا مافي نتيجة يرجع False، إذا في نتيجة يرجع True</returns>
        public static bool IsExists(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");

            using (SqlConnection connection = new SqlConnection(ClsConnectionDB.connectionString))
            {
                connection.Open(); // مهم تفتح الاتصال قبل التنفيذ
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // إضافة البارامترات
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    object result = command.ExecuteScalar();
                    int count = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    return count > 0;

                }
            }
        }


        /// <summary>
        /// مثود عام للتعديل و الحذف و الإضافة
        /// يرجع true إذا تم تنفيذ العملية (تأثر صف واحد أو أكثر)
        /// ويرجع false إذا لم يتم أي تغيير
        /// </summary>
        public static bool ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة.");

            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // ربط الباراميترات
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                // إذا تم تعديل أو إضافة أو حذف صف واحد على الأقل
                return rowsAffected > 0;
            }
        }




        /// <summary>
        /// ينفذ استعلام SQL 
        /// (مثل INSERT أو UPDATE أو DELETE) داخل معاملة 
        /// (Transaction) 
        /// باستخدام الاتصال المحدد، ويضمن أن العملية إما تنجح بالكامل أو يتم إلغاؤها بالكامل.
        /// يرجع True إذا تم تعديل أسطر، و False إذا لم يتم.
        /// </summary>
        public static int ExecuteTransaction(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة.");

            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    try
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit(); // تأكيد التنفيذ إذا نجح

                        return rowsAffected  ; // يقوم ب ارجاع عدد الاسطر التي تم تعديلها 
                    }
                    catch
                    {
                        transaction.Rollback(); // إلغاء التنفيذ إذا صار خطأ
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// وارجاع معرف الصف المضاف   Insert تنفيذ اوامر الاضافة 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns> ارجاع معرف الصف المضاف </returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static int ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString))
                throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة.");

            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                conn.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && result != DBNull.Value)
                    ? Convert.ToInt32(result)
                    : 0;
            }
        }


        /// <summary>
        ///  ComboBox  تقوم بتحميل البيانات في عنصر
        /// </summary>
        /// <param name="Query">الاستعلام</param>
        /// <param name="com">العنصر</param>
        public static void LoadItem_InComboBox(string Query ,  ComboBox com  , string Display , string ValueID)
        {
           // TypeConnetion("exam");
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString)) throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");
            using (SqlConnection conn = new SqlConnection( ClsConnectionDB.connectionString))
            {
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                com.DataSource = dt;
                com.DisplayMember = Display; // التي تعرض في العنصر
                com.ValueMember   = ValueID;  // اختيار  ID تخزين  
            }          
        }


        /// <summary>
        /// List يقوم بتخزين النتائج في 
        /// </summary>
        /// <param name="Query"     > الاستعلام </param>
        /// <param name="NameColumn"> اسم العمود الذي تريد اخذ منه البيانات و تخزينها في القائمة  </param>
        /// <param name="Mylist"    >  القائمة </param>
        public static  void Save_In_List(string Query ,string NameColumn , List<dynamic> Mylist )
        {
            if (string.IsNullOrWhiteSpace(ClsConnectionDB.connectionString)) throw new InvalidOperationException("ClsConnectionDB.connectionString غير مهيّأة. نادِ TypeConnetion قبل ShowData.");
            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader[NameColumn].ToString();
                        Mylist.Add(name);
                    }
                }
            }
        }




    } //  end class
}

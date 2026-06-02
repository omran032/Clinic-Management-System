using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic.InfoTable
{
    public class ClassPerson
    {
        public int PersonID { get; set; }


       
        public string FullName
        { 
        get { return FirstName + " " + LastName; ; }
            set
            {
                FullName = FirstName + " " + LastName;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone {  get; set; }

        public string Address { get; set; }

        public string  CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

 
        public int Age
        {
            get
            {
                    int age = DateTime.Now.Year - BirthDate.Year;

                    // تعديل العمر إذا عيد ميلاده ما إجا هالسنة
                    if (BirthDate.Date > DateTime.Now.AddYears(-age))
                        age--;

                    return age;
            }
        }

        /// <summary>
        ///  حفظ البيانات داخل أوبجكت ..بعد تخزينها في الجدول
        /// </summary>
        /// <param name="dt">جدول البيانات</param>
        /// <returns></returns>
        public static ClassPerson SaveDataInObj(DataTable dt , int RowIndex = 0)
        {
                                // الصف المراد
            DataRow row = dt.Rows[RowIndex]; // Top 1

            ClassPerson person = new ClassPerson()
            {
                PersonID  = int.Parse(row["PersonID"].ToString() ),
                FirstName = row["FirstName"]?.ToString(),
                LastName  = row["LastName"]?.ToString(),
                Gender    = row["Gender"]?.ToString(),
                BirthDate = Convert.ToDateTime(row["BirthDate"]),
                Phone     = row["Phone"]?.ToString(),
                Address   = row["Address"]?.ToString(),
                CreatedAt = row["CreatedAt"]?.ToString(),
                UpdatedAt = row["UpdatedAt"]?.ToString()
            };
             return person;
        }



    }
}

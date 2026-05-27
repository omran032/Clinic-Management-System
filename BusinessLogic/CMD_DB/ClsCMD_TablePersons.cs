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
    public class ClsCMD_TablePersons
    {
        /// <summary>
        /// ارجاع معلومات الشخص ضمن الكلاس عند ارسال معرف الشخص
        /// </summary>
        /// <param name="personID">معرف الشخص</param>
        public static ClassPerson GetPersonByID(int personID)
        {
            string query = @"SELECT PersonID, FullName, Gender, BirthDate, Phone, Address, CreatedAt, UpdatedAt 
                    FROM Persons
                    WHERE PersonID = @PersonID";

              Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@PersonID", personID }
                };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            ClassPerson person = new ClassPerson()
            {
                PersonID = Convert.ToInt32(row["PersonID"]),
                FullName = row["FullName"]?.ToString(),
                Gender = row["Gender"]?.ToString(),
                BirthDate = row["BirthDate"]?.ToString(),
                Phone = row["Phone"]?.ToString(),
                Address = row["Address"]?.ToString(),
                CreatedAt = row["CreatedAt"]?.ToString(),
                UpdatedAt = row["UpdatedAt"]?.ToString()
            };

            return person;
        }


    }
}

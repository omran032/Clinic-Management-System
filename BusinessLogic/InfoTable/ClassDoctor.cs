using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization;

namespace BusinessLogic.InfoTable
{
    public class ClassDoctor
    {
        public int DoctorID { get; set; }

        public int SprcializationID { get; set; }

        public string SprcializationName {  get; set; }

        public string Notes { get; set; }

        public ClassPerson PersonInfo { get; set; }


        public static ClassDoctor GetInfoDoctorInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassDoctor DoctorInfo = new ClassDoctor()
            {
                DoctorID           = Convert.ToInt32(row["Doctor ID"]),
                SprcializationID   = Convert.ToInt32(row["SpecializationId"]),
                SprcializationName = row["Specialization Name"]?.ToString(),
                Notes              = row["DoctorNotes"]?.ToString(),

                PersonInfo         = ClassPerson.SaveDataInObj(dt , RowIndex)
            };

            return DoctorInfo;

        }


        /// <summary>
        /// جلب معلومات دكتور كامل ضمن Object من نوع ClassDoctor
        /// </summary>
        public static ClassDoctor GetDoctorInfo(int doctorId)
        {
            string query = @"
        SELECT 
            d.DoctorID        AS [Doctor ID],
            d.SpecializationId,
            s.Name            AS [Specialization Name],
            d.Notes           AS DoctorNotes,

            p.PersonID,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt

        FROM Doctors d
        INNER JOIN Persons p 
            ON d.PersonID = p.PersonID
        INNER JOIN Specializations s
            ON d.SpecializationId = s.SpecializationId

        WHERE d.DoctorID = @DoctorID ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorID", doctorId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            return ClassDoctor.GetInfoDoctorInObj(dt);
        }


    }
}

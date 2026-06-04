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
                SprcializationName = row["Sprcialization Name"]?.ToString(),
                Notes              = row["DoctorNotes"]?.ToString(),

                PersonInfo         = ClassPerson.SaveDataInObj(dt , RowIndex)
            };

            return DoctorInfo;

        }




    }
}

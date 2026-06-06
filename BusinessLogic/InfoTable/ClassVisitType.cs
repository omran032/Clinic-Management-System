using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassVisitType
    {

        public int VisitTypeID { get; set; }

        public string VisitName { get; set; }

        public string VisitType_Description { get; set; }



        /// <summary>
        /// تحويل صف من DataTable إلى كائن ClassPatients مع معلومات الشخص
        /// </summary>
        public static ClassVisitType GetInfoVisitTypeInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassVisitType VisitType = new ClassVisitType()
            {
                VisitTypeID           = Convert.ToInt32(row["VisitTypeId"]),
                VisitName             = row["VisitTypeName"]?.ToString(),
                VisitType_Description = row["VisitTypeDescription"]?.ToString(),
            };

            return VisitType;
        }



    }
}

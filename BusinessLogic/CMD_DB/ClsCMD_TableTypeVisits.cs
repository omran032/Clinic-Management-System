using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TableTypeVisits
    {

        /// <summary>
        /// جلب أنواع الزيارات من جدول VisitTypes
        /// </summary>
        public static DataTable GetVisitTypes()
        {
            string query = @"SELECT VisitTypeId, TypeName FROM VisitTypes ORDER BY TypeName ASC";

            return ClassCommands.ShowData(query, null);
        }

        /// <summary>
        /// تعبئة كومبوبوكس بأنواع الزيارات
        /// </summary>
        public static void FillVisitTypesComboBox(ComboBox combo)
        {
            DataTable dt = GetVisitTypes();

            combo.DataSource = dt;
            combo.DisplayMember = "TypeName";     // النص الظاهر
            combo.ValueMember = "VisitTypeId";    // القيمة المخفية
        }


    }
}

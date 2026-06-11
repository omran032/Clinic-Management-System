using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    /// <summary>
    /// يمثل الفترة الزمنية التي سيتم تحليلها للبحث عن موعد
    /// </summary>
    public class TimeRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

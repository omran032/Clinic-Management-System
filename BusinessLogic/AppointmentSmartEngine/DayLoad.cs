using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AppointmentSmartEngine
{
    /// <summary>
    /// يمثل مستوى الازدحام ليوم واحد للطبيب.
    /// يتم استخدامه لتحديد أفضل يوم.
    /// </summary>
    public class DayLoad
    {
        public DateTime Date { get; set; }                  // تاريخ اليوم
        public int AppointmentCount { get; set; }           // عدد المواعيد
        public int TotalBusyMinutes { get; set; }           // مجموع الدقائق المشغولة
        public int FreeMinutes { get; set; }                // الدقائق الفارغة
    }

}

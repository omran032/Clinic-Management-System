using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    /// <summary>
    /// يمثل موعد واحد للطبيب ضمن الفترة الزمنية.
    /// هذا الكلاس يستخدم داخلياً لتحليل الازدحام.
    /// </summary>
    public class AppointmentInfo
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int EstimatedDurationMinutes { get; set; }
    }

}

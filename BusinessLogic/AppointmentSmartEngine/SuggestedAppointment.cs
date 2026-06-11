using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AppointmentSmartEngine
{
    /// <summary>
    /// يمثل الموعد المقترح النهائي (تاريخ + وقت).
    /// </summary>
    public class SuggestedAppointment
    {
        public DateTime SuggestedDateTime { get; set; }
        public string Reason { get; set; } // سبب الاقتراح (اختياري)
    }

}

using BusinessLogic.AppointmentSmartEngine;
using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CMD_DB
{
    public class ClsAppointmentSmartEngine
    {
        /// <summary>
        /// الفترات الزمنية التي يمكن للسكرتيرة اختيارها
        /// </summary>
        public enum TimeRangeOption
        {
            Today,          // اليوم
            Tomorrow,       // غداً
            ThisWeek,       // ضمن الأسبوع
            ThisMonth       // ضمن الشهر
        }

        /// <summary>
        /// نوع الموعد المطلوب: أقرب موعد أو أبعد موعد
        /// </summary>
        public enum SearchMode
        {
            Closest,    // أقرب موعد
            Farthest    // أبعد موعد
        }

        // ساعة بدء الدوام
        static int HoursStartWork = 10; // 10 ص
        static int HoursEndWork = 18; // 6 م



        /// <summary>
        /// إنشاء فترة زمنية بناءً على اختيار السكرتيرة (اليوم - غداً - الأسبوع - الشهر)
        /// </summary>
         static TimeRange BuildTimeRange(TimeRangeOption option)
        {
            DateTime today = DateTime.Today;

            switch (option)
            {
                case TimeRangeOption.Today:
                    return new TimeRange
                    {
                        StartDate = today,
                        EndDate = today
                    };

                case TimeRangeOption.Tomorrow:
                    return new TimeRange
                    {
                        StartDate = today.AddDays(1),
                        EndDate = today.AddDays(1)
                    };

                case TimeRangeOption.ThisWeek:
                    return new TimeRange
                    {
                        StartDate = today,
                        EndDate = today.AddDays(7)
                    };

                case TimeRangeOption.ThisMonth:
                    return new TimeRange
                    {
                        StartDate = today,
                        EndDate = today.AddDays(30)
                    };

                default:
                    throw new Exception("خيار الفترة الزمنية غير معروف.");
            }
        }

        /// <summary>
        /// جلب جميع مواعيد الطبيب ضمن الفترة الزمنية المحددة.
        /// يتم إرجاع المواعيد مرتبة حسب التاريخ والوقت.
        /// </summary>
         static List<AppointmentInfo> GetDoctorAppointmentsInRange( int doctorId, TimeRange range)
        {

            /*  شرح هذه الميثود:

            //تجلب كل مواعيد الطبيب

            //ضمن الفترة الزمنية التي اختارتها السكرتيرة

            //مرتبة حسب الوقت

            //مع مدة كل موعد

             وتعيدها كـ List جاهزة للتحليل
            */

            string query = @"
        SELECT 
            AppointmentId,
            AppointmentDate,
            EstimatedDurationMinutes
        FROM Appointments
        WHERE DoctorId = @DoctorId
        AND AppointmentDate >= @StartDate
        AND AppointmentDate <= @EndDate
        ORDER BY AppointmentDate ASC ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId },
                { "@StartDate", range.StartDate },
                { "@EndDate", range.EndDate.AddDays(1).AddSeconds(-1) } 
                // لضمان شمول اليوم كاملاً
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            List<AppointmentInfo> list = new List<AppointmentInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AppointmentInfo
                {
                    AppointmentId = Convert.ToInt32(row["AppointmentId"]),
                    AppointmentDate = Convert.ToDateTime(row["AppointmentDate"]),
                    EstimatedDurationMinutes = row["EstimatedDurationMinutes"] == DBNull.Value
                        ? 15 // قيمة افتراضية إذا لم يتم تحديد مدة
                        : Convert.ToInt32(row["EstimatedDurationMinutes"])
                });
            }

            return list;
        }




        /// <summary>
        /// حساب ازدحام يوم واحد للطبيب.
        /// </summary>
         static DayLoad CalculateDayLoad(DateTime day, List<AppointmentInfo> appointments,  int averageDuration)
        {
            // جلب مواعيد هذا اليوم فقط
            var todaysAppointments = appointments
                .Where(a => a.AppointmentDate.Date == day.Date)
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            int totalBusy = todaysAppointments.Sum(a => a.EstimatedDurationMinutes);

            // نفترض أن الطبيب يعمل 8 ساعات يومياً (480 دقيقة)
            int workingMinutes = 480;

            return new DayLoad
            {
                Date = day,
                AppointmentCount = todaysAppointments.Count,
                TotalBusyMinutes = totalBusy,
                FreeMinutes = workingMinutes - totalBusy
            };
        }





        /// <summary>
        /// تحليل ازدحام جميع الأيام ضمن الفترة الزمنية.
        /// </summary>
         static List<DayLoad> AnalyzeDaysLoad(TimeRange range, List<AppointmentInfo> appointments, int averageDuration)
        {
            List<DayLoad> days = new List<DayLoad>();

            for (DateTime day = range.StartDate; day <= range.EndDate; day = day.AddDays(1))
            {
                days.Add(CalculateDayLoad(day, appointments, averageDuration));
            }

            return days;
        }


        /// <summary>
        /// اختيار أفضل يوم حسب نوع البحث (أقرب أو أبعد).
        /// </summary>
         static DayLoad PickBestDay(List<DayLoad> days, SearchMode mode)
        {
            // استبعاد الأيام التي ليس فيها أي دقيقة فارغة
            var validDays = days.Where(d => d.FreeMinutes > 0).ToList();

            if (validDays.Count == 0)
                return null; // لا يوجد يوم مناسب

            if (mode == SearchMode.Closest)
            {
                // أقرب يوم فيه وقت فارغ
                return validDays.OrderBy(d => d.Date).First();
            }
            else
            {
                // أبعد يوم فيه وقت فارغ
                return validDays.OrderByDescending(d => d.Date).First();
            }
        }






        /// <summary>
        /// جلب مواعيد يوم واحد فقط.
        /// </summary>
         static List<AppointmentInfo> GetAppointmentsForDay(
            DateTime day, List<AppointmentInfo> allAppointments)
        {
            return allAppointments
                .Where(a => a.AppointmentDate.Date == day.Date)
                .OrderBy(a => a.AppointmentDate)
                .ToList();
        }



        /// <summary>
        /// البحث عن فجوة زمنية داخل اليوم تكفي مدة الموعد الجديد.
        /// </summary>
        public static DateTime? FindAvailableGap(
     DateTime day,
     List<AppointmentInfo> todaysAppointments,
     int durationMinutes,
     SearchMode mode)
        {
            // دوام الطبيب
            DateTime workStart = day.Date.AddHours(HoursStartWork).AddMinutes(30); // 10:30 AM
            DateTime workEnd = day.Date.AddHours(HoursEndWork); // 6:00 PM

            DateTime now = DateTime.Now;

            // فقط إذا اليوم هو اليوم الحالي → لا نقترح وقت مضى
            if (day.Date == DateTime.Today)
            {
                if (now > workStart)
                    workStart = now.AddMinutes(5);
            }

            // إذا لا يوجد أي موعد
            if (todaysAppointments.Count == 0)
            {
                if (workStart.AddMinutes(durationMinutes) <= workEnd)
                    return workStart;

                return null;
            }

            // 1) فجوة قبل أول موعد
            var first = todaysAppointments.First();

            DateTime firstGapStart = workStart;

            // إذا اليوم هو اليوم الحالي → لا نقترح وقت مضى
            if (day.Date == DateTime.Today && firstGapStart < now)
                firstGapStart = now.AddMinutes(5);

            if (firstGapStart.AddMinutes(durationMinutes) <= first.AppointmentDate)
                return firstGapStart;

            // 2) فجوات بين المواعيد
            for (int i = 0; i < todaysAppointments.Count - 1; i++)
            {
                var current = todaysAppointments[i];
                var next = todaysAppointments[i + 1];

                DateTime gapStart = current.AppointmentDate.AddMinutes(current.EstimatedDurationMinutes);
                DateTime gapEnd = next.AppointmentDate;

                if (day.Date == DateTime.Today && gapStart < now)
                    gapStart = now.AddMinutes(5);

                if (gapStart.AddMinutes(durationMinutes) <= gapEnd)
                    return gapStart;
            }

            // 3) فجوة بعد آخر موعد
            var last = todaysAppointments.Last();
            DateTime lastEnd = last.AppointmentDate.AddMinutes(last.EstimatedDurationMinutes);

            if (day.Date == DateTime.Today && lastEnd < now)
                lastEnd = now.AddMinutes(5);

            if (lastEnd.AddMinutes(durationMinutes) <= workEnd)
                return lastEnd;

            return null;
        }





        /// <summary>
        /// الميثود النهائية التي تجمع كل خطوات الذكاء.
        /// ترجع أفضل موعد أو رسالة عدم توفر موعد ضمن الفترة (يوم، أسبوع، شهر).
        /// </summary>
        public static SuggestedAppointment SuggestAppointment(
            int doctorId,
            TimeRangeOption rangeOption,
            SearchMode mode,
            int requiredDuration)
        {
            // 1) بناء الفترة الزمنية
            TimeRange range = BuildTimeRange(rangeOption);

            // 2) جلب مواعيد الطبيب ضمن الفترة
            var appointments = GetDoctorAppointmentsInRange(doctorId, range);

            // 3) حساب متوسط مدة الزيارة للطبيب (قيمة افتراضية 20 دقيقة)
            int averageDuration = appointments.Count == 0
                ? 20
                : (int)appointments.Average(a => a.EstimatedDurationMinutes);

            // 4) تحليل ازدحام الأيام
            var daysLoad = AnalyzeDaysLoad(range, appointments, averageDuration);

            // 5) ترتيب الأيام حسب نوع البحث (أقرب / أبعد)
            List<DayLoad> orderedDays;
            if (mode == SearchMode.Closest)
                orderedDays = daysLoad.OrderBy(d => d.Date).ToList();
            else
                orderedDays = daysLoad.OrderByDescending(d => d.Date).ToList();

            // 6) المرور على كل يوم ضمن الفترة والبحث عن أول يوم فيه فجوة مناسبة
            foreach (var dayLoad in orderedDays)
            {
                // جلب مواعيد هذا اليوم
                var todaysAppointments = appointments
                    .Where(a => a.AppointmentDate.Date == dayLoad.Date.Date)
                    .OrderBy(a => a.AppointmentDate)
                    .ToList();

                // البحث عن فجوة في هذا اليوم
                DateTime? gap = FindAvailableGap(
                    dayLoad.Date,
                    todaysAppointments,
                    requiredDuration,
                    mode
                );

                if (gap != null)
                {
                    // وجدنا أول يوم + ساعة مناسبة → نرجع فوراً
                    return new SuggestedAppointment
                    {
                        SuggestedDateTime = gap.Value,
                        Reason = "تم اختيار هذا الموعد لأنه أول وقت متاح مناسب ضمن الفترة المحددة."
                    };
                }
            }

            // 7) إذا لففنا على كل الأيام وما لقينا ولا فجوة
            return new SuggestedAppointment
            {
                SuggestedDateTime = DateTime.MinValue,
                Reason = "لا يوجد أي موعد متاح ضمن الفترة المحددة وفقاً لدوام الطبيب والمواعيد الحالية."
            };
        }



    }



}

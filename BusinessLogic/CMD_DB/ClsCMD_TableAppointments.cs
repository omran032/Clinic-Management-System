using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static BusinessLogic.CMD_DB.ClsCMD_TableVisits;

namespace BusinessLogic.CMD_DB
{
    public  class ClsCMD_TableAppointments
    {

        /// <summary>
        ///  عرض عدد المواعيد حسب الفترة  اليوم – الأسبوع – الشهر 
        /// </summary>
        /// <param name="range">تحديد الفترة</param>
        /// <returns>عدد المواعيد</returns>
        public static int GetAppointmentsCount(Range range)
        {
            string query = "";

            switch (range)
            {
                case Range.Today:
                    query = @"SELECT COUNT(*) 
                      FROM Appointments 
                      WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    query = @"SELECT COUNT(*) 
                      FROM Appointments 
                      WHERE DATEPART(WEEK, AppointmentDate) = DATEPART(WEEK, GETDATE())
                      AND DATEPART(YEAR, AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    query = @"SELECT COUNT(*) 
                      FROM Appointments 
                      WHERE MONTH(AppointmentDate) = MONTH(GETDATE())
                      AND YEAR(AppointmentDate) = YEAR(GETDATE())";
                    break;
            }

            // تنفيذ الاستعلام عبر ShowValue
            return Convert.ToInt32(ClassCommands.ShowValue(query));
        }



        /// <summary>
        ///  ارجاع عدد غيابات المرضى حسب الفترة  اليوم – الأسبوع – الشهر
        /// </summary>
        /// <param name="range">الفترة</param>
        /// <param name="Status">  نص حالة الغياب</param>
        /// <returns></returns>
        public static int GetAbsencesCount(Range range , string Status = "Absent")
        {
            string query = "";

            switch (range)
            {
                case Range.Today:
                    query = $@"SELECT COUNT(*) 
                      FROM Appointments
                      WHERE Status = '{Status}'
                      AND CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    query = $@"SELECT COUNT(*) 
                      FROM Appointments
                      WHERE Status = '{Status}'
                      AND DATEPART(WEEK, AppointmentDate) = DATEPART(WEEK, GETDATE())
                      AND DATEPART(YEAR, AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    query = $@"SELECT COUNT(*) 
                      FROM Appointments
                      WHERE Status = '{Status}'
                      AND MONTH(AppointmentDate) = MONTH(GETDATE())
                      AND YEAR(AppointmentDate) = YEAR(GETDATE())";
                    break;
            }

            return Convert.ToInt32(ClassCommands.ShowValue(query));
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////


        #region   أوامر المخططات البيانية

        /// <summary>
        /// يعرض عدد المواعيد خلال آخر 7 أيام (يوم بيوم)
        /// </summary>
        public static void LoadWeeklyAppointmentsDayByDay(Chart MyChart)
        {
            string Title = "Weekly Appointments (Day by Day)";
            string SeriesName = "Appointments";

            string Query = @"
        SELECT 
            DATENAME(WEEKDAY, AppointmentDate) AS DayName,
            DATEPART(WEEKDAY, AppointmentDate) AS DayOrder,
            COUNT(*) AS Total
        FROM Appointments
        WHERE AppointmentDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
        GROUP BY 
            DATENAME(WEEKDAY, AppointmentDate),
            DATEPART(WEEKDAY, AppointmentDate)
        ORDER BY DayOrder
    ";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "DayName", "Total");
        }


        /// <summary>
        /// يعرض عدد المواعيد خلال آخر 6 أشهر (شهر بشهر)
        /// </summary>
        public static void LoadPreviousMonthsAppointments(Chart MyChart)
        {
            string Title = "Appointments in Last 6 Months";
            string SeriesName = "Months";

            string Query = @"
        SELECT 
            FORMAT(AppointmentDate, 'yyyy-MM') AS MonthName,
            SUM(1) AS Total
        FROM Appointments
        WHERE AppointmentDate >= DATEADD(MONTH, -5, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
        GROUP BY FORMAT(AppointmentDate, 'yyyy-MM')
        ORDER BY MonthName
    ";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "MonthName", "Total");
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public enum AppointmentRange
        {
            Today,
            ThisWeek,
            ThisMonth
        }

        /// <summary>
        /// جلب عدد المواعيد المتبقية لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetRemainingAppointmentsByDoctor(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(AppointmentDate) = MONTH(GETDATE())
                AND YEAR(AppointmentDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT COUNT(*) 
                    FROM Appointments
                        WHERE DoctorId = @DoctorId
                        AND AppointmentDate > GETDATE()   -- الموعد لم يأتِ بعد
                        AND Status NOT IN ('Completed', 'Canceled') -- ليس منتهي أو ملغى
                        AND {dateFilter};";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }


        /// <summary>
        /// جلب تفاصيل المواعيد المتبقية لطبيب معيّن مع تفاصيل المريض.
        /// </summary>
        public static DataTable GetRemainingAppointmentsWithPatientDetails(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, a.AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, a.AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(a.AppointmentDate) = MONTH(GETDATE())
                AND YEAR(a.AppointmentDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT 
                   -- تفاصيل الموعد
            a.AppointmentId,
            a.AppointmentDate,
            a.Status,
            a.Notes AS AppointmentNotes,

                   -- نوع الزيارة
            vt.VisitTypeId,
            vt.TypeName AS VisitTypeName,
            vt.Description AS VisitTypeDescription,

                    -- تفاصيل الخص
            p.PersonId,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt,

                      -- تفاصيل المريض من Patients
            pa.PatientId as [ID Patiient],
            pa.MedicalNotes,
            pa.ChronicDiseases,
            pa.Allergies,
            pa.FirstVisitDate,
            pa.ComplianceScore,
            pa.Notes 


FROM Appointments a
INNER JOIN Persons p ON a.PersonId = p.PersonId
LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
INNER JOIN VisitTypes vt ON a.VisitTypeId = vt.VisitTypeId


        WHERE a.DoctorId = @DoctorId
        AND a.AppointmentDate > GETDATE()
        AND a.Status NOT IN ('Completed', 'Canceled')
        AND {dateFilter}

        ORDER BY a.AppointmentDate ASC; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return ClassCommands.ShowData(query, parameters);
        }


                        // ----------- 

        /// <summary>
        /// جلب عدد المواعيد المنتهية لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetCompletedAppointmentsCount(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(AppointmentDate) = MONTH(GETDATE())
                AND YEAR(AppointmentDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT COUNT(*)
                    FROM Appointments
                        WHERE DoctorId = @DoctorId
                AND Status = 'Completed'
                AND {dateFilter}; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }

        /// <summary>
        /// جلب تفاصيل المواعيد المنتهية لطبيب معيّن مع تفاصيل المريض من Persons + Patients.
        /// </summary>
        public static DataTable GetCompletedAppointmentsFullDetails(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, a.AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, a.AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(a.AppointmentDate) = MONTH(GETDATE())
                AND YEAR(a.AppointmentDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT 
            -- تفاصيل الموعد
            a.AppointmentId,
            a.AppointmentDate,
            a.Status,
            a.Notes AS AppointmentNotes,

            -- نوع الزيارة
            vt.VisitTypeId,
            vt.TypeName AS VisitTypeName,
            vt.Description AS VisitTypeDescription,

            -- تفاصيل المريض من Persons
            p.PersonId,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt,

            -- تفاصيل المريض من Patients
            pa.PatientId ,
            pa.MedicalNotes,
            pa.FirstVisitDate,
            pa.ChronicDiseases,
            pa.Allergies,
            pa.Notes ,
            pa.ComplianceScore

        FROM Appointments a
        INNER JOIN Persons p ON a.PersonId = p.PersonId
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        INNER JOIN VisitTypes vt ON a.VisitTypeId = vt.VisitTypeId

        WHERE a.DoctorId = @DoctorId
        AND a.Status = 'Completed'
        AND {dateFilter}

        ORDER BY a.AppointmentDate DESC; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return ClassCommands.ShowData(query, parameters);
        }


                        // ------------


        /// <summary>
        /// جلب عدد المواعيد التي لم يحضرها المريض لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetAbsentAppointmentsCount(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(AppointmentDate) = MONTH(GETDATE())
                AND YEAR(AppointmentDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorId = @DoctorId
        AND Status = 'Absent'
        AND {dateFilter}; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }


        /// <summary>
        /// جلب تفاصيل المواعيد التي لم يحضرها المريض لطبيب معيّن
        /// مع تفاصيل المريض من Persons + Patients.
        /// </summary>
        public static DataTable GetAbsentAppointmentsFullDetails(int doctorId, AppointmentRange range)
        {
            string dateFilter = "";

            switch (range)
            {
                case AppointmentRange.Today:
                    dateFilter = "CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentRange.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, a.AppointmentDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, a.AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case AppointmentRange.ThisMonth:
                    dateFilter = @"
                MONTH(a.AppointmentDate) = MONTH(GETDATE())
                AND YEAR(a.AppointmentDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT 
                               -- تفاصيل الموعد
            a.AppointmentId,
            a.AppointmentDate,
            a.Status,
            a.Notes AS AppointmentNotes,

                               -- نوع الزيارة
            vt.VisitTypeId,
            vt.TypeName AS VisitTypeName,
            vt.Description AS VisitTypeDescription,

                               -- تفاصيل المريض من Persons
            p.PersonId,
            p.FirstName,
            p.LastName,
            p.Gender,
            p.BirthDate,
            p.Phone,
            p.Address,
            p.CreatedAt,
            p.UpdatedAt,

                                 -- تفاصيل المريض من Patients
            pa.PatientId as [ID Patiient],
            pa.MedicalNotes,
            pa.FirstVisitDate,
            pa.ChronicDiseases,
            pa.Allergies,
            pa.ComplianceScore,
            pa.Notes  

        FROM Appointments a
        INNER JOIN Persons p ON a.PersonId = p.PersonId
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        INNER JOIN VisitTypes vt ON a.VisitTypeId = vt.VisitTypeId

        WHERE a.DoctorId = @DoctorId
        AND a.Status = 'Absent'
        AND {dateFilter}

        ORDER BY a.AppointmentDate DESC; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return ClassCommands.ShowData(query, parameters);
        }




    }
}

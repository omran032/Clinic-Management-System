using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
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

    }
}

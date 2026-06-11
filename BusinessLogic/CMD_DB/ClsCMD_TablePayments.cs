using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static BusinessLogic.CMD_DB.ClsCMD_TableVisits;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TablePayments
    {

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region   أوامر المخططات البيانية

        /// <summary>
        /// يعرض أرباح الأسبوع يوم بيوم (آخر 7 أيام)
        /// </summary>
        public static void LoadWeeklyRevenueDayByDay(Chart MyChart)
        {
            string Title = "Weekly Revenue (Day by Day)";
            string SeriesName = "DailyRevenue";

            string Query = @"
        SELECT 
            DATENAME(WEEKDAY, PaymentDate) AS DayName,
            DATEPART(WEEKDAY, PaymentDate) AS DayOrder,
            SUM(TotalAmount) AS Total
        FROM Payments
        WHERE PaymentDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
        GROUP BY 
            DATENAME(WEEKDAY, PaymentDate),
            DATEPART(WEEKDAY, PaymentDate)
        ORDER BY DayOrder";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "DayName", "Total");
        }

        /// <summary>
        /// يعرض أرباح الأسابيع ضمن الشهر الحالي (Week 1, Week 2...)
        /// </summary>
        public static void LoadWeeklyInMonthRevenue(Chart MyChart)
        {
            string Title = "Weekly Revenue in Current Month";
            string SeriesName = "Weeks";

            string Query = @"
        SELECT 
            DATEPART(WEEK, PaymentDate) AS WeekNumber,
            SUM(TotalAmount) AS Total
        FROM Payments
        WHERE MONTH(PaymentDate) = MONTH(GETDATE())
          AND YEAR(PaymentDate) = YEAR(GETDATE())
        GROUP BY DATEPART(WEEK, PaymentDate)
        ORDER BY WeekNumber
    ";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "WeekNumber", "Total");
        }


        /// <summary>
        /// يعرض أرباح الأشهر ضمن السنة الحالية (Jan, Feb, Mar...)
        /// </summary>
        public static void LoadMonthsInYearRevenue(Chart MyChart)
        {
            string Title = "Monthly Revenue in Current Year";
            string SeriesName = "Months";

            string Query = @"
        SELECT 
            MONTH(PaymentDate) AS MonthNumber,
            SUM(TotalAmount) AS Total
        FROM Payments
        WHERE YEAR(PaymentDate) = YEAR(GETDATE())
        GROUP BY MONTH(PaymentDate)
        ORDER BY MonthNumber
    ";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "MonthNumber", "Total");
        }


        /// <summary>
        /// يعرض أرباح آخر 3 سنوات + السنة الحالية
        /// </summary>
        public static void LoadYearsRevenue(Chart MyChart)
        {
            string Title = "Revenue of Last 4 Years";
            string SeriesName = "Years";

            string Query = @"
        SELECT 
            YEAR(PaymentDate) AS YearNumber,
            SUM(TotalAmount) AS Total
        FROM Payments
        WHERE YEAR(PaymentDate) >= YEAR(GETDATE()) - 3
        GROUP BY YEAR(PaymentDate)
        ORDER BY YearNumber
    ";

            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "YearNumber", "Total");
        }


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        /// تحسب عدد المرضى الذين انتهى موعدهم ولم يقوموا بالدفع،
        /// وذلك حسب المدى الزمني المطلوب(اليوم، هذا الأسبوع، هذا الشهر).
        /// </summary>
        public static  int GetUnpaidFinishedAppointments(Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = "DATEPART(WEEK, A.AppointmentDate) = DATEPART(WEEK, GETDATE()) " +
                                 "AND DATEPART(YEAR, A.AppointmentDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = "MONTH(A.AppointmentDate) = MONTH(GETDATE()) " +
                                 "AND YEAR(A.AppointmentDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT COUNT(*)
        FROM Appointments A
        LEFT JOIN Payments P ON A.AppointmentId = P.AppointmentId
        WHERE 
            {dateFilter}
            AND A.AppointmentDate < DATEADD(MINUTE, -30, GETDATE())   -- مرّ عليه وقت
            AND P.PaymentId IS NULL                                   -- ما دفع
            AND A.Status = 'Completed'"; // حضر الموعد

            return (int)ClassCommands.ShowValue(query);

        }




    }
}

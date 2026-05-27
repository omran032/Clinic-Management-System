using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_TableVisits
    {
        // الفترات
        public enum  Range
        {
            Today,
            ThisWeek,
            ThisMonth
        }

        /// <summary>
        ///  عرض زيارات اليوم _ الاسبوع _ الشهر
        /// </summary>
        /// <param name="range">تحديد الفترة</param>
        /// <returns></returns>
        public static int GetVisitsCount(Range range)
        {
            string query = "";

            switch (range)
            {
                case Range.Today:
                    query = @"SELECT COUNT(*) 
                      FROM Visits 
                      WHERE CAST(VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    query = @"SELECT COUNT(*) 
                      FROM Visits 
                      WHERE DATEPART(WEEK, VisitDate) = DATEPART(WEEK, GETDATE())
                      AND DATEPART(YEAR, VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    query = @"SELECT COUNT(*) 
                      FROM Visits 
                      WHERE MONTH(VisitDate) = MONTH(GETDATE())
                      AND YEAR(VisitDate) = YEAR(GETDATE())";
                    break;
            }


            return (int)ClassCommands.ShowValue(query);

        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////


        #region   أوامر المخططات البيانية

        /// <summary>
        /// عرض زيارات الاسبوع ضمن المخطط
        /// </summary>
        /// <param name="MyChart"></param>
        public static void LoadWeeklyVisitsChart(Chart MyChart)
        {
            string Title = "Weekly Patient Visits (Last 7 Days)";
            string SeriesName = "Visits";


            string Query = @"
        SELECT DATENAME(WEEKDAY, VisitDate) AS DayName,
               COUNT(*) AS Total
        FROM Visits
        WHERE VisitDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
        GROUP BY DATENAME(WEEKDAY, VisitDate), DATEPART(WEEKDAY, VisitDate)
        ORDER BY DATEPART(WEEKDAY, VisitDate)";


            ClsCreateChartColumn.LoadDadaInChart(MyChart, Query, Title, SeriesName, "DayName", "Total");
        }




        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////



    }
}

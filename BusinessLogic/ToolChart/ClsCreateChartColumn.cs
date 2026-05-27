using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BusinessLogic.ToolChart
{
    public class ClsCreateChartColumn
    {



        /// <summary>
        /// عرض البيانات بمخطط بيانات عمودي
        /// </summary>
        /// <param name="MyChart">العنصر</param>
        /// <param name="Query">أمر لجلب البيانات</param>
        /// <param name="Title">عنوان المخطط</param>
        /// <param name="SeriesName">اسم السلسلة</param>
        /// <param name="ColumnName_X"> يجب ان يكون العمود نصي X اسم العمود على محور   </param>
        /// <param name="ColumnName_Y"> يجب ان يكون العمود رقمي Y اسم العمود على محور</param>
        public static void LoadDadaInChart(Chart MyChart ,string Query , string Title ,string SeriesName , string ColumnName_X , string ColumnName_Y)
        {
            // 1) تجهيز منطقة الرسم
            MyChart.ChartAreas.Clear();
            MyChart.ChartAreas.Add("MainArea");

            // 2) تجهيز السلسلة
            MyChart.Series.Clear();
            Series series = new Series(SeriesName);
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.RoyalBlue;
            series.IsValueShownAsLabel = true;
            MyChart.Series.Add(series);

            // 3) عنوان
            MyChart.Titles.Clear();
            MyChart.Titles.Add(Title);
            MyChart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            DataTable dt = ClassCommands.ShowData(Query);

            // 5) تعبئة المخطط
            foreach (DataRow row in dt.Rows)
            {
                string dayName = row[ColumnName_X].ToString();
                int total = Convert.ToInt32(row[ColumnName_Y]);

                MyChart.Series[SeriesName].Points.AddXY(dayName, total);
            }
        }





    }
}

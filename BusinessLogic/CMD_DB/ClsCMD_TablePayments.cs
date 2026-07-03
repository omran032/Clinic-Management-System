using BusinessLogic.InfoTable;
using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /// إرجاع رقم الدفعة المرتبطة بالزيارة إن وجدت، وإلا ترجع null
        /// </summary>
        public static int? GetPaymentIdByVisit(int visitId)
        {
            string query = @"
        SELECT PaymentId 
        FROM Payments
        WHERE VisitId = @VisitId  ";

            var parameters = new Dictionary<string, object>
            {
                { "@VisitId", visitId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null; // لا يوجد دفعة

            return Convert.ToInt32(dt.Rows[0]["PaymentId"]);
        }



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



        /// <summary>
        /// إضافة دفعة جديدة في جدول الدفعات وإرجاع رقم الدفعة الجديدة
        /// </summary>
        public static int AddPayment( int personId, int? visitId, int? appointmentId, decimal amount,decimal discount, string paymentMethod, string notes)
        {
            string query = @"
        INSERT INTO Payments 
        (PersonId, VisitId, AppointmentId, Amount, Discount, PaymentMethod, PaymentDate, CreatedBy, Notes)
        VALUES 
        (@PersonId, @VisitId, @AppointmentId, @Amount, @Discount, @PaymentMethod, GETDATE(), @CreatedBy, @Notes);

        SELECT SCOPE_IDENTITY();
    ";

            var parameters = new Dictionary<string, object>
    {
        { "@PersonId", personId },
        { "@VisitId", visitId ?? (object)DBNull.Value },
        { "@AppointmentId", appointmentId ?? (object)DBNull.Value },
        { "@Amount", amount },
        { "@Discount", discount },
        { "@PaymentMethod", paymentMethod },
        { "@CreatedBy", ClassUser.UserInfo.UserID },   // المستخدم الذي سجل الدفع
        { "@Notes", notes }
    };

            // إرجاع رقم الدفعة الجديدة
            object result = ClassCommands.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }



        /// <summary>
        /// تعديل دفعة موجودة في جدول الدفعات
        /// </summary>
        public static bool UpdatePayment(int paymentId, decimal amount, decimal discount, string paymentMethod,  string notes)
        {
            string query = @"
        UPDATE Payments
        SET 
            Amount = @Amount,
            Discount = @Discount,
            PaymentMethod = @PaymentMethod,
            Notes = @Notes
        WHERE PaymentId = @PaymentId ";

            var parameters = new Dictionary<string, object>
            {
                { "@PaymentId", paymentId },
                { "@Amount", amount },
                { "@Discount", discount },
                { "@PaymentMethod", paymentMethod },
                { "@Notes", notes }
            };

            int rows = ClassCommands.ExecuteScalar(query, parameters);

            return rows > 0; // إذا تم تعديل صف واحد على الأقل → العملية نجحت
        }





        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////


        public enum PaymentFilterType
        {
            All,
            DateRange,
            Doctor,
            PatientPhone,
            PatientName
        }

        /// <summary>
        /// عرض المدفوعات وفلترتها
        /// </summary>
        /// <summary>
        /// عرض المدفوعات وفلترتها
        /// </summary>
        public static DataTable GetPaymentsFelter( PaymentFilterType filterType, DateTime? fromDate = null, DateTime? toDate = null,string doctorName = null, string patientPhone = null, string patientName = null)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            p.PaymentId,
            p.VisitId,
            (per.FirstName + ' ' + per.LastName) AS PatientName,
            (dper.FirstName + ' ' + dper.LastName) AS DoctorName,
            vt.TypeName AS VisitType,
            p.Amount,
            p.Discount,
            p.PaymentMethod AS TypePayment
        FROM Payments p
        LEFT JOIN Persons per ON p.PersonId = per.PersonId
        LEFT JOIN Visits v ON p.VisitId = v.VisitId
        LEFT JOIN Doctors d ON v.DoctorId = d.DoctorId
        LEFT JOIN Persons dper ON d.PersonId = dper.PersonId
        LEFT JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId
        WHERE 1 = 1
    ";

            // إضافة شروط الفلترة حسب نوع الفلتر
            switch (filterType)
            {
                case PaymentFilterType.DateRange:
                    query += " AND p.PaymentDate BETWEEN @FromDate AND @ToDate ";
                    break;

                case PaymentFilterType.Doctor:
                    query += " AND (dper.FirstName + ' ' + dper.LastName) LIKE '%' + @DoctorName + '%' ";
                    break;

                case PaymentFilterType.PatientPhone:
                    query += " AND per.Phone LIKE '%' + @PatientPhone + '%' ";
                    break;

                case PaymentFilterType.PatientName:
                    query += " AND (per.FirstName + ' ' + per.LastName) LIKE '%' + @PatientName + '%' ";
                    break;

                case PaymentFilterType.All:
                default:
                    break;
            }

            query += " ORDER BY p.PaymentDate DESC ";

            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // إضافة الباراميترات حسب الحاجة
                if (filterType == PaymentFilterType.DateRange)
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                }

                if (filterType == PaymentFilterType.Doctor)
                {
                    cmd.Parameters.AddWithValue("@DoctorName", doctorName ?? "");
                }

                if (filterType == PaymentFilterType.PatientPhone)
                {
                    cmd.Parameters.AddWithValue("@PatientPhone", patientPhone ?? "");
                }

                if (filterType == PaymentFilterType.PatientName)
                {
                    cmd.Parameters.AddWithValue("@PatientName", patientName ?? "");
                }

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }




        public enum RevenueType
        {
            Today,
            ThisWeek,
            ThisMonth,
            ThisYear
        }

        /// <summary>
        /// إرجاع إيرادات العيادة حسب الفترة المطلوبة
        /// </summary>
        public static double GetClinicRevenue(RevenueType type)
        {
            string query = @"
        SELECT SUM(Amount) AS TotalRevenue
        FROM Payments
        WHERE 1 = 1
    ";

            var parameters = new Dictionary<string, object>();

            switch (type)
            {
                case RevenueType.Today:
                    query += " AND CAST(PaymentDate AS DATE) = CAST(GETDATE() AS DATE) ";
                    break;

                case RevenueType.ThisWeek:
                    query += @"
                AND PaymentDate >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                AND PaymentDate <  DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
            ";
                    break;

                case RevenueType.ThisMonth:
                    query += @"
                AND MONTH(PaymentDate) = MONTH(GETDATE())
                AND YEAR(PaymentDate) = YEAR(GETDATE())
            ";
                    break;

                case RevenueType.ThisYear:
                    query += " AND YEAR(PaymentDate) = YEAR(GETDATE()) ";
                    break;
            }

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0 || dt.Rows[0]["TotalRevenue"] == DBNull.Value)
                return 0;

            return Convert.ToDouble(dt.Rows[0]["TotalRevenue"]);
        }





        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// حذف دفعة من جدول Payments وإرجاع رسالة بالنتيجة
        /// </summary>
        public static string DeletePayment(int paymentId)
        {
            try
            {
                string query = @" DELETE FROM Payments
                         WHERE PaymentId = @PaymentId  ";

                var parameters = new Dictionary<string, object>
                {
                    { "@PaymentId", paymentId }
                };

                int rows = ClassCommands.ExecuteScalar(query, parameters);

                if (rows > 0)
                {
                    ClassLogs.AddLog(ClassUser.UserInfo.UserID, "DeletePayment", "Payments", paymentId , "حذف دفعة");   // تسجيل العمل في Log
                    MessageBox.Show("تم حذف الدفعة بنجاح" , "تم الحذف" ,MessageBoxButtons.OK , MessageBoxIcon.Information);
                    return "تم حذف الدفعة بنجاح";
                }

                    MessageBox.Show("لم يتم العثور على الدفعة المطلوبة", "فشل عملية الحذف" ,MessageBoxButtons.OK , MessageBoxIcon.Error);
                return "لم يتم العثور على الدفعة المطلوبة";
            }
            catch
            {
                return "حدث خطأ أثناء حذف الدفعة";
            }
        }



    }
}

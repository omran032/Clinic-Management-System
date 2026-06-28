using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static BusinessLogic.CMD_DB.ClsCMD_TableAppointments;

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

        /// <summary>
        /// جلب عدد الزيارات من نوع طوارئ لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetEmergencyVisitsCount(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = @"
                MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }


            string query = $@" SELECT COUNT(*)
                FROM Visits v
                INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId
                WHERE v.DoctorId = @DoctorId
                AND vt.TypeName = N'Emergency' -- طوارئ
                AND {dateFilter};";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }



        /// <summary>
        /// جلب تفاصيل الزيارات الطارئة لطبيب معيّن
        /// مع تفاصيل المريض من Persons + Patients.
        /// </summary>
        public static DataTable GetEmergencyVisitsFullDetails(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = @"
                MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT 
                        -- تفاصيل الزيارة
            v.VisitId,
            v.VisitDate,
            v.Notes AS VisitNotes,

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

        FROM Visits v
        INNER JOIN Persons p ON v.PersonId = p.PersonId
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId

        WHERE v.DoctorId = @DoctorId
                                       --  AND v.VisitTypeID = 3 -- طوارئ
        AND vt.TypeName = N'Emergency' -- طوارئ
        AND {dateFilter}

        ORDER BY v.VisitDate DESC; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return ClassCommands.ShowData(query, parameters);
        }


                        // ---------------

        /// <summary>
        /// جلب عدد الزيارات من نوع Follow-up لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetFollowUpVisitsCount(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = @"
                MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT COUNT(*)
        FROM Visits v
        INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId
        WHERE v.DoctorId = @DoctorId
        AND vt.TypeName = N'Follow-up'
        AND {dateFilter};";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }


        /// <summary>
        /// جلب تفاصيل زيارات Follow-up لطبيب معيّن
        /// مع تفاصيل المريض من Persons + Patients.
        /// </summary>
        public static DataTable GetFollowUpVisitsFullDetails(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = @"
                MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT 
            -- تفاصيل الزيارة
            v.VisitId,
            v.VisitDate,
            v.Notes AS VisitNotes,

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

        FROM Visits v
        INNER JOIN Persons p ON v.PersonId = p.PersonId
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId

        WHERE v.DoctorId = @DoctorId
        AND vt.TypeName = N'Follow-up'
        AND {dateFilter}

        ORDER BY v.VisitDate DESC;
    ";

            var parameters = new Dictionary<string, object>()
    {
        { "@DoctorId", doctorId }
    };

            return ClassCommands.ShowData(query, parameters);
        }


        // ---------------

        /// <summary>
        /// جلب عدد الزيارات من نوع Consultation لطبيب معيّن حسب الفترة الزمنية.
        /// </summary>
        public static int GetConsultationVisitsCount(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @"
                DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                    break;

                case Range.ThisMonth:
                    dateFilter = @"
                MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT COUNT(*)
        FROM Visits v
        INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId
        WHERE v.DoctorId = @DoctorId
        AND vt.TypeName = N'Consultation' -- زيارة استشارية
        AND {dateFilter}; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
        }


        /// <summary>
        /// جلب تفاصيل زيارات Consultation لطبيب معيّن
        /// مع تفاصيل المريض من Persons + Patients.
        /// </summary>
        public static DataTable GetConsultationVisitsFullDetails(int doctorId, Range range)
        {
            string dateFilter = "";

            switch (range)
            {
                case Range.Today:
                    dateFilter = "CAST(v.VisitDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case Range.ThisWeek:
                    dateFilter = @" DATEPART(WEEK, v.VisitDate) = DATEPART(WEEK, GETDATE())
                AND DATEPART(YEAR, v.VisitDate) = DATEPART(YEAR, GETDATE())";
                
                    break;

                case Range.ThisMonth:
                    dateFilter = @"MONTH(v.VisitDate) = MONTH(GETDATE())
                AND YEAR(v.VisitDate) = YEAR(GETDATE())";
                    break;
            }

            string query = $@"
        SELECT 
                        -- تفاصيل الزيارة
            v.VisitId,
            v.VisitDate,
            v.Notes AS VisitNotes,

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

        FROM Visits v
        INNER JOIN Persons p ON v.PersonId = p.PersonId
        LEFT JOIN Patients pa ON p.PersonId = pa.PersonId
        INNER JOIN VisitTypes vt ON v.VisitTypeId = vt.VisitTypeId

        WHERE v.DoctorId = @DoctorId
        AND vt.TypeName = N'Consultation'   -- زيارة استشارية
        AND {dateFilter}

        ORDER BY v.VisitDate DESC; ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId }
            };

            return ClassCommands.ShowData(query, parameters);
        }





        /// <summary>
        /// يبدأ زيارة جديدة بناءً على موعد محدد، 
        /// يسجل وقت البداية، يغير حالة الموعد، 
        /// ويضيف زيارة جديدة مرتبطة بالمريض والطبيب والموعد.
        /// نوع الزيارة يتم تحديده من قبل المستخدم.
        /// </summary>
        public static bool StartVisitFromAppointment(int appointmentId, int personId, int doctorId, int visitTypeId, string visitStatus, string appointmentStatus)
        {
            DateTime startTime = DateTime.Now;

            string query = @"
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1) تحديث حالة الموعد
        UPDATE Appointments
        SET Status = @AppointmentStatus
        WHERE AppointmentId = @AppointmentId;

        -- 2) إنشاء زيارة جديدة
        INSERT INTO Visits (PersonId, DoctorId, AppointmentId, VisitTypeId, VisitDate, StartTime, VisitStatus)
        VALUES (@PersonId, @DoctorId, @AppointmentId, @VisitTypeId, GETDATE(), @StartTime, @VisitStatus);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
    ";

            var parameters = new Dictionary<string, object>
            {
                { "@AppointmentId", appointmentId },
                { "@PersonId", personId },
                { "@DoctorId", doctorId },
                { "@VisitTypeId", visitTypeId },
                { "@StartTime", startTime },
                { "@VisitStatus", visitStatus },
                { "@AppointmentStatus", appointmentStatus }
            };

            return ClassCommands.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// تعديل بيانات زيارة محددة ضمن معاملة واحدة (Transaction).
        /// يقوم بتحديث نوع الزيارة وحالة الزيارة، ثم تعديل حالة الموعد المرتبط بها.
        /// يرجع true عند نجاح العملية بالكامل، و false عند حدوث أي خطأ.
        /// </summary>
        public static bool UpdateVisitWithAppointment( int visitId, int newVisitTypeId, string newVisitStatus, string newAppointmentStatus)
        {
            string query = @"
    BEGIN TRY
        BEGIN TRANSACTION;

        ---------------------------------------------------
        -- 1) تعديل الزيارة
        ---------------------------------------------------
        UPDATE Visits
        SET VisitTypeId = @VisitTypeId,
            VisitStatus = @VisitStatus
        WHERE VisitId = @VisitId;

        ---------------------------------------------------
        -- 2) تعديل حالة الموعد المرتبط بالزيارة
        ---------------------------------------------------
        UPDATE Appointments
        SET Status = @AppointmentStatus
        WHERE AppointmentId = (
            SELECT AppointmentId 
            FROM Visits 
            WHERE VisitId = @VisitId
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH ";

            var parameters = new Dictionary<string, object>
            {
                { "@VisitId", visitId },
                { "@VisitTypeId", newVisitTypeId },
                { "@VisitStatus", newVisitStatus },
                { "@AppointmentStatus", newAppointmentStatus }
            };

            return ClassCommands.ExecuteQuery(query, parameters);
        }



    }
}

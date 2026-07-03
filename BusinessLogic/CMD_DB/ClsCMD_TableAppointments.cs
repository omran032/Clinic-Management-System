using BusinessLogic.InfoTable;
using BusinessLogic.ToolChart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string Title = "مخطط مواعيد الأسبوع";
            string SeriesName = "المواعيد";

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



                ////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        
        /// <summary>
        /// يتحقق إذا كان المريض لديه موعد غير مكتمل (Pending أو Scheduled)
        /// بشرط أن يكون الموعد في المستقبل أو لم يحن وقته بعد.
        /// يرجع True إذا يوجد موعد، False إذا لا يوجد.
        /// </summary>
        public static bool HasFuturePendingAppointment(int personId)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Appointments
        WHERE PersonId = @PersonId
        AND Status IN ('Pending', 'Scheduled')
        AND AppointmentDate >= GETDATE()
    ";

            var parameters = new Dictionary<string, object>()
            {
            { "@PersonId", personId }
            };

            int count = Convert.ToInt32(ClassCommands.ExecuteScalar(query, parameters));

            return count > 0;
        }




        /// <summary>
        /// إضافة موعد جديد مع التحقق من عدم وجود موعد متداخل.

        /// 0 ء  // اذا كان هناك تداخل ترجع
        /// ID ء  // اذا لم يكن هناك تداخل ترجع
        /// -1 ء  // اذا لم تنجح العملية ترجع      

        /// </summary>
        public static int AddAppointmentWithCheck(int doctorId, int personId, int visitTypeId, DateTime appointmentDate, int durationMinutes, string status, string notes)
        {
            // حساب وقت نهاية الموعد الجديد
            DateTime startTime = appointmentDate;
            DateTime endTime = appointmentDate.AddMinutes(durationMinutes);

            // 1) التحقق من وجود موعد متداخل
            string checkQuery = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorId = @DoctorId
        AND (
                (@StartTime < DATEADD(MINUTE, EstimatedDurationMinutes, AppointmentDate)
                 AND @EndTime > AppointmentDate)
            )";

            var checkParams = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId },
                { "@StartTime", startTime },
                { "@EndTime", endTime }
            };

            int conflictCount = Convert.ToInt32(ClassCommands.ExecuteScalar(checkQuery, checkParams));

            if (conflictCount > 0)
            {
                // يوجد موعد متداخل
                return 0;
            }

            // 2) إضافة الموعد الجديد
            string insertQuery = @"
        INSERT INTO Appointments 
        (PersonId, VisitTypeId, AppointmentDate, Status, Notes, EstimatedDurationMinutes, DoctorId)
        VALUES 
        (@PersonId, @VisitTypeId, @AppointmentDate, @Status, @Notes, @Duration, @DoctorId);

        SELECT SCOPE_IDENTITY(); ";

            var insertParams = new Dictionary<string, object>()
            {
                { "@PersonId", personId },
                { "@VisitTypeId", visitTypeId },
                { "@AppointmentDate", appointmentDate },
                { "@Status", status },
                { "@Notes", notes },
                { "@Duration", durationMinutes },
                { "@DoctorId", doctorId }
            };

            object result = ClassCommands.ExecuteScalar(insertQuery, insertParams);

            if (result != null && int.TryParse(result.ToString(), out int newId))
            {
                return newId; // ID الموعد الجديد
            }

            return -1; // خطأ غير متوقع
        }


        /// <summary>
        /// تعديل موعد مع التحقق من عدم وجود موعد متداخل.
        /// 0  → يوجد تداخل
        /// -2 → الموعد مرتبط بزيارة ولا يمكن تعديله
        /// -3 → حالة الموعد لا تسمح بالتعديل
        /// ID → تم التعديل بنجاح
        /// -1 → خطأ غير متوقع
        /// </summary>
          static int UpdateAppointmentWithCheck(
            int appointmentId,
            int doctorId,
            int personId,
            int visitTypeId,
            DateTime appointmentDate,
            int durationMinutes,
            string status,
            string notes)
        {
            // ⭐ 0) التحقق من أن الموعد مرتبط بزيارة
            if (ClsCMD_TableAppointments.IsAppointmentHasVisit(appointmentId))
            {
                return -2; // لا يمكن تعديل الموعد لأنه مرتبط بزيارة
            }

            // ⭐ 1) التحقق من حالة الموعد
            // يسمح بالتعديل فقط إذا كان الموعد Pending
            if (status != "Pending")
            {
                return -3; // حالة الموعد لا تسمح بالتعديل
            }

            DateTime startTime = appointmentDate;
            DateTime endTime = appointmentDate.AddMinutes(durationMinutes);

            // ⭐ 2) التحقق من وجود موعد متداخل (مع استثناء نفس الموعد)
            string checkQuery = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorId = @DoctorId
        AND AppointmentId <> @AppointmentId
        AND (
                (@StartTime < DATEADD(MINUTE, EstimatedDurationMinutes, AppointmentDate)
                 AND @EndTime > AppointmentDate)
            )";

            var checkParams = new Dictionary<string, object>()
            {
                { "@DoctorId", doctorId },
                { "@AppointmentId", appointmentId },
                { "@StartTime", startTime },
                { "@EndTime", endTime }
            };

            int conflictCount = Convert.ToInt32(ClassCommands.ExecuteScalar(checkQuery, checkParams));

            if (conflictCount > 0)
            {
                return 0; // يوجد تداخل
            }

            // ⭐ 3) تنفيذ عملية التعديل
            string updateQuery = @"
        UPDATE Appointments
        SET 
            PersonId = @PersonId,
            VisitTypeId = @VisitTypeId,
            AppointmentDate = @AppointmentDate,
            Status = @Status,
            Notes = @Notes,
            EstimatedDurationMinutes = @Duration,
            DoctorId = @DoctorId
        WHERE AppointmentId = @AppointmentId;

        SELECT @AppointmentId;";

            var updateParams = new Dictionary<string, object>()
            {
                { "@AppointmentId", appointmentId },
                { "@PersonId", personId },
                { "@VisitTypeId", visitTypeId },
                { "@AppointmentDate", appointmentDate },
                { "@Status", status },
                { "@Notes", notes },
                { "@Duration", durationMinutes },
                { "@DoctorId", doctorId }
            };

            object result = ClassCommands.ExecuteScalar(updateQuery, updateParams);

            if (result != null && int.TryParse(result.ToString(), out int updatedId))
            {
                return updatedId; // تم التعديل بنجاح
            }

            return -1; // خطأ غير متوقع
        }


        /// <summary>
        /// تنفيذ عملية التعديل و عرض رسالة بالنتيجة
        /// </summary>
      public static int UpdateAppointmentWithCheckAndReturnMessage(int appointmentId,  int doctorId, int personId, int visitTypeId, DateTime appointmentDate, int durationMinutes, string status, string notes)
        {
            int result = UpdateAppointmentWithCheck(appointmentId, doctorId, personId, visitTypeId, appointmentDate, durationMinutes, status, notes);
 
            if (result == -2)
            {
                MessageBox.Show( "لا يمكن تعديل هذا الموعد لأنه تحول إلى زيارة فعلية.\n" +
                    "بمجرد حضور المريض وبدء الزيارة، يصبح الموعد ثابتاً ولا يمكن تغيير الطبيب أو الوقت أو نوع الزيارة.",
                    "تعديل الموعد غير مسموح",  MessageBoxButtons.OK,  MessageBoxIcon.Warning  );
            }
            else if (result == -3)
            {
                MessageBox.Show("حالة الموعد لا تسمح بالتعديل", " لا يمكن تعديل الموعد", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == 0)
            {
                MessageBox.Show("لم يتم تعديل لانه يوجد موعد في نفس الوقت المحدد", "موعد محجوز", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (result > 0)
            {
                MessageBox.Show("تم تعديل الموعد بنجاح", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("لم تنجح عملية التعديل", " فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }



        /// <summary>
        /// حذف موعد عبر رقم الموعد AppointmentId.
        /// ترجع:
        ///  1  = تم الحذف بنجاح
        ///  0  = الموعد غير موجود
        /// -1  = الموعد مرتبط بمدفوعات أو زيارات (FK Conflict)
        /// </summary>
        public static int DeleteAppointmentById(int appointmentId)
        {
            string query = @"
        DELETE FROM Appointments
        WHERE AppointmentId = @AppointmentId ";

            var parameters = new Dictionary<string, object>()
            {
                { "@AppointmentId", appointmentId }
            };

            try
            {
                bool deleted = ClassCommands.ExecuteQuery(query, parameters);

                if (deleted)
                    return 1;   // تم الحذف

                return 0;       // لم يتم العثور على الموعد
            }
            catch (SqlException ex)
            {
                // FK Conflict
                if (ex.Message.Contains("REFERENCE") || ex.Message.Contains("FK_"))
                    return -1;

                // أي خطأ آخر
                throw;
            }
        }



        /// <summary>
        /// إرجاع المواعيد مع معلومات الطبيب والمريض ونوع الزيارة.
        /// إذا wasUpcoming = true → يرجع المواعيد المتبقية فقط.
        /// إذا wasUpcoming = false → يرجع كل المواعيد.
        /// إذا UserIsDoctor = true → يرجع فقط مواعيد الطبيب الحالي.
        /// </summary>
        public static DataTable GetAppointments(bool wasUpcoming, bool UserIsDoctor = false)
        {
            int DoctorID = 0;

            // إذا المستخدم طبيب → نأخذ معرفه
            if (UserIsDoctor)
            {
                DoctorID = ClassUser.UserInfo.DoctorInfo.DoctorID;
            }

            // شرط المواعيد المتبقية
            string condition = wasUpcoming ? "WHERE A.AppointmentDate >= GETDATE()" : "";

            // إذا المستخدم طبيب → نضيف شرط إضافي
            if (UserIsDoctor)
            {
                // إذا كان هناك شرط سابق (wasUpcoming = true)
                if (!string.IsNullOrEmpty(condition))
                    condition += $" AND A.DoctorId = {DoctorID}";
                else
                    condition = $"WHERE A.DoctorId = {DoctorID}";
            }

            string query = $@"
        SELECT 
            -- معلومات الموعد
            A.AppointmentId,
            A.AppointmentDate,
            A.Status,

            -- معلومات المريض (Persons)
            P.PersonId,
            P.Phone AS PatientPhone,
            (P.FirstName + ' ' + P.LastName) AS PatientName,

            -- معلومات المريض (Patients)
            PT.PatientId AS [ID Patient],

            -- معلومات الطبيب
            D.DoctorId,
            (DP.FirstName + ' ' + DP.LastName) AS DoctorName,
            DP.Phone AS DoctorPhone,
            S.Name AS SpecializationName,

            -- نوع الزيارة
            VT.VisitTypeId,
            VT.TypeName AS VisitTypeName

        FROM Appointments A
        INNER JOIN Persons P ON A.PersonId = P.PersonId
        INNER JOIN Patients PT ON P.PersonId = PT.PersonId
        INNER JOIN Doctors D ON A.DoctorId = D.DoctorId
        INNER JOIN Persons DP ON D.PersonId = DP.PersonId
        INNER JOIN Specializations S ON D.SpecializationId = S.SpecializationId
        INNER JOIN VisitTypes VT ON A.VisitTypeId = VT.VisitTypeId

        {condition}

        ORDER BY A.AppointmentDate ASC ";

            return ClassCommands.ShowData(query);
        }





        public enum AppointmentFilter
        {
            All,
            Today,
            ThisWeek,
            ThisMonth,
            DoctorId,
            DoctorName,
            PatientName,
            AppointmentStatus,
            PatientPhone
        }

        /// <summary>
        /// إرجاع المواعيد حسب نوع الفلترة المطلوبة.
        /// إذا UserIsDoctor = true → يعرض فقط مواعيد الطبيب الحالي.
        /// إذا UserIsDoctor = false → يعرض كل المواعيد.
        /// </summary>
        public static DataTable GetAppointmentsByFilter(AppointmentFilter filter, string value = "", bool UserIsDoctor = false)
        {
            string condition = "";
            var parameters = new Dictionary<string, object>();

            // إذا المستخدم طبيب → نأخذ معرفه
            int doctorId = 0;
            if (UserIsDoctor)
            {
                doctorId = ClassUser.UserInfo.DoctorInfo.DoctorID;
            }


            // فلترة حسب النوع
            switch (filter)
            {
                case AppointmentFilter.Today:
                    condition = "WHERE CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case AppointmentFilter.ThisWeek:
                    condition = @"
                WHERE A.AppointmentDate >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                AND   A.AppointmentDate <  DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) ";
                    break;

                case AppointmentFilter.ThisMonth:
                    condition = @"
                WHERE MONTH(A.AppointmentDate) = MONTH(GETDATE())
                AND   YEAR(A.AppointmentDate) = YEAR(GETDATE())  ";
                    break;

                case AppointmentFilter.DoctorId:
                    condition = "WHERE D.DoctorId = @DoctorId";
                    parameters.Add("@DoctorId", Convert.ToInt32(value));
                    break;

                case AppointmentFilter.DoctorName:
                    condition = "WHERE (DP.FirstName + ' ' + DP.LastName) LIKE '%' + @DoctorName + '%'";
                    parameters.Add("@DoctorName", value);
                    break;

                case AppointmentFilter.PatientName:
                    condition = "WHERE (P.FirstName + ' ' + P.LastName) LIKE '%' + @PatientName + '%'";
                    parameters.Add("@PatientName", value);
                    break;

                case AppointmentFilter.AppointmentStatus:
                    condition = "WHERE A.Status LIKE '%' + @Status + '%'";
                    parameters.Add("@Status", value);
                    break;

                case AppointmentFilter.PatientPhone:
                    condition = "WHERE P.Phone LIKE '%' + @Phone + '%'";
                    parameters.Add("@Phone", value);
                    break;

                case AppointmentFilter.All:
                default:
                    condition = "";
                    break;
            }

            // إضافة شرط الطبيب إذا كان المستخدم طبيب
            if (UserIsDoctor)
            {
                if (string.IsNullOrWhiteSpace(condition))
                {
                    condition = $"WHERE D.DoctorId = @CurrentDoctorId";
                }
                else
                {
                    condition += $" AND D.DoctorId = @CurrentDoctorId";
                }

                parameters.Add("@CurrentDoctorId", doctorId);
            }

            string query = $@"
        SELECT 
            -- معلومات الموعد
            A.AppointmentId,
            A.AppointmentDate,
            A.Status,

            -- معلومات المريض (Persons)
            P.PersonId,
            P.Phone AS PatientPhone,
            (P.FirstName + ' ' + P.LastName) AS PatientName,

            -- معلومات المريض (Patients)
            PT.PatientId AS [ID Patiient],

            -- معلومات الطبيب
            D.DoctorId,
            (DP.FirstName + ' ' + DP.LastName) AS DoctorName,
            DP.Phone AS DoctorPhone,
            S.Name AS SpecializationName,

            -- نوع الزيارة
            VT.VisitTypeId,
            VT.TypeName AS VisitTypeName

        FROM Appointments A
        INNER JOIN Persons P ON A.PersonId = P.PersonId
        INNER JOIN Patients PT ON P.PersonId = PT.PersonId
        INNER JOIN Doctors D ON A.DoctorId = D.DoctorId
        INNER JOIN Persons DP ON D.PersonId = DP.PersonId
        INNER JOIN Specializations S ON D.SpecializationId = S.SpecializationId
        INNER JOIN VisitTypes VT ON A.VisitTypeId = VT.VisitTypeId

        {condition}

        ORDER BY A.AppointmentDate ASC
    ";

            return ClassCommands.ShowData(query, parameters);
        }










        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////







        /// <summary>
        /// يعيد جدولة مواعيد الطبيب بعد انتهاء زيارة فعلية
        /// بفحص التداخل وتعديل كل المواعيد التالية داخل Connection واحد.
        /// </summary>
        public void AutoShiftAppointmentsAfterVisit(int doctorId, DateTime actualEndTime)
        {
            int gapMinutes = 5; // الفاصل بين كل موعد وآخر

            using (SqlConnection conn = new SqlConnection(ClsConnectionDB.connectionString))
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) جلب كل المواعيد التالية لنفس الطبيب ونفس اليوم
                        string selectSql = @"
                    SELECT AppointmentId, StartTime, EstimatedDuration
                    FROM Appointments
                    WHERE DoctorId = @DoctorId
                    AND CAST(StartTime AS DATE) = CAST(@ActualEndTime AS DATE)
                    AND StartTime > @ActualEndTime
                    ORDER BY StartTime ASC
                ";

                        List<ClassAppointment> nextAppointments = new List<ClassAppointment>();

                        using (SqlCommand cmd = new SqlCommand(selectSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                            cmd.Parameters.AddWithValue("@ActualEndTime", actualEndTime);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    nextAppointments.Add(new ClassAppointment
                                    {
                                        AppointmentID = reader.GetInt32(0),
                                        StartTime = reader.GetDateTime(1),
                                        EstimatedDurationMinutes = reader.GetInt32(2)
                                    });
                                }
                            }
                        }

                        // 2) الوقت الجديد الذي يجب أن يبدأ منه أول موعد بعد الزيارة
                        DateTime newStartTime = actualEndTime.AddMinutes(gapMinutes);

                        // 3) تعديل كل المواعيد التالية داخل نفس الـ Transaction
                        foreach (var appt in nextAppointments)
                        {
                            // فحص التداخل
                            if (appt.StartTime < newStartTime)
                            {
                                // تعديل الموعد داخل القاعدة
                                string updateSql = @"
                            UPDATE Appointments
                            SET StartTime = @NewStartTime
                            WHERE AppointmentId = @AppointmentId
                        ";

                                using (SqlCommand updateCmd = new SqlCommand(updateSql, conn, tx))
                                {
                                    updateCmd.Parameters.AddWithValue("@NewStartTime", newStartTime);
                                    updateCmd.Parameters.AddWithValue("@AppointmentId", appt.AppointmentID);
                                    updateCmd.ExecuteNonQuery();
                                }

                                // حساب وقت الموعد التالي
                                newStartTime = newStartTime.AddMinutes(appt.EstimatedDurationMinutes + gapMinutes);
                            }
                            else
                            {
                                // لا يوجد تداخل، نحدّث وقت البداية الجديد بناءً على الموعد الحالي
                                newStartTime = appt.StartTime.AddMinutes(appt.EstimatedDurationMinutes + gapMinutes);
                            }
                        }

                        // 4) حفظ كل التعديلات دفعة واحدة
                        tx.Commit();
                    }
                    catch
                    {
                        // لو صار خطأ، نرجع كل التعديلات
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }



        /// <summary>
        /// يفحص إذا كان الموعد مرتبط بزيارة داخل جدول Visits.
        /// يرجع true إذا كانت هناك زيارة تحمل نفس AppointmentId.
        /// يرجع false إذا لم توجد أي زيارة.
        /// </summary>
        public static bool IsAppointmentHasVisit(int appointmentId)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Visits
        WHERE AppointmentId = @AppointmentId   ";

            var parameters = new Dictionary<string, object>
            {
                { "@AppointmentId", appointmentId }
            };

            // إذا العدد أكبر من صفر → يعني موجود
            int count = Convert.ToInt32(ClassCommands.ShowValue(query, parameters));
            return count > 0;
        }



        public enum AppointmentFilterType
        {
            ByAppointmentID ,          // البحث حسب معرف الموعد
            TodayAllDoctors,          // كل مواعيد الأطباء اليوم
            TodayByDoctor,            // مواعيد طبيب محدد اليوم
            ByStatus,                 // حسب حالة الموعد فقط
            ByStatusAndDoctor         // حسب حالة الموعد + طبيب محدد

        }


        /// <summary>
        /// إرجاع جدول مواعيد مع إمكانية الفلترة حسب نوع الفلتر المرسل.
        /// يدعم عرض مواعيد اليوم لكل الأطباء، أو حسب طبيب محدد، أو حسب حالة الموعد،
        ///— أو حسب حالة الموعد مع الطبيب.
        /// يعرض: AppointmentID / IDPatients / PersonName / VisitType / Status / Time.
        /// يتم ترتيب النتائج تصاعدياً حسب وقت الموعد.
        /// ويمكن عرض كل البيانات للمواعيد _ او بيانات خاصة بمواعيد الطبيب فقط تلقائياً
        /// </summary>
        public static DataTable GetAppointments(
                    AppointmentFilterType filter, int? doctorId = null, string status = null, int? appointmentId = null,bool onlyDoctorAppointments = false  )
        {
            DataTable dt = new DataTable();
            var parameters = new Dictionary<string, object>();

            int doctorIdForFilter = 0;
            if (onlyDoctorAppointments)
            {
                doctorIdForFilter = ClassUser.UserInfo.DoctorInfo.DoctorID;
            }

            string query = @"
        SELECT 
            a.AppointmentID,
            p.PersonId AS IDPatients,
            (p.FirstName + ' ' + p.LastName) AS PersonName,
            vt.TypeName AS VisitType,
            a.Status,
            CONVERT(VARCHAR(5), a.AppointmentDate, 108) AS Time
        FROM Appointments a
        INNER JOIN Persons p ON a.PersonId = p.PersonId
        INNER JOIN VisitTypes vt ON a.VisitTypeId = vt.VisitTypeId
        LEFT JOIN Doctors d ON a.DoctorId = d.DoctorId
        WHERE 1 = 1
    ";

            // ⭐ إذا تم إرسال AppointmentID → تجاهل كل الفلاتر
            if (appointmentId.HasValue)
            {
                query += " AND a.AppointmentID = @AppointmentID ";
                parameters.Add("@AppointmentID", appointmentId.Value);

                query += " ORDER BY a.AppointmentDate ASC ";
                return ClassCommands.ShowData(query, parameters);
            }

            // ⭐ فلترة حسب نوع الطلب
            switch (filter)
            {
                case AppointmentFilterType.ByAppointmentID:
                    query += " AND a.AppointmentID = @AppointmentID ";
                    parameters.Add("@AppointmentID", Convert.ToInt32(status));
                    break;

                case AppointmentFilterType.TodayAllDoctors:
                    query += " AND CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) ";
                    break;

                case AppointmentFilterType.TodayByDoctor:
                    query += " AND CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) ";
                    query += " AND a.DoctorId = @DoctorId ";
                    parameters.Add("@DoctorId", Convert.ToInt32(doctorId));
                    break;

                case AppointmentFilterType.ByStatus:
                    query += " AND a.Status = @Status ";
                    parameters.Add("@Status", status);
                    break;

                case AppointmentFilterType.ByStatusAndDoctor:
                    query += " AND a.Status = @Status ";
                    query += " AND a.DoctorId = @DoctorId ";
                    parameters.Add("@DoctorId", Convert.ToInt32(doctorId));
                    parameters.Add("@Status", status);
                    break;
            }

            // ⭐ فلترة مواعيد الطبيب فقط (الميزة الجديدة)
            if (onlyDoctorAppointments && doctorIdForFilter > 0)
            {
                query += " AND a.DoctorId = @DoctorIdFilter ";
                parameters.Add("@DoctorIdFilter", doctorIdForFilter);
            }

            // ترتيب حسب أقرب وقت للوقت الحالي
            query += " ORDER BY a.AppointmentDate ASC ";

            return ClassCommands.ShowData(query, parameters);
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        ///  ( جلب آخر 3 مواعيد قادمة للطبيب ( غير منتهية 
        /// </summary>
        public static List<ClassAppointment> GetLastThreeUpcomingAppointments(int doctorId)
        {
            string query = @"
        SELECT TOP 3
            A.AppointmentId,
            A.AppointmentDate,
            A.Status,
            A.Notes AS AppointmentNotes,
            A.EstimatedDurationMinutes,

            -- Patient (Persons)
            P.PersonId,
            P.FirstName,
            P.LastName,
            P.Gender,
            P.BirthDate,
            P.Phone,
            P.Address,
            P.CreatedAt,
            P.UpdatedAt,

            -- Patient (Patients)
            PT.PatientId AS [ID Patiient],
            PT.MedicalNotes,
            PT.FirstVisitDate,
            PT.ChronicDiseases,
            PT.Allergies,
            PT.Notes,
            PT.ComplianceScore,

            -- Doctor
            D.DoctorId AS [Doctor ID],
            D.SpecializationId,
            S.Name AS [Specialization Name],
            D.Notes AS DoctorNotes,

            -- Doctor Person
            DP.PersonId AS DoctorPersonId,
            DP.FirstName AS DoctorFirstName,
            DP.LastName AS DoctorLastName,
            DP.Phone AS DoctorPhone,
            DP.Address AS DoctorAddress,

            -- Visit Type
            VT.VisitTypeId,
            VT.TypeName AS VisitTypeName,
            VT.Description AS VisitTypeDescription

        FROM Appointments A
        INNER JOIN Persons P ON A.PersonId = P.PersonId
        INNER JOIN Patients PT ON P.PersonId = PT.PersonId
        INNER JOIN Doctors D ON A.DoctorId = D.DoctorId
        INNER JOIN Persons DP ON D.PersonId = DP.PersonId
        INNER JOIN Specializations S ON D.SpecializationId = S.SpecializationId
        INNER JOIN VisitTypes VT ON A.VisitTypeId = VT.VisitTypeId
        WHERE A.DoctorId = @DoctorId
          AND A.AppointmentDate > GETDATE()
          AND A.Status IN ('Pending', 'InProgress', 'Delayed')
        ORDER BY A.AppointmentDate ASC  ";

            var parameters = new Dictionary<string, object>()
            {
                    { "@DoctorId", doctorId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            List<ClassAppointment> appointments = new List<ClassAppointment>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClassAppointment appointment = ClassAppointment.GetInfoAppointmentInObj(dt, i);
                appointments.Add(appointment);
            }

            return appointments;
        }




    }
}


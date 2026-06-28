using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic.InfoTable
{
    public class ClassAppointment
    {

        public int AppointmentID { get; set; }

        public ClassPatients PatientsInfo { get; set; }

        public ClassVisitType VisitTypeInfo { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }

        public string Appointment_Notes { get; set; }

        public ClassDoctor DoctorInfo { get; set; }

        public int EstimatedDurationMinutes { get; set; }

        public DateTime StartTime { get; set; }

        public static List<string> AppointmentStatusList = new List<string>()
        {
            "Pending",      // قيد الانتظار
            "Completed",    // تمّت الزيارة
            "Cancelled",    // تم الإلغاء
            "Absent",       // لم يحضر
            "Delayed",      // تأخر
            "InProgress"    // قيد الزيارة
        };

        /// <summary>
        /// تعبئة كومبوكس بقائمة نصوص >>>>  حالات الموعد
        /// </summary>
        public static void FillComboWithList(ComboBox combo)
        {
            combo.DataSource = null;   // تنظيف قديم
            combo.Items.Clear();       // مسح العناصر

            combo.DataSource = AppointmentStatusList;  // تعبئة جديد
        }



        /// <summary>
        /// ClassAppointment إلى كائن DataTable تحويل صف من  
        ///  مع معلومات الشخص
        /// </summary>
        /// <summary>
        /// تحويل صف من DataTable إلى كائن ClassAppointment كامل
        /// مع معلومات المريض والطبيب ونوع الزيارة.
        /// </summary>
        public static ClassAppointment GetInfoAppointmentInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassAppointment AppointmentInfo = new ClassAppointment()
            {
                AppointmentID = Convert.ToInt32(row["AppointmentId"]),
                AppointmentDate = Convert.ToDateTime(row["AppointmentDate"]),
                Status = row["Status"]?.ToString(),
                Appointment_Notes = row.Table.Columns.Contains("AppointmentNotes")
                                    ? row["AppointmentNotes"]?.ToString() : null ,

                EstimatedDurationMinutes = Convert.ToInt32(row["EstimatedDurationMinutes"]) 

            };

            // تعبئة معلومات المريض (Patients + Persons)
            AppointmentInfo.PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, RowIndex);
            AppointmentInfo.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

            // تعبئة معلومات نوع الزيارة
            AppointmentInfo.VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, RowIndex);

            // تعبئة معلومات الدكتور إذا موجودة
            if (dt.Columns.Contains("Doctor ID"))
            {
                int DoctorID = Convert.ToInt32(row["Doctor ID"]);
                AppointmentInfo.DoctorInfo = ClassDoctor.GetDoctorInfo(DoctorID);
            }
            else
            {
                AppointmentInfo.DoctorInfo = null;
            }

            return AppointmentInfo;
        }





        /// <summary>
        /// ارسال معرف الموعد ...ليتم ارجاع تفاصيل الموعد كاملة ...للمريض و الطبيب
        /// </summary>
        /// <param name="appointmentId">معرف الموعد</param>
        public static ClassAppointment GetAppointmentById(int appointmentId)
        {
            string query = @"SELECT TOP 1
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
                    WHERE A.AppointmentId = @AppointmentId";

            var parameters = new Dictionary<string, object>()
            {
                { "@AppointmentId", appointmentId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            return ClassAppointment.GetInfoAppointmentInObj(dt, 0);
        }








        #region  ********//

        //public static ClassAppointment GetInfoVisitInObj(DataTable dt, int RowIndex = 0)
        //{

        //        DataRow row = dt.Rows[RowIndex];

        //        ClassAppointment AppointmentInfo = new ClassAppointment()
        //        {
        //            AppointmentID = Convert.ToInt32(row["AppointmentId"]),
        //            AppointmentDate = Convert.ToDateTime(row["AppointmentDate"]),
        //            Status = row["Status"]?.ToString(),
        //            Appointment_Notes = row["AppointmentNotes"]?.ToString(),

        //            PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, RowIndex),
        //            VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, RowIndex)
        //        };

        //        AppointmentInfo.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

        //        // معلومات الدكتور ما عبيتا

        //        return AppointmentInfo;


        //}
        #endregion





    }
}

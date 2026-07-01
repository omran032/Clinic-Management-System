using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassVisit
    {
        public int VisitID { get; set; }

        public ClassPatients PatientsInfo { get; set; }

        public ClassVisitType VisitTypeInfo { get; set; }

        // تاريخ 
        public DateTime VisitDate { get; set; }

 
        public string Visit_Notes { get; set; }

        public ClassDoctor DoctorInfo { get; set; }

        public ClassAppointment AppointmentInfo { get; set; }



        // يرجع وقت فقط بدون تاريخ
        public DateTime StartTime { get; set; }

        // يرجع وقت فقط بدون تاريخ
        public DateTime EndTime { get; set; }

        //فرق الدقائق بين البدء و النهاية 
        public int ActualDirrationMinutes { get; set; }


        public string VisitStatus { get; set; }





        /// <summary>
        /// ClassVisit إلى كائن DataTable تحويل صف من  
        ///  مع معلومات الشخص
        /// </summary>
        public static ClassVisit GetInfoVisitInObj(DataTable dt, int RowIndex = 0)
        {
            DataRow row = dt.Rows[RowIndex];

            ClassVisit VisitInfo = new ClassVisit()
            {
                VisitID = Convert.ToInt32(row["VisitId"]),
                VisitDate = Convert.ToDateTime(row["VisitDate"]),
                Visit_Notes = row["VisitNotes"]?.ToString(),

                PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, RowIndex),
                VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, RowIndex)

            };

            VisitInfo.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

            // معلومات الدكتور ما عبيتا

            return VisitInfo;
        }


        /// <summary>
        /// جلب تفاصيل زيارة كاملة مع معلومات المريض والطبيب ونوع الزيارة والموعد المرتبط.
        /// </summary>
        public static ClassVisit GetVisitById(int visitId)
        {
            string query = @"
        SELECT TOP 1
            V.VisitId,
            V.VisitDate,
            V.Notes AS VisitNotes,
            V.StartTime,
            V.EndTime,
            V.ActualDurationMinutes,
            V.VisitStatus,
            V.AppointmentId,

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

        FROM Visits V
        INNER JOIN Persons P ON V.PersonId = P.PersonId
        INNER JOIN Patients PT ON P.PersonId = PT.PersonId
        INNER JOIN Doctors D ON V.DoctorId = D.DoctorId
        INNER JOIN Persons DP ON D.PersonId = DP.PersonId
        INNER JOIN Specializations S ON D.SpecializationId = S.SpecializationId
        INNER JOIN VisitTypes VT ON V.VisitTypeId = VT.VisitTypeId
        WHERE V.VisitId = @VisitId";

            var parameters = new Dictionary<string, object>()
    {
        { "@VisitId", visitId }
    };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            // تعبئة كائن الزيارة
            ClassVisit visit = new ClassVisit()
            {
                VisitID = Convert.ToInt32(row["VisitId"]),
                VisitDate = Convert.ToDateTime(row["VisitDate"]),
                Visit_Notes = row["VisitNotes"]?.ToString(),
                StartTime = row["StartTime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["StartTime"]),
                EndTime = row["EndTime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["EndTime"]),
                ActualDirrationMinutes = row["ActualDurationMinutes"] == DBNull.Value ? 0 : Convert.ToInt32(row["ActualDurationMinutes"]),
                VisitStatus = row["VisitStatus"]?.ToString()
            };

            // تعبئة معلومات المريض
            visit.PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, 0);
            visit.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, 0);

            // تعبئة نوع الزيارة
            visit.VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, 0);

            // تعبئة معلومات الطبيب
            int doctorId = Convert.ToInt32(row["Doctor ID"]);
            visit.DoctorInfo = ClassDoctor.GetDoctorInfo(doctorId);

            // تعبئة معلومات الموعد المرتبط (إن وجد)
            if (row["AppointmentId"] != DBNull.Value)
            {
                int appointmentId = Convert.ToInt32(row["AppointmentId"]);
                visit.AppointmentInfo = ClassAppointment.GetAppointmentById(appointmentId);
            }

            return visit;
        }



    }
}

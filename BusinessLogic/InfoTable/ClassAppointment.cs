using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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





        /// <summary>
        /// ClassAppointment إلى كائن DataTable تحويل صف من  
        ///  مع معلومات الشخص
        /// </summary>
        public static ClassAppointment GetInfoVisitInObj(DataTable dt, int RowIndex = 0)
        {
            
                DataRow row = dt.Rows[RowIndex];

                ClassAppointment AppointmentInfo = new ClassAppointment()
                {
                    AppointmentID = Convert.ToInt32(row["AppointmentId"]),
                    AppointmentDate = Convert.ToDateTime(row["AppointmentDate"]),
                    Status = row["Status"]?.ToString(),
                    Appointment_Notes = row["AppointmentNotes"]?.ToString(),

                    PatientsInfo = ClassPatients.GetInfoPatientInObj(dt, RowIndex),
                    VisitTypeInfo = ClassVisitType.GetInfoVisitTypeInObj(dt, RowIndex)
                };

                AppointmentInfo.PatientsInfo.PersonInfo = ClassPerson.SaveDataInObj(dt, RowIndex);

                // معلومات الدكتور ما عبيتا

                return AppointmentInfo;
              
           
        }


    }
}

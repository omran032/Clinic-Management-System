using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Doctors.UControls
{
    public partial class Ctrl_InfoVisits_AppointmentsDoctor : UserControl
    {
        public Ctrl_InfoVisits_AppointmentsDoctor()
        {
            InitializeComponent();
        }

        ClassAppointment AppointmentInfo = new ClassAppointment() ; // بيانات موعد المريض

        ClassVisit VisitInfo = new ClassVisit();   // بيانات زيارة المريض

      

        /// <summary>
        /// تحميل معلومات موعد المريض
        /// </summary>
        public void LoadDataِAppointment(ClassAppointment AppointmentInfo_)
        {
            if (AppointmentInfo_ == null) return;

            AppointmentInfo = AppointmentInfo_;

            // حماية قبل Load()
            //if (AppointmentInfo.VisitTypeInfo == null)
            //    lbl_TypeVisit.Text = "نوع الزيارة : غير محدد";
            //else
                lbl_TypeVisit.Text = "Visit Type : " + AppointmentInfo.VisitTypeInfo.VisitName;


           lbl_ID_V_A.Text = "ID Appointment : " + AppointmentInfo.AppointmentID;
           GroupInfo_V_A.Text = "معلومات الموعد";

            ctrlNotes.TitleText = "ملاحظات الموعد";
            ctrlNotes.InfoText = AppointmentInfo_.Appointment_Notes;

            lblStatusAppointment.Visible = true;
            lblStatusAppointment.Text = "حالة الموعد : " + AppointmentInfo.Status;

            lblDate_V_A.Text = "تاريخ الموعد : " + AppointmentInfo.AppointmentDate;
        }


        /// <summary>
        /// تحميل بيانات زيارة المريض
        /// </summary>
        public void LoadDataِVisit(ClassVisit VisitInfo_)
        {
            if (VisitInfo_ == null) return;

            VisitInfo = VisitInfo_;
          
            GroupInfo_V_A.Text = "معلومات الزيارة";

            ctrlNotes.TitleText = "ملاحظات الزيارة";
            ctrlNotes.InfoText = VisitInfo.Visit_Notes;

            lblStatusAppointment.Visible = false;

            lblDate_V_A.Text = "Visit Date : " + VisitInfo_.VisitDate;
            lbl_ID_V_A.Text  = "ID Visit : " + VisitInfo_.VisitID;
            lbl_TypeVisit.Text = "Visit Type : " + VisitInfo_.VisitTypeInfo.VisitName;

            ctrl_PatientInfo1.PatientsInfo = VisitInfo.PatientsInfo;

        }




    }
}

using BusinessLogic.InfoTable;
using Program_Clinic_Management.Patients.UControls;
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
        public void LoadDataِAppointment(ClassAppointment AppointmentInfo_ , bool ShowInfoDoctor = false)
        {
            if (AppointmentInfo_ == null) return;

            AppointmentInfo = AppointmentInfo_;


           lbl_ID_V_A.Text = "ID Appointment : " + AppointmentInfo.AppointmentID;
           GroupInfo_V_A.Text = "معلومات الموعد";

            ctrlNotes.TitleText = "ملاحظات الموعد";
            ctrlNotes.InfoText = AppointmentInfo_.Appointment_Notes;

            lblStatusAppointment.Visible = true;

            lblStatusAppointment.Text =  AppointmentInfo.Status;
            lblType.Text = "نوع الموعد : "; lbl_TypeVisit.Text = AppointmentInfo.VisitTypeInfo.VisitName;
            lblDate.Text = "تاريخ الموعد : "; lblDate_V_A.Text = AppointmentInfo.AppointmentDate.ToString("yyyy / MM /dd _ hh : mm tt");

            // عرض معلومات الطبيب 
            if(ShowInfoDoctor)
            {
                ctrl_PersonInfoDoctor.PersonInfo = AppointmentInfo_.DoctorInfo.PersonInfo;
                lblSpecialization.Text = AppointmentInfo_.DoctorInfo.SprcializationName;
            }
            LoadInfoPatient(AppointmentInfo_.PatientsInfo);


        }


        /// <summary>
        /// تحميل بيانات زيارة المريض
        /// </summary>
        public void LoadDataVisit(ClassVisit VisitInfo_)
        {
            if (VisitInfo_ == null) return;

            VisitInfo = VisitInfo_;
          
            GroupInfo_V_A.Text = "معلومات الزيارة";

            ctrlNotes.TitleText = "ملاحظات الزيارة";
            ctrlNotes.InfoText = VisitInfo.Visit_Notes;

            lblStatus.Visible = false; lblStatusAppointment.Visible = false;

            lbl_ID_V_A.Text  = "ID Visit : " + VisitInfo_.VisitID;
            lblDate.Text = "تاريخ الزيارة : ";  lblDate_V_A.Text = VisitInfo_.VisitDate.ToString("yyyy / MM /dd _ hh : mm tt");
            lblType.Text = "نوع الزيارة : ";  lbl_TypeVisit.Text =  VisitInfo_.VisitTypeInfo.VisitName;

            LoadInfoPatient(VisitInfo.PatientsInfo);
        }

        /// <summary>
        /// تحميل معلومات المريض
        /// </summary>
        /// <param name="PatientInfo"></param>
        public void LoadInfoPatient(ClassPatients PatientInfo)
        {
            ctrl_PatientInfo1.PatientsInfo = PatientInfo;
        }

        
    }
}

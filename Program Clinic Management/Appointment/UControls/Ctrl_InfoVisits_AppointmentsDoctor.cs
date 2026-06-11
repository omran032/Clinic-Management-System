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

            // عرض معلومات الطبيب 
            if(ShowInfoDoctor)
            {
                ctrl_PersonInfoDoctor.PersonInfo = AppointmentInfo_.DoctorInfo.PersonInfo;
                lblSpecialization.Text = "Specialization : " + AppointmentInfo_.DoctorInfo.SprcializationName;
            }

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

            lblStatusAppointment.Visible = false;

            lblDate_V_A.Text = "Visit Date : " + VisitInfo_.VisitDate;
            lbl_ID_V_A.Text  = "ID Visit : " + VisitInfo_.VisitID;
            lbl_TypeVisit.Text = "Visit Type : " + VisitInfo_.VisitTypeInfo.VisitName;

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

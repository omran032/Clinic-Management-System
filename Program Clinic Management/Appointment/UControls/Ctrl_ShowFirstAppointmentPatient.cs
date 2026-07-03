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

namespace Program_Clinic_Management.Appointment.UControls
{
    public partial class Ctrl_ShowFirstAppointmentPatient : UserControl
    {
        public Ctrl_ShowFirstAppointmentPatient()
        {
            InitializeComponent();
        }

        // تحتوي معلومات الموعد كاملة // حتى معلومات الطبيب
        private ClassAppointment InfoAppointmentPatient_;


        public ClassAppointment InfoAppointmentPatient
        {
            get { return InfoAppointmentPatient_; }
            set
            {
                InfoAppointmentPatient_ = value;
                LoadData();
            }
        }

        // تحميل معلومات الموعد
        void LoadData()
        {
            if (InfoAppointmentPatient_ == null) return;

            string Gender = InfoAppointmentPatient_.PatientsInfo.PersonInfo.Gender;
            // تعديلها مستقبلا لعرض الصورة التي تمثل الجنس
            PicGender.Image = Gender == "Male" ? Properties.Resources.Sick : Properties.Resources.Sick;

            lblPatientName.Text  = InfoAppointmentPatient_.PatientsInfo.PersonInfo.FullName;
            lblPhonePatient.Text = InfoAppointmentPatient_.PatientsInfo.PersonInfo.Phone;
            lblTime.Text = InfoAppointmentPatient_.AppointmentDate.ToString("hh : mm  tt");

        }

    }
}

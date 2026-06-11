using BusinessLogic.CMD_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.CMD_DB.ClsCMD_TableAppointments;
using static BusinessLogic.CMD_DB.ClsCMD_TableVisits;
using static Program_Clinic_Management.FrmInfoApplication_Visit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Program_Clinic_Management.Doctors.UControls
{
    public partial class CtrlCountVisits_AppointmentsDoctor : UserControl
    {
        public CtrlCountVisits_AppointmentsDoctor()
        {
            InitializeComponent();

            // Panals لون  
            MyTools.ColorControl(Pnl1, Color.FromArgb(253, 253, 253), Color.FromArgb(212, 222, 224), true, false);
            MyTools.ColorControl(pnl2, Color.FromArgb(253, 253, 253), Color.FromArgb(212, 222, 224), true, false);

            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;


            ComboxTypeAppointment.Text = "المواعيد المتبقية";
            Combox_RangAppointment.Text = "اليوم";

            Combox_RangVisit.Text = "اليوم";
            ComboxTypeVisit.Text = "زيارة طارئه";
        }

        // عرض الواجهة لعرض التفاصيل والمعلومات 
        void ShowForm(DataTable DT , PositionType positionType)
        {
            FrmInfoApplication_Visit infoApplication_Visit = new FrmInfoApplication_Visit(DT, positionType);
            MyTools.ShowForm(infoApplication_Visit);
        }

      public void LoadData(int DoctorID_)
        {
            DoctorID = DoctorID_;

            AppRange = AppointmentRange.Today;
            VisitRange = Range.Today;

            // ِAppointment // المواعيد
            // بيانات المواعيد المتبقية
            lblCountAppointments.Text = "عدد المواعيد : " + ClsCMD_TableAppointments.GetRemainingAppointmentsByDoctor(DoctorID, AppRange); 
            DT_Appointment = ClsCMD_TableAppointments.GetRemainingAppointmentsWithPatientDetails(DoctorID, AppRange);


            // Visit  // الزيارات
            // بيانات الزيارة طارئه 
            lblCountVisits.Text = "عدد الزيارات : " + ClsCMD_TableVisits.GetEmergencyVisitsCount(DoctorID, VisitRange);
            DT_Visit = ClsCMD_TableVisits.GetEmergencyVisitsFullDetails(DoctorID, VisitRange);

        }


        DataTable DT_Appointment = new DataTable();
        DataTable DT_Visit = new DataTable();

        public int DoctorID { get; set; }

        /// <summary>
        /// تغيير لون خلفية الـ GroupBox
        /// </summary>
        public Color GroupBoxBackColor
        {
            get => GroupBox_Info.BackColor;
            set
            {
                GroupBox_Info.BackColor = value;
                GroupBox_Info.FillColor = value;
                //   GroupBox_Info.Invalidate(); // تحديث الشكل
            }
        }




        #region  **** Appointment عناصر المواعيد ****

        ClsCMD_TableAppointments.AppointmentRange AppRange = AppointmentRange.Today;

        // الفترة  ComboBox  // Appointment
        private void Combox_RangAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Range = Combox_RangAppointment.Text.Trim();

            AppRange =         Range == "اليوم"  ? AppointmentRange.Today :
                               Range == "الأسبوع" ? AppointmentRange.ThisWeek :
                                                   AppointmentRange.ThisMonth;
        } 

        // المواعيد  ComboBox  // Appointment
        private void ComboxTypeAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TypeAppointment = ComboxTypeAppointment.Text.Trim();
 
            switch (TypeAppointment)
            {
                case "المواعيد المتبقية":
                    lblCountAppointments.Text = "عدد المواعيد : " + ClsCMD_TableAppointments.GetRemainingAppointmentsByDoctor(DoctorID, AppRange);
                    break;

                case "المواعيد المنتهية":
                    lblCountAppointments.Text = "عدد المواعيد : " + ClsCMD_TableAppointments.GetCompletedAppointmentsCount(DoctorID, AppRange);
                    break;

                case "لم يتم حضورها":
                    lblCountAppointments.Text = "عدد المواعيد : " + ClsCMD_TableAppointments.GetAbsentAppointmentsCount(DoctorID, AppRange);
                    break;
            }
        }


        // زر عرض التفاصيل
        // زر عرض تفاصيل المواعيد حسب النوع و الفترة المختارة
        private void btnShowInfoAppointments_Click(object sender, EventArgs e)
        {
            string TypeAppointment = ComboxTypeAppointment.Text.Trim();

 
            switch (TypeAppointment)
            {
                case "المواعيد المتبقية":
                    DT_Appointment = ClsCMD_TableAppointments.GetRemainingAppointmentsWithPatientDetails(DoctorID, AppRange);
                    break;

                case "المواعيد المنتهية":
                    DT_Appointment = ClsCMD_TableAppointments.GetCompletedAppointmentsFullDetails(DoctorID, AppRange);
                    break;

                case "لم يتم حضورها":
                    DT_Appointment = ClsCMD_TableAppointments.GetAbsentAppointmentsFullDetails(DoctorID, AppRange);
                    break;
            }

            if(DT_Appointment != null)
                // عرض واجهة تفاصيل المواعيد ...حسب الاختيار اعلاه
                ShowForm(DT_Appointment, PositionType.Appointment);

            else
                MessageBox.Show("إختر تفاصيل الموعد أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        #endregion

                                  ///////////////////////////////////////////////////////////

        #region **** Visits  عناصر الزيارات  ****

        ClsCMD_TableVisits.Range VisitRange  = ClsCMD_TableVisits.Range.Today;

        // الفترة  ComboBox  // Visit
        private void Combox_RangVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Range = Combox_RangVisit.Text.Trim();

            VisitRange =       Range == "اليوم" ?  ClsCMD_TableVisits.Range.Today :
                               Range == "الأسبوع" ? ClsCMD_TableVisits.Range.ThisWeek :
                                                   ClsCMD_TableVisits.Range.ThisMonth;
        }
 
        // حالة الزيارة  ComboBox // Visit
        private void ComboxTypeVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TypeVisit = ComboxTypeVisit.Text.Trim();

            switch (TypeVisit)
            {
                case "زيارة طارئه":
                    lblCountVisits.Text = "عدد الزيارات : " + ClsCMD_TableVisits.GetEmergencyVisitsCount(DoctorID, VisitRange);
                    break;

                case "زيارة للمتابعة":
                    lblCountVisits.Text = "عدد الزيارات : " + ClsCMD_TableVisits.GetFollowUpVisitsCount(DoctorID, VisitRange);
                    break;

                case "زيارة استشارية":
                    lblCountVisits.Text = "عدد الزيارات : " + ClsCMD_TableVisits.GetConsultationVisitsCount(DoctorID, VisitRange);
                    break;
            }
        }


        // زر عرض التفاصيل
        // زر عرض تفاصيل المواعيد حسب النوع و الفترة المختارة
        private void btnShowInfoVisits_Click(object sender, EventArgs e)
        {
            string TypeVisit = ComboxTypeVisit.Text.Trim();

 
            switch (TypeVisit)
            {
                case "زيارة طارئه":
                    DT_Visit = ClsCMD_TableVisits.GetEmergencyVisitsFullDetails(DoctorID, VisitRange);
                    break;

                case "زيارة للمتابعة":
                    DT_Visit = ClsCMD_TableVisits.GetFollowUpVisitsFullDetails(DoctorID, VisitRange);
                    break;

                case "زيارة استشارية":
                    DT_Visit = ClsCMD_TableVisits.GetConsultationVisitsFullDetails(DoctorID, VisitRange);
                    break;
            }

            if (DT_Visit != null)
                // عرض واجهة تفاصيل الزيارات ...حسب الاختيار اعلاه
                ShowForm(DT_Visit, PositionType.Visit);

            else
                MessageBox.Show("إختر تفاصيل الزيارة أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion


    }
}

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

namespace Program_Clinic_Management.Doctors.UControls
{
    public partial class CtrlCountVisits_AppointmentsDoctor : UserControl
    {
        public CtrlCountVisits_AppointmentsDoctor()
        {
            InitializeComponent();

            // Panals لون  
            MyTools.ColorControl(Pnl1, Color.FromArgb(253, 253, 253), Color.FromArgb(212, 222, 224), true, false);
            MyTools.ColorControl(Pnl1, Color.FromArgb(253, 253, 253), Color.FromArgb(212, 222, 224), true, false);


        }

        public int DoctorID { get; set; }


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

            // ************************************
            // هون لازم تعرض الواجهة حسب النوع يلي خترته
            // بس حطيت المثود يلي بجيب البيانات مشان ما تتلبك وقت بدك تستدعيه هنيك
            // ************************************

            switch (TypeAppointment)
            {
                case "المواعيد المتبقية":
                     ClsCMD_TableAppointments.GetRemainingAppointmentsWithPatientDetails(DoctorID, AppRange);
                    break;

                case "المواعيد المنتهية":
                      ClsCMD_TableAppointments.GetCompletedAppointmentsFullDetails(DoctorID, AppRange);
                    break;

                case "لم يتم حضورها":
                      ClsCMD_TableAppointments.GetAbsentAppointmentsFullDetails(DoctorID, AppRange);
                    break;
            }
        }


        #endregion


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

            // ************************************
            // هون لازم تعرض الواجهة حسب النوع يلي خترته
            // بس حطيت المثود يلي بجيب البيانات مشان ما تتلبك وقت بدك تستدعيه هنيك
            // ************************************

            switch (TypeVisit)
            {
                case "زيارة طارئه":
                    ClsCMD_TableVisits.GetEmergencyVisitsFullDetails(DoctorID, VisitRange);
                    break;

                case "زيارة للمتابعة":
                    ClsCMD_TableVisits.GetFollowUpVisitsFullDetails(DoctorID, VisitRange);
                    break;

                case "زيارة استشارية":
                    ClsCMD_TableVisits.GetConsultationVisitsFullDetails(DoctorID, VisitRange);
                    break;
            }
        }

        #endregion


    }
}

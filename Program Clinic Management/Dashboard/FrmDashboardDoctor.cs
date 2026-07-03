using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Appointment;
using Program_Clinic_Management.Appointment.UControls;
using Program_Clinic_Management.Manage_Users;
using Program_Clinic_Management.Patients;
using Program_Clinic_Management.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Dashboard
{
    public partial class FrmDashboardDoctor : Form
    {
        public FrmDashboardDoctor()
        {
            InitializeComponent();
            MyTools.SetAppIcon(this);

        }

        // تحميل الفورم
        private void FrmDashboardDoctor_Load(object sender, EventArgs e)
        {
            DisginUI();
            ShowCountAppointmentToday(); // عرض عدد مواعيد اليوم
            ShowLastThreeAppointment();  // عرض اخر 3 مواعيد للمرضى

            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("tt h:mm   yyyy / MM / dd   dddd");

            lblNameUser.Text = "Doctor : "  + ClassUser.UserInfo.PersonInfo.FullName ; // عرض الاسم
        }



        #region  ****  مثود و أوامر  ****

        //الوان الفورم
        void DisginUI()
        {
            MyTools.ColorControl(pnlTopBar, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252));
            //  MyTools.ColorControl(PnlDisplay, Color.FromArgb(186, 249, 253), Color.FromArgb(245, 245, 245));
            MyTools.ColorControl(PnlList, Color.FromArgb(194, 247, 252), Color.FromArgb(245, 245, 245));
        }

        DataTable DatatableAppointmentToday = new DataTable();

        List<ClassAppointment> ListAppointmentDoctor;

        #region  ****  أوامر عرض المواعيد  ****
        /// <summary>
        /// عرض عدد مواعيد اليوم و التفاصيل
        /// </summary>
        void ShowCountAppointmentToday()
        {
            var info = ClsCMD_TableVisits.GetTodayAppointmentsInfo_WithPatientId(ClassUser.UserInfo.DoctorInfo.DoctorID);

            DatatableAppointmentToday = info.List;

            lblTotalAppointment.Text = info.Total.ToString();
            lblRemainingAppointment.Text = info.Remaining.ToString();
        }

        /// <summary>
        /// عرض أخر ثلاث مواعيد
        /// </summary>
        void ShowLastThreeAppointment()
        {
            PnlAppointments.Controls.Clear(); // تنظيف قديم

            ListAppointmentDoctor = ClsCMD_TableAppointments
                .GetLastThreeUpcomingAppointments(ClassUser.UserInfo.DoctorInfo.DoctorID);

            if (ListAppointmentDoctor.Count == 0)
            {
                lblIsNoAppointment.Visible = true;
                return;
            }

            lblIsNoAppointment.Visible = false;

            // إضافة العناصر من الأقدم للأحدث
            foreach (var AppInfo in ListAppointmentDoctor.Reverse<ClassAppointment>())
            {
                Ctrl_ShowFirstAppointmentPatient firstAppointment = new Ctrl_ShowFirstAppointmentPatient();
                firstAppointment.InfoAppointmentPatient = AppInfo; // تعبئة البيانات بالعنصر

                firstAppointment.Dock = DockStyle.Top;
                // إضافة العنصر لل بنل
                PnlAppointments.Controls.Add(firstAppointment);
            }
        }


        #endregion

        #endregion

        // //////////////////////////////////////////////////////////////
        // //////////////////////////////////////////////////////////////

        #region  ****  أزرار وعناصر  ****

        // زر عرض واجهة إدارة المرضى
        private void btnPatients_Click(object sender, EventArgs e)
        {
            FrmManagePatients managePatients = new FrmManagePatients();
            MyTools.ShowForm(managePatients);
        }

        // زر إدارة الزيارات
        private void btn_Visits_Click(object sender, EventArgs e)
        {
            FrmManageVisits manageVisits = new FrmManageVisits();
            MyTools.ShowForm(manageVisits);
        }

        // زر إدارة المواعيد
        private void btn_Appointments_Click(object sender, EventArgs e)
        {
            FrmAppointments frmAppointments = new FrmAppointments();
            MyTools.ShowForm(frmAppointments);
        }

        // زر عرض الملف الشخصي
        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            FrmShowInfoUser showInfoUser = new FrmShowInfoUser(ClassUser.UserInfo.UserID, "My Profile");
            MyTools.ShowForm(showInfoUser);

        }

        // حدث يعمل عند اغلاق الواجهة
        private void FrmDashboardDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            // إظهار شاشة تسجيل الدخول الأصلية
            Application.OpenForms["FrmLogin"].Show();
        }

        //تجسيل الخروج
        private void PicLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            // إظهار شاشة تسجيل الدخول الأصلية
            Application.OpenForms["FrmLogin"].Show();
        }

        // زر تحديث عدد مواعيد اليوم
        private void btnRefreshCountAppointmentToday_Click(object sender, EventArgs e)
        {
            ShowCountAppointmentToday(); // عرض عدد مواعيد اليوم
            ShowLastThreeAppointment();  // عرض اخر 3 مواعيد للمرضى
        }

       

        #endregion

    }
}

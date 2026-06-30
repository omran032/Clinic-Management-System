using BusinessLogic.InfoTable;
using Program_Clinic_Management.Appointment;
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
        }



        // تحميل الفورم
        private void FrmDashboardDoctor_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("tt h:mm   yyyy / MM / dd   dddd");

            lblNameUser.Text = "Doctor : "  + ClassUser.UserInfo.PersonInfo.FullName ; // عرض الاسم
        }


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
    }
}

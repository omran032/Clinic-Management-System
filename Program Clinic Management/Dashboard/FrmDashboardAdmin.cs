using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using BusinessLogic.ToolChart;
using Program_Clinic_Management.Appointment;
using Program_Clinic_Management.Doctors;
using Program_Clinic_Management.Login;
using Program_Clinic_Management.Manage_Users;
using Program_Clinic_Management.Patients;
using Program_Clinic_Management.Payments;
using Program_Clinic_Management.Persons;
using Program_Clinic_Management.Settings.Backup;
using Program_Clinic_Management.Settings.Logs;
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
using System.Windows.Forms.DataVisualization.Charting;
using static BusinessLogic.CMD_DB.ClsCMD_TableVisits;

namespace Program_Clinic_Management.Admin
{
    public partial class FrmDashboardAdmin : Form
    {
        public FrmDashboardAdmin()
        {
            InitializeComponent();
        }

        // تحميل الفورم
        private void FrmDashboardAdmin_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("tt h:mm   yyyy / MM / dd   dddd");

            lblNameUser.Text = ClassUser.UserInfo.Role + " : " +ClassUser.UserInfo.PersonInfo.FullName.Trim(); // عرض الاسم

              LoadData();
            DisginUI();
            DistributionPowers();
        }

        void DisginUI()
        {
            MyTools.ColorControl(pnlTopBar, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252)) ;
            MyTools.ColorControl(ctrl_IconProjectClinic1, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252));
            MyTools.ColorControl(PnlDisplay, Color.FromArgb(186, 249, 253), Color.FromArgb(88, 146, 211));
            MyTools.ColorControl(PnlList, Color.FromArgb(194, 247, 252), Color.FromArgb(121, 243, 252));
        }

     



        /// <summary>
        /// مثود توزيع الصلاحيات
        /// </summary>
        void DistributionPowers()
        {
            string Role = ClassUser.UserInfo.Role;

            if (Role == "Doctor")
            {
                btn_Logs.Visible = false;
                btn_Backup.Visible = false;
                btn_Payments.Visible = false;
            }
            else if (Role == "Reception")
            {
                btn_Logs.Visible = false;
                btn_Backup.Visible = false;
                btn_Doctors.Visible = false;
                btn_ManageUsers.Visible = false;
                btnSettings.Visible = false;
            }
        }


        void LoadData()
        {
            // عرض عدد زيارات اليوم
            ctrl_ShowStatisticscs_Visits.TextLableInfo = ClsCMD_TableVisits.GetVisitsCount(Range.Today).ToString();
            // عرض عدد مواعيد اليوم
            ctrl_ShowStatisticscsAppointment.TextLableInfo = ClsCMD_TableAppointments.GetAppointmentsCount(Range.Today).ToString();
            // عرض عدد غيابات المرضى اليوم   // Appointments اعتمادا على جدول 
            ctrl_ShowStatisticscsAbsences.TextLableInfo    = ClsCMD_TableAppointments.GetAbsencesCount(Range.Today).ToString();
            // عرص المرضى الذين لم يسددو الدفع اليوم
            ctrl_ShowStatisticscs_DelayedPayments.TextLableInfo = ClsCMD_TablePayments.GetUnpaidFinishedAppointments(Range.Today).ToString();


            ////////////////////////     المخططات البيانية    //////////////////////////
            ClsCMD_TableVisits.LoadWeeklyVisitsChart(chartVisits); // مخطط الزيارات
            ClsCMD_TableAppointments.LoadWeeklyAppointmentsDayByDay(ChartAppointment); // عرض مخطط مواعيد الاسبوع
            ClsCMD_TablePayments.LoadWeeklyRevenueDayByDay(chartPayments); // مخطط احصائيات مدفوعات الاسبوع

            //  PnlBackup تعبئة بيانات 
            LoadSystemInfo();

        }


        private void LoadSystemInfo()
        {
            // إصدار البرنامج
            lbl_Virtion.Text +=  MyTools.GetAppVersion();
            // حالة قاعدة البيانات
            lblDatabaseStatus.Text += "متصلة"  ;
            // آخر نسخة احتياطية
            lbl_TimeLastBackup.Text += ClassLogs.GetLastBackupDate();

            // تنصيف النص
            MyTools.LocationIn_Center_X(lbl_Virtion, PnlBackup);
            MyTools.LocationIn_Center_X(lblDatabaseStatus, PnlBackup);
            MyTools.LocationIn_Center_X(lbl_TimeLastBackup, PnlBackup);

        }

        // زر عرض واجهة إدارة الأشخاص
        private void btnPersons_Click(object sender, EventArgs e)
        {
            FrmManagePersons managePersons = new FrmManagePersons();
            MyTools.ShowForm(managePersons);
        }

        // زر عرض واجهة إدارة المرضى
        private void btnPatients_Click(object sender, EventArgs e)
        {
            FrmManagePatients managePatients = new FrmManagePatients();
            MyTools.ShowForm(managePatients);

        }

        // زر عرض واجهة إدارة الأطباء
        private void btn_Doctors_Click(object sender, EventArgs e)
        {
            FrmManageDoctors manageDoctors = new FrmManageDoctors();
            MyTools.ShowForm(manageDoctors);

        }

        // زر النسخ الاحتياطي
        private void btn_Backup_Click(object sender, EventArgs e)
        {
            FrmBackupDB frmBackup = new FrmBackupDB();
            MyTools.ShowForm(frmBackup);

        }

        // زر إدارة المواعيد
        private void btn_Appointments_Click(object sender, EventArgs e)
        {
            FrmAppointments frmAppointments = new FrmAppointments();
            MyTools.ShowForm(frmAppointments);
        }

        // زر إدارة الزيارات
        private void btn_Visits_Click(object sender, EventArgs e)
        {
            FrmManageVisits manageVisits = new FrmManageVisits();
            MyTools.ShowForm(manageVisits);

        }

        // زر اظهار واجهة عرض الموظفين
        private void btn_ManageUsers_Click(object sender, EventArgs e)
        {
            FrmManageUsers manageUsers = new FrmManageUsers();
            MyTools.ShowForm(manageUsers);
        }

        // زر عرض الملف الشخصي
        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            FrmShowInfoUser showInfoUser = new FrmShowInfoUser(ClassUser.UserInfo.UserID , "My Profile");
            showInfoUser.ShowDialog();

        }

        // زر عرض واجهة السجلات
        private void btn_Logs_Click(object sender, EventArgs e)
        {
            FrmLogs frmLogs = new FrmLogs();
            frmLogs.ShowDialog();
        }

        // زر عرض واجهة المدفوعات
        private void btn_Payments_Click(object sender, EventArgs e)
        {
            FrmManagePayments managePayments = new FrmManagePayments();
            MyTools.ShowForm(managePayments);

        }

        // حدث يعمل عند اغلاق الواجهة
        private void FrmDashboardAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // إظهار شاشة تسجيل الدخول الأصلية
          //  Application.OpenForms["FrmLogin"].Show();

        }

        // تسجيل الخروج
        private void PicLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            // إظهار شاشة تسجيل الدخول الأصلية
          //  Application.OpenForms["FrmLogin"].Show();
        }

       
    }
}

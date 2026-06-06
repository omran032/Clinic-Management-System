using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using BusinessLogic.ToolChart;
using Program_Clinic_Management.Doctors;
using Program_Clinic_Management.Patients;
using Program_Clinic_Management.Persons;
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

     //       lblNameUser.Text = ClassUser.UserInfo.PersonInfo.FullName.Trim(); // عرض الاسم

              LoadData();
            DisginUI();
           
        }

        void DisginUI()
        {
            MyTools.ColorControl(pnlTopBar, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252)) ;
            MyTools.ColorControl(ctrl_IconProjectClinic1, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252));
            MyTools.ColorControl(PnlDisplay, Color.FromArgb(186, 249, 253), Color.FromArgb(88, 146, 211));
            MyTools.ColorControl(PnlList, Color.FromArgb(194, 247, 252), Color.FromArgb(121, 243, 252));
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
            ctrl_ShowStatisticscs_DelayedPayments.TextLableInfo = ClsClsCMD_TablePayments.GetUnpaidFinishedAppointments(Range.Today).ToString();


            ////////////////////////     المخططات البيانية    //////////////////////////
            ClsCMD_TableVisits.LoadWeeklyVisitsChart(chartVisits); // مخطط الزيارات
            ClsCMD_TableAppointments.LoadWeeklyAppointmentsDayByDay(ChartAppointment); // عرض مخطط مواعيد الاسبوع
            ClsClsCMD_TablePayments.LoadWeeklyRevenueDayByDay(chartPayments); // مخطط احصائيات مدفوعات الاسبوع

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
    }
}

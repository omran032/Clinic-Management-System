using BusinessLogic;
using BusinessLogic.DB;
using BusinessLogic.InfoTable;
using Microsoft.Win32;
using Program_Clinic_Management.Admin;
using Program_Clinic_Management.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.ClassLogs;


namespace Program_Clinic_Management.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            MyTools.SetAppIcon(this);

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("tt h:mm   yyyy / MM / dd   dddd");

            // عرض معلومات تسجيل الدخول اذا كانت محفوظة
            ShowInfo_RememperMe();
        }


        // زر تسجيل الدخول
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string UserName = TxtUserName.Text.Trim().ToLower();
            string Password = TxtPassword.Text.Trim();

            // هل تم الادخال ؟
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) )
            {
                lblMessageError.Text = "معلومات تسجيل الدخول غير كاملة";
                lblMessageError.Visible = true;
                return;
            }

            string RoleUser = ClassLoginUser.GetUserRole(UserName , Password);
            // هل المعلومات غير صحيحة ؟
            if (RoleUser == null )
            {
                lblMessageError.Text = "أسم المستخدم أو كلمة المرور غير صحيحة";
                lblMessageError.Visible = true;
                return;
            }

            lblMessageError.Visible = false;

            if(RoleUser == "Admin")
            {
                FrmDashboardAdmin dashboardAdmin = new FrmDashboardAdmin();
                dashboardAdmin.ShowDialog();
            }

           else if (RoleUser == "Doctor")
            {
                FrmDashboardDoctor dashboardDoctor = new FrmDashboardDoctor();
                dashboardDoctor.ShowDialog();
            }

            else if (RoleUser == "Reception")
            {
                FrmDashboardAdmin dashboardAdmin = new FrmDashboardAdmin();
                dashboardAdmin.ShowDialog();
            }

           // this.Hide();
            // Logs التسجيل بال
            ClassLogs.AddLog(ClassUser.UserInfo.UserID, LogAction.Login.ToString(), "Users", ClassUser.UserInfo.UserID, "User logged in");

            RememperMe(); // تذكرني ؟
        }


        /// <summary>
        /// المثود المسؤول عن تذكر كلمة المرور
        /// </summary>
        void RememperMe()
        {
            if (chk_RememperMe.Checked) //  تذكرها
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ClinicAppLogin");
                key.SetValue("UserName", TxtUserName.Text);
                key.SetValue("Password", TxtPassword.Text);
                key.Close();
            }
            else // عدم تذكرها
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ClinicAppLogin");
                key.DeleteValue("UserName", false);
                key.DeleteValue("Password", false);
                key.Close();
            }

        }

        /// <summary>
        /// عرض معلومات تسجيل الدخول اذا كانت محفوظة  
        /// </summary>
        void ShowInfo_RememperMe()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\ClinicAppLogin");

            // الحالة الافتراضية: إلغاء التشييك
            chk_RememperMe.Checked = false;

            if (key != null)
            {
                TxtUserName.Text = key.GetValue("UserName", "").ToString();
                TxtPassword.Text = key.GetValue("Password", "").ToString();

                if (!string.IsNullOrEmpty(TxtUserName.Text))
                    chk_RememperMe.Checked = true;
            }
        }


        // زر نسيت كلمة المرور
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "يرجى مراجعة الإدارة لإعادة تعيين كلمة المرور",
              "نسيت كلمة المرور",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
                           );

            // هون يفضل تبدل الرقم صفر ....ب معرف المستخدم الحقيقي
            ClassLogs.AddLog(1, LogAction.ForgotPassword.ToString(), "Users", 1, "User requested password reset");
        }

        // زر اتصل بالإدارة
        private void lbl_CallToManager_Click(object sender, EventArgs e)
        {
            MessageBox.Show("لإنشاء حساب جديد، يرجى مراجعة إدارة العيادة.", "إنشاء حساب", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}

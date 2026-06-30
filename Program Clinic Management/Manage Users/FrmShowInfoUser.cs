using BusinessLogic.CMD_DB;
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

namespace Program_Clinic_Management.Manage_Users
{
    public partial class FrmShowInfoUser : Form
    {
        public FrmShowInfoUser(int UserID_  , string Title  = "Information User")
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);

            UserID = UserID_;
            lblTitle.Text = Title;
        }

        int UserID = 0 ;

        ClassUser UserInfo;

        private void FrmShowInfoUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            if (UserID == 0) return;

            UserInfo = ClsCMD_ManageUsers.GetUserInfo(UserID);

            if (UserInfo == null) return;

            ctrl_PersonInfo1.PersonInfo = UserInfo.PersonInfo;

            lblUserName.Text = UserInfo.UserName;
            lblRole.Text = UserInfo.Role;
            lblIsActive.Text = UserInfo.IsActive ? "Active" : "Inactive";

            lblIsActive.ForeColor = lblIsActive.Text == "Inactive" ? Color.FromArgb(192, 0, 0) : Color.Teal;

            if (UserInfo.DoctorInfo == null) return;
            pnlSpecialization.Visible = true;
            lblSpecialization.Text = UserInfo.DoctorInfo.SprcializationName;

        }

        // زر اغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // زر الاخفاء
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}

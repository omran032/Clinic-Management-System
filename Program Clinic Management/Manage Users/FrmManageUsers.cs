using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Guna.UI2.WinForms;
using Program_Clinic_Management.Persons.UControls;
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
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();

            ClassStyleAndColor.Style_DataGridView(DataGV); // تصميم الجدول
            MyTools.MoveControl(pnl_TopBar, this);
            MyTools.SetAppIcon(this);

        }

        DataTable DatatableUsers = new DataTable();
        int UserIDSelected = 0;

        // تحميل الفورم
        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            LoadDataTable();
        }

        void LoadDataTable()
        {
            DatatableUsers = ClsCMD_ManageUsers.GetUsersForManagement();
            DataGV.DataSource = DatatableUsers;
        }

      



        #region **** أزرار وعناصر  ****

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


        // حدث اختيار الصف بالجدول
        private void DataGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DatatableUsers.Rows.Count == 0) return;
            // منع الخطأ عند الضغط على Header
            if (DataGV.CurrentRow == null) return;
            if (DataGV.CurrentRow.Index < 0) return;

            try
            {
                UserIDSelected = (int)DataGV.CurrentRow.Cells[0].Value;        // معرف المستخدم
            }
            catch { }
        }

        // زر إضافة مستخدم
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateUsers add_UpdateUsers = new FrmAdd_UpdateUsers();
            add_UpdateUsers.EventRefreshData += LoadDataTable; // تحديث عند الاضافة
            MyTools.ShowForm(add_UpdateUsers);
        }

        // زر القائمة لعرض المعلومات
        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e)
        {
            if (UserIDSelected == 0) return;

            FrmShowInfoUser showInfoUser = new FrmShowInfoUser(UserIDSelected);
            MyTools.ShowForm(showInfoUser);

        }

        // زر القائمة لتعديل المستخدم
        private void ToolStripMenu_btnUpdate_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateUsers add_UpdateUsers = new FrmAdd_UpdateUsers(FrmAdd_UpdateUsers.Mode.Update , UserIDSelected);
            add_UpdateUsers.EventRefreshData += LoadDataTable; // تحديث عند الاضافة
            MyTools.ShowForm(add_UpdateUsers);
        }


        #endregion

       
    }
}

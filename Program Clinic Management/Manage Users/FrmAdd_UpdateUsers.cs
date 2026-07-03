using BusinessLogic.CMD_DB;
using BusinessLogic.DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Persons.UControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.ClassLogs;

namespace Program_Clinic_Management.Manage_Users
{
    public partial class FrmAdd_UpdateUsers : Form
    {
        public FrmAdd_UpdateUsers(Mode mode_ = Mode.Add  , int UserID_ = 0 )
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);
            MyTools.SetAppIcon(this);

            ModeForm = mode_;
            UserID_Update = UserID_;
        }

        // حدث يعمل عند الإضافة أو التعديل
        public Action EventRefreshData;

       public enum Mode { Add ,  Update}
        Mode ModeForm;

        ClassPerson PersonInfo;
        ClassUser UserInfo;

        string SelectedRole;
        int     RoleID = 0;
        string SelectedSpecialization;
        int     SpecializationID = 0 ;
        int UserID_Update;

         // تحميل الفورم
        private void FrmAdd_UpdateUsers_Load(object sender, EventArgs e)
        {
            ctrl_FeltterDataPersons1.TrueSearchAll = true;
            // إضافة حدث ارجاع بيانات الشخص عند البحث
            ctrl_FeltterDataPersons1.EventReturnInfoDataPerson += GetPersonInfo;

            // تحميل  اختصاصات الاطباء
            ClsCMD_TableDoctors.LoadSpecializations(ComboxSpicealizations);
            // تحميل الصلاحيات
            ClsCMD_ManageUsers.LoadRoles(ComboxRoles);

            LoadData();
        }

        void LoadData()
        {
            if(ModeForm == Mode.Add)
            {
            }

            else if (ModeForm == Mode.Update)
            {
                btnSave.Text = "تعديل";
                lblTitle.Text = "Update User";
                btnSave.Image = Properties.Resources.Synchronize;

                PnlIsActive.Visible = true;
                if (UserID_Update == null) return;

                UserInfo = ClsCMD_ManageUsers.GetUserInfo(UserID_Update);

                if (UserInfo == null) return;

                PersonInfo = UserInfo.PersonInfo;
                ctrl_PersonInfo1.PersonInfo = UserInfo.PersonInfo;

                TxtUserName.Text = UserInfo.UserName;
                ComboxRoles.Text = UserInfo.Role;

                RdoIsNotActive.Checked = !UserInfo.IsActive;  // عرض اذا كان الحساب فعال
                // اذا المستخدم طبيب ...عرضلي الاختصاص
                if (UserInfo.Role == "Doctor")
                {
                    ComboxSpicealizations.Visible = true;
                    ComboxSpicealizations.Text = UserInfo.DoctorInfo.SprcializationName;
                }

            }
        }

        /// <summary>
        /// تحميل بيانات الشخص ب أوبجكت بعد الفلترة
        /// </summary>
        void GetPersonInfo(ClassPerson PersonInfo_)
        {
            if (PersonInfo_ == null) return;

            PersonInfo = PersonInfo_;
            ctrl_PersonInfo1.PersonInfo = PersonInfo;

            // التحقق من وجود الشخص كمستخدم
            string Role = ClsCMD_ManageUsers.GetUserRoleByPersonId(PersonInfo.PersonID);
            if (Role != null)
            {
                MessageBox.Show(" الشخص موجود كمستخدم فعلي ضمن النظام ولديه صلاحية " + Role, "لا يمكن اضافة هذا المستخدم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            else
                btnSave.Enabled = true;

        }



        /// <summary>
        /// وضع خطأ على العنصر الغير محدد
        /// </summary>
        bool ErrorContrl(Control ctrl, string Message = "هذا الحقل مطلوب")
        {
            string text = ctrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                errorProvider1.SetError(ctrl, Message);
                return true;   // يعني في خطأ
            }
            else
            {
                errorProvider1.SetError(ctrl, null);
                return false;  // يعني ما في خطأ
            }
        }


        #region ****  أزرار وعناصر  ****

        // زر اغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // زر الاخفاء
        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //  إختيار الصلاحية Combox
        private void ComboxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboxRoles.SelectedValue == null) return;
            if (ComboxRoles.SelectedValue is DataRowView) return;

            RoleID = Convert.ToInt32(ComboxRoles.SelectedValue);
            SelectedRole = ComboxRoles.Text;

            if (SelectedRole == "Doctor")
                pnlSpecialization.Visible = true;
            else
                pnlSpecialization.Visible = false;



        }

        //  إختيار اختصاص الطبيب  Combox
        private void ComboxSpicealizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboxSpicealizations.SelectedValue == null) return;
            if (ComboxSpicealizations.SelectedValue is DataRowView) return;

            SelectedSpecialization = ComboxSpicealizations.Text;
              SpecializationID = Convert.ToInt32(ComboxSpicealizations.SelectedValue);

        }


        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            string PassFirst  = TxtPasswordFirst. Text.Trim();
            string PassSecond = TxtPasswordSecond.Text.Trim();
            string UserName = TxtUserName.Text.Trim().ToLower();

            if(PersonInfo == null)
            {
                MessageBox.Show(" حدد معلومات الشخص من خلال البحث عنه ", "لا يمكن الاكمال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // التحقق من ادخال الاختيارات
            if (ErrorContrl(ComboxRoles)) return; if (ErrorContrl(TxtUserName)) return;
            if (ErrorContrl(TxtPasswordFirst)) return; if (ErrorContrl(TxtPasswordSecond)) return;

            if (SelectedRole == "Doctor")
            {
                if (ErrorContrl(ComboxSpicealizations)) return;
            }

                // التحقق من تطابق كلمة المرور //  
                if (PassFirst != PassSecond)
                { 
                    errorProvider1.SetError(TxtPasswordSecond, "كلمة المرور ليست متطابقة");
                    return;
                }
                    errorProvider1.SetError(TxtPasswordSecond,null);

            // تشفير كلمة المرور
            PassFirst = ClassLoginUser.HashPasswordSHA256(PassFirst);

            if (ModeForm == Mode.Add)
            {
               bool result =  ClsCMD_ManageUsers.AddUser(PersonInfo.PersonID, UserName, PassFirst, RoleID, SpecializationID);

                if(result)
                {
                    EventRefreshData?.Invoke(); // تحديث قائمة المستخدمين 
                  MessageBox.Show(" تم إضافة مستخدم جديد بصلاحية" + SelectedRole, "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log(LogAction.AddUser, "Users",0, "إضافة مستخدم جديد");   // تسجيل العمل في Log

                    this.Close();
                }

                else
                    MessageBox.Show(" لم تتم عملية إضافة السمتخدم "  , "لم تنجح عملية الإضافة ,حصل مشكلة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (ModeForm == Mode.Update)
            {
               bool result =  ClsCMD_ManageUsers.UpdateUser(UserID_Update , PersonInfo.PersonID, UserName, PassFirst, RoleID, RdoIsActive.Checked, SpecializationID);

                if (result)
                {
                    EventRefreshData?.Invoke(); // تحديث قائمة المستخدمين 
                    MessageBox.Show(" تم تعديل بيانات مستخدم  " , "تمت عملية التعديل بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log(LogAction.UpdateUser, "Users", UserID_Update, "تعديل بيانات مستخدم");   // تسجيل العمل في Log

                    this.Close();
                }
                else
                    MessageBox.Show(" لم تتم عملية تعديل المستخدم ", "لم تنجح عملية التعديل ,حصل مشكلة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}

using BusinessLogic;
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
using static System.Net.Mime.MediaTypeNames;

namespace Program_Clinic_Management.Persons.UI
{
    public partial class FrmAdd_UpdatePerson : Form
    {
        public FrmAdd_UpdatePerson(Mode mode_ , ClassPerson personInfo_ = null)
        {
            InitializeComponent();

            SettingsControls();


            mode = mode_;

             PersonInfo = personInfo_;
            Load();
        }

        // وضع التشغيل
       public Mode mode;
        public enum Mode
        {
            Add,
            Update
        }

        ClassPerson PersonInfo;

        // تحديد وضع عرض الواجهة ... تعديل _ حذف
        void Load( )
        {
            if(mode == Mode.Add)
            {
                lblTitle.Text = "Add";
                picTitle.Image = Properties.Resources.user;
                btnSave.Image  = Properties.Resources.user;
                btnSave.Text  = "إضافة";

            }
            else if (mode == Mode.Update)
            {
                lblTitle.Text = "Update";
                picTitle.Image = Properties.Resources.Synchronize;
                btnSave.Image = Properties.Resources.Synchronize;
                btnSave.Text = "تعديل";

                LoadInfoPerson();
            }
        }

        // عرض معلومات الشخص لتعديلها
        void LoadInfoPerson()
        {
            if (PersonInfo == null) return;

            lblID.Text       += PersonInfo.PersonID.ToString();
            txtFirstName.Text = PersonInfo.FirstName;
            txtLastName.Text  = PersonInfo.LastName;
            DateTimeP_BirthDate.Value =   PersonInfo.BirthDate  ;
            txtPhone.Text   = PersonInfo.Phone;
            txtAddress.Text = PersonInfo.Address;
            RdoMale.Checked = PersonInfo.Gender == "ذكر";
        }

        // 
       void SaveInfoPerson_InObj()
        {
            PersonInfo = new ClassPerson();
          //  if(mode == Mode.Update)
            int.TryParse(lblID.Text.Replace("ID :", "").Trim() ,out int ID  );
            PersonInfo.PersonID = ID;

            PersonInfo.FirstName = txtFirstName.Text.Trim();
            PersonInfo.LastName  = txtLastName.Text.Trim();
            PersonInfo.BirthDate = DateTimeP_BirthDate.Value;
            PersonInfo.Phone    = txtPhone.Text.Trim();
            PersonInfo.Address  = txtAddress.Text.Trim();
            PersonInfo.Gender   = RdoMale.Checked ? "ذكر" : "أنثى";

        }


        /// <summary>
        /// التحقق من إدخال جميع معلومات الشخص قبل الحفظ.
        /// ترجع true إذا كانت كل الحقول ممتلئة.
        /// </summary>
        public bool IsPersonInfoValid()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) return false;

            if (!RdoMale.Checked && !RdoFemale.Checked)
                return false;

            if (DateTimeP_BirthDate.Value > DateTime.Now)
                return false;

            return true;
        }


        /// <summary>
        /// ضبط العناصر على الشاشة 
        /// </summary>
        void SettingsControls()
        {
            // ضبط شكل ولون البار العلوي و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);

            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this);

            DateTimeP_BirthDate.MaxDate = DateTime.Now.AddMonths(-2);
        }

        //  إغلاق 
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // اخفاء الفورم
        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
     

        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsPersonInfoValid())
            {
                MessageBox.Show("أكمل بقية المعلومات ليتم حفظها", "المعلومات غير مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
             }
            SaveInfoPerson_InObj(); // حفظ المعلومات بالاوبجكت

            if (mode == Mode.Add)
            {
                PersonInfo.PersonID = ClsCMD_TablePersons.AddPerson(PersonInfo);

                //  تغيير الوضع
                mode = Mode.Update;
                Load();
            }

            else if(mode == Mode.Update)
            {
                ClsCMD_TablePersons.UpdatePerson(PersonInfo);
            }
        }
    }
}

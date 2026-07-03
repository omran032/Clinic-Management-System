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
using static BusinessLogic.CMD_DB.ClsCMD_TablePersons;
using BusinessLogic;
using Program_Clinic_Management.Persons.UI;


namespace Program_Clinic_Management.Persons
{
    public partial class FrmManagePersons : Form
    {
        public FrmManagePersons()
        {
            InitializeComponent();
            SettingsControls();
            MyTools.SetAppIcon(this);

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar , this); 
            ClassStyleAndColor.Style_DataGridView(DataGV);
        }

        


        private void FrmManagePersons_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ////////////////////////////////////////////////////////////////

        #region عمليات 

        void LoadData()
        {
            // عرض بيانات الأشخاص
            DataGV.DataSource = ClsCMD_TablePersons.FilterPersons(PersonFilterType.All, null);
        }

        // ارسال حدث للكونترول الخاص بالفلتر ..حتى يتم ارجاع النتيجة بعد كل فلترة
        void LoadDataSearch(DataTable dt)
        { 
            DataGV.DataSource = dt;
        }

        int IndexRowSelected = -1;

        void SettingsControls()
        {
            // ارسال حدث للكونترول الخاص بالفلتر ..حتى يتم ارجاع النتيجة بعد كل فلترة
            ctrl_FeltterDataPersons1.EventShowDataPersonsInDataTable += LoadDataSearch;

            // ارجاع الصف المختار
            MyTools.EnableRightClickSelection(DataGV, MyContextMS, (rowIndex) =>
            {
                // Index Row
                IndexRowSelected = rowIndex;
            });

            GetPersonID(); // GetID
            GetInfoPerson(); // Get Info

        ///////////////////////////////////
            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this); 
        }

        int PersonID = -1;
        // جلب ID الشخص
        void GetPersonID()
        {
            if (IndexRowSelected == -1) return;                        // ID عمود ال
            PersonID = Convert.ToInt32(DataGV.Rows[IndexRowSelected].Cells[0].Value); 
        }


        ClassPerson PersonInfo;

        void GetInfoPerson()
        {
            PersonInfo =  ClsCMD_TablePersons.GetPersonByID(PersonID);
        }

        void Delete()
        {
            if (PersonID == -1)
            {
                MessageBox.Show("حدد الشخص أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassLogs.AddLog(ClassUser.UserInfo.UserID, "DeletePerson", "Persons", PersonID , "حذف شخص");   // تسجيل العمل في Log
                return;
            }
            ClsCMD_TablePersons.DeletePerson(PersonID);
            LoadData();

        }


        #endregion

        // ////////////////////////////////////////////////////////////////


        // زر الحذف
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SettingsControls();
            Delete();
        }
        // زر التعديل
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SettingsControls();

            if (PersonInfo == null)
            {
                MessageBox.Show("حدد الشخص أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAdd_UpdatePerson frmAdd_Update = new FrmAdd_UpdatePerson(FrmAdd_UpdatePerson.Mode.Update, PersonInfo);
            frmAdd_Update.ShowDialog();
            LoadData();
        }

        // زر الإضافة
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdatePerson add_UpdatePerson = new FrmAdd_UpdatePerson(FrmAdd_UpdatePerson.Mode.Add);
            MyTools.ShowForm(add_UpdatePerson);
            LoadData();

        }
        // زر عرض المعلومات
        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e)
        {
            SettingsControls();

            FrmDisplayInfoPerson displayInfoPerson = new FrmDisplayInfoPerson(PersonInfo);
            MyTools.ShowForm(displayInfoPerson);
        }

     

        // زر الاغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // اخفاء الفورم
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

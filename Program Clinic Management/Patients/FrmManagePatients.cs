using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Patients.UI;
using Program_Clinic_Management.Persons.UControls;
using Program_Clinic_Management.Persons.UI;
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

namespace Program_Clinic_Management.Patients
{
    public partial class FrmManagePatients : Form
    {
        public FrmManagePatients()
        {
            InitializeComponent();

            LoadData();
            SettingsControls();

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);
            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this);

        }

        // التحقق اذا كان طبيب 
        bool isDoctor = false;

        private void FrmManagePatients_Load(object sender, EventArgs e) // تحميل الفورم
        {
            // اذا المستخدم طبيب
            // يتم عرض مرضى الطبيب فقط
            if (ClassUser.UserInfo.Role == "Doctor")
            {
                isDoctor = true;

                btnDelete.Visible = false;
                btnAdd.Visible = false;
            }
       }

        void LoadData()
        {
            DT_InfoPatients = ClsCMD_TablePatients.GetAllPatientsWithPersonInfo();
            // تحميل البيانات بالجدول
            DataGV.DataSource = DT_InfoPatients;

            // اخفاء الاعمدة الغير مرادة
            FormatPatientsGrid();
        }

        /// <summary>
        /// إحضار البيانات بعد الفلترة وعرضها بالجدول
        /// </summary>
        void GetDataFeltter(DataTable DataFeltter)
        {
            // تحميل بيانات الفلترة بالجدول
            DataGV.DataSource = DataFeltter;

            // اخفاء الاعمدة الغير مرادة
            FormatPatientsGrid();
        }


        /// <summary>
        /// إخفاء جميع الأعمدة في DataGridView
        /// وإظهار الأعمدة المطلوبة فقط.
        /// </summary>
           void FormatPatientsGrid( )
        {
            if (DataGV.Columns.Count == 0)
                return;

            // إخفاء كل الأعمدة
            foreach (DataGridViewColumn col in DataGV.Columns)
                col.Visible = false;

            // إظهار الأعمدة المطلوبة فقط
            ShowColumn("ID Patiient");
            ShowColumn( "PersonID");
            ShowColumn( "FirstName");
            ShowColumn( "LastName");
            ShowColumn( "BirthDate");
            ShowColumn( "Phone");

            // تحسين عرض الأعمدة
            DataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// مساعد لإظهار عمود إذا كان موجوداً
        /// </summary>
            void ShowColumn(  string columnName)
        {
            if (DataGV.Columns.Contains(columnName))
                DataGV.Columns[columnName].Visible = true;
        }




        DataTable DT_InfoPatients = new DataTable();

        int PatientID = 0;
        int IndexRowSelected = -1;

        // ضبط العناصر
        void SettingsControls()
        {
            // ارسال حدث للكونترول الخاص بالفلتر ..حتى يتم ارجاع النتيجة بعد كل فلترة
            ctrl_FeltterDataPatients1.EventShowDataPatientsInDataTable += GetDataFeltter;

            // ارجاع الصف المختار
            MyTools.EnableRightClickSelection(DataGV, MyContextMS, (rowIndex) =>
            {
                // Index Row
                IndexRowSelected = rowIndex;
            });

            GetPatientID(); // GetID
            GetInfoPatient(); // Get Info

            ///////////////////////////////////

        }


        void GetPatientID()
        {
            if (IndexRowSelected == -1) return;                        // للمريض  ID عمود ال
            PatientID = Convert.ToInt32(DataGV.Rows[IndexRowSelected].Cells[0].Value);
        }


        ClassPatients PatientInfo = new ClassPatients();

        /// <summary>
        /// حفظ معلومات المريض كاملة واحضارها ضمن اوبجكت
        /// </summary>
        void GetInfoPatient()
        {
            if (DT_InfoPatients.Rows.Count == 0 || IndexRowSelected == -1) return;

            PatientInfo =  ClassPatients.GetInfoPatientInObj(DT_InfoPatients, IndexRowSelected);
         }





        void Delete()
        {
            if (PatientID <= 0)
            {
                MessageBox.Show("حدد المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult OptionMessage =   MessageBox.Show("هل انت متاكد من حذف المريض ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OptionMessage == DialogResult.No) return;

            // حذف
         int result =   ClsCMD_TablePatients.DeletePatientByID(PatientID);
            if(result == 1 )
            {     // حفظ العملية بالسجل
                ClassLogs.AddLog(ClassUser.UserInfo.UserID, LogAction.Delete.ToString(), "Patients", PatientID, "حذف المريض");

                LoadData();
            }
        }

        // زر إغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // زر الإخفاء
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // زر التعديل
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SettingsControls();

            if (PatientInfo == null || IndexRowSelected == -1)
            {
                MessageBox.Show("حدد المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAdd_UpdatePatient add_UpdatePatient = new FrmAdd_UpdatePatient(FrmAdd_UpdatePatient.Mode.Update, PatientInfo);
            add_UpdatePatient.EventShowRefrechData += LoadData; // حدث التحديث عند التغيير
            MyTools.ShowForm(add_UpdatePatient);
        }

        // زر الحذف
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SettingsControls();
            Delete();
        }

        // زر الاضافة
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdatePatient add_UpdatePatient = new FrmAdd_UpdatePatient(FrmAdd_UpdatePatient.Mode.Add);
            add_UpdatePatient.EventShowRefrechData += LoadData; // حدث التحديث عند التغيير
            MyTools.ShowForm(add_UpdatePatient);
        }

        // زر عرض معلومات المريض
        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e)
        {
            SettingsControls();
            if (PatientInfo == null)
            {
                MessageBox.Show("حدد المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Frm_InfoPatient  ForminfoPatient = new Frm_InfoPatient(PatientInfo);
            MyTools.ShowForm(ForminfoPatient);
        }

  
    }
}

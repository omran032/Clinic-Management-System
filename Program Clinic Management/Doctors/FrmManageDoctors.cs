using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Patients.UControls;
using Program_Clinic_Management.Patients.UI;
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
using static BusinessLogic.CMD_DB.ClsCMD_TableDoctors;
using Program_Clinic_Management.Doctors.UI;

namespace Program_Clinic_Management.Doctors
{
    public partial class FrmManageDoctors : Form
    {
        public FrmManageDoctors()
        {
            InitializeComponent();

            LoadData();
            SettingsControls();

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);

        }

        #region   **** مثود  مساعدة ****


        DataTable DT_InfoDoctors = new DataTable();

        void LoadData()
        {
            DT_InfoDoctors = ClsCMD_TableDoctors.DesplayAnd_FilterDoctors(DoctorFilterType.All); // بدك تساوي مثود ارجاع البيانات
            // تحميل البيانات بالجدول
            DataGV.DataSource = DT_InfoDoctors;

            // اخفاء الاعمدة الغير مرادة
              FormatPatientsGrid();
        }

        /// <summary>
        /// إخفاء جميع الأعمدة في DataGridView
        /// وإظهار الأعمدة المطلوبة فقط.
        /// </summary>
        void FormatPatientsGrid()
        {
            if (DataGV.Columns.Count == 0)
                return;

            // إخفاء كل الأعمدة
            foreach (DataGridViewColumn col in DataGV.Columns)
                col.Visible = false;

            // إظهار الأعمدة المطلوبة فقط
            ShowColumn("Doctor ID");
            ShowColumn("PersonID");
            ShowColumn("FirstName");
            ShowColumn("LastName");
            ShowColumn("Specialization Name");
            ShowColumn("Phone");

            // تحسين عرض الأعمدة
            DataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// مساعد لإظهار عمود إذا كان موجوداً
        /// </summary>
        void ShowColumn(string columnName)
        {
            if (DataGV.Columns.Contains(columnName))
                DataGV.Columns[columnName].Visible = true;
        }



        int DoctorID = 0;
        int IndexRowSelected = -1;

        // ضبط العناصر
        void SettingsControls()
        {
            // ارسال حدث للكونترول الخاص بالفلتر ..حتى يتم ارجاع النتيجة بعد كل فلترة
        //    ctrl_FeltterDataPatients1.EventShowDataPatientsInDataTable += GetDataFeltter;

            // ارجاع الصف المختار
            MyTools.EnableRightClickSelection(DataGV, MyContextMS, (rowIndex) =>
            {
                // Index Row
                IndexRowSelected = rowIndex;
            });

            GetPatientID(); // GetID
            GetInfoPatient(); // Get Info

            ///////////////////////////////////
            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this);
        }

        void GetPatientID()
        {
            if (IndexRowSelected == -1) return;                        // للطبيب  ID عمود ال
            DoctorID = Convert.ToInt32(DataGV.Rows[IndexRowSelected].Cells[0].Value);
        }


        ClassDoctor DoctorInfo = new ClassDoctor();

        /// <summary>
        /// حفظ معلومات الطبيب كاملة واحضارها ضمن اوبجكت
        /// </summary>
        void GetInfoPatient()
        {
            if (DT_InfoDoctors.Rows.Count == 0 || IndexRowSelected == -1) return;

            DoctorInfo = ClassDoctor.GetInfoDoctorInObj(DT_InfoDoctors, IndexRowSelected);
        }


        void Delete ()
        {
            if (DoctorID <= 0)
            {
                MessageBox.Show("حدد الطبيب أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult OptionMessage = MessageBox.Show("هل انت متاكد من حذف الطبيب ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OptionMessage == DialogResult.No) return;

            // حذف
            int result = ClsCMD_TableDoctors.DeleteDoctor(DoctorID);

            if (result == 1)
            {     // حفظ العملية بالسجل
                ClassLogs.AddLog(ClassUser.UserInfo.UserID, LogAction.Delete.ToString(), "Doctors", DoctorID, "حذف الطبيب");

                LoadData();
            }
        }


        #endregion

        // زر حذف الطبيب
        private void ToolStripMenu_btnDelete_Click(object sender, EventArgs e)
        {
            SettingsControls();
            Delete();
        }


        // زر التعديل
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SettingsControls();

            if (DoctorInfo == null || IndexRowSelected == -1)
            {
                MessageBox.Show("حدد المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //FrmAdd_UpdateDoctor add_UpdateDoctor = new FrmAdd_UpdateDoctor(FrmAdd_UpdatePatient.Mode.Update, DoctorInfo);
            //add_UpdatePatient.EventShowRefrechData += LoadData; // حدث التحديث عند التغيير
            //MyTools.ShowForm(add_UpdateDoctor);
        }

        // زر الإضافة
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //FrmAdd_UpdateDoctor add_UpdatePatient = new FrmAdd_UpdateDoctor(FrmAdd_UpdatePatient.Mode.Add);
            //add_UpdatePatient.EventShowRefrechData += LoadData; // حدث التحديث عند التغيير
            //MyTools.ShowForm(add_UpdatePatient);
        }

        // زر عرض معلومات الطبيب
        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e)
        {
            SettingsControls();
            if (DoctorInfo == null)
            {
                MessageBox.Show("حدد الطبيب أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Frm_InfoDoctor ForminfoPatient = new Frm_InfoDoctor(DoctorInfo);
            MyTools.ShowForm(ForminfoPatient);
        }
    }
}

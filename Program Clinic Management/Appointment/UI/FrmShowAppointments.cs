using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Doctors.UI;
using Program_Clinic_Management.Patients.UControls;
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

namespace Program_Clinic_Management.Appointment.UI
{
    public partial class FrmShowAppointments : Form
    {
        public FrmShowAppointments()
        {
            InitializeComponent();

            ClassStyleAndColor.Style_DataGridView(DataGV);
            MyTools.SetAppIcon(this);

            DistributionPowers();
            LoadDataInTable();

             SettingsControls();
        }



        bool UserIsDoctor = false;
        /// <summary>
        /// مثود عرض الصلاحيات حسب الدور
        /// </summary>
        void DistributionPowers()
        {
            string Role = ClassUser.UserInfo.Role;
            if (Role == "Doctor")
            {
                UserIsDoctor = true;

                btnUpdate.Visible = false;
                // اخفاء خيارات القائمة
                ToolStripMenu_btnUpdate.Visible = false;
                ToolStripMenu_btnDelete.Visible = false;
                ToolStripMenuItem.Visible = false;
                return;
            }
        }








        #region   ***** أوامر *****

        // تحميل البيانات في الجدول 
        void LoadDataInTable()
        {
            DT_InfoPatients = ClsCMD_TableAppointments.GetAppointments(false , UserIsDoctor);
            DataGV.DataSource = DT_InfoPatients;
            FormatPatientsGrid();

            // تسجيل حدث ارجاع جدول البيانات عند الفلترة
            ctrl_FeltterDataAppointment1.EventShowDataAppointmentsInDataTable += LoadDataFeltter;
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
            ShowColumn("AppointmentId");
            ShowColumn("AppointmentDate");
            ShowColumn("Status");
            ShowColumn("PatientName");
            ShowColumn("PatientPhone");
            ShowColumn("DoctorName");
            ShowColumn("DoctorPhone");
            ShowColumn("Specialization");
            ShowColumn("VisitTypeName");

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




        DataTable DT_InfoPatients = new DataTable();
        ClassAppointment AppointmentInfo = new ClassAppointment();
        int IndexRowSelected = -1;
        int AppointmentID = 0;


        void SettingsControls()
        {
            // ارسال حدث للكونترول الخاص بالفلتر ..حتى يتم ارجاع النتيجة بعد كل فلترة
          //  ctrl_FeltterDataPatients1.EventShowDataPatientsInDataTable += GetDataFeltter;

            // ارجاع الصف المختار
            MyTools.EnableRightClickSelection(DataGV, MyContextMS, (rowIndex) =>
            {
                // Index Row
                IndexRowSelected = rowIndex;
            });

            GetAppointmentID(); // GetID
            GetInfoAppointment(); // Get Info

            ///////////////////////////////////

        }

        // ارجاع معرف الموعد الذي تم اختياره
        void GetAppointmentID()
        {
            if (IndexRowSelected < 0) return;

            var cellValue = DataGV.Rows[IndexRowSelected].Cells["AppointmentId"].Value;

            if (cellValue == null || cellValue == DBNull.Value)
                return;

            AppointmentID = Convert.ToInt32(cellValue);
        }


        /// <summary>
        /// حفظ معلومات الموعد كاملة واحضارها ضمن اوبجكت
        /// </summary>
        void GetInfoAppointment()
        {
            if (DT_InfoPatients.Rows.Count == 0 || IndexRowSelected == -1) return;

            AppointmentInfo = ClassAppointment.GetAppointmentById(AppointmentID);
        }


        void LoadDataFeltter(DataTable DT)
        {
            DataGV.DataSource = DT;
            FormatPatientsGrid();
        }

        #endregion


        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////

        #region   ***** أزرار وعناصر *****

        // عرض معلومات الموعد
        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e)
        {
            SettingsControls();
            if (AppointmentID == 0 || AppointmentInfo == null)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            FrmInfoAppointment frmInfoAppointment = new FrmInfoAppointment(AppointmentInfo);
            MyTools.ShowForm(frmInfoAppointment);

        }

        // زر الحذف
        private void ToolStripMenu_btnDelete_Click(object sender, EventArgs e)
        {
            SettingsControls();

            if (AppointmentID == 0)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult Result = MessageBox.Show("هل انت متأكد من حذف الموعد ؟", "تأكيد !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.No) return;



            int result = ClsCMD_TableAppointments.DeleteAppointmentById(AppointmentID);

            if (result == 1)
            {
                MessageBox.Show("تم حذف الموعد بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log(LogAction.DeleteAppointment, "Appointments", AppointmentID, "حذف موعد");   // تسجيل العمل في Log
                LoadDataInTable(); // Reeresh
            }
            else if (result == 0)
            {
                MessageBox.Show("لم يتم العثور على الموعد.", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == -1)
            {
                MessageBox.Show("لا يمكن حذف الموعد لأنه مرتبط بمدفوعات أو زيارات.", "فشل الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //زر التعديل
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SettingsControls();

            if (AppointmentID == 0)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            FrmAdd_UpdateAppointment add_UpdateAppointment = new FrmAdd_UpdateAppointment(FrmAdd_UpdateAppointment.Mode.Update, AppointmentInfo);

            FrmAppointments frm = (FrmAppointments)MyTools.GetOrOpenForm<FrmAppointments>();
            MyTools.SitingsPanel(frm.PnlShowForms, add_UpdateAppointment);

        }


        #endregion

        
    }
}

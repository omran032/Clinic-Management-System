using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Appointment;
using Program_Clinic_Management.Patients.UI;
using Program_Clinic_Management.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.CMD_DB.ClsCMD_TableVisits;

namespace Program_Clinic_Management.Visits
{
    public partial class FrmManageVisits : Form
    {
        public FrmManageVisits()
        {
            InitializeComponent();
            MyTools.SetAppIcon(this);
            MyTools.MoveControl(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);

            LoadData();
        }

        DataTable DatatableVisits = new DataTable();
        ClassAppointment AppointmentInfo = new ClassAppointment();
        int AppointmentID = -1;
        int VisittID = -1;

        // هل المستخدم طبيب ؟
        bool IsDoctor = false;

        void LoadData()
        {
            // عرض الصلاحيات حسب الدور
            DistributionPowers();

            // Combox تعبئة أنواع الزيارات في     
            ClsCMD_TableTypeVisits.FillVisitTypesComboBox(ComboxVisitTypes);
            ComboxVisitTypes.Text = null;

            LoadDataTable();
        }


        ////**********//********//**********//********//**********//********
        ////**********//********//**********//********//**********//********



        #region  **** مثود وأوامر  ****

        void LoadDataTable()
        {
            DatatableVisits = GetVisitsFiltered(VisitFilterType.All, "", 0, 0, null, IsDoctor);
            DataGV.DataSource = DatatableVisits;
        }

        /// <summary>
        /// مثود عرض الصلاحيات حسب الدور
        /// </summary>
        void DistributionPowers()
        {
            string Role = ClassUser.UserInfo.Role;
            if(Role == "Doctor")
            {
                IsDoctor = true;
                lblTitle.Text = "Manage Your Visits";
                btnAddVisit.Visible = false;
                btnDeleteVisit.Visible = false;
                ComboxDoctors.Text = ClassUser.UserInfo.PersonInfo.FullName;
                ToolStrip_btnAddPayment.Visible = false;

                return;
            }

            else if(Role == "Reception")
            {    
            }

            // Combox تعبئة اسماء الاطباء بالعنصر
            ClsCMD_TableDoctors.FillDoctorsComboBox(ComboxDoctors);
            ComboxDoctors.Text = null;
        }



        /// <summary>
        /// حفظ معلومات الموعد كاملة واحضارها ضمن اوبجكت
        /// </summary>
        void GetInfoAppointment()
        {
            if (DatatableVisits.Rows.Count == 0) return;

            // منع الخطأ عند الضغط على Header
            if (DataGV.CurrentRow == null) return;
            if (DataGV.CurrentRow.Index < 0) return;

            VisittID = (int)DataGV.CurrentRow.Cells[0].Value;        // معرف الزيارة
             AppointmentID = (int)DataGV.CurrentRow.Cells[1].Value; // ايجاد معرف الموعد المختار

            AppointmentInfo = ClassAppointment.GetAppointmentById(AppointmentID);
        }

        /// <summary>
        /// عرض معلومات الموعد
        /// </summary>
        void DisplayInfoAppointment()
        {
            if (AppointmentInfo == null) return;

            lblNameDoctor.Text = AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            lblPatientName.Text = AppointmentInfo.PatientsInfo.PersonInfo.FullName;

            lblVisitType.Text = AppointmentInfo.VisitTypeInfo.VisitName;
            lblVisitDate.Text = AppointmentInfo.AppointmentDate.ToString("yyyy / MM / dd ");
            lblTimeAppointment.Text = AppointmentInfo.AppointmentDate.ToString("hh : mm  tt");

            lblDuration.Text = AppointmentInfo.EstimatedDurationMinutes.ToString();
            lblScore.Text = AppointmentInfo.PatientsInfo.StatusComplianceScore;

            // منع الخطأ عند الضغط على Header
            if (DataGV.CurrentRow == null) return;
            if (DataGV.CurrentRow.Index < 0) return;

            string VisitTypes = DataGV.CurrentRow.Cells[4].Value.ToString();
            ComboxVisitTypes.SelectedValue = AppointmentInfo.VisitTypeInfo.VisitTypeID;
        }

        #endregion

       

        ////**********//********//**********//********//**********//********
        ////**********//********//**********//********//**********//********

        #region  **** عناصر وأزرار  ****

        // زر الاغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // زر الاخفاء
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // زر إضافة زيارة جديدة
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateVisit frmAdd = new FrmAdd_UpdateVisit();
            MyTools.ShowForm(frmAdd);
        }

        // زر عرض معلومات المريض
        private void btnShowInfoPatient_Click(object sender, EventArgs e) 
        {
            if (AppointmentInfo.PatientsInfo == null)
            {
                MessageBox.Show("حدد زيارة المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frm_InfoPatient ForminfoPatient = new Frm_InfoPatient(AppointmentInfo.PatientsInfo);
            MyTools.ShowForm(ForminfoPatient);
        }

        // زر حذف الموعد
        private void btnDeleteVisit_Click(object sender, EventArgs e)
        {
            if (VisittID <= 0)
            {
                MessageBox.Show("الرجاء اختيار زيارة أولاً.");
                return;
            }

            ClsCMD_TableVisits.DeleteVisit(VisittID);

            // إعادة تحميل الجدول بعد الحذف
            LoadDataTable();
        }

        // زر فتح واجهة تعديل زيارة
        private void btnUpdateVisit_Click(object sender, EventArgs e)
        {
            if (VisittID <= 0 || AppointmentInfo == null)
            {
                MessageBox.Show("اختر زيارة أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmAdd_UpdateVisit frm = new FrmAdd_UpdateVisit(AppointmentInfo, VisittID);
            MyTools.ShowForm(frm);
        }


        // حدث الضغط على الصف
        private void DataGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DatatableVisits.Rows.Count == 0) return;

            GetInfoAppointment(); // AppointmentInfo تحميل معلومات الموعد

            // عرض المعلومات
            DisplayInfoAppointment();
        }

        string SelectedPatentName;
        string SelectedVisitType;
        string SelectedDoctor;
        DateTime SelectedDate;

        // البحث عن مريض حسب الاسم TextBox
        private void TxtSearchNamePatient_TextChanged(object sender, EventArgs e)  // البحث عن مريض TextBox
        {
            SelectedPatentName = TxtSearchNamePatient.Text.Trim();
        }
        private void TxtSearchNamePatient_KeyPress(object sender, KeyPressEventArgs e) // البحث عن مريض TextBox
        {
            // Enter
            if (e.KeyChar == (char)13)
            {
                e.Handled = true; // يمنع الصوت أو السطر الجديد
                btnSearchFelter.PerformClick(); // ينفذ زر البحث
            }
        }

        //  Combox فلتر اختيار نوع الزيارة
        private void ComboxVisitTypes_SelectedIndexChanged(object sender, EventArgs e) 
        {
            SelectedVisitType = ComboxVisitTypes.Text;
        }

        //  Combox فلتر اختيار الطبيب
        private void ComboxDoctors_SelectedIndexChanged(object sender, EventArgs e)  
        {
            SelectedDoctor = ComboxDoctors.Text;
        }

        // فلتر اختيار التاريخ
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (RdoFalseFelterDate.Checked) return;

            SelectedDate = guna2DateTimePicker1.Value ;

        }

        // زر إضافة دفعة للزيارة
        private void ToolStrip_btnAddPayment_Click(object sender, EventArgs e)
        {
            if (VisittID <= 0) return;

            // فحص اذا كانت الزيارة تم تسجيل دفعة فيها أم لاء
            if (ClsCMD_TablePayments.GetPaymentIdByVisit(VisittID) != null)
            {
                MessageBox.Show("تم دفع رسوم الزيارة ..لذلك لا يمكن إضافة دفعة جديدة عليها", "لا يمكن إضافة دفعة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            FrmAddPayment addPayment = new FrmAddPayment(VisittID);
            MyTools.ShowForm(addPayment);
        }

        // زر عرض كل الزيارات لكل الاطباء
        private void btnShowAllVisits_Click(object sender, EventArgs e)
        {
            RdoFalseFelterDate.Checked = true;
            ComboxVisitTypes.Text = null;
            TxtSearchNamePatient.Text = null;

            LoadDataTable();

            if (!IsDoctor) // مشان ما يمسح اسم الدكتور
            ComboxDoctors.Text = null;
        }

        // زر البحث بعد اختيار نوع الفلترة
        private void btnSearchFelter_Click(object sender, EventArgs e)
        {
            VisitFilterType filterType = VisitFilterType.All;

            // تحويل النصوص إلى ID من الكومبو
            int visitTypeId = 0;
            int doctorId = 0;

            if (ComboxVisitTypes.SelectedValue != null && ComboxVisitTypes.SelectedValue is int)
                visitTypeId = (int)ComboxVisitTypes.SelectedValue;

            if (ComboxDoctors.SelectedValue != null && ComboxDoctors.SelectedValue is int)
                doctorId = (int)ComboxDoctors.SelectedValue;

            // تحديد نوع الفلترة حسب العناصر المختارة
            if (!string.IsNullOrWhiteSpace(SelectedPatentName))
            {
                filterType = VisitFilterType.ByPatientName;
            }
            else if (visitTypeId > 0 && doctorId > 0)
            {
                filterType = VisitFilterType.ByVisitTypeAndDoctor;
            }
            else if (visitTypeId > 0)
            {
                filterType = VisitFilterType.ByVisitType;
            }
            else if (doctorId > 0)
            {
                filterType = VisitFilterType.ByDoctor;
            }
            else
            {
                filterType = VisitFilterType.All;
            }
            // التاريخ اختياري
            DateTime? dateFilter = null;

            if (RdoTrueFelterDate.Checked)  dateFilter = SelectedDate;

            // تنفيذ الفلترة حسب الصلاحية للمستخدم
             DatatableVisits = GetVisitsFiltered(filterType, SelectedPatentName, visitTypeId, doctorId, dateFilter, IsDoctor);

            DataGV.DataSource = DatatableVisits;
        }


        #endregion



     



    }
}

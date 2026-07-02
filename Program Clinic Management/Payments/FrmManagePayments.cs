using BusinessLogic;
using BusinessLogic.CMD_DB;
using Program_Clinic_Management.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.CMD_DB.ClsCMD_TablePayments;

namespace Program_Clinic_Management.Payments
{
    public partial class FrmManagePayments : Form
    {
        public FrmManagePayments()
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);


        }


        DataTable DataTablePayment = new DataTable();

        PaymentFilterType paymentFilterType;

        int VisitID = 0;
        int PaymentID = 0;

        // تحميل الفورم
        private void FrmManagePayments_Load(object sender, EventArgs e)
        {
            LoadData();

            ComboxFelterTypes.Text = "عرض الكل";
        }


        #region ****  مثود وأوامر  ****

        void LoadData()
        {
            LoadDataTableAll();
            // عرض ايرادات العيادة حسب الفترات التالية
            lblRevenueToday.Text = ClsCMD_TablePayments.GetClinicRevenue(RevenueType.Today) + "";
            lblRevenueWeek.Text = ClsCMD_TablePayments.GetClinicRevenue(RevenueType.ThisWeek) + "";
            lblRevenueMounth.Text = ClsCMD_TablePayments.GetClinicRevenue(RevenueType.ThisMonth) + "";
            lblRevenueYear.Text = ClsCMD_TablePayments.GetClinicRevenue(RevenueType.ThisYear) + "";
        }

        void LoadDataTableAll()
        {
            // تحميل كل الدفعات بالجدول
            paymentFilterType = PaymentFilterType.All;
            DataTablePayment = ClsCMD_TablePayments.GetPaymentsFelter(paymentFilterType);
            DataGV.DataSource = DataTablePayment;
        }

        #endregion


        // ///////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////

        #region ****  أزرار زعناصر  ****

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

        // TextBox Felter // Validation
        private void TxtFellterPatientAndDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(paymentFilterType == PaymentFilterType.PatientPhone) // اذا كان الادخال رقم هاتف
               if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                   e.Handled = true;
        }


        // نوع الفلترة  Combox
        private void ComboxFelterTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TypeFelter = ComboxFelterTypes.Text.Trim();

            PnlDate.Visible = false;
            PnlTxt.Visible = false;
            Pnl_BtnSearsh.Visible = true;

            TxtFellterPatientAndDoctor.Text = null;

            switch (TypeFelter)
            {
                case "عرض الكل":
                    Pnl_BtnSearsh.Visible = false;
                    LoadDataTableAll();
                    break;

                case "أسم المريض":
                    PnlTxt.Visible = true;
                    TxtFellterPatientAndDoctor.PlaceholderText = "أدخل أسم المريض";
                    paymentFilterType = PaymentFilterType.PatientName;

                    break;

                case "رقم هاتف المريض":
                    PnlTxt.Visible = true;
                    TxtFellterPatientAndDoctor.PlaceholderText = "أدخل رقم هاتف المريض";
                    paymentFilterType = PaymentFilterType.PatientPhone;

                    break;

                case "الطبيب":
                    PnlTxt.Visible = true;
                    TxtFellterPatientAndDoctor.PlaceholderText = "أدخل أسم الطبيب";
                    paymentFilterType = PaymentFilterType.Doctor;

                    break;

                case "التاريخ":
                    PnlDate.Visible = true;
                    paymentFilterType = PaymentFilterType.DateRange;

                    break;
            }
        }


        // زر البحث
        private void btnSearsh_Click(object sender, EventArgs e)
        {
            string ValueTxt;

            switch (paymentFilterType)
            {
                case PaymentFilterType.PatientName:
                      ValueTxt = TxtFellterPatientAndDoctor.Text;
                      DataTablePayment = ClsCMD_TablePayments.GetPaymentsFelter(paymentFilterType , null , null , null , null , ValueTxt);
                    break;

                case PaymentFilterType.PatientPhone:
                      ValueTxt = TxtFellterPatientAndDoctor.Text;
                      DataTablePayment = ClsCMD_TablePayments.GetPaymentsFelter(paymentFilterType, null, null, null, ValueTxt, null);
                    break;

                case PaymentFilterType.Doctor:
                    ValueTxt = TxtFellterPatientAndDoctor.Text;
                    DataTablePayment = ClsCMD_TablePayments.GetPaymentsFelter(paymentFilterType, null, null, ValueTxt, null, null);
                    break;

                case PaymentFilterType.DateRange:
                    DataTablePayment = ClsCMD_TablePayments.GetPaymentsFelter(paymentFilterType, DateTP_From.Value, DateTP_To.Value, null, null, null);
                    break;
            }

            DataGV.DataSource = DataTablePayment;

        }


        // زر حذف الدفعة
        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (PaymentID <= 0) return;

            ClsCMD_TablePayments.DeletePayment(PaymentID);

            LoadDataTableAll();
        }

        // زر إضافة دفعة
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            // عرض واجهة الزيارات
            // ومنها يتم اختيار الزيارة لربط الدفعة معها
            FrmManageVisits manageVisits = new FrmManageVisits();
            MyTools.ShowForm(manageVisits);
        }

        // زر تعديل دفعة
        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (PaymentID <= 0) return;

            FrmAddPayment addPayment = new FrmAddPayment(PaymentID, FrmAddPayment.Mode.Update);
            addPayment.EventRefreshData += LoadDataTableAll;
            MyTools.ShowForm(addPayment);
        }

        // حدث اختيار صف من الجدول
        private void DataGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DataTablePayment.Rows.Count == 0) return;
            // منع الخطأ عند الضغط على Header
            if (DataGV.CurrentRow == null) return;
            if (DataGV.CurrentRow.Index < 0) return;

            try
            {
                VisitID = (int)DataGV.CurrentRow.Cells[1].Value;        // معرف الزيارة
                PaymentID = (int)DataGV.CurrentRow.Cells[0].Value;     //  معرف  الدفعة
            }
            catch { }

        }


        // زر عرض معلومات الدفعة
        private void ToolStrip_btnInfoPayment_Click(object sender, EventArgs e)
        {
            if (PaymentID <= 0) return;

            FrmInfoPayment infoPayment = new FrmInfoPayment(PaymentID);
            infoPayment.ShowDialog();

        }
        #endregion


    }
}

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

namespace Program_Clinic_Management.Payments
{
    public partial class FrmAddPayment : Form
    {
        public FrmAddPayment(int VisitID_)
        {
            InitializeComponent();
            MyTools.SetAppIcon(this);

            VisitID = VisitID_;
            ModeForm = Mode.Add;
        }

        public FrmAddPayment(int PaymentID_, Mode ModeForm_ )
        {
            InitializeComponent();

            PaymentID = PaymentID_;
            ModeForm = Mode.Update;
        }

        public Action EventRefreshData;
        public enum Mode { Add , Update}
        Mode ModeForm = Mode.Add;
        int VisitID = 0;
        int PaymentID = 0;
        ClassVisit VisitInfo;
        ClassPayments PaymentInfo;

        // تحميل الفورم
        private void FrmAddPayment_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            MyTools.MoveControl(pnl_TopBar, this);

            if (ModeForm == Mode.Add)
            {
                // تحميل بيانات الزيار في العنصر
                ctrlInfoVisit.LoadData(VisitID);
                // تحميل بيانات الزيارة من العنصر
                VisitInfo = ctrlInfoVisit.VisitInfo;
            }

           else if (ModeForm == Mode.Update) // تعديل
            {
                btnSavePayment.Text = "تعديل دفعة";

                if (PaymentID <= 0) return;

                PaymentInfo = ClassPayments.GetPaymentById(PaymentID);
                if (PaymentInfo == null) return;

                // عرض المعلومات
                TxtAmount.Text = (PaymentInfo.Amount + PaymentInfo.Discount).ToString();
                TxtDiscount.Text = PaymentInfo.Discount.ToString();
                lblAmountDue.Text = PaymentInfo.Amount.ToString();
                ComboxTypeAmount.Text = PaymentInfo.PaymentType;
                TxtNotes.Text = PaymentInfo.Notes;

                // تحميل بيانات الزيار في العنصر
                ctrlInfoVisit.LoadData(PaymentInfo.VisitInfo.VisitID);

                // حفظ البيانات
                VisitInfo = PaymentInfo.VisitInfo;
            }

        }

        #region ****  مثود وأوامر   ****


        // لمنع ادخال الاحرف TextBox حدث
        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
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

        /// <summary>
        /// التحقق مما إذا كانت واجهة FrmManagePayments مفتوحة،
        ///— وإذا كانت مفتوحة يتم تنفيذ الميثود LoadDataTableAll داخلها.
        /// </summary>
        public static void RefreshManagePaymentsIfOpen()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmManagePayments managePaymentsForm)
                {
                    managePaymentsForm.LoadDataTableAll();
                    return; // تم التنفيذ
                }
            }
        }

        #endregion


        //*********************************************************
        //*********************************************************
        //*********************************************************


        #region ****  أزرار و عناصر   ****

        int TotalAmount;
        int Discount = 0; // مبلغ الخصم

        // تحديد الخصم TextBox
        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtDiscount.Text.Trim(), out Discount); //  الخصم
            int.TryParse(TxtAmount.Text.Trim(), out int Amount);     // المبلغ الكلي

            TotalAmount = Amount - Discount;
            lblAmountDue.Text = TotalAmount.ToString();
        }

        // زر حفظ الدفعة
        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            if(VisitInfo == null)
            {
                MessageBox.Show("معلومات الزيارة غير مكتملة ..أعد المحاولة", "لم يتم تحديد الزيارة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ErrorContrl(TxtAmount)) return;
            if (ErrorContrl(TxtDiscount)) return;
            if (ErrorContrl(ComboxTypeAmount)) return;

            if(ModeForm == Mode.Add)
            // فحص اذا كانت الزيارة تم تسجيل دفعة فيها أم لاء
            if(ClsCMD_TablePayments.GetPaymentIdByVisit(VisitInfo.VisitID) != null)
            {
                MessageBox.Show("تم دفع رسوم الزيارة ..لذلك لا يمكن إضافة دفعة جديدة عليها", "لا يمكن إضافة دفعة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int personID = VisitInfo.PatientsInfo.PersonInfo.PersonID;
            int AppointmentID = VisitInfo.AppointmentInfo.AppointmentID;
            int visitID = VisitInfo.VisitID;
            string TypePayment = ComboxTypeAmount.Text;
            string Notes = TxtNotes.Text;

            if (ModeForm == Mode.Add) // إضافة
            {
                int PaymentID = ClsCMD_TablePayments.AddPayment(personID, visitID, AppointmentID, TotalAmount, Discount, TypePayment, Notes);

                if (PaymentID > 0)
                {
                    MessageBox.Show(" تم إضافة دفعة جديدة من المريض  ", " الدفعة رقم " + PaymentID, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClassLogs.AddLog(ClassUser.UserInfo.UserID, "AddPayment", "Payments", PaymentID , "إضافة دفعة جديدة");   // تسجيل العمل في Log
                }
                else
                {
                    MessageBox.Show(" لم تنجح عملية إضافة الدفعة", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (ModeForm == Mode.Update) // تعديل
            {
                bool result = ClsCMD_TablePayments.UpdatePayment(personID, TotalAmount, Discount, TypePayment, Notes);
                if (result  )
                {
                    MessageBox.Show("تم تعديل الدفعة بنجاح ", " تمت عملية التعديل "  , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClassLogs.AddLog(ClassUser.UserInfo.UserID, "UpdatePayment", "Payments", personID , "تعديل دفعة");   // تسجيل العمل في Log
                }
                else
                {
                    MessageBox.Show(" لم تنجح عملية تعديل الدفعة", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // تنفيذ حدث التحديث 
            EventRefreshData?.Invoke();
            RefreshManagePaymentsIfOpen(); // تحديث بيانات المدفوعات
        }

        // إغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // زر الاخفاء
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion


    }
}

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

namespace Program_Clinic_Management.Payments.Ctrl
{
    public partial class Ctrl_InfoPayment : UserControl
    {
        public Ctrl_InfoPayment()
        {
            InitializeComponent();
        }


        int PaymentID  ;
        ClassPayments PaymentInfo;


        /// <summary>
        /// تحميل معلومات الدفعة
        /// </summary>
       public void LoadData(int PaymentID_)
        {
            if (PaymentID_ <= 0) return;

            PaymentID = PaymentID_;

            PaymentInfo = ClassPayments.GetPaymentById(PaymentID);

            if (PaymentInfo == null) return;

            lblPaymentID.Text = PaymentID.ToString();
            lblCreateBy.Text  = ClsCMD_ManageUsers.GetUserFullName(PaymentInfo.CreateBy);
            lblAmount.Text    = PaymentInfo.Amount.ToString();
            lblDiscount.Text  = PaymentInfo.Discount.ToString();
            lblTypePayment.Text  = PaymentInfo.PaymentType ;
            lblPaymentDate.Text  = PaymentInfo.PaymentDate.ToString("yyyy / MM / dd _ hh : mm tt");
            TxtNotes.Text        = PaymentInfo.Notes ;
        }







    }
}

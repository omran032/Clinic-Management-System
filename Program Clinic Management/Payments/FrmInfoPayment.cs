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
    public partial class FrmInfoPayment : Form
    {
        public FrmInfoPayment(int PaymentID_)
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);
            MyTools.SetAppIcon(this);

            PaymentID = PaymentID_;
        }

        int PaymentID = 0;


        // تحميل الفورم
        private void FrmInfoPayment_Load(object sender, EventArgs e)
        {
            if (PaymentID <= 0) return;

            // تحميل معلومات الدفعة في العنصر
            ctrl_InfoPayment1.LoadData(PaymentID); 

        }

        // اغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Appointment.UI;
using Program_Clinic_Management.Doctors.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Appointment
{
    public partial class FrmAppointments : Form
    {
        public FrmAppointments()
        {
            InitializeComponent();

            MyTools.MoveControl(pnl_TopBar, this);

        }







        /// <summary>
        /// مثود عرض الصلاحيات حسب الدور
        /// </summary>
        void DistributionPowers()
        {
            string Role = ClassUser.UserInfo.Role;
            if (Role == "Doctor")
            {
                Pnl_Option.Visible = false;
                this.Size = new Size(1471, 615);

                // عرض واجهة الواعيد فقط
                FrmShowAppointments showAppointments = new FrmShowAppointments();
                MyTools.SitingsPanel(PnlShowForms, showAppointments);

                return;
            }
           
        }




        #region  **** ازرار  ****

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


        // زر إضافة موعد
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateAppointment frmAppointments = new FrmAdd_UpdateAppointment();
            MyTools.SitingsPanel(PnlShowForms, frmAppointments); // فتح الفورم داخل البنل
        }


        // فتح واجهة عر ضالمواعيد
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            FrmShowAppointments showAppointments = new FrmShowAppointments();
            MyTools.SitingsPanel(PnlShowForms, showAppointments);
        }


        #endregion


    }
}

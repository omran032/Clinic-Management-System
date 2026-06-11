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

namespace Program_Clinic_Management.Appointment.UI
{
    public partial class FrmInfoAppointment : Form
    {
        public FrmInfoAppointment(ClassAppointment AppointMentInfo_)
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);

            if (AppointMentInfo_ == null) return;

            ctrl_InfoVisits_AppointmentsDoctor1.LoadDataِAppointment(AppointMentInfo_ , true);
            ctrl_InfoVisits_AppointmentsDoctor1.LoadInfoPatient(AppointMentInfo_.PatientsInfo);
        }

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


    }
}

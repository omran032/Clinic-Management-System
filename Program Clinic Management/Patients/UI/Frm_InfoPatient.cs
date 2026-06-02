using BusinessLogic;
using BusinessLogic.InfoTable;
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

namespace Program_Clinic_Management.Patients.UI
{
    public partial class Frm_InfoPatient : Form
    {
        public Frm_InfoPatient(ClassPatients PatientInfo)
        {
            InitializeComponent();

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);
            MyTools.MoveControl(pnl_TopBar, this);

            if (PatientInfo == null) return;

            ctrl_PatientInfo1.PatientsInfo = PatientInfo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

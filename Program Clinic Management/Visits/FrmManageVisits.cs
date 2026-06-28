using Program_Clinic_Management.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Visits
{
    public partial class FrmManageVisits : Form
    {
        public FrmManageVisits()
        {
            InitializeComponent();
        }

        // إضافة زيارة جديدة
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateVisit frmAdd = new FrmAdd_UpdateVisit();
            MyTools.ShowForm(frmAdd);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

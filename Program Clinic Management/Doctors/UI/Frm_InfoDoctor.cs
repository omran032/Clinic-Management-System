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

namespace Program_Clinic_Management.Doctors.UI
{
    public partial class Frm_InfoDoctor : Form
    {
        public Frm_InfoDoctor(ClassDoctor DoctorInfo_)
        {
            InitializeComponent();

            DoctorInfo = DoctorInfo_;
        }

        ClassDoctor DoctorInfo;

    }
}

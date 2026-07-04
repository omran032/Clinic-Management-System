using BusinessLogic;
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

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);
            MyTools.MoveControl(pnl_TopBar, this);
            MyTools.SetAppIcon(this);

            if (DoctorInfo_ == null || DesignMode) return;

            DoctorInfo = DoctorInfo_;

            LoadData();

        }

        ClassDoctor DoctorInfo;

        void LoadData()
        {
            ctrl_PersonInfo1.PersonInfo = DoctorInfo.PersonInfo;
            // الاختصاص
            lblSpecialization.Text =  DoctorInfo.SprcializationName;

            // حساب فترة توظيف الطبيب
            string WorkPeriod =  MyTools.GetDateDifferenceText( Convert.ToDateTime(DoctorInfo.PersonInfo.CreatedAt) );
            lbl_WorkPeriod.Text =   WorkPeriod;
            // عرض معلومات المواعيد و الزيارات لدى الطبيب
            ctrlCountVisits_AppointmentsDoctor1.LoadData(DoctorInfo.DoctorID);
        }

        // زر إغلاق
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

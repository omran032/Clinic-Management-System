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

namespace Program_Clinic_Management.Visits.UControls
{
    public partial class CtrlInfoVisit : UserControl
    {
        public CtrlInfoVisit()
        {
            InitializeComponent();
        }

        // معلومات الزيارة 
      public  ClassVisit VisitInfo;

        /// <summary>
        /// تحميل معلومات الزيارة ..بعد ارسال معرف الزيارة 
        /// </summary>
      public  void LoadData(int VisitID)
        {
            if (VisitID <= 0) return;

            // تعبئة معلومات الزيارة كاملة ..مع كافة التفاصيل
            VisitInfo = ClassVisit.GetVisitById(VisitID);

            if (VisitInfo == null) return;

            ShowInfoOnCtrl();

        }

        /// <summary>
        /// عرض المعلومات في العنصر
        /// </summary>
        void ShowInfoOnCtrl()
        {
            lblPatientName.Text = VisitInfo.PatientsInfo.PersonInfo.FullName;
            lblDoctorName.Text = VisitInfo.DoctorInfo.PersonInfo.FullName;
            lblVisitType.Text = VisitInfo.VisitTypeInfo.VisitName;
            lblAppointmentDate.Text = VisitInfo.AppointmentInfo.AppointmentDate.ToString("yyyy  /MM / dd _ hh : mm tt");
            lblVisitDate.Text = VisitInfo.VisitDate.ToString("yyyy / MM / dd");
            lblVisitTime.Text = VisitInfo.StartTime.ToString("hh : mm tt");
        }


    }
}

using BusinessLogic.AppointmentSmartEngine;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Patients.UControls;
using Program_Clinic_Management.Patients.UI;
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
    public partial class FrmAdd_UpdateAppointment : Form
    {
        public FrmAdd_UpdateAppointment(Mode ModeForm_ = Mode.Add , ClassAppointment AppointmentInfo_ = null)
        {

            InitializeComponent();

            LoadData();
            ModeForm = ModeForm_;

            if (ModeForm == Mode.Add)
            {
                // حالة الموعد ثابتة عند الإضافة
                Combox_StatusAppointment.Enabled = false;
                Combox_StatusAppointment.Text = "Pending"; //  قيد الانتظار
            }

            else if(ModeForm == Mode.Update)
            {
                if (AppointmentInfo_ == null) return;

                AppointmentInfo = AppointmentInfo_;
                LoadModeUpdate();
            }

        }
      

        public enum Mode { Add , Update}

        Mode ModeForm = Mode.Add;
        ClassAppointment AppointmentInfo ;


      






        int doctorId = 0;
        ClassDoctor DoctorInfo;
        ClassPatients PatientInfo;
        bool ChoiceDoctor = false;
        bool ChoicePatient = false;


        #region   ****** أوامر  *****

        void LoadData()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // تسجيل الحدث عند اختيا المريض لعرض بياناته
            ctrl_FeltterDataPatients1.EventReturnInfoDataPatient += LoadInfoPatent;
            // اخفاء خيار عرض الكل
            ctrl_FeltterDataPatients1.TrueSearchAll = true;

            // Combox تعبئة اسماء الاطباء بالعنصر
            ClsCMD_TableDoctors.FillDoctorsComboBox(ComboxDoctors);
            ComboxDoctors.Text = null;

            // Combox تعبئة انواع الزيارات داخل العنصر
            ClsCMD_TableTypeVisits.FillVisitTypesComboBox(Combx_TypeVisit);
            Combx_TypeVisit.Text = null;

            // StatusAppointment  Combox تعبئة حالات الموعد ب عنصر
            ClassAppointment.FillComboWithList(Combox_StatusAppointment);

            // تصغير حجم البنل لقتراح الموعد
            pnl_AI.Size = new Size(1447, 100);


        }


        // مثود لتحميل معلومات المريض بعد البحث
        void LoadInfoPatent(ClassPatients PatientInfo_)
        {
            PatientInfo = PatientInfo_;

            if (PatientInfo != null)
            {
                lblNamePatients.Text = "Name : " + PatientInfo_.PersonInfo.FullName;
                lbl_PatientID.Text = "ID : " + PatientInfo_.PatientID;
                lblGenderPatient.Text = "Gender : " + PatientInfo_.PersonInfo.Gender;
                lblAgePatient.Text = "Age : " + PatientInfo_.PersonInfo.Age;

                ChoicePatient = true; // تم تحديد المريض
            }
        }

        //تحميل بيانات الطبيب
        void LoadInfoDoctor(ClassDoctor InfoDoctor_)
        {
            if (InfoDoctor_ != null)
            {
                lbl_NameDoctor.Text = "Name Doctor : " + InfoDoctor_.PersonInfo.FullName;
                lbl_DoctorID.Text = "ID : " + doctorId;

                int CountAppointment = ClsCMD_TableAppointments.GetRemainingAppointmentsByDoctor(doctorId, ClsCMD_TableAppointments.AppointmentRange.Today);
                lbl_CountAppointmentDoctor.Text = "Number of appointments : " + CountAppointment;

                ChoiceDoctor = true; // / تم تحديد الطبيب
            }
        }


        /// <summary>
        /// تحميل وضع التعديل وعرض البيانات
        /// </summary>
        void LoadModeUpdate()
        {
            if (AppointmentInfo == null || ModeForm != Mode.Update) return;

            doctorId = AppointmentInfo.DoctorInfo.DoctorID;
            ComboxDoctors.SelectedValue = doctorId;

            lblAppointmentID.Visible = true;
            lblAppointmentID.Text = "Appointment ID : " + AppointmentInfo.AppointmentID;

            DoctorInfo = AppointmentInfo.DoctorInfo;
            // عرض بيانات المريض و الطبيب
            LoadInfoPatent(AppointmentInfo.PatientsInfo);
            LoadInfoDoctor(DoctorInfo);

            ChoiceDoctor = true;
            ChoicePatient = true;

            // مدة الموعد
            numeric_TimeApp.Value = AppointmentInfo.EstimatedDurationMinutes;
            // تاريخ و الوقت
            DateTP_DateApp.Value = AppointmentInfo.AppointmentDate;

            // VisitType نوع الزيارة
            Combx_TypeVisit.SelectedValue = AppointmentInfo.VisitTypeInfo.VisitTypeID;

            // عرض حالة الموعد
            Combox_StatusAppointment.Enabled = true;
            Combox_StatusAppointment.Text = AppointmentInfo.Status;

            // ملاحظات الموعد
            txtNotes.Text = AppointmentInfo.Appointment_Notes;

            btnSave.Text = "تعديل الموعد";
            btnSave.Image = Properties.Resources.Synchronize;

        }

        /// <summary>
        /// مثود التحقق من الادخال
        /// </summary>
        bool InputVerification()
        {
            if (!ChoicePatient) return false;
            else if (!ChoiceDoctor) return false;
            else if (ComboxDoctors.SelectedIndex == -1) return false;
            else if (Combx_TypeVisit.SelectedIndex == -1) return false;

            return true;

        }

        #endregion



        // تحميل الفورم
        private void FrmAdd_UpdateAppointment_Load(object sender, EventArgs e)
        {
            if(ModeForm == Mode.Add)
            {
                // منع اختيار الموعد قبل التاريخ الحالي
                DateTP_DateApp.MinDate = DateTP_DateApp.Value;
            }
        }


        #region  ***** العناصر *****

        // اختيار الطبيب Combox
        private void ComboxDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ComboxDoctors.SelectedValue == null) return;
            if (ComboxDoctors.SelectedValue is DataRowView) return;

            doctorId = Convert.ToInt32(ComboxDoctors.SelectedValue);

              DoctorInfo = ClassDoctor.GetDoctorInfo(doctorId);

            //تحميل بيانات الطبيب
            LoadInfoDoctor(DoctorInfo);

        }

        int VisitTypeID = 0;
        // VisitType   تحديد نوع الزيارة Combox
        private void Combx_TypeVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combx_TypeVisit.SelectedValue == null) return;
            if (Combx_TypeVisit.SelectedValue is DataRowView) return;

            VisitTypeID = Convert.ToInt32(Combx_TypeVisit.SelectedValue);
        }


        //DateTimePicer عنصر اختيار الموعد
        private void DateTP_DateApp_ValueChanged(object sender, EventArgs e)
        {
            //DateTime selected = DateTP_DateApp.Value;

            //// إذا اختار وقت قد مضى
            //if (selected < DateTime.Now)
            //{
            //   // MessageBox.Show("لا يمكن اختيار موعد قد مضى", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    // hourse 1 +  رجّع الوقت الحالي
            //    DateTP_DateApp.Value = DateTime.Now.AddHours(1);
            //    return;
            //}
        }


        // زر عرض معلومات الطبيب
        private void link_InfoDoctor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(DoctorInfo != null)
            {
                Frm_InfoDoctor frm_Info = new Frm_InfoDoctor(DoctorInfo);
                MyTools.ShowForm(frm_Info);
            }
            else
            {
                MessageBox.Show("حدد الطبيب أولاً", "لا يوجد معلومات", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        // زر عرض مواعيد الطبيب
        private void btn_SHowAppointmentDoctor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("غير مفعل");
        }


        // عرض معلومات المريض
        private void link_InfoPatient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(PatientInfo != null)
            {
               Frm_InfoPatient _InfoPatient = new Frm_InfoPatient(PatientInfo);
                MyTools.ShowForm(_InfoPatient);
            }
            else
            {
                MessageBox.Show("حدد المريض أولاً", "لا يوجد معلومات", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        int TimeApp = 15;
        // عنصر تحديد  فترة الموعد بالدقائق
        private void numeric_TimeApp_ValueChanged(object sender, EventArgs e)
        {
            TimeApp = (int)numeric_TimeApp.Value;
            AppointmentInfo.EstimatedDurationMinutes = TimeApp;
        }

        SuggestedAppointment result ;


        // زر اقتراح موعد
        private void btnProposeDate_Click(object sender, EventArgs e)
        {
            if (!ChoiceDoctor)
            {
                MessageBox.Show("حدد الطبيب أولاً", "لا يوجد معلومات", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


              result = ClsAppointmentSmartEngine.SuggestAppointment
                    (
                        doctorId: doctorId,
                        rangeOption: Range,        // تحديد متى يريد الموعد
                        mode: searchMode,         // تحديد اذا الموعد قريب ام بعيد
                        requiredDuration: TimeApp // مدة الموعد المحدد
                    );

            pnl_AI.Size = new Size(1447, 213);

            if (result.SuggestedDateTime == DateTime.MinValue) // لم يتم ايجاد موعد
            {
                lblMessageResult.Text = result.Reason; // رسالة عدم ايجاد موعد

                btn_UseDate.Enabled = false;
                lblDate.Visible = false;

            }
            else // تم ايجاد موعد
            {
                lblMessageResult.Text = result.Reason; // رسالة ايجاد موعد
                lblDate.Text = result.SuggestedDateTime.ToString("yyyy/MM/dd hh:mm tt");

                btn_UseDate.Enabled = true;
                lblDate.Visible = true;
            }

          

        }

        // زر استخدام التاريخ المقترح
        private void btn_UseDate_Click(object sender, EventArgs e)
        {
            if (result != null)
            {
                DateTP_DateApp.Value = result.SuggestedDateTime;
            }
            else
                MessageBox.Show("لم يتم تحديد الموعد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!InputVerification() )
            {
                MessageBox.Show("المعلومات غير مكتملة" , "ادخل بقية المعلومات" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            DateTime AppointmentDate = DateTP_DateApp.Value;
            string Notes = txtNotes.Text.Trim();
            string StatusAppointment = Combox_StatusAppointment.Text.Trim();

            if (ModeForm == Mode.Add)
            {
                if (ClsCMD_TableAppointments.HasFuturePendingAppointment(PatientInfo.PatientID))
                {
                    MessageBox.Show("لا يمكن إضافة موعد جديد \n لان المريض لديه موعد غير مكتمل بعد", "وجود موعد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ResultAdd = ClsCMD_TableAppointments.AddAppointmentWithCheck(doctorId, PatientInfo.PatientID, VisitTypeID, AppointmentDate, TimeApp, StatusAppointment, Notes);

                if (ResultAdd > 0)
                {
                    lblAppointmentID.Visible = true;
                    lblAppointmentID.Text = "Appointment ID : " + ResultAdd;
                    MessageBox.Show("تم إضافة الموعد بنجاح", "تم الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // هون فيك تحول شكل لواجهة لوضع التعديل تلقائيا اذا بدك
                    return;
                }
                else if (ResultAdd == 0)
                {
                    MessageBox.Show("لم يتم الاضافة لانه يوجد موعد في نفس الوقت المحدد", "موعد محجوز", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                else if (ResultAdd == -1)
                {
                    MessageBox.Show("لم تنجح عملية الإضافة", " فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


           else if (ModeForm == Mode.Update)
            {
                int ResultUpdate = ClsCMD_TableAppointments.UpdateAppointmentWithCheck
                    (AppointmentInfo.AppointmentID, doctorId, PatientInfo.PatientID, VisitTypeID, AppointmentDate, TimeApp, StatusAppointment, Notes);
                if (ResultUpdate > 0)
                {
                    MessageBox.Show("تم تعديل الموعد بنجاح", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (ResultUpdate == 0)
                {
                    MessageBox.Show("لم يتم تعديل لانه يوجد موعد في نفس الوقت المحدد", "موعد محجوز", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                else if (ResultUpdate == -1)
                {
                    MessageBox.Show("لم تنجح عملية التعديل", " فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }












        #region  **** عناصر الراديو  ****

        ClsAppointmentSmartEngine.TimeRangeOption Range = ClsAppointmentSmartEngine.TimeRangeOption.Today;
        ClsAppointmentSmartEngine.SearchMode searchMode = ClsAppointmentSmartEngine.SearchMode.Closest;
        // تحديد فترة اليوم Rdo 
        private void RdoRangeToday_CheckedChanged(object sender, EventArgs e)
        {
            Range = ClsAppointmentSmartEngine.TimeRangeOption.Today;
        }
        // تحديد فترة غدا Rdo 
        private void RdoRangeTomorrow_CheckedChanged(object sender, EventArgs e)
        {
            Range = ClsAppointmentSmartEngine.TimeRangeOption.Tomorrow;
        }

        // تحديد فترة هذا الأسبوع Rdo 
        private void RdoRangeThisWeek_CheckedChanged(object sender, EventArgs e)
        {
            Range = ClsAppointmentSmartEngine.TimeRangeOption.ThisWeek;
        }

        // تحديد فترة هذا الشهر Rdo 
        private void RdoRangeThisMonth_CheckedChanged(object sender, EventArgs e)
        {
            Range = ClsAppointmentSmartEngine.TimeRangeOption.ThisMonth;
        }

        // تحديد اقرب موعد
        private void RdoNearestAppointment_CheckedChanged(object sender, EventArgs e)
        {
            searchMode = ClsAppointmentSmartEngine.SearchMode.Closest;
        }

        // تحديد ابعد موعد
        private void RdoLatestAppointment_CheckedChanged(object sender, EventArgs e)
        {
            searchMode = ClsAppointmentSmartEngine.SearchMode.Farthest;
        }






        #endregion

        #endregion

       
    }
}

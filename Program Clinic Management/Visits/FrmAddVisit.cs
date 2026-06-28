using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Appointment;
using Program_Clinic_Management.Appointment.UI;
using Program_Clinic_Management.Doctors.UI;
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
using static BusinessLogic.CMD_DB.ClsCMD_TableAppointments;

namespace Program_Clinic_Management.Visits
{
    public partial class FrmAdd_UpdateVisit : Form
    {
        public FrmAdd_UpdateVisit( )
        {
            InitializeComponent();

            Mode_ = Mode.Add;
            LoadData();
        }

        public FrmAdd_UpdateVisit(Mode mode, ClassAppointment AppointmentInfo_ , int VisitID_)
        {
            InitializeComponent();

            Mode_ = mode;
            AppointmentInfo = AppointmentInfo_;
            VisitID = VisitID_;
            LoadData();
        }


        DataTable DataAppointments = new DataTable();
        AppointmentFilterType filterType = AppointmentFilterType.TodayAllDoctors;

        // وضع الفورم
      public  enum Mode   {Update , Add }
        Mode Mode_ = Mode.Add;

        ClassDoctor DoctorInfo;
        ClassAppointment AppointmentInfo = new ClassAppointment();

        int VisitTypeIDSelected = -1;
        int DoctorIDSelected = -1;
        int AppointmentID = -1;
        int VisitID;
        void LoadData()
        {
            MyTools.MoveControl(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);

            if (Mode_ == Mode.Add)
            {
                // Combox تعبئة اسماء الاطباء بالعنصر
                ClsCMD_TableDoctors.FillDoctorsComboBox(ComboxDoctors);
                AddSelextAllDoctor(); // All إضافة خيار 
                ComboxDoctors.Text = "All";

                ClsCMD_TableTypeVisits.FillVisitTypesComboBox(ComboxVisitTypes);
                ComboxVisitTypes.Text = null;

                CombxStatusVisit.Text = "In Progress";

                // عرض كل مواعيد  لكل الأطباء
                DisplayAllAppointment();
            }

            else if (Mode_ == Mode.Update)
            {
                lblTitle.Text = "Update Visit";
                btnSaveVisit.Text = "تعديل الزيارة";
                ComboxDoctors.Enabled = false;
                btnShowInfoDoctor.Visible = true;

                DisplayInfoAppointment();
                CombxStatusAppointment.Text = AppointmentInfo.Status;

            }
        }

                        ////**********//********//**********//********//**********//********
                        ////**********//********//**********//********//**********//********

        #region  **** أوامر  ****


        /// <summary>
        /// إضافة خيار عرض  مواعيد كل الاطباء
        /// </summary>
        void AddSelextAllDoctor()
        {
            DataTable dt = (DataTable)ComboxDoctors.DataSource;
            DataRow row = dt.NewRow();
            row["DoctorID"] = -1;           // قيمة خاصة للعنصر اليدوي
            row["DoctorName"] = "All";      // النص الظاهر
            dt.Rows.InsertAt(row, 0);       // ضيفه بأول القائمة

            ComboxDoctors.DataSource = dt;
            ComboxDoctors.DisplayMember = "DoctorName";
            ComboxDoctors.ValueMember = "DoctorID";
        }


        /// <summary>
        /// مثود لعرض كل مواعيد  لكل الأطباء
        /// </summary>
        void DisplayAllAppointment()
        {
            DataAppointments = ClsCMD_TableAppointments.GetAppointments(filterType);
            DataGV.DataSource = DataAppointments;
        }

        void DisplaylAppointmentDoctor()
        {
            if (DoctorIDSelected <= 0) return;

            DataAppointments = ClsCMD_TableAppointments.GetAppointments(filterType, DoctorIDSelected);
            DataGV.DataSource = DataAppointments;
        }


        public Action EventRefreshInfoVisits; // تحديث البيانات عند إضافة زيارة



        /// <summary>
        /// حفظ معلومات الموعد كاملة واحضارها ضمن اوبجكت
        /// </summary>
        void GetInfoAppointment()
        {
            if (DataAppointments.Rows.Count == 0 || AppointmentID <= 0) return;

            AppointmentInfo = ClassAppointment.GetAppointmentById(AppointmentID);
        }


        void DisplayInfoAppointment()
        {
            if (AppointmentInfo == null) return;

            lblNameDoctor.Text = AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            lblPatientName.Text = AppointmentInfo.PatientsInfo.PersonInfo.FullName;

            lblVisitType.Text = AppointmentInfo.VisitTypeInfo.VisitName;
            lblVisitDate.Text = AppointmentInfo.AppointmentDate.ToString("yyyy / MM / dd ");
            lblTimeAppointment.Text = AppointmentInfo.AppointmentDate.ToString("hh : mm  tt");

            lblDuration.Text = AppointmentInfo.EstimatedDurationMinutes.ToString();
            lblScore.Text = AppointmentInfo.PatientsInfo.StatusComplianceScore;


            ComboxVisitTypes.SelectedValue = AppointmentInfo.VisitTypeInfo.VisitTypeID;
            CombxStatusAppointment.Text = "In Progress";
        }

        /// <summary>
        /// وضع خطأ على العنصر الغير محدد
        /// </summary>
        bool ErrorContrl(Control ctrl, string Message = "هذا الحقل مطلوب")
        {
            string text = ctrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                errorProvider1.SetError(ctrl, Message);
                return true;   // يعني في خطأ
            }
            else
            {
                errorProvider1.SetError(ctrl, null);
                return false;  // يعني ما في خطأ
            }
        }

        #endregion

                        ////**********//********//**********//********//**********//********
                        ////**********//********//**********//********//**********//********

        #region  **** عناصر وأزرار  ****

        private void btnClose_Click(object sender, EventArgs e) // زر الاغلاق
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)  // زر الاخفاء
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnRefreshDataTable_Click(object sender, EventArgs e) // تحديث بيانات الجدول
        {
            DisplaylAppointmentDoctor();
        }

        private void ComboxVisitTypes_SelectedIndexChanged(object sender, EventArgs e) // تحديد نوع الزيارة
        {
            if (ComboxVisitTypes.SelectedValue == null) return;
            if (ComboxVisitTypes.SelectedValue is DataRowView) return;

            VisitTypeIDSelected = Convert.ToInt32(ComboxVisitTypes.SelectedValue);
        }
        private void ComboxDoctors_SelectedIndexChanged(object sender, EventArgs e) // اختيار الطبيب Combox
        {
            if (ComboxDoctors.SelectedValue == null) return;
            if (ComboxDoctors.SelectedValue is DataRowView) return;

            if(ComboxDoctors.Text == "All")
            {
                filterType = AppointmentFilterType.TodayAllDoctors;
                DisplayAllAppointment();
                btnShowInfoDoctor.Visible = false;
                lblSpecialization.Text = null;
                return;
            }
             
            btnShowInfoDoctor.Visible = true;
            DoctorIDSelected = Convert.ToInt32(ComboxDoctors.SelectedValue);

            DoctorInfo = ClassDoctor.GetDoctorInfo(DoctorIDSelected);
            lblSpecialization.Text = " الإختصاص : " + DoctorInfo.SprcializationName;

            filterType = AppointmentFilterType.TodayByDoctor;
            DisplaylAppointmentDoctor();
        }

        private void btnShowInfoDoctor_Click(object sender, EventArgs e) // زر عرض معلومات الطبيب
        {
            if (ComboxDoctors.SelectedValue == null) return;
            if (ComboxDoctors.SelectedValue is DataRowView) return;

            DoctorIDSelected = Convert.ToInt32(ComboxDoctors.SelectedValue);

            DoctorInfo = ClassDoctor.GetDoctorInfo(DoctorIDSelected);

            Frm_InfoDoctor infoDoctor = new Frm_InfoDoctor(DoctorInfo);
            MyTools.ShowForm(infoDoctor);
        }
      
        private void DataGV_SelectionChanged(object sender, EventArgs e) // حدث الضغط على الصف
        {
            if (DataAppointments.Rows.Count == 0) return;

            AppointmentID = (int)DataGV.CurrentRow.Cells[0].Value; // ايجاد معرف الموعد المختار
            GetInfoAppointment(); // AppointmentInfo تحميل معلومات الموعد

            btnSaveVisit.Visible = true;

            // عرض المعلومات
            DisplayInfoAppointment();

          
        }

        private void ToolStripMenu_btnShowInfo_Click(object sender, EventArgs e) // خيار عرض معلومات الموعد
        {
            if (DataAppointments.Rows.Count == 0) return;

            if (AppointmentID <= 0 || AppointmentInfo == null)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            // CellClick يتم تحميل معلومات الموعد من حدث الضغط على الصف
            FrmInfoAppointment frmInfoAppointment = new FrmInfoAppointment(AppointmentInfo);
            MyTools.ShowForm(frmInfoAppointment);
        }

        private void ToolStripMenu_btnUpdate_Click(object sender, EventArgs e) // زر تعديل الموعد
        {
            if (AppointmentInfo == null)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            FrmAdd_UpdateAppointment add_UpdateAppointment = new FrmAdd_UpdateAppointment(FrmAdd_UpdateAppointment.Mode.Update, AppointmentInfo);

            FrmAppointments frm = (FrmAppointments)MyTools.GetOrOpenForm<FrmAppointments>();
            MyTools.SitingsPanel(frm.PnlShowForms, add_UpdateAppointment);
        }

        private void ToolStripMenu_btnInfoPatient_Click(object sender, EventArgs e) // زر عرض معلومات المريض
        {
            if (AppointmentInfo.PatientsInfo == null)
            {
                MessageBox.Show("حدد موعد المريض أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Frm_InfoPatient ForminfoPatient = new Frm_InfoPatient(AppointmentInfo.PatientsInfo);
            MyTools.ShowForm(ForminfoPatient);
        }


        private void btnSaveVisit_Click(object sender, EventArgs e) // زر حفظ الزيارة
        {
            if (DataAppointments.Rows.Count == 0) return;
            if (AppointmentID <= 0 || AppointmentInfo == null)
            {
                MessageBox.Show("اختر الموعد من الجدول أولاً", "الموعد غير معروف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // التحقق من الاختيارات
            if (ErrorContrl(ComboxDoctors)) return; if (ErrorContrl(ComboxVisitTypes)) return;
            if (ErrorContrl(ComboxVisitTypes)) return; if (ErrorContrl(CombxStatusAppointment)) return;

            int PersonID = AppointmentInfo.PatientsInfo.PersonInfo.PersonID;
            int DoctorID = AppointmentInfo.DoctorInfo.DoctorID;
            string StatusVisit = CombxStatusVisit.Text.Trim();
            string StatusAppointment = CombxStatusAppointment.Text.Trim();


            string NamePatient = AppointmentInfo.PatientsInfo.PersonInfo.FullName;

            if (Mode_ == Mode.Add) // وضع الاضافة
            {
                bool IsSecsesful = ClsCMD_TableVisits.StartVisitFromAppointment(AppointmentID, PersonID, DoctorID, VisitTypeIDSelected, StatusVisit, StatusAppointment);
                if (IsSecsesful)
                {
                    ClsCMD_TablePatients.UpdateComplianceByAppointmentStatus(PersonID, StatusAppointment); // تحديث درجة الالتزام
                    MessageBox.Show($"تم تسجيل الزيارة للمريض \n\n {NamePatient} ", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplaylAppointmentDoctor();
                    return;
                }
                else
                {
                    MessageBox.Show($"لم يتم تسجيل الزيارة للمريض \n\n {NamePatient} ", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            else if (Mode_ == Mode.Update) // وضع الاضافة
            {
                bool IsSecsesful = ClsCMD_TableVisits.UpdateVisitWithAppointment(VisitID, VisitTypeIDSelected, StatusVisit, StatusAppointment);
                if (IsSecsesful)
                {
                    ClsCMD_TablePatients.UpdateComplianceByAppointmentStatus(PersonID, StatusAppointment); // تحديث درجة الالتزام
                    MessageBox.Show($"تم تعديل الزيارة للمريض \n\n {NamePatient} ", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplaylAppointmentDoctor();
                    return;
                }
                else
                {
                    MessageBox.Show($"لم يتم تعديل الزيارة للمريض \n\n {NamePatient} ", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        #endregion

    }
}

using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Persons.UControls;
using Program_Clinic_Management.Persons.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.ClassLogs;
using static Program_Clinic_Management.Patients.UI.FrmAdd_UpdatePatient;
using static Program_Clinic_Management.Persons.UI.FrmAdd_UpdatePerson;

namespace Program_Clinic_Management.Patients.UI
{
    public partial class FrmAdd_UpdatePatient : Form
    {
        public FrmAdd_UpdatePatient(  Mode mode_ ,  ClassPatients PatientsInfo_ = null )
        {
            InitializeComponent();

            SettingsControls();

            mode = mode_;
            PatientsInfo = PatientsInfo_;

            Load();
        }

        //   حدث مشان الرفرش
        public event Action EventShowRefrechData;

        ClassPatients PatientsInfo = new ClassPatients();
        ClassPerson   InfoPersonSearch;

        /// <summary>
        /// ضبط العناصر على الشاشة 
        /// </summary>
        void SettingsControls()
        {
            // اخفاء خيار عرض الكل في الفلتر
            ctrl_FeltterDataPersons.TrueSearchAll = true;
            // إضافة حدث ارجاع بيانات الشخص عند البحث
            ctrl_FeltterDataPersons.EventReturnInfoDataPerson += GetPersonInfo;

            // ضبط شكل ولون البار العلوي و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);

            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this);

        }



        // وضع التشغيل
        public Mode mode;
        public enum Mode
        {
            Add,
            Update
        }

        // تحديد وضع عرض الواجهة ... تعديل _ حذف
        void Load()
        {
            // اذا المستخدم طبيب
            // يتم عرض مرضى الطبيب فقط
            if (ClassUser.UserInfo.Role == "Doctor")
            {
                btn_AddPerson.Visible = false;
            }

            if (mode == Mode.Add)
            {
                lblTitle.Text = "Add";
                picTitle.Image = Properties.Resources.user;
                btnSave.Image = Properties.Resources.user;
                btnSave.Text = "إضافة";

                btn_Next.Enabled = false;
                btnSave.Enabled = false;
                PnlInfoPatient.Enabled = false;

                PnlStatusPatient.Visible = false;
            }
            else if (mode == Mode.Update)
            {
                lblTitle.Text = "Update";
                picTitle.Image = Properties.Resources.Synchronize;
                btnSave.Image = Properties.Resources.Synchronize;
                btnSave.Text = "تعديل";
                // ارسال بيانات الشخص لعرضها بالعنصر
                ctrl_PersonInfo.PersonInfo = PatientsInfo.PersonInfo;

                btn_Next.Enabled = true;
                btnSave.Enabled = true;
                PnlInfoPatient.Enabled = true;

                PnlStatusPatient.Visible = true;

                LoadInfoPatient();
            }
        }


        void LoadInfoPatient()
        {
            lblID_Patient.Text       = "ID Patient : " + PatientsInfo.PatientID;
            Txt_MedicalNotes.Text    = PatientsInfo.MedicalNotes;
            Txt_ChronicDiseases.Text = PatientsInfo.ChronicDiseases;
            Txt_Allergies.Text       = PatientsInfo.Allergies;
            Txt_Notes.Text           = PatientsInfo.Notes;

            lblFirstVisitDate.Text         = "Date of the first visit : " + PatientsInfo.FirstVisitDate;
            lbl_StatusComplianceScore.Text = "Commitment Status : "       + PatientsInfo.StatusComplianceScore;
            lbl_ComplianceScore.Text       = "Degree of commitment : "    + PatientsInfo.ComplianceScore;
        }

        bool PersonIsFind = false;

        /// <summary>
        /// يتم تنفيذها في حدث الفلتر ..عندما نريد عرض بيانات شخص
        /// ويتم تنفيذها عند عرض بيانات الشخص في حالة التعديل
        /// </summary>
        void GetPersonInfo(ClassPerson PersonInfo)
        {
            bool personUsed = ClsCMD_TablePatients.IsPersonAlreadyPatient(PersonInfo.PersonID);

            if (mode == Mode.Add)
            {
                if (personUsed)
                {
                    MessageBox.Show("هذا الشخص مسجّل مسبقاً كمريض.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (mode == Mode.Update)
            {
                if (personUsed && PatientsInfo.PersonInfo.PersonID != PersonInfo.PersonID)
                {
                    MessageBox.Show("هذا الشخص مرتبط بمريض آخر.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // الشخص صالح للاستخدام
            PersonIsFind = false;

            // تفعيل عناصر الواجهة
            btn_Next.Enabled = true;
            btnSave.Enabled = true;
            PnlInfoPatient.Enabled = true;
            tabControl1.Enabled = true;

            // عرض بيانات الشخص
            ctrl_PersonInfo.PersonInfo = PersonInfo;

            if (PatientsInfo == null)
                PatientsInfo = new ClassPatients();

            PatientsInfo.PersonInfo = PersonInfo;
        }




        // التحقق من ادخال كامل المعلومات
        bool IsPatentInfoValid()
        {
            if (PatientsInfo.PersonInfo == null || PatientsInfo.PersonInfo.PersonID == 0)
                return false;

            if (string.IsNullOrWhiteSpace(Txt_MedicalNotes.Text)) return false;
            if (string.IsNullOrWhiteSpace(Txt_ChronicDiseases.Text)) return false;
            if (string.IsNullOrWhiteSpace(Txt_Allergies.Text)) return false;
            if (string.IsNullOrWhiteSpace(Txt_Notes.Text)) return false;

            return true;
        }


        /// <summary>
        /// حفظ البيانات بالاوبجكت
        /// </summary>
        void SaveInfoPatient_InObj()
        {
            PatientsInfo.MedicalNotes = Txt_MedicalNotes.Text.Trim();
            PatientsInfo.ChronicDiseases = Txt_ChronicDiseases.Text.Trim();
            PatientsInfo.Allergies = Txt_Allergies.Text.Trim();
            PatientsInfo.Notes = Txt_Notes.Text.Trim();

            // تاريخ الزيارة الأولى لا يتغير في التعديل
            if (mode == Mode.Add)
                PatientsInfo.FirstVisitDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        // عرض بيانات الشخص على العنصر اذا تم اضافته
        void ShowInfoNePerson(ClassPerson PersonInfo)
        {
            ctrl_PersonInfo.PersonInfo = PersonInfo;

            if (PatientsInfo == null)
                PatientsInfo = new ClassPatients();

            PatientsInfo.PersonInfo = PersonInfo;
            GetPersonInfo(PersonInfo);
        }


        // Next زر   
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (!PersonIsFind)
            {
                tabControl1.Enabled = true;
                tabControl1.SelectedIndex = 1;   // التاب الثاني
            }
        }

        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsPatentInfoValid())
            {
                MessageBox.Show("أكمل بقية المعلومات ليتم حفظها",
                    "المعلومات غير مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // حفظ البيانات داخل الأوبجكت
            SaveInfoPatient_InObj();

            // معرف المستخدم الحالي
            int currentUserID = 1;
               if (ClassUser.UserInfo != null)
                     currentUserID =   ClassUser.UserInfo.UserID ;

            if (mode == Mode.Add)
            {
                int newID = ClsCMD_TablePatients.AddPatientOnly(PatientsInfo);

                if (newID > 0)
                {
                    // حفظ رقم المريض الجديد داخل الأوبجكت
                    PatientsInfo.PatientID = newID;

                    // تسجيل العملية
                    ClassLogs.AddLog(currentUserID, LogAction.Add.ToString(),"Patients", newID, "إضافة مريض جديد");

                    // التحويل لوضع التعديل
                    mode = Mode.Update;
                    Load();

                    EventShowRefrechData?.Invoke(); // تحديث البيانات
                }
            }
            else if (mode == Mode.Update)
            {
                bool ok = ClsCMD_TablePatients.UpdatePatient(PatientsInfo);

                if (ok)
                {
                    // تسجيل عملية التعديل
                    ClassLogs.AddLog(currentUserID, LogAction.Update.ToString(), "Patients", PatientsInfo.PatientID, "تعديل بيانات المريض");

                    LoadInfoPatient(); // تحديث العرض
                    EventShowRefrechData?.Invoke(); // تحديث البيانات
                }
            }
        }

        // إغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // إخفاء الفورم
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Person زر إضافة شخص
        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdatePerson add_UpdatePerson = new FrmAdd_UpdatePerson(FrmAdd_UpdatePerson.Mode.Add);
            // تسجيل الحدث   // عند  إضفة الشخص يتم عرض معلوماته فورا
            add_UpdatePerson.EventShowDataPerson += ShowInfoNePerson; 
            MyTools.ShowForm(add_UpdatePerson);
        }

      
    }
}

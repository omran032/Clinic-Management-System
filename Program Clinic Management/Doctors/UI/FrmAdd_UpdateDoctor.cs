using BusinessLogic;
using BusinessLogic.CMD_DB;
using BusinessLogic.InfoTable;
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

namespace Program_Clinic_Management.Doctors.UI
{
    public partial class FrmAdd_UpdateDoctor : Form
    {
        public FrmAdd_UpdateDoctor(Mode mode_, ClassDoctor DoctorInfo_ = null)
        {
            InitializeComponent();

            SettingsControls();

            mode = mode_;
            DoctorInfo = DoctorInfo_;

            Load();

        }


        //   حدث مشان الرفرش عند استععمال احد الواجهات لواجهة التعديل
        public event Action EventShowRefrechData;

        ClassDoctor DoctorInfo ;


        // وضع التشغيل
        public Mode mode;
        public enum Mode
        {
            Add,
            Update
        }

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

            // Combox تحميل الاختصاصات داخل عنصر 
            ClsCMD_TableDoctors.LoadSpecializations(Combx_Specialization);

        }

        // تحديد وضع عرض الواجهة ... تعديل _ حذف
        void Load()
        {
            if (mode == Mode.Add)
            {
                lblTitle.Text = "Add";
                picTitle.Image = Properties.Resources.user;
                btnSave.Image = Properties.Resources.user;
                btnSave.Text = "إضافة";

                btnSave.Enabled = false;

            }
            else if (mode == Mode.Update)
            {
                if (DoctorInfo == null || DoctorInfo.PersonInfo == null)
                    return;

                lblTitle.Text = "Update";
                picTitle.Image = Properties.Resources.Synchronize;
                btnSave.Image = Properties.Resources.Synchronize;
                btnSave.Text = "تعديل";
                // ارسال بيانات الشخص لعرضها بالعنصر
                ctrl_PersonInfo.PersonInfo = DoctorInfo.PersonInfo;
                // حفظ معرف الشخص حتى نتمكن من معرفة المعرف القديم عند التعديل
                OldPersonID = DoctorInfo.PersonInfo.PersonID;

                lblID_Doctor.Text = "ID Doctor : " + DoctorInfo.DoctorID;

                btnSave.Enabled = true;

                LoadInfoPatient();
            }
        }



        void LoadInfoPatient()
        {
            txtNotes.Text = DoctorInfo.Notes;
            Combx_Specialization.SelectedValue = DoctorInfo.SprcializationID;

        }


        int OldPersonID; // معرف الشخص القديم

        bool PersonIsFind = false;

        /// <summary>
        /// يتم تنفيذها في حدث الفلتر ..عندما نريد عرض بيانات شخص
        /// ويتم تنفيذها عند عرض بيانات الشخص في حالة التعديل
        /// </summary>
        void GetPersonInfo(ClassPerson PersonInfo)
        {
            bool personUsed = ClsCMD_TableDoctors.IsPersonDoctor(PersonInfo.PersonID);

            if (mode == Mode.Add)
            {
                if (personUsed)
                {
                    MessageBox.Show("هذا الشخص مسجّل مسبقاً كطبيب.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (mode == Mode.Update)
            {
                if (personUsed && DoctorInfo.PersonInfo.PersonID != PersonInfo.PersonID)
                {
                    MessageBox.Show("هذا الشخص مرتبط بطبيب آخر.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // الشخص صالح للاستخدام
            PersonIsFind = false;//؟؟
            btnSave.Enabled = true;

            // عرض بيانات الشخص
            ctrl_PersonInfo.PersonInfo = PersonInfo;

            if (DoctorInfo == null)
                DoctorInfo = new ClassDoctor();

            DoctorInfo.PersonInfo = PersonInfo;
        }


        // التحقق من ادخال كامل المعلومات
        bool IsPatentInfoValid()
        {
            if (DoctorInfo.PersonInfo == null || DoctorInfo.PersonInfo.PersonID == 0)
                return false;

            if (string.IsNullOrWhiteSpace(txtNotes.Text)) return false;
            if (Combx_Specialization.SelectedValue == null) return false;

            return true;
        }


        /// <summary>
        /// حفظ البيانات بالاوبجكت
        /// </summary>
        void SaveInfoPatient_InObj()
        {
            DoctorInfo.Notes = txtNotes.Text.Trim();
            DoctorInfo.SprcializationName = Combx_Specialization.Text.Trim();
            DoctorInfo.SprcializationID = Convert.ToInt32(Combx_Specialization.SelectedValue);

            // تاريخ الزيارة الأولى لا يتغير في التعديل
            //if (mode == Mode.Add)
            //    PatientsInfo.FirstVisitDate = DateTime.Now.ToString("yyyy-MM-dd"); ??????????????????
        }

        // عرض بيانات الشخص على العنصر اذا تم اضافته
        // عند البحث بالفلتر
        void ShowInfoNePerson(ClassPerson PersonInfo)
        {
            ctrl_PersonInfo.PersonInfo = PersonInfo;

            if (PersonInfo == null)
                DoctorInfo = new ClassDoctor();

            DoctorInfo.PersonInfo = PersonInfo;
            GetPersonInfo(PersonInfo);
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
                currentUserID = ClassUser.UserInfo.UserID;

            if (mode == Mode.Add)
            {
                int newID = ClsCMD_TableDoctors.AddDoctor(DoctorInfo);

                if (newID > 0)
                {
                    // حفظ رقم المريض الجديد داخل الأوبجكت
                    DoctorInfo.DoctorID = newID;
                    lblID_Doctor.Text = "ID Doctor : " + newID;

                    // تسجيل العملية
                    ClassLogs.AddLog(currentUserID, LogAction.Add.ToString(), "Doctors", newID, "إضافة طبيب جديد");

                    // التحويل لوضع التعديل
                    mode = Mode.Update;
                    Load();

                    EventShowRefrechData?.Invoke(); // تحديث البيانات
                }
            }
            else if (mode == Mode.Update)
            {
                // تنفيذ التعديل .... و التحقق اذا تم تنفيذه ؟
                bool ok = ClsCMD_TableDoctors.UpdateDoctor(DoctorInfo  , OldPersonID) == 1 ;

                if (ok)
                {
                    // تسجيل عملية التعديل بالسجل
                    ClassLogs.AddLog(currentUserID, LogAction.Update.ToString(), "Doctors", DoctorInfo.DoctorID, "تعديل بيانات الطبيب");

                    LoadInfoPatient(); // تحديث العرض
                    EventShowRefrechData?.Invoke(); // تحديث البيانات
                }
            }
        }

        // Person زر إضافة شخص
        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdatePerson add_UpdatePerson = new FrmAdd_UpdatePerson(FrmAdd_UpdatePerson.Mode.Add);
            // تسجيل الحدث   // عند  إضفة الشخص يتم عرض معلوماته فورا
            add_UpdatePerson.EventShowDataPerson += ShowInfoNePerson;
            MyTools.ShowForm(add_UpdatePerson);
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

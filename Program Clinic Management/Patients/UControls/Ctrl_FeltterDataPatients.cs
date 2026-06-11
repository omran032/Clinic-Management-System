using BusinessLogic.CMD_DB;
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
using static BusinessLogic.CMD_DB.ClsCMD_TablePatients;
using static BusinessLogic.CMD_DB.ClsCMD_TablePersons;

namespace Program_Clinic_Management.Patients.UControls
{
    public partial class Ctrl_FeltterDataPatients : UserControl
    {
        public Ctrl_FeltterDataPatients()
        {
            InitializeComponent();
        }



        /// <summary>
        /// حدث عرض كل بيانات المرضى في عملية البحث 
        /// </summary>
        public event Action<DataTable> EventShowDataPatientsInDataTable;

        /// <summary>
        /// ClassPatients في حال كنت تريد عرض بيانات مريض واحد ..عبر استعمال الأوبجكت
        /// </summary>
        public event Action<ClassPatients> EventReturnInfoDataPatient;


        // ComboBox خاصيات اخفاء خيار عرض كل البيانات في
        private bool TrueSearchAll_;
        public bool TrueSearchAll
        {
            get { return TrueSearchAll_; }
            set
            {
                if (DesignMode) return;

                if (value)
                {   // إخفاء خيار عرض الكل
                    Combx_TypeFeltter.Items.Remove("عرض الكل");
                }
                else
                {
                    Combx_TypeFeltter.Text = "عرض الكل";
                }

            }
        }



        DataTable DataPatients = new DataTable(); // جدول عرض البيانات

        // ClassPatients اذا تم اعطائها القيمة ستقوم بتنفيذ حدث ارجاع البيانات ضمن اوبجكت
        ClassPatients InfoPatients_;

        ClassPatients InfoPatients
        {
            get { return InfoPatients_; }
            set
            {
                InfoPatients_ = value;
                EventReturnInfoDataPatient?.Invoke(InfoPatients_); // تنفيذ الحدث
            }
        }





        // ComboBox عنصر
        private void Combx_TypeFeltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Search.Enabled = true;
            Txt_TextSearch.Enabled = true;

            Txt_TextSearch.Text = null;

            string TypeFeltter = Combx_TypeFeltter.Text.Trim();

            switch (TypeFeltter)
            {
                case "عرض الكل":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataPatients = ClsCMD_TablePatients.FeltterPatient(PatientFilterType.All); // بدلها بالامر عرض كل المرضى

                    EventShowDataPatientsInDataTable?.Invoke(DataPatients); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "معرف الشخص":
                case "معرف المريض":
                case "رقم الهاتف":
                    // تنفيذ مثود عدم السماح ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch, false);
                    break;

                case "أسم المريض":
                case "الرقم الوطني":
                    // تنفيذ مثود السماح ب ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch);
                    break;
            }
        }





        // زر البحث
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string TypeFeltter = Combx_TypeFeltter.Text.Trim();
            string SearchValue = Txt_TextSearch.Text.Trim();
            PatientFilterType PatientFilterType = PatientFilterType.All;

            switch (TypeFeltter)
            {
                case "أسم المريض":
                    PatientFilterType = PatientFilterType.PersonName;
                    break;

                case "معرف الشخص":
                    PatientFilterType = PatientFilterType.PersonID;
                    break;

                case "معرف المريض":
                    PatientFilterType = PatientFilterType.PatientID;
                    break;

                case "رقم الهاتف":
                    PatientFilterType = PatientFilterType.Phone;
                    break;

                default:
                    MessageBox.Show("قم بإختيار نوع البحث أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
            // إظهار البيانات
            DataPatients = ClsCMD_TablePatients.FeltterPatient(PatientFilterType, SearchValue);

            EventShowDataPatientsInDataTable?.Invoke(DataPatients); // تنفيذ حدث عرض البيانات في الجدول

            if (DataPatients.Rows.Count == 0) return;

            // تنفيذ حدث عرض بيانات شخص واحد
            InfoPatients = ClassPatients.GetInfoPatientInObj(DataPatients);
        }










    }
}

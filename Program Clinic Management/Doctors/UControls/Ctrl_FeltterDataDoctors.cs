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
using static BusinessLogic.CMD_DB.ClsCMD_TableDoctors;

namespace Program_Clinic_Management
{
    public partial class Ctrl_FeltterDataDoctors : UserControl
    {
        public Ctrl_FeltterDataDoctors()
        {
            InitializeComponent();
        }




        /// <summary>
        /// حدث عرض كل بيانات الأطباء في عملية البحث 
        /// </summary>
        public event Action<DataTable> EventShowDataPDoctorsInDataTable;

        /// <summary>
        /// ClassDoctor في حال كنت تريد عرض بيانات طبيب واحد ..عبر استعمال الأوبجكت
        /// </summary>
        public event Action<ClassDoctor> EventReturnInfoDataDoctor;


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


        DataTable DataDoctors = new DataTable(); // جدول عرض البيانات

        // ClassDoctor اذا تم اعطائها القيمة ستقوم بتنفيذ حدث ارجاع البيانات ضمن اوبجكت
        ClassDoctor InfoDoctors_;

        ClassDoctor InfoDoctors
        {
            get { return InfoDoctors_; }
            set
            {
                InfoDoctors_ = value;
                EventReturnInfoDataDoctor?.Invoke(InfoDoctors_); // تنفيذ الحدث
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
                    DataDoctors = ClsCMD_TableDoctors.DesplayAnd_FilterDoctors(DoctorFilterType.All);  // Table All Info 

                    EventShowDataPDoctorsInDataTable?.Invoke(DataDoctors); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "المعرف الشخصي":
                case "معرف الطبيب":
                case "رقم الهاتف":
                    // تنفيذ مثود عدم السماح ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch, false);
                    break;

                case "أسم الطبيب":
                case "الاختصاص":
                case "الرقم الوطني":
                    // تنفيذ مثود السماح ب ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch);
                    break;
            }
        }



        // زر البحث
        private void Txt_TextSearch_TextChanged(object sender, EventArgs e)
        {
            string TypeFeltter = Combx_TypeFeltter.Text.Trim();
            string SearchValue = Txt_TextSearch.Text.Trim();
            DoctorFilterType DoctorFilterType = DoctorFilterType.All;

            switch (TypeFeltter)
            {
                case "أسم الطبيب":
                    DoctorFilterType = DoctorFilterType.Name;
                    break;

                case "المعرف الشخصي":
                    DoctorFilterType = DoctorFilterType.PersonId;
                    break;

                case "معرف الطبيب":
                    DoctorFilterType = DoctorFilterType.DoctorId;
                    break;

                case "رقم الهاتف":
                    DoctorFilterType = DoctorFilterType.Phone;
                    break;

                case "الاختصاص":
                    DoctorFilterType = DoctorFilterType.Specialization;
                    break;

                default:
                    MessageBox.Show("قم بإختيار نوع البحث أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            // إظهار البيانات
            DataDoctors = ClsCMD_TableDoctors.DesplayAnd_FilterDoctors(DoctorFilterType, SearchValue);

            EventShowDataPDoctorsInDataTable?.Invoke(DataDoctors); // تنفيذ حدث عرض البيانات في الجدول

            if (DataDoctors.Rows.Count == 0) return;

            // تنفيذ حدث عرض بيانات شخص واحد
            InfoDoctors = ClassDoctor.GetInfoDoctorInObj(DataDoctors);
        }
    }
}

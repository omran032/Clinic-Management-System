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
using static BusinessLogic.CMD_DB.ClsCMD_TablePersons;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Program_Clinic_Management.Persons.UControls
{
    public partial class Ctrl_FeltterDataPersons : UserControl
    {
        public Ctrl_FeltterDataPersons()
        {
            InitializeComponent();
           

        }

       /// <summary>
       /// حدث عرض كل بيانات الأشخاص في عملية البحث 
       /// </summary>
        public event Action<DataTable> EventShowDataPersonsInDataTable;

        /// <summary>
        /// ClassPerson في حال كنت تريد عرض بيانات شخص واحد ..عبر استعمال الأوبجكت
        /// </summary>
        public event Action<ClassPerson> EventReturnInfoDataPerson;


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


        DataTable DataPersons = new DataTable(); // جدول عرض البيانات

        // ClassPerson اذا تم اعطائها القيمة ستقوم بتنفيذ حدث ارجاع البيانات ضمن اوبجكت
        ClassPerson InfoPerson_;
        ClassPerson InfoPerson
        {
            get { return InfoPerson_; }
            set
            {
                InfoPerson_ = value;
                EventReturnInfoDataPerson?.Invoke(InfoPerson_); // تنفيذ الحدث
            }
        }



        // ComboBox عنصر
        private void Combx_TypeFeltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Search.Enabled = true;
            Txt_TextSearch.Enabled = true;

            string SearchValue = Txt_TextSearch.Text.Trim();

            string TypeFeltter = Combx_TypeFeltter.Text.Trim();

            switch (TypeFeltter)
            {
                case "عرض الكل":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataPersons = ClsCMD_TablePersons.FilterPersons(PersonFilterType.All, SearchValue);
                       EventShowDataPersonsInDataTable?.Invoke(DataPersons); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "ID":
                    // تنفيذ مثود عدم السماح ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch ,false);
                    break;

                case "الأسم":
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
            PersonFilterType personFilterType = PersonFilterType.All; 

            switch (TypeFeltter)
            {
                case "ID":
                      personFilterType = PersonFilterType.ID;
                    break;

                case "الأسم":
                      personFilterType = PersonFilterType.FullName;
                    break;

                case "الرقم الوطني":
                    personFilterType = PersonFilterType.NationalNumber;
                    break;

                default:
                       MessageBox.Show("قم بإختيار نوع البحث أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
            // إظهار البيانات
            DataPersons = ClsCMD_TablePersons.FilterPersons(personFilterType, SearchValue);
            EventShowDataPersonsInDataTable?. Invoke(DataPersons); // تنفيذ حدث عرض البيانات في الجدول

            if (DataPersons.Rows.Count == 0) return;

            // تنفيذ حدث عرض بيانات شخص واحد
            InfoPerson = ClassPerson.SaveDataInObj(DataPersons);
        }

       
    }
}

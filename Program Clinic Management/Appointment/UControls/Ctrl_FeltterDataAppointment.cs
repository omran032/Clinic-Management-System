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
using static BusinessLogic.CMD_DB.ClsCMD_TableAppointments;
using static BusinessLogic.CMD_DB.ClsCMD_TableDoctors;

namespace Program_Clinic_Management.Appointment.UControls
{
    public partial class Ctrl_FeltterDataAppointment : UserControl
    {
        public Ctrl_FeltterDataAppointment()
        {
            InitializeComponent();
        }

        // تحميل العنصر
        private void Ctrl_FeltterDataAppointment_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Combox تعبئة اسماء الاطباء داخل عنصر
            ClsCMD_TableDoctors.FillDoctorsComboBox(Combx_Doctors);
            Combx_Doctors.Text = null;

        }


        /// حدث عرض كل بيانات الأطباء في عملية البحث 
        /// </summary>
        public event Action<DataTable> EventShowDataAppointmentsInDataTable;

        /// <summary>
        /// ClassDoctor في حال كنت تريد عرض بيانات طبيب واحد ..عبر استعمال الأوبجكت
        /// </summary>
        public event Action<ClassAppointment> EventReturnInfoDataAppointment;


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
                    Combx_TypeFeltter.Items.Remove("مواعيد اليوم");
                    Combx_TypeFeltter.Items.Remove("مواعيد الأسبوع");
                    Combx_TypeFeltter.Items.Remove("مواعيد الشهر");
                }
                else
                {
                    Combx_TypeFeltter.Text = "عرض الكل";
                }

            }
        }


        DataTable DataAppointment = new DataTable(); // جدول عرض البيانات

        // ClassDoctor اذا تم اعطائها القيمة ستقوم بتنفيذ حدث ارجاع البيانات ضمن اوبجكت
        ClassAppointment InfoAppointment_;

        ClassAppointment InfoAppointment
        {
            get { return InfoAppointment_; }
            set
            {
                InfoAppointment_ = value;
                EventReturnInfoDataAppointment?.Invoke(InfoAppointment_); // تنفيذ الحدث
            }
        }




        // ComboBox عنصر
        private void Combx_TypeFeltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Search.Enabled = true;
            Txt_TextSearch.Enabled = true;


            Combx_Doctors.Visible = false;
            Txt_TextSearch.Visible = true;
            btn_Search.Visible = true;

            Txt_TextSearch.Text = null;

            string TypeFeltter = Combx_TypeFeltter.Text.Trim();

            switch (TypeFeltter)
            {
                case "عرض الكل":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter.All);  // Table All Info 

                    EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "مواعيد اليوم":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter.Today);

                    EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "مواعيد الأسبوع":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter.ThisWeek);

                    EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "مواعيد الشهر":
                    btn_Search.Enabled = false;
                    Txt_TextSearch.Enabled = false;
                    DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter.ThisMonth);

                    EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول
                    break;

                case "مواعيد الطبيب":
                    Combx_Doctors.Visible = true;
                    Txt_TextSearch.Visible = false;
                    btn_Search.Visible = false;

                    break;

                 case "رقم هاتف المريض":
                    // تنفيذ مثود عدم السماح ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch, false);
                    break;

                case "أسم المريض":
                case "حالة الموعد":
                    // تنفيذ مثود السماح ب ادخال احرف
                    MyTools.SetTextBoxInputMode(Txt_TextSearch);
                    break;
            }
        }

        //زر البحث 
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string TypeFeltter = Combx_TypeFeltter.Text.Trim();
            string SearchValue = Txt_TextSearch.Text.Trim();
            AppointmentFilter AppointmentFilter_ = AppointmentFilter.All;

            switch (TypeFeltter)
            {
                case "رقم هاتف المريض":
                    AppointmentFilter_ = AppointmentFilter.PatientPhone;
                    break;

                case "أسم المريض":
                    AppointmentFilter_ = AppointmentFilter.PatientName;
                    break;

                case "حالة الموعد":
                    AppointmentFilter_ = AppointmentFilter.AppointmentStatus;
                    break;

                default:
                    MessageBox.Show("قم بإختيار نوع البحث أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            // إظهار البيانات
            DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter_, SearchValue);

            EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول

            if (DataAppointment.Rows.Count == 0) return;

            int ApointmentID = Convert.ToInt32(DataAppointment.Rows[0]["AppointmentId"]);

            // تنفيذ حدث عرض بيانات الموعد المحدد
            InfoAppointment = ClassAppointment.GetAppointmentById(ApointmentID);
        }



        // إختيار مواعيد لطبيب ممحدد  ComboBox
        private void Combx_Doctors_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Combx_Doctors.SelectedValue == null) return;
            if (Combx_Doctors.SelectedValue is DataRowView) return;

           int  doctorId = Convert.ToInt32(Combx_Doctors.SelectedValue);

            // إظهار مهام الطبيب المختار 
            DataAppointment = ClsCMD_TableAppointments.GetAppointmentsByFilter(AppointmentFilter.DoctorId , doctorId.ToString() );
            EventShowDataAppointmentsInDataTable?.Invoke(DataAppointment); // تنفيذ حدث عرض البيانات في الجدول

        }


    }
}

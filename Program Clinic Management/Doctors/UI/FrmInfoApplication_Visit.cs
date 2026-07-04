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

namespace Program_Clinic_Management
{
    public partial class FrmInfoApplication_Visit : Form
    {
        public FrmInfoApplication_Visit(DataTable DT , PositionType PositionTypeForm_)
        {
            InitializeComponent();

            // ضبط شكل العناصر و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);
            ClassStyleAndColor.Style_DataGridView(DataGV);
            MyTools.MoveControl(pnl_TopBar, this);
            MyTools.SetAppIcon(this);

            if (DT == null || DesignMode ) return;

            PositionTypeForm = PositionTypeForm_;
            DataTableInfo = DT;

            LoadData();

        }

        public enum PositionType { Appointment , Visit}

        PositionType PositionTypeForm = PositionType.Visit;

        DataTable DataTableInfo;

        void LoadData()
        {
            DataGV.DataSource = DataTableInfo;

            if (PositionTypeForm == PositionType.Appointment)
                lblTitle.Text = "تفاصيل موعد المريض";
            else if (PositionTypeForm == PositionType.Visit)
                lblTitle.Text = "تفاصيل زيارة المريض";

            FormatPatientsGrid();

        }

        /// <summary>
        /// إخفاء جميع الأعمدة في DataGridView
        /// وإظهار الأعمدة المطلوبة فقط.
        /// </summary>
        void FormatPatientsGrid()
        {
            if (DataGV.Columns.Count == 0)
                return;

            // إخفاء كل الأعمدة
            foreach (DataGridViewColumn col in DataGV.Columns)
                col.Visible = false;

                // إظهار الأعمدة المطلوبة فقط

            if (PositionTypeForm == PositionType.Appointment)
            {
                ShowColumn("AppointmentDate");
                ShowColumn("Status");
            }
            else if (PositionTypeForm == PositionType.Visit)
            {
                ShowColumn("VisitDate");
                ShowColumn("VisitTypeName");
            }
            ShowColumn("FirstName");
            ShowColumn("LastName");
            ShowColumn("Phone");

            // تحسين عرض الأعمدة
            DataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// مساعد لإظهار عمود إذا كان موجوداً
        /// </summary>
        void ShowColumn(string columnName)
        {
            if (DataGV.Columns.Contains(columnName))
                DataGV.Columns[columnName].Visible = true;
        }

        bool isBigForm = false;
        void SizeForm()
        {
            if (isBigForm)
            {
                this.Size = new Size(870, 604);
                lblTitle.Location = new Point(803, 13);
                isBigForm = false;
            }
            else
            {
                this.Size = new Size(1747, 959);
                lblTitle.Location = new Point(350, 13);
                isBigForm = true;

            }
        }

        int IndexRowSelected = -1;

        // ضبط العناصر
        void SettingsControls()
        {
            // ارجاع الصف المختار
            MyTools.EnableRightClickSelection(DataGV, MyContextMS, (rowIndex) =>
            {
                // Index Row
                IndexRowSelected = rowIndex;
            });

        }

     
        /// <summary>
        ///  تحميل بيانات المواعيد 
        /// </summary>
        void LoadDataAppointment()
        {
            ClassAppointment AppointmentInfo = new ClassAppointment();
            AppointmentInfo = ClassAppointment.GetInfoAppointmentInObj(DataTableInfo, IndexRowSelected);

            if (AppointmentInfo == null) return;

            ctrl_InfoVisits_AppointmentsDoctor1.LoadDataِAppointment(AppointmentInfo);

        }

        /// <summary>
        /// تحميل بيانات الزيارات
        /// </summary>
        void LoadDataVisit()
        {
            ClassVisit VisitInfo = new ClassVisit();
            VisitInfo = ClassVisit.GetInfoVisitInObj(DataTableInfo, IndexRowSelected);

            if (VisitInfo == null) return;

            ctrl_InfoVisits_AppointmentsDoctor1.LoadDataVisit(VisitInfo);

        }

        // حدث الانتقال لصف جديد
        private void DataGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            IndexRowSelected = e.RowIndex;

            if (IndexRowSelected == -1) return;
             

            if (PositionTypeForm == PositionType.Appointment)
            {
                LoadDataAppointment();
            }

            else if (PositionTypeForm == PositionType.Visit)
            {
                LoadDataVisit();
            }

            
          
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

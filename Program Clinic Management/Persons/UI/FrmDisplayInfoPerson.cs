using BusinessLogic;
using BusinessLogic.InfoTable;
using Program_Clinic_Management.Persons.UControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Persons.UI
{
    public partial class FrmDisplayInfoPerson : Form
    {
        public FrmDisplayInfoPerson()
        {
            InitializeComponent();
            SettingsControls();
        }
        public FrmDisplayInfoPerson(ClassPerson PersonInfo)
        {
            InitializeComponent();

            SettingsControls();

            if (PersonInfo == null) return;

            ctrl_PersonInfo.PersonInfo = PersonInfo;
        }

       

        /// <summary>
        /// ضبط العناصر على الشاشة 
        /// </summary>
        void SettingsControls()
        {
            // ضبط شكل ولون البار العلوي و الفورم
            ClassStyleAndColor.Style_TopBar_And_HiderForm(pnl_TopBar, this);

            // تحريك الفورم
            MyTools.MoveControl(pnl_TopBar, this);
        }

        //  إغلاق 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // اخفاء الفورم
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}

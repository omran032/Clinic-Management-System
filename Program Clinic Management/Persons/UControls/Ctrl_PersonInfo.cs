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


namespace Program_Clinic_Management.Persons.UControls
{
    public partial class Ctrl_PersonInfo : UserControl
    {
        public Ctrl_PersonInfo()
        {
            InitializeComponent();
        }


        // يمكن ارسال اوبكت لتحميل وعرض المعلومات
        private ClassPerson PersonInfo_;

        public ClassPerson PersonInfo
        {
            get { return PersonInfo_; }
            set
            {
                if (value == null) return;

                PersonInfo_ = value;
                LoadData();
            }
        }


        // يمكن ارسال معرف الشخص لتحميل وعرض المعلومات
        private int PersonsID_;
        public int PersonID
        {
            get { return PersonsID_; }
            set
            {
                if (value == 0) return;

                PersonsID_ = value;
                PersonInfo = ClsCMD_TablePersons.GetPersonByID(value);
            }
        }


        // عنوان الغروب بوكس
        private string _groupTitle;
        public string GroupTitle
        {
            get => _groupTitle;
            set
            {
                if (value == null) return;

                _groupTitle = value;
                groupBox1.Text = value;   // تغيير عنوان الغروب بوكس
            }
        }

        void LoadData()
        {
            lbl_ID.Text       = "ID : " + PersonInfo.PersonID;
            lblFullName.Text  = "Full Name : " + PersonInfo.FullName;
            lblGender.Text    = "Gender : " + PersonInfo.Gender;
            lblBirthDate.Text = "BirthDate : " + PersonInfo.BirthDate.ToString("yyyy / MM / dd");
            lblAge.Text       = "Age : "   + PersonInfo.Age;
            lblPhone.Text     = "Phone : " + PersonInfo.Phone;
            lblAddress.Text   = "Address : " + PersonInfo.Address;
            lblCtratedAt.Text = "Ctreated At : " + PersonInfo.CreatedAt;
            lblUpdatedAt.Text = "Updated At : "  + PersonInfo.UpdatedAt;
        }


    }
}

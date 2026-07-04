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
            lbl_ID.Text       =  PersonInfo.PersonID.ToString();
            lblFullName.Text  =  PersonInfo.FullName;
            lblGender.Text    =  PersonInfo.Gender;
            lblBirthDate.Text =  PersonInfo.BirthDate.ToString("yyyy / MM / dd");
            lblAge.Text       =  PersonInfo.Age.ToString();
            lblPhone.Text     =  PersonInfo.Phone;
            lblAddress.Text   =  PersonInfo.Address;
            lblCtratedAt.Text =  PersonInfo.CreatedAt;
            lblUpdatedAt.Text =  PersonInfo.UpdatedAt;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace Program_Clinic_Management.UControls
{
    public partial class Ctrl_ShowStatisticscs : UserControl
    {
        public Ctrl_ShowStatisticscs()
        {
            InitializeComponent();
            
        }

        public string TextLableTitle
        {
            get { return lblTitle.Text.Trim(); }
            set
            {
                lblTitle.Text = value;
                MyTools.LocationIn_Center_X(lblTitle, this);

            }
        }

        public string TextLableInfo
        {
            get { return lblInfo.Text.Trim(); }
            set
            {
                lblInfo.Text = value;
                MyTools.LocationIn_Center_X(lblInfo, this);
             }
        }


        private PictureBox Pic = new PictureBox();

        public Image PicImage
        {
            get { return Pic.Image; }
            set
            {
                Pic.Image = value;
            }
        }


        public void LoadData(string Title , string Info)
        {
            lblTitle.Text = Title;
            lblInfo.Text = Info;
            MyTools.LocationIn_Center_X(lblTitle, this);
            MyTools.LocationIn_Center_X(lblInfo, this);

        }
 
    }
}

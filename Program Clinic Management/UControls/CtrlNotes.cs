using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Program_Clinic_Management.UControls
{
    public partial class CtrlNotes : UserControl
    {
        public CtrlNotes()
        {
            InitializeComponent();

            MyTools.ColorControl(pnlTitle, Color.FromArgb(253, 253, 253), Color.FromArgb(212, 222, 224), true , false);

            TitleText = "Notes";
         
        }

        #region  ***** خواص العناصر  *****

        private string titleText_;
        public string TitleText
        {
            get => titleText_;
            set
            {
                titleText_ = value;
                //    تغيير نص الليبل ... العنوان
                lblTitle.Text = value;  
            }
        }
         
        // نص المعلومات و الملاحظات
        private string InfoText_;
        public string InfoText
        {
            get => InfoText_;
            set
            {
                InfoText_ = value;
                //    تغيير نص المعلومات 
                txt_Info.Text = value;
                CenterText(txt_Info);

            }
        }

        // صورة الانتقال لعرض المعلومات
        private Image _picture;
        public Image Picture
        {
            get => _picture;
            set
            {
                _picture = value;
                PicTitle.Image = value ?? Properties.Resources.NextPage;
            }
        }


        /// <summary>
        /// تغيير لون خط الليبل
        /// </summary>
        public Color LabelTextColor
        {
            get => lblTitle.ForeColor;
            set => lblTitle.ForeColor = value;
        }



        #endregion


        #region **** مثود  ****

        public static void CenterText(RichTextBox rtb)
        {
            rtb.SelectAll();
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.DeselectAll();
        }


        // فحص اذا هل يوجد معلومات ام لا
        bool TextInfoIstNull()
        {
            return string.IsNullOrEmpty(txt_Info.Text);
        }

        #endregion

        // زر عرض المعلومات
        private void PicTitle_Click(object sender, EventArgs e)
        {
            if (TextInfoIstNull())
            {
                MessageBox.Show("لا يوجد أي معلومات في هذا القسم", $" لا تحتوي على معلومات {titleText_}" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }

            if(this.Height > 80)
            this.Size = new Size(this.Width, 80);

            else
                this.Size = new Size(this.Width, 260);

        }



    }
}

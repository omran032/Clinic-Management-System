using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic
{
    public partial class Ctrl_IconProjectClinic : UserControl
    {
        public Ctrl_IconProjectClinic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// تغيير لون خط الليبل الرئيسي في الفورم.
        /// </summary>
        public Color TitleNameColor
        {
            get { return lbl_TitleName.ForeColor; }
            set { lbl_TitleName.ForeColor = value; }
        }

    }
}

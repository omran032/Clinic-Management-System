using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic
{
    public class ClassStyleAndColor
    {

        /// <summary>
        /// ضبط لون العناصر التالية
        /// </summary>
        /// <param name="TopBar">الشريط العلوي</param>
        /// <param name="HiderForm">جسم الفورم</param>
        public static void Style_TopBar_And_HiderForm(Control TopBar , Control HiderForm )
        {
            MyTools.ColorControl(TopBar, Color.FromArgb(0, 0, 64), Color.FromArgb(184, 247, 252));
            MyTools.ColorControl(HiderForm, Color.FromArgb(186, 249, 253), Color.FromArgb(138, 199, 232));
        }

        /// <summary>
        /// DataGridView ضبط لون وشكل عنصر 
        /// </summary>
        public static void Style_DataGridView(DataGridView dgv)
        {
            // الخط العام
            dgv.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // لون الخلفية العام
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            // إخفاء الخطوط الرأسية
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 220, 220);

            // تلوين الصفوف المتناوبة
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);

            // لون الصف العادي
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // لون النص
            dgv.RowsDefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);

            // لون الصف المحدد
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(72, 133, 237);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // تنسيق الهيدر
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // ارتفاع الصفوف
            dgv.RowTemplate.Height = 35;

            // منع التعديل المباشر
            dgv.ReadOnly = true;

            // جعل الأعمدة تمتد تلقائيًا
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // إزالة حدود التحديد حول الخلية
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }


    }
}

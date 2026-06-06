namespace Program_Clinic_Management
{
    partial class Ctrl_FeltterDataDoctors
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ElipseControl = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btn_Search = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_TextSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.Combx_TypeFeltter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // ElipseControl
            // 
            this.ElipseControl.BorderRadius = 20;
            this.ElipseControl.TargetControl = this;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_Search.BorderRadius = 15;
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Search.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_Search.FillColor2 = System.Drawing.Color.White;
            this.btn_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Image = global::Program_Clinic_Management.Properties.Resources.Search;
            this.btn_Search.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_Search.Location = new System.Drawing.Point(701, 4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(52, 44);
            this.btn_Search.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "البحث حسب";
            // 
            // Txt_TextSearch
            // 
            this.Txt_TextSearch.BackColor = System.Drawing.Color.Transparent;
            this.Txt_TextSearch.BorderColor = System.Drawing.Color.Navy;
            this.Txt_TextSearch.BorderRadius = 10;
            this.Txt_TextSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_TextSearch.DefaultText = "";
            this.Txt_TextSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_TextSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_TextSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_TextSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_TextSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_TextSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_TextSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_TextSearch.Location = new System.Drawing.Point(411, 9);
            this.Txt_TextSearch.Name = "Txt_TextSearch";
            this.Txt_TextSearch.PlaceholderText = "";
            this.Txt_TextSearch.SelectedText = "";
            this.Txt_TextSearch.Size = new System.Drawing.Size(271, 36);
            this.Txt_TextSearch.TabIndex = 9;
            this.Txt_TextSearch.TextChanged += new System.EventHandler(this.Txt_TextSearch_TextChanged);
            // 
            // Combx_TypeFeltter
            // 
            this.Combx_TypeFeltter.BackColor = System.Drawing.Color.Transparent;
            this.Combx_TypeFeltter.BorderColor = System.Drawing.Color.Navy;
            this.Combx_TypeFeltter.BorderRadius = 10;
            this.Combx_TypeFeltter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Combx_TypeFeltter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combx_TypeFeltter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Combx_TypeFeltter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Combx_TypeFeltter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Combx_TypeFeltter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Combx_TypeFeltter.ItemHeight = 30;
            this.Combx_TypeFeltter.Items.AddRange(new object[] {
            "عرض الكل",
            "أسم الطبيب",
            "المعرف الشخصي",
            "معرف الطبيب",
            "الاختصاص",
            "رقم الهاتف"});
            this.Combx_TypeFeltter.Location = new System.Drawing.Point(125, 9);
            this.Combx_TypeFeltter.Name = "Combx_TypeFeltter";
            this.Combx_TypeFeltter.Size = new System.Drawing.Size(250, 36);
            this.Combx_TypeFeltter.TabIndex = 8;
            this.Combx_TypeFeltter.SelectedIndexChanged += new System.EventHandler(this.Combx_TypeFeltter_SelectedIndexChanged);
            // 
            // Ctrl_FeltterDataDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_TextSearch);
            this.Controls.Add(this.Combx_TypeFeltter);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Ctrl_FeltterDataDoctors";
            this.Size = new System.Drawing.Size(778, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse ElipseControl;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Search;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox Txt_TextSearch;
        private Guna.UI2.WinForms.Guna2ComboBox Combx_TypeFeltter;
    }
}

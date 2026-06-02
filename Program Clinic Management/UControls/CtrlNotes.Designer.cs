namespace Program_Clinic_Management.UControls
{
    partial class CtrlNotes
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
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.txt_Info = new System.Windows.Forms.RichTextBox();
            this.ElipseTextBox = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ElipsePnl = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.PicTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // ElipseControl
            // 
            this.ElipseControl.BorderRadius = 20;
            this.ElipseControl.TargetControl = this;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.PicTitle);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(189, 8);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(470, 61);
            this.pnlTitle.TabIndex = 0;
            // 
            // txt_Info
            // 
            this.txt_Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Info.Location = new System.Drawing.Point(26, 80);
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Info.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txt_Info.Size = new System.Drawing.Size(799, 169);
            this.txt_Info.TabIndex = 1;
            this.txt_Info.Text = "";
            // 
            // ElipseTextBox
            // 
            this.ElipseTextBox.BorderRadius = 15;
            this.ElipseTextBox.TargetControl = this.txt_Info;
            // 
            // ElipsePnl
            // 
            this.ElipsePnl.BorderRadius = 30;
            this.ElipsePnl.TargetControl = this.pnlTitle;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(84, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(50, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // PicTitle
            // 
            this.PicTitle.BackColor = System.Drawing.Color.Transparent;
            this.PicTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicTitle.FillColor = System.Drawing.Color.Transparent;
            this.PicTitle.Image = global::Program_Clinic_Management.Properties.Resources.NextPage;
            this.PicTitle.ImageRotate = 0F;
            this.PicTitle.Location = new System.Drawing.Point(392, 8);
            this.PicTitle.Name = "PicTitle";
            this.PicTitle.Size = new System.Drawing.Size(50, 45);
            this.PicTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTitle.TabIndex = 2;
            this.PicTitle.TabStop = false;
            this.PicTitle.Click += new System.EventHandler(this.PicTitle_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Navy;
            this.guna2Panel1.Location = new System.Drawing.Point(126, 254);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(600, 1);
            this.guna2Panel1.TabIndex = 2;
            // 
            // CtrlNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CtrlNotes";
            this.Size = new System.Drawing.Size(850, 77);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse ElipseControl;
        private System.Windows.Forms.RichTextBox txt_Info;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private Guna.UI2.WinForms.Guna2PictureBox PicTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Elipse ElipseTextBox;
        private Guna.UI2.WinForms.Guna2Elipse ElipsePnl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}

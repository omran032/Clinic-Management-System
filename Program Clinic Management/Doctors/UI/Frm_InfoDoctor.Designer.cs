namespace Program_Clinic_Management.Doctors.UI
{
    partial class Frm_InfoDoctor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrl_PersonInfo1 = new Program_Clinic_Management.Persons.UControls.Ctrl_PersonInfo();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_TopBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TopBar
            // 
            this.pnl_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnl_TopBar.Controls.Add(this.guna2Panel1);
            this.pnl_TopBar.Controls.Add(this.ctrl_IconProjectClinic1);
            this.pnl_TopBar.Controls.Add(this.label1);
            this.pnl_TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopBar.Name = "pnl_TopBar";
            this.pnl_TopBar.Size = new System.Drawing.Size(824, 61);
            this.pnl_TopBar.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(688, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(136, 61);
            this.guna2Panel1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Program_Clinic_Management.Properties.Resources.X;
            this.btnClose.ImageRotate = 0F;
            this.btnClose.Location = new System.Drawing.Point(94, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::Program_Clinic_Management.Properties.Resources.Minimize;
            this.btnMinimize.ImageRotate = 0F;
            this.btnMinimize.Location = new System.Drawing.Point(43, 14);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 30);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.TabStop = false;
            // 
            // ctrl_IconProjectClinic1
            // 
            this.ctrl_IconProjectClinic1.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_IconProjectClinic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_IconProjectClinic1.Location = new System.Drawing.Point(-26, 0);
            this.ctrl_IconProjectClinic1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrl_IconProjectClinic1.Name = "ctrl_IconProjectClinic1";
            this.ctrl_IconProjectClinic1.Size = new System.Drawing.Size(246, 57);
            this.ctrl_IconProjectClinic1.TabIndex = 4;
            this.ctrl_IconProjectClinic1.TitleNameColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(367, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "معلومات الطبيب";
            // 
            // ctrl_PersonInfo1
            // 
            this.ctrl_PersonInfo1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PersonInfo1.GroupTitle = "المعلومات الشخصية للطبيب";
            this.ctrl_PersonInfo1.Location = new System.Drawing.Point(33, 74);
            this.ctrl_PersonInfo1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrl_PersonInfo1.Name = "ctrl_PersonInfo1";
            this.ctrl_PersonInfo1.PersonID = 0;
            this.ctrl_PersonInfo1.PersonInfo = null;
            this.ctrl_PersonInfo1.Size = new System.Drawing.Size(768, 494);
            this.ctrl_PersonInfo1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Specialization :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 652);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Work period : ";
            // 
            // Frm_InfoDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 896);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrl_PersonInfo1);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Frm_InfoDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_InfoDoctor";
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private System.Windows.Forms.Label label1;
        private Persons.UControls.Ctrl_PersonInfo ctrl_PersonInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
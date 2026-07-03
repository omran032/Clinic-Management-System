namespace Program_Clinic_Management.Appointment.UI
{
    partial class FrmInfoAppointment
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
            this.components = new System.ComponentModel.Container();
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrl_InfoVisits_AppointmentsDoctor1 = new Program_Clinic_Management.Doctors.UControls.Ctrl_InfoVisits_AppointmentsDoctor();
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
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
            this.pnl_TopBar.Size = new System.Drawing.Size(1729, 61);
            this.pnl_TopBar.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(1593, 0);
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
            this.btnClose.Location = new System.Drawing.Point(85, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 36);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::Program_Clinic_Management.Properties.Resources.Minimize;
            this.btnMinimize.ImageRotate = 0F;
            this.btnMinimize.Location = new System.Drawing.Point(19, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(42, 40);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // ctrl_IconProjectClinic1
            // 
            this.ctrl_IconProjectClinic1.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_IconProjectClinic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_IconProjectClinic1.Location = new System.Drawing.Point(5, 3);
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
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(814, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "معلومات الموعد";
            // 
            // ctrl_InfoVisits_AppointmentsDoctor1
            // 
            this.ctrl_InfoVisits_AppointmentsDoctor1.BackColor = System.Drawing.Color.AliceBlue;
            this.ctrl_InfoVisits_AppointmentsDoctor1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoVisits_AppointmentsDoctor1.Location = new System.Drawing.Point(0, 59);
            this.ctrl_InfoVisits_AppointmentsDoctor1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_InfoVisits_AppointmentsDoctor1.Name = "ctrl_InfoVisits_AppointmentsDoctor1";
            this.ctrl_InfoVisits_AppointmentsDoctor1.Size = new System.Drawing.Size(1729, 885);
            this.ctrl_InfoVisits_AppointmentsDoctor1.TabIndex = 5;
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // FrmInfoAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1729, 947);
            this.Controls.Add(this.ctrl_InfoVisits_AppointmentsDoctor1);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmInfoAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInfoAppointment";
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private System.Windows.Forms.Label label1;
        private Doctors.UControls.Ctrl_InfoVisits_AppointmentsDoctor ctrl_InfoVisits_AppointmentsDoctor1;
        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
    }
}
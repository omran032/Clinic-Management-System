namespace Program_Clinic_Management.Dashboard
{
    partial class FrmDashboardDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboardDoctor));
            this.pnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlList = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSettings = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Visits = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Appointments = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnPatients = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(57)))), ((int)(((byte)(107)))));
            this.pnlTopBar.Controls.Add(this.ctrl_IconProjectClinic1);
            this.pnlTopBar.Controls.Add(this.lblDate);
            this.pnlTopBar.Controls.Add(this.lblNameUser);
            this.pnlTopBar.Controls.Add(this.pictureBox1);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1222, 65);
            this.pnlTopBar.TabIndex = 2;
            // 
            // ctrl_IconProjectClinic1
            // 
            this.ctrl_IconProjectClinic1.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_IconProjectClinic1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrl_IconProjectClinic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_IconProjectClinic1.Location = new System.Drawing.Point(0, 0);
            this.ctrl_IconProjectClinic1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_IconProjectClinic1.Name = "ctrl_IconProjectClinic1";
            this.ctrl_IconProjectClinic1.Size = new System.Drawing.Size(240, 65);
            this.ctrl_IconProjectClinic1.TabIndex = 4;
            this.ctrl_IconProjectClinic1.TitleNameColor = System.Drawing.Color.White;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(421, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(260, 19);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = " AM 8:30  2026 / 5 / 25   الإثنين";
            // 
            // lblNameUser
            // 
            this.lblNameUser.AutoSize = true;
            this.lblNameUser.BackColor = System.Drawing.Color.Transparent;
            this.lblNameUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameUser.ForeColor = System.Drawing.Color.White;
            this.lblNameUser.Location = new System.Drawing.Point(910, 22);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.Size = new System.Drawing.Size(225, 19);
            this.lblNameUser.TabIndex = 2;
            this.lblNameUser.Text = "Admin : Mohammad Sayed";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1151, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PnlList
            // 
            this.PnlList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.PnlList.Controls.Add(this.btnSettings);
            this.PnlList.Controls.Add(this.btn_Visits);
            this.PnlList.Controls.Add(this.btn_Appointments);
            this.PnlList.Controls.Add(this.btnPatients);
            this.PnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlList.Location = new System.Drawing.Point(0, 65);
            this.PnlList.Name = "PnlList";
            this.PnlList.Size = new System.Drawing.Size(240, 627);
            this.PnlList.TabIndex = 3;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderRadius = 5;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSettings.FillColor2 = System.Drawing.Color.Cyan;
            this.btnSettings.FocusedColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageOffset = new System.Drawing.Point(-12, 0);
            this.btnSettings.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSettings.Location = new System.Drawing.Point(12, 362);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(210, 47);
            this.btnSettings.TabIndex = 27;
            this.btnSettings.Text = "Sittings";
            // 
            // btn_Visits
            // 
            this.btn_Visits.BackColor = System.Drawing.Color.Transparent;
            this.btn_Visits.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Visits.BorderRadius = 5;
            this.btn_Visits.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Visits.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Visits.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Visits.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Visits.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Visits.FillColor = System.Drawing.Color.RoyalBlue;
            this.btn_Visits.FillColor2 = System.Drawing.Color.Cyan;
            this.btn_Visits.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_Visits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Visits.ForeColor = System.Drawing.Color.White;
            this.btn_Visits.Image = global::Program_Clinic_Management.Properties.Resources.Date;
            this.btn_Visits.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btn_Visits.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_Visits.Location = new System.Drawing.Point(12, 248);
            this.btn_Visits.Name = "btn_Visits";
            this.btn_Visits.Size = new System.Drawing.Size(210, 47);
            this.btn_Visits.TabIndex = 17;
            this.btn_Visits.Text = "الزيارات";
            this.btn_Visits.Click += new System.EventHandler(this.btn_Visits_Click);
            // 
            // btn_Appointments
            // 
            this.btn_Appointments.BackColor = System.Drawing.Color.Transparent;
            this.btn_Appointments.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Appointments.BorderRadius = 5;
            this.btn_Appointments.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Appointments.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Appointments.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Appointments.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Appointments.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Appointments.FillColor = System.Drawing.Color.RoyalBlue;
            this.btn_Appointments.FillColor2 = System.Drawing.Color.Cyan;
            this.btn_Appointments.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_Appointments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Appointments.ForeColor = System.Drawing.Color.White;
            this.btn_Appointments.Image = global::Program_Clinic_Management.Properties.Resources.Appointment;
            this.btn_Appointments.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btn_Appointments.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_Appointments.Location = new System.Drawing.Point(12, 139);
            this.btn_Appointments.Name = "btn_Appointments";
            this.btn_Appointments.Size = new System.Drawing.Size(210, 47);
            this.btn_Appointments.TabIndex = 15;
            this.btn_Appointments.Text = "المواعيد";
            // 
            // btnPatients
            // 
            this.btnPatients.BackColor = System.Drawing.Color.Transparent;
            this.btnPatients.BorderColor = System.Drawing.Color.Transparent;
            this.btnPatients.BorderRadius = 5;
            this.btnPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPatients.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPatients.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnPatients.FillColor2 = System.Drawing.Color.Cyan;
            this.btnPatients.FocusedColor = System.Drawing.Color.Transparent;
            this.btnPatients.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatients.ForeColor = System.Drawing.Color.White;
            this.btnPatients.Image = ((System.Drawing.Image)(resources.GetObject("btnPatients.Image")));
            this.btnPatients.ImageOffset = new System.Drawing.Point(-19, 0);
            this.btnPatients.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPatients.Location = new System.Drawing.Point(12, 34);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(210, 47);
            this.btnPatients.TabIndex = 11;
            this.btnPatients.Text = "المرضى";
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // FrmDashboardDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1222, 692);
            this.Controls.Add(this.PnlList);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmDashboardDoctor";
            this.Text = "Dashboard Doctor";
            this.Load += new System.EventHandler(this.FrmDashboardDoctor_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNameUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private Guna.UI2.WinForms.Guna2Panel PnlList;
        private Guna.UI2.WinForms.Guna2GradientButton btnSettings;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Visits;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Appointments;
        private Guna.UI2.WinForms.Guna2GradientButton btnPatients;
    }
}
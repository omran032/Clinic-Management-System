namespace Program_Clinic_Management.Visits
{
    partial class FrmAdd_UpdateVisit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdd_UpdateVisit));
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnShowInfoDoctor = new Guna.UI2.WinForms.Guna2Button();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboxVisitTypes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSaveVisit = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshDataTable = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboxDoctors = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblTimeAppointment = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblVisitDate = new System.Windows.Forms.Label();
            this.lblVisitType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNameDoctor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DataGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MyContextMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenu_btnShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnInfoPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.CombxStatusAppointment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CombxStatusVisit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_TopBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).BeginInit();
            this.MyContextMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TopBar
            // 
            this.pnl_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnl_TopBar.Controls.Add(this.guna2Panel1);
            this.pnl_TopBar.Controls.Add(this.ctrl_IconProjectClinic1);
            this.pnl_TopBar.Controls.Add(this.lblTitle);
            this.pnl_TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopBar.Name = "pnl_TopBar";
            this.pnl_TopBar.Size = new System.Drawing.Size(1422, 61);
            this.pnl_TopBar.TabIndex = 6;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(1286, 0);
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
            this.ctrl_IconProjectClinic1.Location = new System.Drawing.Point(-15, 3);
            this.ctrl_IconProjectClinic1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrl_IconProjectClinic1.Name = "ctrl_IconProjectClinic1";
            this.ctrl_IconProjectClinic1.Size = new System.Drawing.Size(246, 57);
            this.ctrl_IconProjectClinic1.TabIndex = 4;
            this.ctrl_IconProjectClinic1.TitleNameColor = System.Drawing.Color.White;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(674, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 36);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Start Visit";
            // 
            // btnShowInfoDoctor
            // 
            this.btnShowInfoDoctor.BorderRadius = 5;
            this.btnShowInfoDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowInfoDoctor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoDoctor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoDoctor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowInfoDoctor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowInfoDoctor.FillColor = System.Drawing.Color.MediumBlue;
            this.btnShowInfoDoctor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInfoDoctor.ForeColor = System.Drawing.Color.White;
            this.btnShowInfoDoctor.Location = new System.Drawing.Point(848, 93);
            this.btnShowInfoDoctor.Name = "btnShowInfoDoctor";
            this.btnShowInfoDoctor.Size = new System.Drawing.Size(162, 33);
            this.btnShowInfoDoctor.TabIndex = 42;
            this.btnShowInfoDoctor.Text = "معلومات الطبيب";
            this.btnShowInfoDoctor.Visible = false;
            this.btnShowInfoDoctor.Click += new System.EventHandler(this.btnShowInfoDoctor_Click);
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialization.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialization.ForeColor = System.Drawing.Color.Black;
            this.lblSpecialization.Location = new System.Drawing.Point(443, 93);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(60, 22);
            this.lblSpecialization.TabIndex = 29;
            this.lblSpecialization.Text = "          ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 674);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "نوع الزيارة ";
            // 
            // ComboxVisitTypes
            // 
            this.ComboxVisitTypes.BackColor = System.Drawing.Color.Transparent;
            this.ComboxVisitTypes.BorderRadius = 10;
            this.ComboxVisitTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxVisitTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxVisitTypes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxVisitTypes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxVisitTypes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxVisitTypes.ForeColor = System.Drawing.Color.Black;
            this.ComboxVisitTypes.ItemHeight = 30;
            this.ComboxVisitTypes.Location = new System.Drawing.Point(113, 668);
            this.ComboxVisitTypes.Name = "ComboxVisitTypes";
            this.ComboxVisitTypes.Size = new System.Drawing.Size(217, 36);
            this.ComboxVisitTypes.TabIndex = 10;
            this.ComboxVisitTypes.SelectedIndexChanged += new System.EventHandler(this.ComboxVisitTypes_SelectedIndexChanged);
            // 
            // btnSaveVisit
            // 
            this.btnSaveVisit.BorderRadius = 5;
            this.btnSaveVisit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveVisit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveVisit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveVisit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveVisit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveVisit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(111)))), ((int)(((byte)(207)))));
            this.btnSaveVisit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveVisit.ForeColor = System.Drawing.Color.White;
            this.btnSaveVisit.Location = new System.Drawing.Point(401, 732);
            this.btnSaveVisit.Name = "btnSaveVisit";
            this.btnSaveVisit.Size = new System.Drawing.Size(311, 51);
            this.btnSaveVisit.TabIndex = 43;
            this.btnSaveVisit.Text = "تسجيل الزيارة";
            this.btnSaveVisit.Visible = false;
            this.btnSaveVisit.Click += new System.EventHandler(this.btnSaveVisit_Click);
            // 
            // btnRefreshDataTable
            // 
            this.btnRefreshDataTable.BorderRadius = 5;
            this.btnRefreshDataTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDataTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshDataTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshDataTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshDataTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshDataTable.FillColor = System.Drawing.Color.MediumBlue;
            this.btnRefreshDataTable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDataTable.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDataTable.Location = new System.Drawing.Point(886, 166);
            this.btnRefreshDataTable.Name = "btnRefreshDataTable";
            this.btnRefreshDataTable.Size = new System.Drawing.Size(124, 40);
            this.btnRefreshDataTable.TabIndex = 44;
            this.btnRefreshDataTable.Text = "تحديث";
            this.btnRefreshDataTable.Click += new System.EventHandler(this.btnRefreshDataTable_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 93);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(98, 22);
            this.label8.TabIndex = 44;
            this.label8.Text = "مواعيد الطبيب";
            // 
            // ComboxDoctors
            // 
            this.ComboxDoctors.BackColor = System.Drawing.Color.Transparent;
            this.ComboxDoctors.BorderRadius = 10;
            this.ComboxDoctors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxDoctors.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxDoctors.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxDoctors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxDoctors.ForeColor = System.Drawing.Color.Black;
            this.ComboxDoctors.ItemHeight = 30;
            this.ComboxDoctors.Location = new System.Drawing.Point(141, 87);
            this.ComboxDoctors.Name = "ComboxDoctors";
            this.ComboxDoctors.Size = new System.Drawing.Size(271, 36);
            this.ComboxDoctors.TabIndex = 43;
            this.ComboxDoctors.SelectedIndexChanged += new System.EventHandler(this.ComboxDoctors_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(88, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 1);
            this.panel1.TabIndex = 46;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.lblTimeAppointment);
            this.guna2GroupBox1.Controls.Add(this.label9);
            this.guna2GroupBox1.Controls.Add(this.lblScore);
            this.guna2GroupBox1.Controls.Add(this.label18);
            this.guna2GroupBox1.Controls.Add(this.panel5);
            this.guna2GroupBox1.Controls.Add(this.lblDuration);
            this.guna2GroupBox1.Controls.Add(this.label15);
            this.guna2GroupBox1.Controls.Add(this.lblVisitDate);
            this.guna2GroupBox1.Controls.Add(this.lblVisitType);
            this.guna2GroupBox1.Controls.Add(this.label11);
            this.guna2GroupBox1.Controls.Add(this.label10);
            this.guna2GroupBox1.Controls.Add(this.panel3);
            this.guna2GroupBox1.Controls.Add(this.lblNameDoctor);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.lblPatientName);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(111)))), ((int)(((byte)(207)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(1057, 166);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(353, 470);
            this.guna2GroupBox1.TabIndex = 47;
            this.guna2GroupBox1.Text = "تفاصيل الموعد";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTimeAppointment
            // 
            this.lblTimeAppointment.AutoSize = true;
            this.lblTimeAppointment.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeAppointment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeAppointment.ForeColor = System.Drawing.Color.Black;
            this.lblTimeAppointment.Location = new System.Drawing.Point(128, 280);
            this.lblTimeAppointment.Name = "lblTimeAppointment";
            this.lblTimeAppointment.Size = new System.Drawing.Size(40, 22);
            this.lblTimeAppointment.TabIndex = 41;
            this.lblTimeAppointment.Text = "___";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(49, 280);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(55, 22);
            this.label9.TabIndex = 40;
            this.label9.Text = ": الوقت";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Black;
            this.lblScore.Location = new System.Drawing.Point(128, 415);
            this.lblScore.Name = "lblScore";
            this.lblScore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblScore.Size = new System.Drawing.Size(40, 22);
            this.lblScore.TabIndex = 39;
            this.lblScore.Text = "___";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(25, 415);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label18.Size = new System.Drawing.Size(99, 22);
            this.label18.TabIndex = 36;
            this.label18.Text = ": درجة الإلتزام";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(22, 392);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 1);
            this.panel5.TabIndex = 19;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Location = new System.Drawing.Point(128, 336);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(40, 22);
            this.lblDuration.TabIndex = 33;
            this.lblDuration.Text = "___";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(23, 336);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(99, 22);
            this.label15.TabIndex = 32;
            this.label15.Text = ": المدة المقدرة";
            // 
            // lblVisitDate
            // 
            this.lblVisitDate.AutoSize = true;
            this.lblVisitDate.BackColor = System.Drawing.Color.Transparent;
            this.lblVisitDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitDate.ForeColor = System.Drawing.Color.Black;
            this.lblVisitDate.Location = new System.Drawing.Point(128, 224);
            this.lblVisitDate.Name = "lblVisitDate";
            this.lblVisitDate.Size = new System.Drawing.Size(40, 22);
            this.lblVisitDate.TabIndex = 31;
            this.lblVisitDate.Text = "___";
            // 
            // lblVisitType
            // 
            this.lblVisitType.AutoSize = true;
            this.lblVisitType.BackColor = System.Drawing.Color.Transparent;
            this.lblVisitType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitType.ForeColor = System.Drawing.Color.Black;
            this.lblVisitType.Location = new System.Drawing.Point(128, 168);
            this.lblVisitType.Name = "lblVisitType";
            this.lblVisitType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVisitType.Size = new System.Drawing.Size(40, 22);
            this.lblVisitType.TabIndex = 30;
            this.lblVisitType.Text = "___";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(22, 224);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(100, 22);
            this.label11.TabIndex = 29;
            this.label11.Text = ": تاريخ الموعد";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(33, 168);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(89, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = ": نوع الزيارة";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(17, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 1);
            this.panel3.TabIndex = 17;
            // 
            // lblNameDoctor
            // 
            this.lblNameDoctor.AutoSize = true;
            this.lblNameDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lblNameDoctor.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameDoctor.ForeColor = System.Drawing.Color.Black;
            this.lblNameDoctor.Location = new System.Drawing.Point(92, 106);
            this.lblNameDoctor.Name = "lblNameDoctor";
            this.lblNameDoctor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNameDoctor.Size = new System.Drawing.Size(30, 22);
            this.lblNameDoctor.TabIndex = 27;
            this.lblNameDoctor.Text = "    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = ": الطبيب";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.ForeColor = System.Drawing.Color.Black;
            this.lblPatientName.Location = new System.Drawing.Point(92, 58);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPatientName.Size = new System.Drawing.Size(30, 22);
            this.lblPatientName.TabIndex = 25;
            this.lblPatientName.Text = "    ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(34, 58);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(52, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = ": الاسم";
            // 
            // DataGV
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.DataGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGV.ColumnHeadersHeight = 4;
            this.DataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGV.ContextMenuStrip = this.MyContextMS;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.Location = new System.Drawing.Point(22, 224);
            this.DataGV.Name = "DataGV";
            this.DataGV.RowHeadersVisible = false;
            this.DataGV.Size = new System.Drawing.Size(1009, 412);
            this.DataGV.TabIndex = 48;
            this.DataGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGV.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGV.ThemeStyle.ReadOnly = false;
            this.DataGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGV.ThemeStyle.RowsStyle.Height = 22;
            this.DataGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGV.SelectionChanged += new System.EventHandler(this.DataGV_SelectionChanged);
            // 
            // MyContextMS
            // 
            this.MyContextMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyContextMS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MyContextMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_btnShowInfo,
            this.ToolStripMenu_btnUpdate,
            this.ToolStripMenu_btnInfoPatient});
            this.MyContextMS.Name = "MyContextMS";
            this.MyContextMS.Size = new System.Drawing.Size(212, 118);
            // 
            // ToolStripMenu_btnShowInfo
            // 
            this.ToolStripMenu_btnShowInfo.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenu_btnShowInfo.Image")));
            this.ToolStripMenu_btnShowInfo.Name = "ToolStripMenu_btnShowInfo";
            this.ToolStripMenu_btnShowInfo.Size = new System.Drawing.Size(211, 38);
            this.ToolStripMenu_btnShowInfo.Text = "معلومات الموعد";
            this.ToolStripMenu_btnShowInfo.Click += new System.EventHandler(this.ToolStripMenu_btnShowInfo_Click);
            // 
            // ToolStripMenu_btnUpdate
            // 
            this.ToolStripMenu_btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenu_btnUpdate.Image")));
            this.ToolStripMenu_btnUpdate.Name = "ToolStripMenu_btnUpdate";
            this.ToolStripMenu_btnUpdate.Size = new System.Drawing.Size(211, 38);
            this.ToolStripMenu_btnUpdate.Text = "تعديل الوعد";
            this.ToolStripMenu_btnUpdate.Click += new System.EventHandler(this.ToolStripMenu_btnUpdate_Click);
            // 
            // ToolStripMenu_btnInfoPatient
            // 
            this.ToolStripMenu_btnInfoPatient.Name = "ToolStripMenu_btnInfoPatient";
            this.ToolStripMenu_btnInfoPatient.Size = new System.Drawing.Size(211, 38);
            this.ToolStripMenu_btnInfoPatient.Text = "معلومات المريض";
            this.ToolStripMenu_btnInfoPatient.Click += new System.EventHandler(this.ToolStripMenu_btnInfoPatient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(718, 674);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(83, 22);
            this.label4.TabIndex = 50;
            this.label4.Text = "حالة الموعد";
            // 
            // CombxStatusAppointment
            // 
            this.CombxStatusAppointment.BackColor = System.Drawing.Color.Transparent;
            this.CombxStatusAppointment.BorderRadius = 10;
            this.CombxStatusAppointment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxStatusAppointment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxStatusAppointment.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxStatusAppointment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxStatusAppointment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxStatusAppointment.ForeColor = System.Drawing.Color.Black;
            this.CombxStatusAppointment.ItemHeight = 30;
            this.CombxStatusAppointment.Items.AddRange(new object[] {
            "Pinding",
            "In Progress",
            "Completed",
            "Delayed",
            "Absent",
            "Cancelled"});
            this.CombxStatusAppointment.Location = new System.Drawing.Point(814, 668);
            this.CombxStatusAppointment.Name = "CombxStatusAppointment";
            this.CombxStatusAppointment.Size = new System.Drawing.Size(217, 36);
            this.CombxStatusAppointment.TabIndex = 49;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(111)))), ((int)(((byte)(207)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1132, 656);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(241, 40);
            this.guna2Button1.TabIndex = 52;
            this.guna2Button1.Text = " معلومات المريض";
            this.guna2Button1.Click += new System.EventHandler(this.ToolStripMenu_btnInfoPatient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(361, 674);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(81, 22);
            this.label5.TabIndex = 54;
            this.label5.Text = "حالة الزيارة";
            // 
            // CombxStatusVisit
            // 
            this.CombxStatusVisit.BackColor = System.Drawing.Color.Transparent;
            this.CombxStatusVisit.BorderRadius = 10;
            this.CombxStatusVisit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxStatusVisit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxStatusVisit.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxStatusVisit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxStatusVisit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxStatusVisit.ForeColor = System.Drawing.Color.Black;
            this.CombxStatusVisit.ItemHeight = 30;
            this.CombxStatusVisit.Items.AddRange(new object[] {
            "No Started",
            "In Progress",
            "Completed",
            "No Show"});
            this.CombxStatusVisit.Location = new System.Drawing.Point(457, 668);
            this.CombxStatusVisit.Name = "CombxStatusVisit";
            this.CombxStatusVisit.Size = new System.Drawing.Size(217, 36);
            this.CombxStatusVisit.TabIndex = 53;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAdd_UpdateVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1422, 805);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CombxStatusVisit);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CombxStatusAppointment);
            this.Controls.Add(this.DataGV);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowInfoDoctor);
            this.Controls.Add(this.ComboxVisitTypes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.btnRefreshDataTable);
            this.Controls.Add(this.ComboxDoctors);
            this.Controls.Add(this.btnSaveVisit);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmAdd_UpdateVisit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddVisit";
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).EndInit();
            this.MyContextMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnShowInfoDoctor;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxVisitTypes;
        private Guna.UI2.WinForms.Guna2Button btnSaveVisit;
        private Guna.UI2.WinForms.Guna2Button btnRefreshDataTable;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxDoctors;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblVisitDate;
        private System.Windows.Forms.Label lblVisitType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNameDoctor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DataGridView DataGV;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox CombxStatusAppointment;
        private System.Windows.Forms.ContextMenuStrip MyContextMS;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnShowInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnInfoPatient;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox CombxStatusVisit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTimeAppointment;
        private System.Windows.Forms.Label label9;
    }
}
namespace Program_Clinic_Management.Patients.UI
{
    partial class FrmAdd_UpdatePatient
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
            this.lblID_Patient = new System.Windows.Forms.Label();
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.picTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Next = new Guna.UI2.WinForms.Guna2Button();
            this.btn_AddPerson = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrl_PersonInfo = new Program_Clinic_Management.Persons.UControls.Ctrl_PersonInfo();
            this.ctrl_FeltterDataPersons = new Program_Clinic_Management.Persons.UControls.Ctrl_FeltterDataPersons();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PnlInfoPatient = new Guna.UI2.WinForms.Guna2Panel();
            this.Txt_Allergies = new Guna.UI2.WinForms.Guna2TextBox();
            this.Txt_MedicalNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_ChronicDiseases = new Guna.UI2.WinForms.Guna2TextBox();
            this.Txt_Notes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PnlStatusPatient = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_ComplianceScore = new System.Windows.Forms.Label();
            this.lbl_StatusComplianceScore = new System.Windows.Forms.Label();
            this.lblFirstVisitDate = new System.Windows.Forms.Label();
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnl_TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PnlInfoPatient.SuspendLayout();
            this.PnlStatusPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID_Patient
            // 
            this.lblID_Patient.AutoSize = true;
            this.lblID_Patient.BackColor = System.Drawing.Color.Transparent;
            this.lblID_Patient.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID_Patient.ForeColor = System.Drawing.Color.Maroon;
            this.lblID_Patient.Location = new System.Drawing.Point(389, 92);
            this.lblID_Patient.Name = "lblID_Patient";
            this.lblID_Patient.Size = new System.Drawing.Size(114, 24);
            this.lblID_Patient.TabIndex = 23;
            this.lblID_Patient.Text = "ID Patient: ";
            // 
            // pnl_TopBar
            // 
            this.pnl_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnl_TopBar.Controls.Add(this.picTitle);
            this.pnl_TopBar.Controls.Add(this.lblTitle);
            this.pnl_TopBar.Controls.Add(this.guna2Panel1);
            this.pnl_TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopBar.Name = "pnl_TopBar";
            this.pnl_TopBar.Size = new System.Drawing.Size(955, 62);
            this.pnl_TopBar.TabIndex = 22;
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.Transparent;
            this.picTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTitle.Image = global::Program_Clinic_Management.Properties.Resources.user;
            this.picTitle.ImageRotate = 0F;
            this.picTitle.Location = new System.Drawing.Point(384, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(45, 45);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTitle.TabIndex = 6;
            this.picTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(435, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 36);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Add";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(828, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(127, 62);
            this.guna2Panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Program_Clinic_Management.Properties.Resources.X;
            this.btnClose.ImageRotate = 0F;
            this.btnClose.Location = new System.Drawing.Point(80, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
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
            this.btnMinimize.Location = new System.Drawing.Point(24, 13);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 36);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Blue;
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Blue;
            this.btnSave.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Program_Clinic_Management.Properties.Resources.user;
            this.btnSave.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(295, 781);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(349, 50);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "إضافة";
            this.btnSave.TextOffset = new System.Drawing.Point(0, 3);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 119);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 639);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_Next);
            this.tabPage1.Controls.Add(this.btn_AddPerson);
            this.tabPage1.Controls.Add(this.ctrl_PersonInfo);
            this.tabPage1.Controls.Add(this.ctrl_FeltterDataPersons);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(918, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "المعلومات الشخصية";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Next
            // 
            this.btn_Next.BorderRadius = 20;
            this.btn_Next.BorderThickness = 1;
            this.btn_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Next.FillColor = System.Drawing.Color.Transparent;
            this.btn_Next.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.ForeColor = System.Drawing.Color.Black;
            this.btn_Next.Location = new System.Drawing.Point(792, 543);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(82, 44);
            this.btn_Next.TabIndex = 27;
            this.btn_Next.Text = "Next";
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_AddPerson
            // 
            this.btn_AddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddPerson.BorderColor = System.Drawing.Color.Blue;
            this.btn_AddPerson.BorderRadius = 10;
            this.btn_AddPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_AddPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_AddPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_AddPerson.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_AddPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_AddPerson.FillColor = System.Drawing.Color.RoyalBlue;
            this.btn_AddPerson.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_AddPerson.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddPerson.ForeColor = System.Drawing.Color.White;
            this.btn_AddPerson.Image = global::Program_Clinic_Management.Properties.Resources.user;
            this.btn_AddPerson.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_AddPerson.Location = new System.Drawing.Point(822, 36);
            this.btn_AddPerson.Name = "btn_AddPerson";
            this.btn_AddPerson.Size = new System.Drawing.Size(59, 44);
            this.btn_AddPerson.TabIndex = 26;
            this.btn_AddPerson.TextOffset = new System.Drawing.Point(0, 3);
            this.btn_AddPerson.Click += new System.EventHandler(this.btn_AddPerson_Click);
            // 
            // ctrl_PersonInfo
            // 
            this.ctrl_PersonInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PersonInfo.GroupTitle = null;
            this.ctrl_PersonInfo.Location = new System.Drawing.Point(157, 110);
            this.ctrl_PersonInfo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_PersonInfo.Name = "ctrl_PersonInfo";
            this.ctrl_PersonInfo.PersonID = 0;
            this.ctrl_PersonInfo.PersonInfo = null;
            this.ctrl_PersonInfo.Size = new System.Drawing.Size(576, 427);
            this.ctrl_PersonInfo.TabIndex = 1;
            // 
            // ctrl_FeltterDataPersons
            // 
            this.ctrl_FeltterDataPersons.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_FeltterDataPersons.Location = new System.Drawing.Point(62, 30);
            this.ctrl_FeltterDataPersons.Margin = new System.Windows.Forms.Padding(5);
            this.ctrl_FeltterDataPersons.Name = "ctrl_FeltterDataPersons";
            this.ctrl_FeltterDataPersons.Size = new System.Drawing.Size(775, 58);
            this.ctrl_FeltterDataPersons.TabIndex = 0;
            this.ctrl_FeltterDataPersons.TrueSearchAll = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PnlInfoPatient);
            this.tabPage2.Controls.Add(this.PnlStatusPatient);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(918, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "معلومات المريض";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PnlInfoPatient
            // 
            this.PnlInfoPatient.Controls.Add(this.Txt_Allergies);
            this.PnlInfoPatient.Controls.Add(this.Txt_MedicalNotes);
            this.PnlInfoPatient.Controls.Add(this.label1);
            this.PnlInfoPatient.Controls.Add(this.label4);
            this.PnlInfoPatient.Controls.Add(this.Txt_ChronicDiseases);
            this.PnlInfoPatient.Controls.Add(this.Txt_Notes);
            this.PnlInfoPatient.Controls.Add(this.label2);
            this.PnlInfoPatient.Controls.Add(this.label3);
            this.PnlInfoPatient.Location = new System.Drawing.Point(6, 6);
            this.PnlInfoPatient.Name = "PnlInfoPatient";
            this.PnlInfoPatient.Size = new System.Drawing.Size(885, 482);
            this.PnlInfoPatient.TabIndex = 11;
            // 
            // Txt_Allergies
            // 
            this.Txt_Allergies.AutoScroll = true;
            this.Txt_Allergies.BorderRadius = 15;
            this.Txt_Allergies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_Allergies.DefaultText = "";
            this.Txt_Allergies.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_Allergies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_Allergies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_Allergies.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_Allergies.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_Allergies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_Allergies.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_Allergies.Location = new System.Drawing.Point(35, 274);
            this.Txt_Allergies.Multiline = true;
            this.Txt_Allergies.Name = "Txt_Allergies";
            this.Txt_Allergies.PlaceholderText = "";
            this.Txt_Allergies.SelectedText = "";
            this.Txt_Allergies.Size = new System.Drawing.Size(815, 73);
            this.Txt_Allergies.TabIndex = 4;
            this.Txt_Allergies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_MedicalNotes
            // 
            this.Txt_MedicalNotes.AutoScroll = true;
            this.Txt_MedicalNotes.BorderRadius = 15;
            this.Txt_MedicalNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_MedicalNotes.DefaultText = "";
            this.Txt_MedicalNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_MedicalNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_MedicalNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_MedicalNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_MedicalNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_MedicalNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_MedicalNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_MedicalNotes.Location = new System.Drawing.Point(35, 44);
            this.Txt_MedicalNotes.Multiline = true;
            this.Txt_MedicalNotes.Name = "Txt_MedicalNotes";
            this.Txt_MedicalNotes.PlaceholderText = "";
            this.Txt_MedicalNotes.SelectedText = "";
            this.Txt_MedicalNotes.Size = new System.Drawing.Size(815, 73);
            this.Txt_MedicalNotes.TabIndex = 0;
            this.Txt_MedicalNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "ملاحظات طبية";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "ملاحظات";
            // 
            // Txt_ChronicDiseases
            // 
            this.Txt_ChronicDiseases.AutoScroll = true;
            this.Txt_ChronicDiseases.BorderRadius = 15;
            this.Txt_ChronicDiseases.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_ChronicDiseases.DefaultText = "";
            this.Txt_ChronicDiseases.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_ChronicDiseases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_ChronicDiseases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_ChronicDiseases.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_ChronicDiseases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_ChronicDiseases.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_ChronicDiseases.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_ChronicDiseases.Location = new System.Drawing.Point(35, 158);
            this.Txt_ChronicDiseases.Multiline = true;
            this.Txt_ChronicDiseases.Name = "Txt_ChronicDiseases";
            this.Txt_ChronicDiseases.PlaceholderText = "";
            this.Txt_ChronicDiseases.SelectedText = "";
            this.Txt_ChronicDiseases.Size = new System.Drawing.Size(815, 73);
            this.Txt_ChronicDiseases.TabIndex = 2;
            this.Txt_ChronicDiseases.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Notes
            // 
            this.Txt_Notes.AutoScroll = true;
            this.Txt_Notes.BorderRadius = 15;
            this.Txt_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_Notes.DefaultText = "";
            this.Txt_Notes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_Notes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_Notes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_Notes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_Notes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_Notes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_Notes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_Notes.Location = new System.Drawing.Point(35, 384);
            this.Txt_Notes.Multiline = true;
            this.Txt_Notes.Name = "Txt_Notes";
            this.Txt_Notes.PlaceholderText = "";
            this.Txt_Notes.SelectedText = "";
            this.Txt_Notes.Size = new System.Drawing.Size(815, 73);
            this.Txt_Notes.TabIndex = 6;
            this.Txt_Notes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "الأمراض المزمنة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "الحساسية";
            // 
            // PnlStatusPatient
            // 
            this.PnlStatusPatient.Controls.Add(this.lbl_ComplianceScore);
            this.PnlStatusPatient.Controls.Add(this.lbl_StatusComplianceScore);
            this.PnlStatusPatient.Controls.Add(this.lblFirstVisitDate);
            this.PnlStatusPatient.Location = new System.Drawing.Point(6, 491);
            this.PnlStatusPatient.Name = "PnlStatusPatient";
            this.PnlStatusPatient.Size = new System.Drawing.Size(885, 100);
            this.PnlStatusPatient.TabIndex = 8;
            // 
            // lbl_ComplianceScore
            // 
            this.lbl_ComplianceScore.AutoSize = true;
            this.lbl_ComplianceScore.Location = new System.Drawing.Point(631, 63);
            this.lbl_ComplianceScore.Name = "lbl_ComplianceScore";
            this.lbl_ComplianceScore.Size = new System.Drawing.Size(205, 22);
            this.lbl_ComplianceScore.TabIndex = 10;
            this.lbl_ComplianceScore.Text = "Degree of commitment :";
            this.toolTip1.SetToolTip(this.lbl_ComplianceScore, "درجة الالتزام بالمواعيد");
            // 
            // lbl_StatusComplianceScore
            // 
            this.lbl_StatusComplianceScore.AutoSize = true;
            this.lbl_StatusComplianceScore.Location = new System.Drawing.Point(85, 63);
            this.lbl_StatusComplianceScore.Name = "lbl_StatusComplianceScore";
            this.lbl_StatusComplianceScore.Size = new System.Drawing.Size(181, 22);
            this.lbl_StatusComplianceScore.TabIndex = 9;
            this.lbl_StatusComplianceScore.Text = "Commitment Status :";
            this.toolTip1.SetToolTip(this.lbl_StatusComplianceScore, " حالة الالتزام بالمواعيد");
            // 
            // lblFirstVisitDate
            // 
            this.lblFirstVisitDate.AutoSize = true;
            this.lblFirstVisitDate.Location = new System.Drawing.Point(81, 8);
            this.lblFirstVisitDate.Name = "lblFirstVisitDate";
            this.lblFirstVisitDate.Size = new System.Drawing.Size(186, 22);
            this.lblFirstVisitDate.TabIndex = 8;
            this.lblFirstVisitDate.Text = "Date of the first visit :";
            this.toolTip1.SetToolTip(this.lblFirstVisitDate, "تاريخ أول زيارة");
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // FrmAdd_UpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 870);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblID_Patient);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmAdd_UpdatePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdd_UpdatePatient";
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.PnlInfoPatient.ResumeLayout(false);
            this.PnlInfoPatient.PerformLayout();
            this.PnlStatusPatient.ResumeLayout(false);
            this.PnlStatusPatient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID_Patient;
        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2PictureBox picTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
        private Persons.UControls.Ctrl_FeltterDataPersons ctrl_FeltterDataPersons;
        private Persons.UControls.Ctrl_PersonInfo ctrl_PersonInfo;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox Txt_ChronicDiseases;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox Txt_MedicalNotes;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox Txt_Allergies;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox Txt_Notes;
        private System.Windows.Forms.Label lbl_ComplianceScore;
        private System.Windows.Forms.Label lbl_StatusComplianceScore;
        private System.Windows.Forms.Label lblFirstVisitDate;
        private Guna.UI2.WinForms.Guna2GradientButton btn_AddPerson;
        private Guna.UI2.WinForms.Guna2Button btn_Next;
        private Guna.UI2.WinForms.Guna2Panel PnlStatusPatient;
        private Guna.UI2.WinForms.Guna2Panel PnlInfoPatient;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
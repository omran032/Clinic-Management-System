namespace Program_Clinic_Management.Manage_Users
{
    partial class FrmAdd_UpdateUsers
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ComboxRoles = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboxSpicealizations = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSpecialization = new System.Windows.Forms.Panel();
            this.TxtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtPasswordFirst = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtPasswordSecond = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrl_PersonInfo1 = new Program_Clinic_Management.Persons.UControls.Ctrl_PersonInfo();
            this.ctrl_FeltterDataPersons1 = new Program_Clinic_Management.Persons.UControls.Ctrl_FeltterDataPersons();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PnlIsActive = new System.Windows.Forms.Panel();
            this.RdoIsNotActive = new Guna.UI2.WinForms.Guna2RadioButton();
            this.RdoIsActive = new Guna.UI2.WinForms.Guna2RadioButton();
            this.pnl_TopBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.pnlSpecialization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.PnlIsActive.SuspendLayout();
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
            this.pnl_TopBar.Size = new System.Drawing.Size(890, 61);
            this.pnl_TopBar.TabIndex = 8;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(754, 0);
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
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(432, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 36);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Add Users";
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // ComboxRoles
            // 
            this.ComboxRoles.BackColor = System.Drawing.Color.Transparent;
            this.ComboxRoles.BorderRadius = 10;
            this.ComboxRoles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxRoles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxRoles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboxRoles.ItemHeight = 30;
            this.ComboxRoles.Location = new System.Drawing.Point(145, 576);
            this.ComboxRoles.Name = "ComboxRoles";
            this.ComboxRoles.Size = new System.Drawing.Size(256, 36);
            this.ComboxRoles.TabIndex = 11;
            this.ComboxRoles.SelectedIndexChanged += new System.EventHandler(this.ComboxRoles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "الصلاحية";
            // 
            // ComboxSpicealizations
            // 
            this.ComboxSpicealizations.BackColor = System.Drawing.Color.Transparent;
            this.ComboxSpicealizations.BorderRadius = 10;
            this.ComboxSpicealizations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxSpicealizations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxSpicealizations.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxSpicealizations.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxSpicealizations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxSpicealizations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboxSpicealizations.ItemHeight = 30;
            this.ComboxSpicealizations.Location = new System.Drawing.Point(99, 2);
            this.ComboxSpicealizations.Name = "ComboxSpicealizations";
            this.ComboxSpicealizations.Size = new System.Drawing.Size(256, 36);
            this.ComboxSpicealizations.TabIndex = 14;
            this.ComboxSpicealizations.SelectedIndexChanged += new System.EventHandler(this.ComboxSpicealizations_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "الإختصاص";
            // 
            // pnlSpecialization
            // 
            this.pnlSpecialization.BackColor = System.Drawing.Color.Transparent;
            this.pnlSpecialization.Controls.Add(this.ComboxSpicealizations);
            this.pnlSpecialization.Controls.Add(this.label3);
            this.pnlSpecialization.Location = new System.Drawing.Point(439, 572);
            this.pnlSpecialization.Name = "pnlSpecialization";
            this.pnlSpecialization.Size = new System.Drawing.Size(376, 40);
            this.pnlSpecialization.TabIndex = 16;
            this.pnlSpecialization.Visible = false;
            // 
            // TxtUserName
            // 
            this.TxtUserName.BorderRadius = 15;
            this.TxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtUserName.DefaultText = "";
            this.TxtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Location = new System.Drawing.Point(301, 625);
            this.TxtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.PlaceholderText = "أسم المستخدم";
            this.TxtUserName.SelectedText = "";
            this.TxtUserName.Size = new System.Drawing.Size(316, 39);
            this.TxtUserName.TabIndex = 17;
            this.TxtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPasswordFirst
            // 
            this.TxtPasswordFirst.BorderRadius = 15;
            this.TxtPasswordFirst.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPasswordFirst.DefaultText = "";
            this.TxtPasswordFirst.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPasswordFirst.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPasswordFirst.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPasswordFirst.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPasswordFirst.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPasswordFirst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPasswordFirst.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPasswordFirst.Location = new System.Drawing.Point(519, 683);
            this.TxtPasswordFirst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtPasswordFirst.Name = "TxtPasswordFirst";
            this.TxtPasswordFirst.PlaceholderText = "كلمة المرور";
            this.TxtPasswordFirst.SelectedText = "";
            this.TxtPasswordFirst.Size = new System.Drawing.Size(316, 39);
            this.TxtPasswordFirst.TabIndex = 19;
            this.TxtPasswordFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPasswordSecond
            // 
            this.TxtPasswordSecond.BorderRadius = 15;
            this.TxtPasswordSecond.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPasswordSecond.DefaultText = "";
            this.TxtPasswordSecond.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPasswordSecond.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPasswordSecond.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPasswordSecond.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPasswordSecond.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPasswordSecond.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPasswordSecond.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPasswordSecond.Location = new System.Drawing.Point(60, 683);
            this.TxtPasswordSecond.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPasswordSecond.Name = "TxtPasswordSecond";
            this.TxtPasswordSecond.PlaceholderText = "تكرار كلمة المرور";
            this.TxtPasswordSecond.SelectedText = "";
            this.TxtPasswordSecond.Size = new System.Drawing.Size(316, 39);
            this.TxtPasswordSecond.TabIndex = 24;
            this.TxtPasswordSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnSave.Location = new System.Drawing.Point(285, 787);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(349, 50);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "إضافة";
            this.btnSave.TextOffset = new System.Drawing.Point(0, 3);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrl_PersonInfo1
            // 
            this.ctrl_PersonInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PersonInfo1.GroupTitle = null;
            this.ctrl_PersonInfo1.Location = new System.Drawing.Point(99, 137);
            this.ctrl_PersonInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_PersonInfo1.Name = "ctrl_PersonInfo1";
            this.ctrl_PersonInfo1.PersonID = 0;
            this.ctrl_PersonInfo1.PersonInfo = null;
            this.ctrl_PersonInfo1.Size = new System.Drawing.Size(716, 427);
            this.ctrl_PersonInfo1.TabIndex = 10;
            // 
            // ctrl_FeltterDataPersons1
            // 
            this.ctrl_FeltterDataPersons1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_FeltterDataPersons1.Location = new System.Drawing.Point(60, 70);
            this.ctrl_FeltterDataPersons1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrl_FeltterDataPersons1.Name = "ctrl_FeltterDataPersons1";
            this.ctrl_FeltterDataPersons1.Size = new System.Drawing.Size(775, 58);
            this.ctrl_FeltterDataPersons1.TabIndex = 9;
            this.ctrl_FeltterDataPersons1.TrueSearchAll = false;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PnlIsActive
            // 
            this.PnlIsActive.BackColor = System.Drawing.Color.Transparent;
            this.PnlIsActive.Controls.Add(this.RdoIsActive);
            this.PnlIsActive.Controls.Add(this.RdoIsNotActive);
            this.PnlIsActive.Location = new System.Drawing.Point(201, 741);
            this.PnlIsActive.Name = "PnlIsActive";
            this.PnlIsActive.Size = new System.Drawing.Size(505, 40);
            this.PnlIsActive.TabIndex = 17;
            this.PnlIsActive.Visible = false;
            // 
            // RdoIsNotActive
            // 
            this.RdoIsNotActive.AutoSize = true;
            this.RdoIsNotActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoIsNotActive.CheckedState.BorderThickness = 0;
            this.RdoIsNotActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RdoIsNotActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.RdoIsNotActive.CheckedState.InnerOffset = -4;
            this.RdoIsNotActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RdoIsNotActive.Location = new System.Drawing.Point(100, 9);
            this.RdoIsNotActive.Name = "RdoIsNotActive";
            this.RdoIsNotActive.Size = new System.Drawing.Size(82, 26);
            this.RdoIsNotActive.TabIndex = 26;
            this.RdoIsNotActive.Text = "غير فعّال";
            this.RdoIsNotActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RdoIsNotActive.UncheckedState.BorderThickness = 2;
            this.RdoIsNotActive.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.RdoIsNotActive.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // RdoIsActive
            // 
            this.RdoIsActive.AutoSize = true;
            this.RdoIsActive.Checked = true;
            this.RdoIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoIsActive.CheckedState.BorderThickness = 0;
            this.RdoIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RdoIsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.RdoIsActive.CheckedState.InnerOffset = -4;
            this.RdoIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.RdoIsActive.Location = new System.Drawing.Point(318, 11);
            this.RdoIsActive.Name = "RdoIsActive";
            this.RdoIsActive.Size = new System.Drawing.Size(54, 26);
            this.RdoIsActive.TabIndex = 27;
            this.RdoIsActive.TabStop = true;
            this.RdoIsActive.Text = "فعّال";
            this.RdoIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RdoIsActive.UncheckedState.BorderThickness = 2;
            this.RdoIsActive.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.RdoIsActive.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // FrmAdd_UpdateUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 856);
            this.Controls.Add(this.PnlIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TxtPasswordSecond);
            this.Controls.Add(this.TxtPasswordFirst);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.pnlSpecialization);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboxRoles);
            this.Controls.Add(this.ctrl_PersonInfo1);
            this.Controls.Add(this.ctrl_FeltterDataPersons1);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmAdd_UpdateUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdd_UpdateUsers";
            this.Load += new System.EventHandler(this.FrmAdd_UpdateUsers_Load);
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.pnlSpecialization.ResumeLayout(false);
            this.pnlSpecialization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.PnlIsActive.ResumeLayout(false);
            this.PnlIsActive.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
        private Persons.UControls.Ctrl_FeltterDataPersons ctrl_FeltterDataPersons1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxSpicealizations;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxRoles;
        private System.Windows.Forms.Panel pnlSpecialization;
        private Guna.UI2.WinForms.Guna2TextBox TxtPasswordFirst;
        private Guna.UI2.WinForms.Guna2TextBox TxtUserName;
        private Persons.UControls.Ctrl_PersonInfo ctrl_PersonInfo1;
        private Guna.UI2.WinForms.Guna2TextBox TxtPasswordSecond;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel PnlIsActive;
        private Guna.UI2.WinForms.Guna2RadioButton RdoIsActive;
        private Guna.UI2.WinForms.Guna2RadioButton RdoIsNotActive;
    }
}
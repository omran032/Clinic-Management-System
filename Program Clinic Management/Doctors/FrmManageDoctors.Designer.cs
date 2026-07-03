namespace Program_Clinic_Management.Doctors
{
    partial class FrmManageDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageDoctors));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.MyContextMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenu_btnShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.حجزموعدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجيلزيارةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ElipseDGV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.DataGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddDoctor = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrl_FeltterDataDoctors = new Program_Clinic_Management.Ctrl_FeltterDataDoctors();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            this.MyContextMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).BeginInit();
            this.pnl_TopBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // MyContextMS
            // 
            this.MyContextMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyContextMS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MyContextMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_btnShowInfo,
            this.ToolStripMenu_btnUpdate,
            this.ToolStripMenu_btnDelete,
            this.حجزموعدToolStripMenuItem,
            this.تسجيلزيارةToolStripMenuItem});
            this.MyContextMS.Name = "MyContextMS";
            this.MyContextMS.Size = new System.Drawing.Size(205, 194);
            // 
            // ToolStripMenu_btnShowInfo
            // 
            this.ToolStripMenu_btnShowInfo.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenu_btnShowInfo.Image")));
            this.ToolStripMenu_btnShowInfo.Name = "ToolStripMenu_btnShowInfo";
            this.ToolStripMenu_btnShowInfo.Size = new System.Drawing.Size(204, 38);
            this.ToolStripMenu_btnShowInfo.Text = "عرض المعلومات";
            this.ToolStripMenu_btnShowInfo.Click += new System.EventHandler(this.ToolStripMenu_btnShowInfo_Click);
            // 
            // ToolStripMenu_btnUpdate
            // 
            this.ToolStripMenu_btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenu_btnUpdate.Image")));
            this.ToolStripMenu_btnUpdate.Name = "ToolStripMenu_btnUpdate";
            this.ToolStripMenu_btnUpdate.Size = new System.Drawing.Size(204, 38);
            this.ToolStripMenu_btnUpdate.Text = "تعديل";
            this.ToolStripMenu_btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ToolStripMenu_btnDelete
            // 
            this.ToolStripMenu_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenu_btnDelete.Image")));
            this.ToolStripMenu_btnDelete.Name = "ToolStripMenu_btnDelete";
            this.ToolStripMenu_btnDelete.Size = new System.Drawing.Size(204, 38);
            this.ToolStripMenu_btnDelete.Text = "حذف";
            this.ToolStripMenu_btnDelete.Click += new System.EventHandler(this.ToolStripMenu_btnDelete_Click);
            // 
            // حجزموعدToolStripMenuItem
            // 
            this.حجزموعدToolStripMenuItem.Name = "حجزموعدToolStripMenuItem";
            this.حجزموعدToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.حجزموعدToolStripMenuItem.Text = "حجز موعد";
            // 
            // تسجيلزيارةToolStripMenuItem
            // 
            this.تسجيلزيارةToolStripMenuItem.Name = "تسجيلزيارةToolStripMenuItem";
            this.تسجيلزيارةToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.تسجيلزيارةToolStripMenuItem.Text = "تسجيل زيارة";
            // 
            // ElipseDGV
            // 
            this.ElipseDGV.BorderRadius = 25;
            this.ElipseDGV.TargetControl = this.DataGV;
            // 
            // DataGV
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.DataGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGV.ColumnHeadersHeight = 4;
            this.DataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGV.DefaultCellStyle = dataGridViewCellStyle9;
            this.DataGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.Location = new System.Drawing.Point(42, 187);
            this.DataGV.Name = "DataGV";
            this.DataGV.RowHeadersVisible = false;
            this.DataGV.Size = new System.Drawing.Size(1300, 330);
            this.DataGV.TabIndex = 4;
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
            this.pnl_TopBar.Size = new System.Drawing.Size(1398, 61);
            this.pnl_TopBar.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(1262, 0);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(677, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "الأطباء";
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDoctor.BorderColor = System.Drawing.Color.Blue;
            this.btnAddDoctor.BorderRadius = 10;
            this.btnAddDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDoctor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddDoctor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddDoctor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddDoctor.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddDoctor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddDoctor.FillColor = System.Drawing.Color.Blue;
            this.btnAddDoctor.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnAddDoctor.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDoctor.ForeColor = System.Drawing.Color.White;
            this.btnAddDoctor.Image = global::Program_Clinic_Management.Properties.Resources.user;
            this.btnAddDoctor.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddDoctor.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddDoctor.Location = new System.Drawing.Point(507, 653);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(212, 53);
            this.btnAddDoctor.TabIndex = 12;
            this.btnAddDoctor.Text = "إضافة";
            this.btnAddDoctor.Visible = false;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderColor = System.Drawing.Color.Blue;
            this.btnUpdate.BorderRadius = 10;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.FillColor2 = System.Drawing.Color.LimeGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::Program_Clinic_Management.Properties.Resources.Synchronize;
            this.btnUpdate.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnUpdate.ImageSize = new System.Drawing.Size(30, 30);
            this.btnUpdate.Location = new System.Drawing.Point(254, 566);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(212, 53);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "تعديل";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ctrl_FeltterDataDoctors
            // 
            this.ctrl_FeltterDataDoctors.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_FeltterDataDoctors.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_FeltterDataDoctors.Location = new System.Drawing.Point(42, 124);
            this.ctrl_FeltterDataDoctors.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_FeltterDataDoctors.Name = "ctrl_FeltterDataDoctors";
            this.ctrl_FeltterDataDoctors.Size = new System.Drawing.Size(778, 55);
            this.ctrl_FeltterDataDoctors.TabIndex = 14;
            this.ctrl_FeltterDataDoctors.TrueSearchAll = false;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 705);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 22);
            this.label2.TabIndex = 15;
            this.label2.Tag = "السبب هو انه عند إضافة طبيب من واجهة الإضافة لا يتم إضافة الطبيب  ضمن اليوزر _ له" +
    "يك مستقبلا بدك تلاقي طريقة تضيفه بنفس الرطريقة مع إضافته ضمن اليوزر ";
            this.label2.Text = "مخفي _ متوقف _ السبب بالتاغ";
            this.label2.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.Blue;
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Blue;
            this.btnAdd.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::Program_Clinic_Management.Properties.Resources.user;
            this.btnAdd.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAdd.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAdd.Location = new System.Drawing.Point(766, 566);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(212, 53);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // FrmManageDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 736);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrl_FeltterDataDoctors);
            this.Controls.Add(this.btnAddDoctor);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.DataGV);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmManageDoctors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+++++++";
            this.MyContextMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).EndInit();
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
        private System.Windows.Forms.ContextMenuStrip MyContextMS;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnShowInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnDelete;
        private System.Windows.Forms.ToolStripMenuItem حجزموعدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تسجيلزيارةToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Elipse ElipseDGV;
        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGV;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddDoctor;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Ctrl_FeltterDataDoctors ctrl_FeltterDataDoctors;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
    }
}
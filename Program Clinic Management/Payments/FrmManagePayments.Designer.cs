namespace Program_Clinic_Management.Payments
{
    partial class FrmManagePayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRevenueYear = new System.Windows.Forms.Label();
            this.lblRevenueMounth = new System.Windows.Forms.Label();
            this.lblRevenueWeek = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRevenueToday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboxFelterTypes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Pnl_BtnSearsh = new System.Windows.Forms.Panel();
            this.btnSearsh = new Guna.UI2.WinForms.Guna2GradientButton();
            this.PnlDate = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.DateTP_To = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.DateTP_From = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.PnlTxt = new System.Windows.Forms.Panel();
            this.TxtFellterPatientAndDoctor = new Guna.UI2.WinForms.Guna2TextBox();
            this.MyContextMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ElipseDGV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnDeletePayment = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdatePayment = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnAddPayment = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ToolStrip_btnInfoPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلالدفعةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).BeginInit();
            this.pnl_TopBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.Pnl_BtnSearsh.SuspendLayout();
            this.PnlDate.SuspendLayout();
            this.PnlTxt.SuspendLayout();
            this.MyContextMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGV.ColumnHeadersHeight = 4;
            this.DataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGV.ContextMenuStrip = this.MyContextMS;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.Location = new System.Drawing.Point(0, 165);
            this.DataGV.Name = "DataGV";
            this.DataGV.RowHeadersVisible = false;
            this.DataGV.Size = new System.Drawing.Size(1101, 472);
            this.DataGV.TabIndex = 21;
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
            // pnl_TopBar
            // 
            this.pnl_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnl_TopBar.Controls.Add(this.guna2Panel1);
            this.pnl_TopBar.Controls.Add(this.ctrl_IconProjectClinic1);
            this.pnl_TopBar.Controls.Add(this.lblTitle);
            this.pnl_TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopBar.Name = "pnl_TopBar";
            this.pnl_TopBar.Size = new System.Drawing.Size(1461, 61);
            this.pnl_TopBar.TabIndex = 22;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnMinimize);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(1325, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(136, 61);
            this.guna2Panel1.TabIndex = 6;
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
            this.lblTitle.Location = new System.Drawing.Point(621, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 36);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Payment Management";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.panel4);
            this.guna2ShadowPanel1.Controls.Add(this.panel3);
            this.guna2ShadowPanel1.Controls.Add(this.panel1);
            this.guna2ShadowPanel1.Controls.Add(this.lblRevenueYear);
            this.guna2ShadowPanel1.Controls.Add(this.lblRevenueMounth);
            this.guna2ShadowPanel1.Controls.Add(this.lblRevenueWeek);
            this.guna2ShadowPanel1.Controls.Add(this.label6);
            this.guna2ShadowPanel1.Controls.Add(this.label5);
            this.guna2ShadowPanel1.Controls.Add(this.label4);
            this.guna2ShadowPanel1.Controls.Add(this.lblRevenueToday);
            this.guna2ShadowPanel1.Controls.Add(this.label2);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Controls.Add(this.panel2);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(1132, 220);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 5;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 200;
            this.guna2ShadowPanel1.ShadowShift = 3;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(317, 361);
            this.guna2ShadowPanel1.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(38, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 1);
            this.panel4.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(38, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 1);
            this.panel3.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(38, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            this.panel1.TabIndex = 25;
            // 
            // lblRevenueYear
            // 
            this.lblRevenueYear.AutoSize = true;
            this.lblRevenueYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(89)))), ((int)(((byte)(155)))));
            this.lblRevenueYear.Location = new System.Drawing.Point(137, 301);
            this.lblRevenueYear.Name = "lblRevenueYear";
            this.lblRevenueYear.Size = new System.Drawing.Size(20, 22);
            this.lblRevenueYear.TabIndex = 42;
            this.lblRevenueYear.Text = "0";
            // 
            // lblRevenueMounth
            // 
            this.lblRevenueMounth.AutoSize = true;
            this.lblRevenueMounth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(89)))), ((int)(((byte)(155)))));
            this.lblRevenueMounth.Location = new System.Drawing.Point(137, 228);
            this.lblRevenueMounth.Name = "lblRevenueMounth";
            this.lblRevenueMounth.Size = new System.Drawing.Size(20, 22);
            this.lblRevenueMounth.TabIndex = 41;
            this.lblRevenueMounth.Text = "0";
            // 
            // lblRevenueWeek
            // 
            this.lblRevenueWeek.AutoSize = true;
            this.lblRevenueWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(89)))), ((int)(((byte)(155)))));
            this.lblRevenueWeek.Location = new System.Drawing.Point(137, 155);
            this.lblRevenueWeek.Name = "lblRevenueWeek";
            this.lblRevenueWeek.Size = new System.Drawing.Size(20, 22);
            this.lblRevenueWeek.TabIndex = 40;
            this.lblRevenueWeek.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 22);
            this.label6.TabIndex = 39;
            this.label6.Text = "إيرادات السنة :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 38;
            this.label5.Text = "إيرادات الشهر :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "إيرادات الأسبوع :";
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(89)))), ((int)(((byte)(155)))));
            this.lblRevenueToday.Location = new System.Drawing.Point(137, 82);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(20, 22);
            this.lblRevenueToday.TabIndex = 36;
            this.lblRevenueToday.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "إيرادات اليوم :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(87, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 34;
            this.label1.Text = "إحصائيات سريعة";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(38, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            this.panel2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 51;
            this.label3.Text = "التصفية حسب : ";
            // 
            // ComboxFelterTypes
            // 
            this.ComboxFelterTypes.BackColor = System.Drawing.Color.Transparent;
            this.ComboxFelterTypes.BorderRadius = 10;
            this.ComboxFelterTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxFelterTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxFelterTypes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxFelterTypes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxFelterTypes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxFelterTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboxFelterTypes.ItemHeight = 30;
            this.ComboxFelterTypes.Items.AddRange(new object[] {
            "عرض الكل",
            "أسم المريض",
            "رقم هاتف المريض",
            "الطبيب",
            "التاريخ"});
            this.ComboxFelterTypes.Location = new System.Drawing.Point(153, 13);
            this.ComboxFelterTypes.Name = "ComboxFelterTypes";
            this.ComboxFelterTypes.Size = new System.Drawing.Size(254, 36);
            this.ComboxFelterTypes.TabIndex = 50;
            this.ComboxFelterTypes.SelectedIndexChanged += new System.EventHandler(this.ComboxFelterTypes_SelectedIndexChanged);
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.ComboxFelterTypes);
            this.guna2ShadowPanel2.Controls.Add(this.panel5);
            this.guna2ShadowPanel2.Controls.Add(this.label3);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(27, 78);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 5;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.ShadowDepth = 200;
            this.guna2ShadowPanel2.ShadowShift = 2;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(1400, 63);
            this.guna2ShadowPanel2.TabIndex = 43;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Pnl_BtnSearsh);
            this.panel5.Controls.Add(this.PnlDate);
            this.panel5.Controls.Add(this.PnlTxt);
            this.panel5.Location = new System.Drawing.Point(413, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(970, 57);
            this.panel5.TabIndex = 57;
            // 
            // Pnl_BtnSearsh
            // 
            this.Pnl_BtnSearsh.Controls.Add(this.btnSearsh);
            this.Pnl_BtnSearsh.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pnl_BtnSearsh.Location = new System.Drawing.Point(840, 0);
            this.Pnl_BtnSearsh.Name = "Pnl_BtnSearsh";
            this.Pnl_BtnSearsh.Size = new System.Drawing.Size(104, 57);
            this.Pnl_BtnSearsh.TabIndex = 50;
            this.Pnl_BtnSearsh.Visible = false;
            // 
            // btnSearsh
            // 
            this.btnSearsh.BorderRadius = 20;
            this.btnSearsh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearsh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearsh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearsh.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearsh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearsh.FillColor = System.Drawing.Color.Blue;
            this.btnSearsh.FillColor2 = System.Drawing.Color.Navy;
            this.btnSearsh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearsh.ForeColor = System.Drawing.Color.White;
            this.btnSearsh.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnSearsh.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearsh.Location = new System.Drawing.Point(5, 7);
            this.btnSearsh.Name = "btnSearsh";
            this.btnSearsh.Size = new System.Drawing.Size(82, 44);
            this.btnSearsh.TabIndex = 51;
            this.btnSearsh.Text = "بحث";
            this.btnSearsh.Click += new System.EventHandler(this.btnSearsh_Click);
            // 
            // PnlDate
            // 
            this.PnlDate.Controls.Add(this.label8);
            this.PnlDate.Controls.Add(this.DateTP_To);
            this.PnlDate.Controls.Add(this.DateTP_From);
            this.PnlDate.Controls.Add(this.label7);
            this.PnlDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlDate.Location = new System.Drawing.Point(290, 0);
            this.PnlDate.Name = "PnlDate";
            this.PnlDate.Size = new System.Drawing.Size(550, 57);
            this.PnlDate.TabIndex = 53;
            this.PnlDate.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 22);
            this.label8.TabIndex = 56;
            this.label8.Text = "إلى";
            // 
            // DateTP_To
            // 
            this.DateTP_To.BorderRadius = 10;
            this.DateTP_To.Checked = true;
            this.DateTP_To.FillColor = System.Drawing.Color.White;
            this.DateTP_To.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTP_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTP_To.Location = new System.Drawing.Point(344, 11);
            this.DateTP_To.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTP_To.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTP_To.Name = "DateTP_To";
            this.DateTP_To.Size = new System.Drawing.Size(182, 36);
            this.DateTP_To.TabIndex = 55;
            this.DateTP_To.Value = new System.DateTime(2026, 7, 1, 21, 4, 57, 804);
            // 
            // DateTP_From
            // 
            this.DateTP_From.BorderRadius = 10;
            this.DateTP_From.Checked = true;
            this.DateTP_From.FillColor = System.Drawing.Color.White;
            this.DateTP_From.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTP_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTP_From.Location = new System.Drawing.Point(63, 11);
            this.DateTP_From.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTP_From.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTP_From.Name = "DateTP_From";
            this.DateTP_From.Size = new System.Drawing.Size(182, 36);
            this.DateTP_From.TabIndex = 53;
            this.DateTP_From.Value = new System.DateTime(2026, 7, 1, 21, 4, 57, 804);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 22);
            this.label7.TabIndex = 54;
            this.label7.Text = "من";
            // 
            // PnlTxt
            // 
            this.PnlTxt.Controls.Add(this.TxtFellterPatientAndDoctor);
            this.PnlTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlTxt.Location = new System.Drawing.Point(0, 0);
            this.PnlTxt.Name = "PnlTxt";
            this.PnlTxt.Size = new System.Drawing.Size(290, 57);
            this.PnlTxt.TabIndex = 58;
            this.PnlTxt.Visible = false;
            // 
            // TxtFellterPatientAndDoctor
            // 
            this.TxtFellterPatientAndDoctor.BorderRadius = 10;
            this.TxtFellterPatientAndDoctor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFellterPatientAndDoctor.DefaultText = "";
            this.TxtFellterPatientAndDoctor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtFellterPatientAndDoctor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtFellterPatientAndDoctor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFellterPatientAndDoctor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFellterPatientAndDoctor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFellterPatientAndDoctor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtFellterPatientAndDoctor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFellterPatientAndDoctor.Location = new System.Drawing.Point(11, 10);
            this.TxtFellterPatientAndDoctor.Name = "TxtFellterPatientAndDoctor";
            this.TxtFellterPatientAndDoctor.PlaceholderText = "";
            this.TxtFellterPatientAndDoctor.SelectedText = "";
            this.TxtFellterPatientAndDoctor.Size = new System.Drawing.Size(276, 36);
            this.TxtFellterPatientAndDoctor.TabIndex = 52;
            this.TxtFellterPatientAndDoctor.Visible = false;
            this.TxtFellterPatientAndDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFellterPatientAndDoctor_KeyPress);
            // 
            // MyContextMS
            // 
            this.MyContextMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyContextMS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MyContextMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_btnInfoPayment,
            this.تعديلالدفعةToolStripMenuItem});
            this.MyContextMS.Name = "MyContextMS";
            this.MyContextMS.Size = new System.Drawing.Size(202, 102);
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // ElipseDGV
            // 
            this.ElipseDGV.BorderRadius = 25;
            this.ElipseDGV.TargetControl = this.DataGV;
            // 
            // btnDeletePayment
            // 
            this.btnDeletePayment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletePayment.BorderRadius = 20;
            this.btnDeletePayment.BorderThickness = 1;
            this.btnDeletePayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeletePayment.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeletePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeletePayment.FillColor = System.Drawing.Color.Gray;
            this.btnDeletePayment.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletePayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePayment.ForeColor = System.Drawing.Color.White;
            this.btnDeletePayment.Image = global::Program_Clinic_Management.Properties.Resources.Remove;
            this.btnDeletePayment.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnDeletePayment.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDeletePayment.Location = new System.Drawing.Point(841, 667);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(243, 49);
            this.btnDeletePayment.TabIndex = 49;
            this.btnDeletePayment.Text = "حذف دفعة";
            this.btnDeletePayment.Click += new System.EventHandler(this.btnDeletePayment_Click);
            // 
            // btnUpdatePayment
            // 
            this.btnUpdatePayment.BorderColor = System.Drawing.Color.Lime;
            this.btnUpdatePayment.BorderRadius = 20;
            this.btnUpdatePayment.BorderThickness = 1;
            this.btnUpdatePayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdatePayment.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdatePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdatePayment.FillColor = System.Drawing.Color.Teal;
            this.btnUpdatePayment.FillColor2 = System.Drawing.Color.Green;
            this.btnUpdatePayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePayment.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePayment.Image = global::Program_Clinic_Management.Properties.Resources.Update;
            this.btnUpdatePayment.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnUpdatePayment.ImageSize = new System.Drawing.Size(40, 40);
            this.btnUpdatePayment.Location = new System.Drawing.Point(63, 667);
            this.btnUpdatePayment.Name = "btnUpdatePayment";
            this.btnUpdatePayment.Size = new System.Drawing.Size(246, 49);
            this.btnUpdatePayment.TabIndex = 48;
            this.btnUpdatePayment.Text = " تعديل دفعة";
            this.btnUpdatePayment.Click += new System.EventHandler(this.btnUpdatePayment_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BorderRadius = 20;
            this.btnAddPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPayment.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPayment.FillColor = System.Drawing.Color.Blue;
            this.btnAddPayment.FillColor2 = System.Drawing.Color.Navy;
            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Image = global::Program_Clinic_Management.Properties.Resources.Payment;
            this.btnAddPayment.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnAddPayment.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPayment.Location = new System.Drawing.Point(447, 667);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(236, 49);
            this.btnAddPayment.TabIndex = 47;
            this.btnAddPayment.Text = "إضافة دفعة";
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
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
            // ToolStrip_btnInfoPayment
            // 
            this.ToolStrip_btnInfoPayment.Image = global::Program_Clinic_Management.Properties.Resources.Info;
            this.ToolStrip_btnInfoPayment.Name = "ToolStrip_btnInfoPayment";
            this.ToolStrip_btnInfoPayment.Size = new System.Drawing.Size(201, 38);
            this.ToolStrip_btnInfoPayment.Text = "معلومات الدفعة";
            this.ToolStrip_btnInfoPayment.Click += new System.EventHandler(this.ToolStrip_btnInfoPayment_Click);
            // 
            // تعديلالدفعةToolStripMenuItem
            // 
            this.تعديلالدفعةToolStripMenuItem.Image = global::Program_Clinic_Management.Properties.Resources.Update;
            this.تعديلالدفعةToolStripMenuItem.Name = "تعديلالدفعةToolStripMenuItem";
            this.تعديلالدفعةToolStripMenuItem.Size = new System.Drawing.Size(201, 38);
            this.تعديلالدفعةToolStripMenuItem.Text = "تعديل الدفعة";
            this.تعديلالدفعةToolStripMenuItem.Click += new System.EventHandler(this.btnUpdatePayment_Click);
            // 
            // FrmManagePayments
            // 
            this.AcceptButton = this.btnSearsh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1461, 752);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.btnDeletePayment);
            this.Controls.Add(this.btnUpdatePayment);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.pnl_TopBar);
            this.Controls.Add(this.DataGV);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmManagePayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmManagePayments";
            this.Load += new System.EventHandler(this.FrmManagePayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).EndInit();
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.Pnl_BtnSearsh.ResumeLayout(false);
            this.PnlDate.ResumeLayout(false);
            this.PnlDate.PerformLayout();
            this.PnlTxt.ResumeLayout(false);
            this.MyContextMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DataGV;
        private Guna.UI2.WinForms.Guna2Panel pnl_TopBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox btnMinimize;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddPayment;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdatePayment;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeletePayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRevenueYear;
        private System.Windows.Forms.Label lblRevenueMounth;
        private System.Windows.Forms.Label lblRevenueWeek;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRevenueToday;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxFelterTypes;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTP_From;
        private Guna.UI2.WinForms.Guna2TextBox TxtFellterPatientAndDoctor;
        private System.Windows.Forms.Panel PnlDate;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTP_To;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel PnlTxt;
        private System.Windows.Forms.Panel Pnl_BtnSearsh;
        private Guna.UI2.WinForms.Guna2GradientButton btnSearsh;
        private System.Windows.Forms.ContextMenuStrip MyContextMS;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_btnInfoPayment;
        private System.Windows.Forms.ToolStripMenuItem تعديلالدفعةToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
        private Guna.UI2.WinForms.Guna2Elipse ElipseDGV;
    }
}
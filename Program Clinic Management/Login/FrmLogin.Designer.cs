namespace Program_Clinic_Management.Login
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMessageError = new System.Windows.Forms.Label();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.lbl_CallToManager = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Login = new Guna.UI2.WinForms.Guna2GradientButton();
            this.chk_RememperMe = new System.Windows.Forms.CheckBox();
            this.TxtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ElipsePanal = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblDate = new System.Windows.Forms.Label();
            this.ctrl_IconProjectClinic1 = new BusinessLogic.Ctrl_IconProjectClinic();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.MintCream;
            this.guna2Panel1.Controls.Add(this.lblMessageError);
            this.guna2Panel1.Controls.Add(this.lblForgotPassword);
            this.guna2Panel1.Controls.Add(this.lbl_CallToManager);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.btn_Login);
            this.guna2Panel1.Controls.Add(this.chk_RememperMe);
            this.guna2Panel1.Controls.Add(this.TxtPassword);
            this.guna2Panel1.Controls.Add(this.TxtUserName);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(340, 46);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(356, 434);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lblMessageError
            // 
            this.lblMessageError.AutoSize = true;
            this.lblMessageError.BackColor = System.Drawing.Color.Transparent;
            this.lblMessageError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessageError.Location = new System.Drawing.Point(73, 238);
            this.lblMessageError.Name = "lblMessageError";
            this.lblMessageError.Size = new System.Drawing.Size(222, 13);
            this.lblMessageError.TabIndex = 13;
            this.lblMessageError.Text = "أسم المستخدم أو كلمة المرور غير صحيحة";
            this.lblMessageError.Visible = false;
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblForgotPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.ForeColor = System.Drawing.Color.Blue;
            this.lblForgotPassword.Location = new System.Drawing.Point(41, 269);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(111, 19);
            this.lblForgotPassword.TabIndex = 12;
            this.lblForgotPassword.Text = "نسيت كلمة المرور؟";
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // lbl_CallToManager
            // 
            this.lbl_CallToManager.AutoSize = true;
            this.lbl_CallToManager.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CallToManager.Cursor = System.Windows.Forms.Cursors.Help;
            this.lbl_CallToManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CallToManager.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CallToManager.Location = new System.Drawing.Point(90, 384);
            this.lbl_CallToManager.Name = "lbl_CallToManager";
            this.lbl_CallToManager.Size = new System.Drawing.Size(77, 19);
            this.lbl_CallToManager.TabIndex = 11;
            this.lbl_CallToManager.Text = "إتصل بالإدارة";
            this.lbl_CallToManager.Click += new System.EventHandler(this.lbl_CallToManager_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "ليس لديك حساب؟";
            // 
            // btn_Login
            // 
            this.btn_Login.BorderRadius = 20;
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Login.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Login.FillColor = System.Drawing.Color.MidnightBlue;
            this.btn_Login.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(36, 313);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(291, 44);
            this.btn_Login.TabIndex = 8;
            this.btn_Login.Text = "تسجيل الدخول";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // chk_RememperMe
            // 
            this.chk_RememperMe.AutoSize = true;
            this.chk_RememperMe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_RememperMe.Location = new System.Drawing.Point(264, 268);
            this.chk_RememperMe.Name = "chk_RememperMe";
            this.chk_RememperMe.Size = new System.Drawing.Size(63, 23);
            this.chk_RememperMe.TabIndex = 6;
            this.chk_RememperMe.Text = "تذكرني";
            this.chk_RememperMe.UseVisualStyleBackColor = true;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderRadius = 15;
            this.TxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPassword.DefaultText = "";
            this.TxtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.IconRight = ((System.Drawing.Image)(resources.GetObject("TxtPassword.IconRight")));
            this.TxtPassword.IconRightOffset = new System.Drawing.Point(3, 0);
            this.TxtPassword.IconRightSize = new System.Drawing.Size(28, 28);
            this.TxtPassword.Location = new System.Drawing.Point(36, 197);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PlaceholderText = "كلمة المرور";
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.Size = new System.Drawing.Size(291, 36);
            this.TxtPassword.TabIndex = 5;
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
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.IconLeftSize = new System.Drawing.Size(40, 40);
            this.TxtUserName.IconRight = ((System.Drawing.Image)(resources.GetObject("TxtUserName.IconRight")));
            this.TxtUserName.IconRightOffset = new System.Drawing.Point(3, 0);
            this.TxtUserName.IconRightSize = new System.Drawing.Size(30, 30);
            this.TxtUserName.Location = new System.Drawing.Point(36, 125);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TxtUserName.PlaceholderText = "أسم المستخدم";
            this.TxtUserName.SelectedText = "";
            this.TxtUserName.Size = new System.Drawing.Size(291, 36);
            this.TxtUserName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "أدخل بياناتك للوصول للواجهة الرئيسية";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "تسجيل الدخول إلى النظام";
            // 
            // ElipsePanal
            // 
            this.ElipsePanal.BorderRadius = 20;
            this.ElipsePanal.TargetControl = this.guna2Panel1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(767, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(227, 21);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = " AM 8:30  2026 / 5 / 24   الأحد";
            // 
            // ctrl_IconProjectClinic1
            // 
            this.ctrl_IconProjectClinic1.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_IconProjectClinic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_IconProjectClinic1.Location = new System.Drawing.Point(-21, 5);
            this.ctrl_IconProjectClinic1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrl_IconProjectClinic1.Name = "ctrl_IconProjectClinic1";
            this.ctrl_IconProjectClinic1.Size = new System.Drawing.Size(246, 57);
            this.ctrl_IconProjectClinic1.TabIndex = 14;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 534);
            this.Controls.Add(this.ctrl_IconProjectClinic1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login User";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse ElipsePanal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Login;
        private System.Windows.Forms.CheckBox chk_RememperMe;
        private Guna.UI2.WinForms.Guna2TextBox TxtPassword;
        private Guna.UI2.WinForms.Guna2TextBox TxtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_CallToManager;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label lblMessageError;
        private BusinessLogic.Ctrl_IconProjectClinic ctrl_IconProjectClinic1;
    }
}
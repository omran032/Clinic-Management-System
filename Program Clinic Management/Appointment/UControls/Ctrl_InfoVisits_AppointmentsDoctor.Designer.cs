namespace Program_Clinic_Management.Doctors.UControls
{
    partial class Ctrl_InfoVisits_AppointmentsDoctor
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
            this.ElipseCtrl = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.GroupInfo_V_A = new System.Windows.Forms.GroupBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatusAppointment = new System.Windows.Forms.Label();
            this.lblDate_V_A = new System.Windows.Forms.Label();
            this.lbl_ID_V_A = new System.Windows.Forms.Label();
            this.lbl_TypeVisit = new System.Windows.Forms.Label();
            this.PnlInfoDoctor = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.ctrl_PersonInfoDoctor = new Program_Clinic_Management.Persons.UControls.Ctrl_PersonInfo();
            this.ctrlNotes = new Program_Clinic_Management.UControls.CtrlNotes();
            this.ctrl_PatientInfo1 = new Program_Clinic_Management.Patients.UControls.Ctrl_PatientInfo();
            this.GroupInfo_V_A.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.PnlInfoDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElipseCtrl
            // 
            this.ElipseCtrl.BorderRadius = 25;
            this.ElipseCtrl.TargetControl = this;
            // 
            // GroupInfo_V_A
            // 
            this.GroupInfo_V_A.Controls.Add(this.guna2Panel1);
            this.GroupInfo_V_A.Controls.Add(this.lblStatusAppointment);
            this.GroupInfo_V_A.Controls.Add(this.lblDate_V_A);
            this.GroupInfo_V_A.Controls.Add(this.lbl_ID_V_A);
            this.GroupInfo_V_A.Controls.Add(this.lbl_TypeVisit);
            this.GroupInfo_V_A.ForeColor = System.Drawing.Color.Gray;
            this.GroupInfo_V_A.Location = new System.Drawing.Point(3, 534);
            this.GroupInfo_V_A.Name = "GroupInfo_V_A";
            this.GroupInfo_V_A.Size = new System.Drawing.Size(854, 348);
            this.GroupInfo_V_A.TabIndex = 1;
            this.GroupInfo_V_A.TabStop = false;
            this.GroupInfo_V_A.Text = "معلومات الزيارة";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoScroll = true;
            this.guna2Panel1.Controls.Add(this.ctrlNotes);
            this.guna2Panel1.Location = new System.Drawing.Point(6, 173);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(831, 155);
            this.guna2Panel1.TabIndex = 5;
            // 
            // lblStatusAppointment
            // 
            this.lblStatusAppointment.AutoSize = true;
            this.lblStatusAppointment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusAppointment.ForeColor = System.Drawing.Color.Black;
            this.lblStatusAppointment.Location = new System.Drawing.Point(500, 97);
            this.lblStatusAppointment.Name = "lblStatusAppointment";
            this.lblStatusAppointment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatusAppointment.Size = new System.Drawing.Size(91, 22);
            this.lblStatusAppointment.TabIndex = 4;
            this.lblStatusAppointment.Text = "حالة الزيارة :";
            // 
            // lblDate_V_A
            // 
            this.lblDate_V_A.AutoSize = true;
            this.lblDate_V_A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate_V_A.ForeColor = System.Drawing.Color.Black;
            this.lblDate_V_A.Location = new System.Drawing.Point(45, 134);
            this.lblDate_V_A.Name = "lblDate_V_A";
            this.lblDate_V_A.Size = new System.Drawing.Size(100, 22);
            this.lblDate_V_A.TabIndex = 2;
            this.lblDate_V_A.Text = "Visit Date :";
            // 
            // lbl_ID_V_A
            // 
            this.lbl_ID_V_A.AutoSize = true;
            this.lbl_ID_V_A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_V_A.ForeColor = System.Drawing.Color.Navy;
            this.lbl_ID_V_A.Location = new System.Drawing.Point(382, 22);
            this.lbl_ID_V_A.Name = "lbl_ID_V_A";
            this.lbl_ID_V_A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_ID_V_A.Size = new System.Drawing.Size(172, 22);
            this.lbl_ID_V_A.TabIndex = 1;
            this.lbl_ID_V_A.Text = "ID Appointment :  X";
            // 
            // lbl_TypeVisit
            // 
            this.lbl_TypeVisit.AutoSize = true;
            this.lbl_TypeVisit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TypeVisit.ForeColor = System.Drawing.Color.Black;
            this.lbl_TypeVisit.Location = new System.Drawing.Point(49, 74);
            this.lbl_TypeVisit.Name = "lbl_TypeVisit";
            this.lbl_TypeVisit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_TypeVisit.Size = new System.Drawing.Size(89, 22);
            this.lbl_TypeVisit.TabIndex = 0;
            this.lbl_TypeVisit.Text = "نوع الزيارة :";
            // 
            // PnlInfoDoctor
            // 
            this.PnlInfoDoctor.BackColor = System.Drawing.Color.Transparent;
            this.PnlInfoDoctor.Controls.Add(this.lblSpecialization);
            this.PnlInfoDoctor.Controls.Add(this.ctrl_PersonInfoDoctor);
            this.PnlInfoDoctor.Location = new System.Drawing.Point(9, 9);
            this.PnlInfoDoctor.Name = "PnlInfoDoctor";
            this.PnlInfoDoctor.Size = new System.Drawing.Size(848, 524);
            this.PnlInfoDoctor.TabIndex = 10;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialization.Location = new System.Drawing.Point(39, 464);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(109, 19);
            this.lblSpecialization.TabIndex = 11;
            this.lblSpecialization.Text = "Specialization :";
            // 
            // ctrl_PersonInfoDoctor
            // 
            this.ctrl_PersonInfoDoctor.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_PersonInfoDoctor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PersonInfoDoctor.GroupTitle = "المعلومات الشخصية للطبيب";
            this.ctrl_PersonInfoDoctor.Location = new System.Drawing.Point(0, -1);
            this.ctrl_PersonInfoDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_PersonInfoDoctor.Name = "ctrl_PersonInfoDoctor";
            this.ctrl_PersonInfoDoctor.PersonID = 0;
            this.ctrl_PersonInfoDoctor.PersonInfo = null;
            this.ctrl_PersonInfoDoctor.Size = new System.Drawing.Size(848, 427);
            this.ctrl_PersonInfoDoctor.TabIndex = 10;
            // 
            // ctrlNotes
            // 
            this.ctrlNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlNotes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlNotes.ForeColor = System.Drawing.Color.Black;
            this.ctrlNotes.InfoText = null;
            this.ctrlNotes.LabelTextColor = System.Drawing.Color.Black;
            this.ctrlNotes.Location = new System.Drawing.Point(0, 0);
            this.ctrlNotes.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlNotes.Name = "ctrlNotes";
            this.ctrlNotes.Picture = null;
            this.ctrlNotes.Size = new System.Drawing.Size(831, 77);
            this.ctrlNotes.TabIndex = 3;
            this.ctrlNotes.TitleText = "تفاصيل الزيارة";
            // 
            // ctrl_PatientInfo1
            // 
            this.ctrl_PatientInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrl_PatientInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PatientInfo1.Location = new System.Drawing.Point(847, 4);
            this.ctrl_PatientInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_PatientInfo1.Name = "ctrl_PatientInfo1";
            this.ctrl_PatientInfo1.PatientsInfo = null;
            this.ctrl_PatientInfo1.Size = new System.Drawing.Size(878, 893);
            this.ctrl_PatientInfo1.TabIndex = 0;
            // 
            // Ctrl_InfoVisits_AppointmentsDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlInfoDoctor);
            this.Controls.Add(this.GroupInfo_V_A);
            this.Controls.Add(this.ctrl_PatientInfo1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ctrl_InfoVisits_AppointmentsDoctor";
            this.Size = new System.Drawing.Size(1729, 885);
            this.GroupInfo_V_A.ResumeLayout(false);
            this.GroupInfo_V_A.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.PnlInfoDoctor.ResumeLayout(false);
            this.PnlInfoDoctor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse ElipseCtrl;
        private Patients.UControls.Ctrl_PatientInfo ctrl_PatientInfo1;
        private System.Windows.Forms.GroupBox GroupInfo_V_A;
        private System.Windows.Forms.Label lblDate_V_A;
        private System.Windows.Forms.Label lbl_ID_V_A;
        private System.Windows.Forms.Label lblStatusAppointment;
        private Program_Clinic_Management.UControls.CtrlNotes ctrlNotes;
        private System.Windows.Forms.Label lbl_TypeVisit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel PnlInfoDoctor;
        private System.Windows.Forms.Label lblSpecialization;
        private Persons.UControls.Ctrl_PersonInfo ctrl_PersonInfoDoctor;
    }
}

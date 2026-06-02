namespace Program_Clinic_Management.Patients.UControls
{
    partial class Ctrl_PatientInfo
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
            this.ElipseControl = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.Ctrl_Notes = new Program_Clinic_Management.UControls.CtrlNotes();
            this.Ctrl_Allergies = new Program_Clinic_Management.UControls.CtrlNotes();
            this.Ctrl_ChronicDiseases = new Program_Clinic_Management.UControls.CtrlNotes();
            this.Ctrl_MedicalNotes = new Program_Clinic_Management.UControls.CtrlNotes();
            this.lbl_ComplianceScore = new System.Windows.Forms.Label();
            this.lbl_StatusComplianceScore = new System.Windows.Forms.Label();
            this.lblFirstVisitDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrl_PersonInfo1 = new Program_Clinic_Management.Persons.UControls.Ctrl_PersonInfo();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElipseControl
            // 
            this.ElipseControl.BorderRadius = 20;
            this.ElipseControl.TargetControl = this;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.AutoScroll = true;
            this.guna2Panel2.Controls.Add(this.Ctrl_Notes);
            this.guna2Panel2.Controls.Add(this.Ctrl_Allergies);
            this.guna2Panel2.Controls.Add(this.Ctrl_ChronicDiseases);
            this.guna2Panel2.Controls.Add(this.Ctrl_MedicalNotes);
            this.guna2Panel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Location = new System.Drawing.Point(9, 25);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(839, 322);
            this.guna2Panel2.TabIndex = 0;
            // 
            // Ctrl_Notes
            // 
            this.Ctrl_Notes.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ctrl_Notes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ctrl_Notes.InfoText = null;
            this.Ctrl_Notes.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.Ctrl_Notes.Location = new System.Drawing.Point(0, 231);
            this.Ctrl_Notes.Margin = new System.Windows.Forms.Padding(4);
            this.Ctrl_Notes.Name = "Ctrl_Notes";
            this.Ctrl_Notes.Picture = null;
            this.Ctrl_Notes.Size = new System.Drawing.Size(839, 77);
            this.Ctrl_Notes.TabIndex = 3;
            this.Ctrl_Notes.TitleText = "ملاحظات";
            // 
            // Ctrl_Allergies
            // 
            this.Ctrl_Allergies.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ctrl_Allergies.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ctrl_Allergies.InfoText = null;
            this.Ctrl_Allergies.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.Ctrl_Allergies.Location = new System.Drawing.Point(0, 154);
            this.Ctrl_Allergies.Margin = new System.Windows.Forms.Padding(4);
            this.Ctrl_Allergies.Name = "Ctrl_Allergies";
            this.Ctrl_Allergies.Picture = null;
            this.Ctrl_Allergies.Size = new System.Drawing.Size(839, 77);
            this.Ctrl_Allergies.TabIndex = 2;
            this.Ctrl_Allergies.TitleText = "الحساسية";
            // 
            // Ctrl_ChronicDiseases
            // 
            this.Ctrl_ChronicDiseases.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ctrl_ChronicDiseases.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ctrl_ChronicDiseases.InfoText = null;
            this.Ctrl_ChronicDiseases.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.Ctrl_ChronicDiseases.Location = new System.Drawing.Point(0, 77);
            this.Ctrl_ChronicDiseases.Margin = new System.Windows.Forms.Padding(4);
            this.Ctrl_ChronicDiseases.Name = "Ctrl_ChronicDiseases";
            this.Ctrl_ChronicDiseases.Picture = null;
            this.Ctrl_ChronicDiseases.Size = new System.Drawing.Size(839, 77);
            this.Ctrl_ChronicDiseases.TabIndex = 1;
            this.Ctrl_ChronicDiseases.TitleText = "الأمراض المزمنة";
            // 
            // Ctrl_MedicalNotes
            // 
            this.Ctrl_MedicalNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ctrl_MedicalNotes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ctrl_MedicalNotes.InfoText = null;
            this.Ctrl_MedicalNotes.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.Ctrl_MedicalNotes.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_MedicalNotes.Margin = new System.Windows.Forms.Padding(4);
            this.Ctrl_MedicalNotes.Name = "Ctrl_MedicalNotes";
            this.Ctrl_MedicalNotes.Picture = null;
            this.Ctrl_MedicalNotes.Size = new System.Drawing.Size(839, 77);
            this.Ctrl_MedicalNotes.TabIndex = 0;
            this.Ctrl_MedicalNotes.TitleText = "ملاحظات طبية";
            // 
            // lbl_ComplianceScore
            // 
            this.lbl_ComplianceScore.AutoSize = true;
            this.lbl_ComplianceScore.Location = new System.Drawing.Point(559, 71);
            this.lbl_ComplianceScore.Name = "lbl_ComplianceScore";
            this.lbl_ComplianceScore.Size = new System.Drawing.Size(166, 19);
            this.lbl_ComplianceScore.TabIndex = 10;
            this.lbl_ComplianceScore.Text = "Degree of commitment:";
            this.toolTip1.SetToolTip(this.lbl_ComplianceScore, "درجة الالتزام بالمواعيد");
            // 
            // lbl_StatusComplianceScore
            // 
            this.lbl_StatusComplianceScore.AutoSize = true;
            this.lbl_StatusComplianceScore.Location = new System.Drawing.Point(72, 71);
            this.lbl_StatusComplianceScore.Name = "lbl_StatusComplianceScore";
            this.lbl_StatusComplianceScore.Size = new System.Drawing.Size(145, 19);
            this.lbl_StatusComplianceScore.TabIndex = 9;
            this.lbl_StatusComplianceScore.Text = "Commitment Status:";
            this.toolTip1.SetToolTip(this.lbl_StatusComplianceScore, "حالة الالتزام بالمواعيد");
            // 
            // lblFirstVisitDate
            // 
            this.lblFirstVisitDate.AutoSize = true;
            this.lblFirstVisitDate.Location = new System.Drawing.Point(66, 22);
            this.lblFirstVisitDate.Name = "lblFirstVisitDate";
            this.lblFirstVisitDate.Size = new System.Drawing.Size(156, 19);
            this.lblFirstVisitDate.TabIndex = 8;
            this.lblFirstVisitDate.Text = "Date of the first visit :";
            this.toolTip1.SetToolTip(this.lblFirstVisitDate, "تاريخ الزيارة الأولى : ");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_StatusComplianceScore);
            this.groupBox1.Controls.Add(this.lbl_ComplianceScore);
            this.groupBox1.Controls.Add(this.lblFirstVisitDate);
            this.groupBox1.Location = new System.Drawing.Point(16, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 103);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.guna2Panel2);
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(13, 530);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(854, 353);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "معلومات طبية";
            // 
            // ctrl_PersonInfo1
            // 
            this.ctrl_PersonInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_PersonInfo1.GroupTitle = "المعلومات الشخصية للمريض";
            this.ctrl_PersonInfo1.Location = new System.Drawing.Point(4, 4);
            this.ctrl_PersonInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_PersonInfo1.Name = "ctrl_PersonInfo1";
            this.ctrl_PersonInfo1.PersonID = 0;
            this.ctrl_PersonInfo1.PersonInfo = null;
            this.ctrl_PersonInfo1.Size = new System.Drawing.Size(870, 425);
            this.ctrl_PersonInfo1.TabIndex = 10;
            // 
            // Ctrl_PatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrl_PersonInfo1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ctrl_PatientInfo";
            this.Size = new System.Drawing.Size(878, 893);
            this.guna2Panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse ElipseControl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Program_Clinic_Management.UControls.CtrlNotes Ctrl_Notes;
        private Program_Clinic_Management.UControls.CtrlNotes Ctrl_Allergies;
        private Program_Clinic_Management.UControls.CtrlNotes Ctrl_ChronicDiseases;
        private Program_Clinic_Management.UControls.CtrlNotes Ctrl_MedicalNotes;
        private System.Windows.Forms.Label lbl_ComplianceScore;
        private System.Windows.Forms.Label lbl_StatusComplianceScore;
        private System.Windows.Forms.Label lblFirstVisitDate;
        private Persons.UControls.Ctrl_PersonInfo ctrl_PersonInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

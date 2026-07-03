namespace Program_Clinic_Management.Appointment.UControls
{
    partial class Ctrl_ShowFirstAppointmentPatient
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
            this.Pnl_Patient1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.PicGender = new System.Windows.Forms.PictureBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPhonePatient = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_Patient1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicGender)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Patient1
            // 
            this.Pnl_Patient1.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_Patient1.Controls.Add(this.label1);
            this.Pnl_Patient1.Controls.Add(this.lblTime);
            this.Pnl_Patient1.Controls.Add(this.lblPhonePatient);
            this.Pnl_Patient1.Controls.Add(this.lblPatientName);
            this.Pnl_Patient1.Controls.Add(this.PicGender);
            this.Pnl_Patient1.FillColor = System.Drawing.Color.White;
            this.Pnl_Patient1.Location = new System.Drawing.Point(9, 11);
            this.Pnl_Patient1.Name = "Pnl_Patient1";
            this.Pnl_Patient1.Radius = 10;
            this.Pnl_Patient1.ShadowColor = System.Drawing.Color.DarkGray;
            this.Pnl_Patient1.Size = new System.Drawing.Size(889, 68);
            this.Pnl_Patient1.TabIndex = 23;
            // 
            // PicGender
            // 
            this.PicGender.BackColor = System.Drawing.Color.Transparent;
            this.PicGender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicGender.Image = global::Program_Clinic_Management.Properties.Resources.Sick;
            this.PicGender.Location = new System.Drawing.Point(20, 13);
            this.PicGender.Name = "PicGender";
            this.PicGender.Size = new System.Drawing.Size(48, 44);
            this.PicGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicGender.TabIndex = 25;
            this.PicGender.TabStop = false;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPatientName.Location = new System.Drawing.Point(78, 22);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(133, 24);
            this.lblPatientName.TabIndex = 26;
            this.lblPatientName.Text = "Patient Name";
            // 
            // lblPhonePatient
            // 
            this.lblPhonePatient.AutoSize = true;
            this.lblPhonePatient.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonePatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPhonePatient.Location = new System.Drawing.Point(452, 22);
            this.lblPhonePatient.Name = "lblPhonePatient";
            this.lblPhonePatient.Size = new System.Drawing.Size(53, 24);
            this.lblPhonePatient.TabIndex = 27;
            this.lblPhonePatient.Text = "Num";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTime.Location = new System.Drawing.Point(713, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 24);
            this.lblTime.TabIndex = 28;
            this.lblTime.Text = "Time :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(340, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "رقم المريض :";
            // 
            // Ctrl_ShowFirstAppointmentPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pnl_Patient1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Ctrl_ShowFirstAppointmentPatient";
            this.Size = new System.Drawing.Size(903, 87);
            this.Pnl_Patient1.ResumeLayout(false);
            this.Pnl_Patient1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicGender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel Pnl_Patient1;
        private System.Windows.Forms.PictureBox PicGender;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPhonePatient;
        private System.Windows.Forms.Label label1;
    }
}

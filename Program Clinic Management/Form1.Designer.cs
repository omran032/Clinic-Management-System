namespace Program_Clinic_Management
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ctrlNotes1 = new Program_Clinic_Management.UControls.CtrlNotes();
            this.ctrlNotes5 = new Program_Clinic_Management.UControls.CtrlNotes();
            this.ctrlNotes2 = new Program_Clinic_Management.UControls.CtrlNotes();
            this.ctrlNotes3 = new Program_Clinic_Management.UControls.CtrlNotes();
            this.SuspendLayout();
            // 
            // ctrlNotes1
            // 
            this.ctrlNotes1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlNotes1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlNotes1.InfoText = resources.GetString("ctrlNotes1.InfoText");
            this.ctrlNotes1.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlNotes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlNotes1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlNotes1.Name = "ctrlNotes1";
            this.ctrlNotes1.Picture = null;
            this.ctrlNotes1.Size = new System.Drawing.Size(847, 80);
            this.ctrlNotes1.TabIndex = 0;
            this.ctrlNotes1.TitleText = "Notes";
            // 
            // ctrlNotes5
            // 
            this.ctrlNotes5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlNotes5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlNotes5.InfoText = resources.GetString("ctrlNotes5.InfoText");
            this.ctrlNotes5.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlNotes5.Location = new System.Drawing.Point(0, 80);
            this.ctrlNotes5.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlNotes5.Name = "ctrlNotes5";
            this.ctrlNotes5.Picture = null;
            this.ctrlNotes5.Size = new System.Drawing.Size(847, 80);
            this.ctrlNotes5.TabIndex = 4;
            this.ctrlNotes5.TitleText = "Notes";
            // 
            // ctrlNotes2
            // 
            this.ctrlNotes2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlNotes2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlNotes2.InfoText = null;
            this.ctrlNotes2.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlNotes2.Location = new System.Drawing.Point(0, 160);
            this.ctrlNotes2.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlNotes2.Name = "ctrlNotes2";
            this.ctrlNotes2.Picture = null;
            this.ctrlNotes2.Size = new System.Drawing.Size(847, 77);
            this.ctrlNotes2.TabIndex = 5;
            this.ctrlNotes2.TitleText = "Notes";
            // 
            // ctrlNotes3
            // 
            this.ctrlNotes3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlNotes3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlNotes3.InfoText = null;
            this.ctrlNotes3.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlNotes3.Location = new System.Drawing.Point(0, 237);
            this.ctrlNotes3.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlNotes3.Name = "ctrlNotes3";
            this.ctrlNotes3.Picture = null;
            this.ctrlNotes3.Size = new System.Drawing.Size(847, 77);
            this.ctrlNotes3.TabIndex = 6;
            this.ctrlNotes3.TitleText = "Notes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 786);
            this.Controls.Add(this.ctrlNotes3);
            this.Controls.Add(this.ctrlNotes2);
            this.Controls.Add(this.ctrlNotes5);
            this.Controls.Add(this.ctrlNotes1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UControls.CtrlNotes ctrlNotes1;
        private UControls.CtrlNotes ctrlNotes5;
        private UControls.CtrlNotes ctrlNotes2;
        private UControls.CtrlNotes ctrlNotes3;
    }
}


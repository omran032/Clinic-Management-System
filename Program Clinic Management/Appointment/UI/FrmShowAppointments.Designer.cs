namespace Program_Clinic_Management.Appointment.UI
{
    partial class FrmShowAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowAppointments));
            this.DataGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MyContextMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenu_btnShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجيلزيارةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrl_FeltterDataAppointment1 = new Program_Clinic_Management.Appointment.UControls.Ctrl_FeltterDataAppointment();
            this.ElipseDGV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).BeginInit();
            this.MyContextMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGV.ColumnHeadersHeight = 4;
            this.DataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGV.Location = new System.Drawing.Point(44, 110);
            this.DataGV.Name = "DataGV";
            this.DataGV.RowHeadersVisible = false;
            this.DataGV.Size = new System.Drawing.Size(1372, 330);
            this.DataGV.TabIndex = 5;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1256, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "مواعيد العيادة";
            // 
            // MyContextMS
            // 
            this.MyContextMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyContextMS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MyContextMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_btnShowInfo,
            this.ToolStripMenu_btnUpdate,
            this.ToolStripMenu_btnDelete,
            this.تسجيلزيارةToolStripMenuItem});
            this.MyContextMS.Name = "MyContextMS";
            this.MyContextMS.Size = new System.Drawing.Size(205, 156);
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
            // تسجيلزيارةToolStripMenuItem
            // 
            this.تسجيلزيارةToolStripMenuItem.Name = "تسجيلزيارةToolStripMenuItem";
            this.تسجيلزيارةToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.تسجيلزيارةToolStripMenuItem.Text = "تسجيل زيارة";
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
            this.btnUpdate.Location = new System.Drawing.Point(641, 477);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(212, 53);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "تعديل";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ctrl_FeltterDataAppointment1
            // 
            this.ctrl_FeltterDataAppointment1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_FeltterDataAppointment1.Location = new System.Drawing.Point(53, 37);
            this.ctrl_FeltterDataAppointment1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_FeltterDataAppointment1.Name = "ctrl_FeltterDataAppointment1";
            this.ctrl_FeltterDataAppointment1.Size = new System.Drawing.Size(766, 49);
            this.ctrl_FeltterDataAppointment1.TabIndex = 11;
            this.ctrl_FeltterDataAppointment1.TrueSearchAll = false;
            // 
            // ElipseDGV
            // 
            this.ElipseDGV.BorderRadius = 20;
            this.ElipseDGV.TargetControl = this.DataGV;
            // 
            // FrmShowAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1471, 883);
            this.Controls.Add(this.ctrl_FeltterDataAppointment1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGV);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmShowAppointments";
            this.Text = "FrmShowAppointments";
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).EndInit();
            this.MyContextMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DataGV;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private System.Windows.Forms.ContextMenuStrip MyContextMS;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnShowInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_btnDelete;
        private System.Windows.Forms.ToolStripMenuItem تسجيلزيارةToolStripMenuItem;
        private UControls.Ctrl_FeltterDataAppointment ctrl_FeltterDataAppointment1;
        private Guna.UI2.WinForms.Guna2Elipse ElipseDGV;
    }
}
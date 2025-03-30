namespace Universt_System.Teachers
{
    partial class frmSetTeacherPermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkCanViewGrades;
        private System.Windows.Forms.CheckBox chkCanEditGrades;
        private System.Windows.Forms.CheckBox chkCanViewStudents;
        private System.Windows.Forms.CheckBox chkCanEditStudents;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;

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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.chkCanViewGrades = new System.Windows.Forms.CheckBox();
            this.chkCanEditGrades = new System.Windows.Forms.CheckBox();
            this.chkCanViewStudents = new System.Windows.Forms.CheckBox();
            this.chkCanEditStudents = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.chkCanViewGrades);
            this.pnlContainer.Controls.Add(this.chkCanEditGrades);
            this.pnlContainer.Controls.Add(this.chkCanViewStudents);
            this.pnlContainer.Controls.Add(this.chkCanEditStudents);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Location = new System.Drawing.Point(10, 10);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(280, 240);
            this.pnlContainer.TabIndex = 0;
            // 
            // chkCanViewGrades
            // 
            this.chkCanViewGrades.AutoSize = true;
            this.chkCanViewGrades.Location = new System.Drawing.Point(15, 50);
            this.chkCanViewGrades.Name = "chkCanViewGrades";
            this.chkCanViewGrades.Size = new System.Drawing.Size(112, 17);
            this.chkCanViewGrades.TabIndex = 1;
            this.chkCanViewGrades.Text = "Can View Grades";
            this.chkCanViewGrades.UseVisualStyleBackColor = true;
            // 
            // chkCanEditGrades
            // 
            this.chkCanEditGrades.AutoSize = true;
            this.chkCanEditGrades.Location = new System.Drawing.Point(15, 80);
            this.chkCanEditGrades.Name = "chkCanEditGrades";
            this.chkCanEditGrades.Size = new System.Drawing.Size(110, 17);
            this.chkCanEditGrades.TabIndex = 2;
            this.chkCanEditGrades.Text = "Can Edit Grades";
            this.chkCanEditGrades.UseVisualStyleBackColor = true;
            // 
            // chkCanViewStudents
            // 
            this.chkCanViewStudents.AutoSize = true;
            this.chkCanViewStudents.Location = new System.Drawing.Point(15, 110);
            this.chkCanViewStudents.Name = "chkCanViewStudents";
            this.chkCanViewStudents.Size = new System.Drawing.Size(118, 17);
            this.chkCanViewStudents.TabIndex = 3;
            this.chkCanViewStudents.Text = "Can View Students";
            this.chkCanViewStudents.UseVisualStyleBackColor = true;
            // 
            // chkCanEditStudents
            // 
            this.chkCanEditStudents.AutoSize = true;
            this.chkCanEditStudents.Location = new System.Drawing.Point(15, 140);
            this.chkCanEditStudents.Name = "chkCanEditStudents";
            this.chkCanEditStudents.Size = new System.Drawing.Size(117, 17);
            this.chkCanEditStudents.TabIndex = 4;
            this.chkCanEditStudents.Text = "Can Edit Students";
            this.chkCanEditStudents.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Permissions";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Teacher Permissions";
            // 
            // frmSetTeacherPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(300, 260);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSetTeacherPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Teacher Permissions";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}

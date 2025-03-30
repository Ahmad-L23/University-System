using System.Windows.Forms;
using System.Drawing;
using System;

namespace Universt_System.Teachers
{
    partial class frmAddUpdateTeacher
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblFormTitle;
        private TextBox txtTeacherNumber;
        private TextBox txtName;
        private TextBox txtDepartment;
        private TextBox txtSalary;
        private TextBox txtPassword;
        private CheckBox chkEditPassword;
        private Button btnSave;
        private Button btnCancel;
        private Button btnPermissions; // Button already present for permissions
        private ErrorProvider errorProvider;
        private Label lblTeacherNumber;
        private Label lblName;
        private Label lblDepartment;
        private Label lblSalary;
        private Label lblPassword;
        private ToolTip toolTip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.txtTeacherNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkEditPassword = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPermissions = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTeacherNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblFormTitle.Location = new System.Drawing.Point(30, 10);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(143, 21);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Add New Teacher";
            // 
            // txtTeacherNumber
            // 
            this.txtTeacherNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.txtTeacherNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtTeacherNumber.Location = new System.Drawing.Point(150, 38);
            this.txtTeacherNumber.Name = "txtTeacherNumber";
            this.txtTeacherNumber.ReadOnly = true;
            this.txtTeacherNumber.Size = new System.Drawing.Size(310, 23);
            this.txtTeacherNumber.TabIndex = 2;
            this.toolTip.SetToolTip(this.txtTeacherNumber, "Unique identifier for the teacher");
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtName.Location = new System.Drawing.Point(150, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(310, 23);
            this.txtName.TabIndex = 4;
            this.toolTip.SetToolTip(this.txtName, "Enter the teacher\'s full name");
            // 
            // txtDepartment
            // 
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtDepartment.Location = new System.Drawing.Point(150, 98);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(310, 23);
            this.txtDepartment.TabIndex = 6;
            this.toolTip.SetToolTip(this.txtDepartment, "Enter the teacher\'s department");
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtSalary.Location = new System.Drawing.Point(150, 128);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(310, 23);
            this.txtSalary.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtSalary, "Enter the teacher\'s salary (numeric value)");
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtPassword.Location = new System.Drawing.Point(150, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 23);
            this.txtPassword.TabIndex = 10;
            this.toolTip.SetToolTip(this.txtPassword, "Enter a secure password");
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chkEditPassword
            // 
            this.chkEditPassword.AutoSize = true;
            this.chkEditPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkEditPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.chkEditPassword.Location = new System.Drawing.Point(150, 185);
            this.chkEditPassword.Name = "chkEditPassword";
            this.chkEditPassword.Size = new System.Drawing.Size(99, 19);
            this.chkEditPassword.TabIndex = 11;
            this.chkEditPassword.Text = "Edit Password";
            this.chkEditPassword.Visible = false;
            this.chkEditPassword.CheckedChanged += new System.EventHandler(this.chkEditPassword_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.toolTip.SetToolTip(this.btnSave, "Save the teacher details");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.Location = new System.Drawing.Point(360, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.toolTip.SetToolTip(this.btnCancel, "Discard changes and close");
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPermissions
            // 
            this.btnPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermissions.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnPermissions.ForeColor = System.Drawing.Color.White;
            this.btnPermissions.Location = new System.Drawing.Point(470, 340);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(100, 30);
            this.btnPermissions.TabIndex = 14;
            this.btnPermissions.Text = "Permissions";
            this.toolTip.SetToolTip(this.btnPermissions, "Manage teacher permissions");
            this.btnPermissions.UseVisualStyleBackColor = false;
            this.btnPermissions.Click += new System.EventHandler(this.btnPermissions_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblTeacherNumber
            // 
            this.lblTeacherNumber.AutoSize = true;
            this.lblTeacherNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTeacherNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblTeacherNumber.Location = new System.Drawing.Point(30, 40);
            this.lblTeacherNumber.Name = "lblTeacherNumber";
            this.lblTeacherNumber.Size = new System.Drawing.Size(103, 15);
            this.lblTeacherNumber.TabIndex = 1;
            this.lblTeacherNumber.Text = "Teacher Number:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblName.Location = new System.Drawing.Point(30, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblDepartment.Location = new System.Drawing.Point(30, 100);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(79, 15);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department:";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblSalary.Location = new System.Drawing.Point(30, 130);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(43, 15);
            this.lblSalary.TabIndex = 7;
            this.lblSalary.Text = "Salary:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.lblPassword.Location = new System.Drawing.Point(30, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(62, 15);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password:";
            // 
            // frmAddUpdateTeacher
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.lblTeacherNumber);
            this.Controls.Add(this.txtTeacherNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkEditPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPermissions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAddUpdateTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher Management";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
namespace University_System
{
    partial class frmDeleteCourse
    {
        private System.ComponentModel.IContainer components = null;

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
            this.grpCourseInfo = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCourseNumber = new System.Windows.Forms.TextBox();
            this.lblCourseNumber = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.txtTeacherID = new System.Windows.Forms.TextBox();
            this.lblTeacherID = new System.Windows.Forms.Label();
            this.grpCourseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCourseInfo
            // 
            this.grpCourseInfo.Controls.Add(this.lblTeacherID);
            this.grpCourseInfo.Controls.Add(this.txtTeacherID);
            this.grpCourseInfo.Controls.Add(this.lblDepartmentID);
            this.grpCourseInfo.Controls.Add(this.txtDepartmentID);
            this.grpCourseInfo.Controls.Add(this.lblCategoryID);
            this.grpCourseInfo.Controls.Add(this.txtCategoryID);
            this.grpCourseInfo.Controls.Add(this.lblName);
            this.grpCourseInfo.Controls.Add(this.txtName);
            this.grpCourseInfo.Controls.Add(this.lblHours);
            this.grpCourseInfo.Controls.Add(this.txtHours);
            this.grpCourseInfo.Enabled = false;
            this.grpCourseInfo.Location = new System.Drawing.Point(12, 79);
            this.grpCourseInfo.Name = "grpCourseInfo";
            this.grpCourseInfo.Size = new System.Drawing.Size(350, 210);
            this.grpCourseInfo.TabIndex = 0;
            this.grpCourseInfo.TabStop = false;
            this.grpCourseInfo.Text = "Course Information";
            this.grpCourseInfo.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 299);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 15);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status Message";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(126, 124);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(200, 23);
            this.txtHours.TabIndex = 7;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(6, 127);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(94, 15);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Number of Hours:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtCourseNumber
            // 
            this.txtCourseNumber.Location = new System.Drawing.Point(126, 15);
            this.txtCourseNumber.Name = "txtCourseNumber";
            this.txtCourseNumber.Size = new System.Drawing.Size(200, 23);
            this.txtCourseNumber.TabIndex = 0;
            // 
            // lblCourseNumber
            // 
            this.lblCourseNumber.AutoSize = true;
            this.lblCourseNumber.Location = new System.Drawing.Point(12, 18);
            this.lblCourseNumber.Name = "lblCourseNumber";
            this.lblCourseNumber.Size = new System.Drawing.Size(106, 15);
            this.lblCourseNumber.TabIndex = 1;
            this.lblCourseNumber.Text = "Enter Course Number:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(255, 295);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(255, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Location = new System.Drawing.Point(6, 93);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(75, 15);
            this.lblCategoryID.TabIndex = 4;
            this.lblCategoryID.Text = "Category ID:";
            this.lblCategoryID.Visible = false;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(126, 90);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(200, 23);
            this.txtCategoryID.TabIndex = 5;
            this.txtCategoryID.Visible = false;
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Location = new System.Drawing.Point(126, 158);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(200, 23);
            this.txtDepartmentID.TabIndex = 9;
            this.txtDepartmentID.Visible = false;
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.AutoSize = true;
            this.lblDepartmentID.Location = new System.Drawing.Point(6, 161);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(97, 15);
            this.lblDepartmentID.TabIndex = 8;
            this.lblDepartmentID.Text = "Department ID:";
            this.lblDepartmentID.Visible = false;
            // 
            // txtTeacherID
            // 
            this.txtTeacherID.Location = new System.Drawing.Point(126, 187);
            this.txtTeacherID.Name = "txtTeacherID";
            this.txtTeacherID.Size = new System.Drawing.Size(200, 23);
            this.txtTeacherID.TabIndex = 11;
            this.txtTeacherID.Visible = false;
            // 
            // lblTeacherID
            // 
            this.lblTeacherID.AutoSize = true;
            this.lblTeacherID.Location = new System.Drawing.Point(6, 190);
            this.lblTeacherID.Name = "lblTeacherID";
            this.lblTeacherID.Size = new System.Drawing.Size(74, 15);
            this.lblTeacherID.TabIndex = 10;
            this.lblTeacherID.Text = "Teacher ID:";
            this.lblTeacherID.Visible = false;
            // 
            // frmDeleteCourse
            // 
            this.ClientSize = new System.Drawing.Size(374, 331);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpCourseInfo);
            this.Controls.Add(this.txtCourseNumber);
            this.Controls.Add(this.lblCourseNumber);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmDeleteCourse";
            this.Text = "Delete Course";
            this.grpCourseInfo.ResumeLayout(false);
            this.grpCourseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox grpCourseInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCourseNumber;
        private System.Windows.Forms.Label lblCourseNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.TextBox txtTeacherID;
        private System.Windows.Forms.Label lblTeacherID;
    }
}

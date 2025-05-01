partial class frmAddUpdateCourseSection
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cmbCourses;
    private System.Windows.Forms.TextBox txtSectionName;
    private System.Windows.Forms.DateTimePicker dtpStartTime;
    private System.Windows.Forms.DateTimePicker dtpEndTime;
    private System.Windows.Forms.TextBox txtLocation;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblCourse;
    private System.Windows.Forms.Label lblSectionName;
    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.Label lblEndTime;
    private System.Windows.Forms.Label lblLocation;

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
        this.cmbCourses = new System.Windows.Forms.ComboBox();
        this.txtSectionName = new System.Windows.Forms.TextBox();
        this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
        this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
        this.txtLocation = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.lblCourse = new System.Windows.Forms.Label();
        this.lblSectionName = new System.Windows.Forms.Label();
        this.lblStartTime = new System.Windows.Forms.Label();
        this.lblEndTime = new System.Windows.Forms.Label();
        this.lblLocation = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lblCourse
        // 
        this.lblCourse.AutoSize = true;
        this.lblCourse.Location = new System.Drawing.Point(30, 25);
        this.lblCourse.Name = "lblCourse";
        this.lblCourse.Size = new System.Drawing.Size(46, 13);
        this.lblCourse.Text = "Course:";
        // 
        // cmbCourses
        // 
        this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCourses.FormattingEnabled = true;
        this.cmbCourses.Location = new System.Drawing.Point(120, 22);
        this.cmbCourses.Name = "cmbCourses";
        this.cmbCourses.Size = new System.Drawing.Size(200, 21);
        // 
        // lblSectionName
        // 
        this.lblSectionName.AutoSize = true;
        this.lblSectionName.Location = new System.Drawing.Point(30, 60);
        this.lblSectionName.Name = "lblSectionName";
        this.lblSectionName.Size = new System.Drawing.Size(78, 13);
        this.lblSectionName.Text = "Section Name:";
        // 
        // txtSectionName
        // 
        this.txtSectionName.Location = new System.Drawing.Point(120, 57);
        this.txtSectionName.Name = "txtSectionName";
        this.txtSectionName.Size = new System.Drawing.Size(200, 20);
        // 
        // lblStartTime
        // 
        this.lblStartTime.AutoSize = true;
        this.lblStartTime.Location = new System.Drawing.Point(30, 95);
        this.lblStartTime.Name = "lblStartTime";
        this.lblStartTime.Size = new System.Drawing.Size(61, 13);
        this.lblStartTime.Text = "Start Time:";
        // 
        // dtpStartTime
        // 
        this.dtpStartTime.Location = new System.Drawing.Point(120, 92);
        this.dtpStartTime.Name = "dtpStartTime";
        this.dtpStartTime.ShowCheckBox = true;
        this.dtpStartTime.Size = new System.Drawing.Size(200, 20);
        // 
        // lblEndTime
        // 
        this.lblEndTime.AutoSize = true;
        this.lblEndTime.Location = new System.Drawing.Point(30, 130);
        this.lblEndTime.Name = "lblEndTime";
        this.lblEndTime.Size = new System.Drawing.Size(58, 13);
        this.lblEndTime.Text = "End Time:";
        // 
        // dtpEndTime
        // 
        this.dtpEndTime.Location = new System.Drawing.Point(120, 127);
        this.dtpEndTime.Name = "dtpEndTime";
        this.dtpEndTime.ShowCheckBox = true;
        this.dtpEndTime.Size = new System.Drawing.Size(200, 20);
        // 
        // lblLocation
        // 
        this.lblLocation.AutoSize = true;
        this.lblLocation.Location = new System.Drawing.Point(30, 165);
        this.lblLocation.Name = "lblLocation";
        this.lblLocation.Size = new System.Drawing.Size(51, 13);
        this.lblLocation.Text = "Location:";
        // 
        // txtLocation
        // 
        this.txtLocation.Location = new System.Drawing.Point(120, 162);
        this.txtLocation.Name = "txtLocation";
        this.txtLocation.Size = new System.Drawing.Size(200, 20);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(120, 200);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(80, 30);
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(240, 200);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(80, 30);
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // frmAddUpdateCourseSection
        // 
        this.ClientSize = new System.Drawing.Size(370, 250);
        this.Controls.Add(this.lblCourse);
        this.Controls.Add(this.cmbCourses);
        this.Controls.Add(this.lblSectionName);
        this.Controls.Add(this.txtSectionName);
        this.Controls.Add(this.lblStartTime);
        this.Controls.Add(this.dtpStartTime);
        this.Controls.Add(this.lblEndTime);
        this.Controls.Add(this.dtpEndTime);
        this.Controls.Add(this.lblLocation);
        this.Controls.Add(this.txtLocation);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAddUpdateCourseSection";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

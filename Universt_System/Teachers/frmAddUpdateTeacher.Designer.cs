using System.Windows.Forms;
using System.Drawing;

namespace Universt_System.Teachers
{
    partial class frmAddUpdateTeacher
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtTeacherNumber;
        private TextBox txtName;
        private TextBox txtDepartment;
        private TextBox txtSalary;
        private TextBox txtPassword;
        private CheckBox chkEditPassword;
        private Button btnSave;
        private Button btnCancel;
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
            this.txtTeacherNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkEditPassword = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTeacherNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            this.SuspendLayout();

            // Form Styling
            this.BackColor = Color.FromArgb(128, 255, 255); // Light cyan background
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new Size(600, 400); // Form size remains 600x400
            this.StartPosition = FormStartPosition.CenterScreen;

            // Teacher Number Label
            this.lblTeacherNumber.AutoSize = true;
            this.lblTeacherNumber.Location = new Point(30, 30);
            this.lblTeacherNumber.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblTeacherNumber.ForeColor = Color.FromArgb(25, 25, 112); // MidnightBlue
            this.lblTeacherNumber.Text = "Teacher Number:";

            // Teacher Number TextBox
            this.txtTeacherNumber.Location = new Point(150, 28);
            this.txtTeacherNumber.Size = new Size(420, 22);
            this.txtTeacherNumber.ReadOnly = true;
            this.txtTeacherNumber.BackColor = Color.FromArgb(245, 245, 220); // Beige
            this.txtTeacherNumber.Font = new Font("Segoe UI", 8.5F);
            this.toolTip.SetToolTip(this.txtTeacherNumber, "Unique identifier for the teacher");

            // Name Label
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(30, 60);
            this.lblName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblName.ForeColor = Color.FromArgb(25, 25, 112);
            this.lblName.Text = "Name:";

            // Name TextBox
            this.txtName.Location = new Point(150, 58);
            this.txtName.Size = new Size(420, 22);
            this.txtName.Font = new Font("Segoe UI", 8.5F);
            this.toolTip.SetToolTip(this.txtName, "Enter the teacher's full name");

            // Department Label
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new Point(30, 90);
            this.lblDepartment.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblDepartment.ForeColor = Color.FromArgb(25, 25, 112);
            this.lblDepartment.Text = "Department:";

            // Department TextBox
            this.txtDepartment.Location = new Point(150, 88);
            this.txtDepartment.Size = new Size(420, 22);
            this.txtDepartment.Font = new Font("Segoe UI", 8.5F);
            this.toolTip.SetToolTip(this.txtDepartment, "Enter the teacher's department");

            // Salary Label
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new Point(30, 120);
            this.lblSalary.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblSalary.ForeColor = Color.FromArgb(25, 25, 112);
            this.lblSalary.Text = "Salary:";

            // Salary TextBox
            this.txtSalary.Location = new Point(150, 118);
            this.txtSalary.Size = new Size(420, 22);
            this.txtSalary.Font = new Font("Segoe UI", 8.5F);
            this.toolTip.SetToolTip(this.txtSalary, "Enter the teacher's salary (numeric value)");

            // Password Label
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(30, 150);
            this.lblPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(25, 25, 112);
            this.lblPassword.Text = "Password:";

            // Password TextBox
            this.txtPassword.Location = new Point(150, 148);
            this.txtPassword.Size = new Size(420, 22);
            this.txtPassword.Font = new Font("Segoe UI", 8.5F);
            this.txtPassword.UseSystemPasswordChar = true; // Mask password
            this.txtPassword.Enabled = false; // Disabled by default
            this.txtPassword.Visible = true; // Initially visible for Add mode
            this.toolTip.SetToolTip(this.txtPassword, "Enter a secure password");

            // Edit Password CheckBox
            this.chkEditPassword.AutoSize = true;
            this.chkEditPassword.Location = new Point(150, 175);
            this.chkEditPassword.Font = new Font("Segoe UI", 8.5F);
            this.chkEditPassword.ForeColor = Color.FromArgb(25, 25, 112);
            this.chkEditPassword.Text = "Edit Password";
            this.chkEditPassword.Visible = false; // Hidden by default for Add mode
            this.chkEditPassword.CheckedChanged += new System.EventHandler(this.chkEditPassword_CheckedChanged);

            // Save Button
            this.btnSave.Location = new Point(360, 340);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.btnSave.ForeColor = Color.White; // White text for contrast
            this.btnSave.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.toolTip.SetToolTip(this.btnSave, "Save the teacher details");

            // Cancel Button
            this.btnCancel.Location = new Point(470, 340);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Color.FromArgb(205, 92, 92); // IndianRed
            this.btnCancel.ForeColor = Color.FromArgb(240, 240, 240); // Light gray text for readability
            this.btnCancel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.toolTip.SetToolTip(this.btnCancel, "Discard changes and close");

            // ErrorProvider
            this.errorProvider.ContainerControl = this;
            this.errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            // Form Setup
            this.Controls.AddRange(new Control[] {
                this.lblTeacherNumber, this.txtTeacherNumber,
                this.lblName, this.txtName,
                this.lblDepartment, this.txtDepartment,
                this.lblSalary, this.txtSalary,
                this.lblPassword, this.txtPassword,
                this.chkEditPassword, this.btnSave, this.btnCancel
            });
            this.Name = "frmAddUpdateTeacher";
            this.Text = "Add or Update Teacher"; // Default title, overridden in constructors

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
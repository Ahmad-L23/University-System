using System;
using System.Windows.Forms;
using University_Bussiness;
using static University_Bussiness.clsTeacher;

namespace Universt_System.Teachers
{
    public partial class frmAddUpdateTeacher : Form
    {
        private clsTeacher _teacher;

        public frmAddUpdateTeacher()
        {
            InitializeComponent();
            _teacher = new clsTeacher();
            lblFormTitle.Text = "Add New Teacher"; // Set label text for Add mode
            chkEditPassword.Visible = false;
            txtPassword.Enabled = true;
            txtTeacherNumber.Visible = false;
            lblTeacherNumber.Visible = false;
        }

        public frmAddUpdateTeacher(string teacherNumber)
        {
            InitializeComponent();
            _teacher = new clsTeacher();
            lblFormTitle.Text = "Update Teacher Info"; // Set label text for Update mode

            if (_teacher.FindTeacherByTeacherNumber(teacherNumber))
            {
                LoadTeacherData();
            }
            else
            {
                MessageBox.Show("Teacher not found.");
            }
        }

        private void LoadTeacherData()
        {
            txtTeacherNumber.Text = _teacher.TeacherNumber;
            txtName.Text = _teacher.Name;
            txtDepartment.Text = _teacher.Department;
            txtSalary.Text = _teacher.Salary.ToString();

            
            txtPassword.Visible = false;
            chkEditPassword.Visible = true;
        }

        private void chkEditPassword_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPassword.Enabled = this.chkEditPassword.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            _teacher.Name = txtName.Text;
            _teacher.Department = txtDepartment.Text;
            _teacher.Salary = int.Parse(txtSalary.Text);
            

            // Handle password if checkbox is checked
            if (chkEditPassword.Checked && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _teacher.Password = txtPassword.Text;
            }

            

            if (_teacher.ExecuteOperation())
            {
                MessageBox.Show("Saved successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Save failed.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Name is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                errorProvider.SetError(txtDepartment, "Department is required.");
                return false;
            }

            if (!int.TryParse(txtSalary.Text, out int salary) || salary <= 0)
            {
                errorProvider.SetError(txtSalary, "Please enter a valid positive salary.");
                return false;
            }

            if (chkEditPassword.Checked && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password cannot be empty when updating.");
                return false;
            }

            return true;
        }

        private void frmAddUpdateTeacher_Load(object sender, EventArgs e)
        {

        }

        public void SetTeacherPermissions(int permissions)
        {
            _teacher.Permissions = permissions;
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            frmSetTeacherPermissions permissionForm = new frmSetTeacherPermissions(this);
            permissionForm.ShowDialog();
        }
    }
}

using System;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.Teachers
{
    public partial class frmAddUpdateTeacher : Form
    {
        private clsTeacher _teacher;

        public frmAddUpdateTeacher()
        {
            InitializeComponent();
            _teacher = new clsTeacher();
            this.Text = "Add Teacher";
            chkEditPassword.Visible = false;
        }

        public frmAddUpdateTeacher(string teacherNumber)
        {
            InitializeComponent();
            _teacher = new clsTeacher();
            this.Text = "Update Teacher";

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

            if (chkEditPassword.Checked && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _teacher.Password = txtPassword.Text;
            }

            if (_teacher.ExecuteOperation())
            {
                MessageBox.Show("Operation successful.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation failed.");
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
    }
}

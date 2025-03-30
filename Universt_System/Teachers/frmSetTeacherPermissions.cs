using System;
using System.Windows.Forms;
using University_Bussiness;
using static University_Bussiness.clsTeacher;

namespace Universt_System.Teachers
{
    public partial class frmSetTeacherPermissions : Form
    {
        private int _permissions = 0;
        private frmAddUpdateTeacher _parentForm;

        public frmSetTeacherPermissions(frmAddUpdateTeacher parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Reset permissions to 0
            _permissions = 0;

            // Check if each checkbox is checked and assign corresponding permissions
            if (chkCanViewGrades.Checked)
                _permissions |= (byte)TeacherPermissions.CanViewGrades;

            if (chkCanEditGrades.Checked)
                _permissions |= (byte)TeacherPermissions.CanEditGrades;

            if (chkCanViewStudents.Checked)
                _permissions |= (byte)TeacherPermissions.CanViewStudents;

            if (chkCanEditStudents.Checked)
                _permissions |= (byte)TeacherPermissions.CanEditStudents;

            // Pass the calculated permissions to the parent form
            _parentForm.SetTeacherPermissions(_permissions);

            // Show a confirmation message
            MessageBox.Show("Permissions set successfully.");

            // Close the current form
            this.Close();
        }

    }
}

using System;
using System.Windows.Forms;
using University_Bussiness;

namespace University_System
{
    public partial class frmDeleteCourse : Form
    {
        private int _courseIdToDelete = -1;

        public frmDeleteCourse()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            grpCourseInfo.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCourseNumber.Text.Trim(), out int courseNumber))
            {
                lblStatus.Text = "Please enter a valid course number.";
                btnDelete.Enabled = false;
                grpCourseInfo.Visible = false;
                return;
            }

            clsCourse foundCourse = clsCourse.FindByCourseNumber(courseNumber);

            if (foundCourse != null)
            {
                _courseIdToDelete = foundCourse.CourseID.Value;

                txtName.Text = foundCourse.Name;
                txtHours.Text = foundCourse.NumberOfHours.ToString();

                // Hide the fields for Department ID, Teacher ID, and Category ID
                txtCategoryID.Visible = false;
                txtDepartmentID.Visible = false;
                txtTeacherID.Visible = false;

                lblCategoryID.Visible = false;
                lblDepartmentID.Visible = false;
                lblTeacherID.Visible = false;

                grpCourseInfo.Visible = true;
                btnDelete.Enabled = true;
                lblStatus.Text = "Course found. You can now delete it.";
            }
            else
            {
                _courseIdToDelete = -1;
                grpCourseInfo.Visible = false;
                btnDelete.Enabled = false;

                // Show message to inform the user that no course was found
                MessageBox.Show("No course found with this number.", "Course Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "No course found with this number.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_courseIdToDelete == -1)
            {
                lblStatus.Text = "No valid course selected for deletion.";
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this course?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (clsCourse.DeleteCourse(_courseIdToDelete))
                {
                    lblStatus.Text = "Course deleted successfully.";
                    btnDelete.Enabled = false;
                    grpCourseInfo.Visible = false;
                    txtCourseNumber.Clear();
                }
                else
                {
                    lblStatus.Text = "Failed to delete the course.";
                }
            }
        }
    }
}

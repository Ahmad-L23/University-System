using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.Students
{
    public partial class frmUpdateStudent : Form
    {
        clsStudent _stduent; 

        public frmUpdateStudent()
        {
            InitializeComponent();
            _stduent = new clsStudent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentID = SearchStudentNumberTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Please enter a valid student ID before searching.",
                                "Input Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

             _stduent = clsStudent.FindStudentByID(studentID);

            if (_stduent != null)
            {
                nameTxt.Text = _stduent.Name;
                TxtPlaceOfBirth.Text = _stduent.PlaceOfBirth;
                majorTxt.Text = _stduent.Major;
            }
            else
            {
                MessageBox.Show("No student was found with the provided ID. Please check the ID and try again.",
                                "Student Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_stduent.StudentNumber))
            {
                MessageBox.Show("Please search for a student before updating.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _stduent.Name = nameTxt.Text.Trim();
            _stduent.PlaceOfBirth = TxtPlaceOfBirth.Text.Trim();
            _stduent.Password = passwordTxt.Text.Trim();

            bool isUpdated = _stduent.UpdateStudent();
            if (isUpdated)
            {
                MessageBox.Show($"Student With ID {_stduent.StudentNumber} Updated Successfully", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update student. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

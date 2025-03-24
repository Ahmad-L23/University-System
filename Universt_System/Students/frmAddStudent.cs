using System;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.Students
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void frmAddStudent_Load(object sender, EventArgs e)
        {
            // Ensure that the cities are added to the ComboBox collection
            Cities.Items.Clear();  // Clear any existing items in the ComboBox to prevent duplication
            Cities.Items.Add("Irbid");
            Cities.Items.Add("Amman");
            Cities.Items.Add("Jerash");
            Cities.Items.Add("Ajlon");
            Cities.Items.Add("Al'aqba");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                clsStudent student = new clsStudent
                {
                    Name = nameTxt.Text,
                    Password = passwordTxt.Text,
                    Major = majorTxt.Text,
                    PlaceOfBirth = Cities.SelectedItem.ToString()
                };

                if (student.AddStudent())
                {
                    
                    MessageBox.Show($"Student added successfully! Student Number: {student.StudentNumber}. Please remember student number.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There was an error adding the student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(majorTxt.Text))
            {
                MessageBox.Show("Major is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Cities.SelectedItem == null)
            {
                MessageBox.Show("Place of birth is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void frmAddStudent_Load_1(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.majors
{
    public partial class frmAddUpdateMajor : Form
    {
        private int _selectedFacultyId = -1;
        private int _majorID = -1; // Store the major ID if updating
        private TextBox txtMajorName;
        private TextBox txtNewMajorName;
        private ComboBox cmbFaculty;
        private Label lblOldMajorName;
        private Button btnSave;
        private Button btnUpdate;

        // Non-parameterized constructor for adding a new major
        public frmAddUpdateMajor()
        {
            InitializeComponent();
            this.Size = new Size(400, 250);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Add Major";

            // Call the Add() method to set up the form for adding a major
            Add();
        }

        // Parameterized constructor for updating an existing major
        public frmAddUpdateMajor(string existingMajorName)
        {
            InitializeComponent();
            this.Size = new Size(400, 350);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Update Major";

            // Check if the major exists before continuing
            if (string.IsNullOrEmpty(existingMajorName) || !clsMajor.MajorExist(existingMajorName))
            {
                MessageBox.Show("Major name does not exist or invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            existingMajorName = existingMajorName.ToLower();
            _majorID = clsMajor.FindMajorID(existingMajorName);

            // Set up UI for updating the major
            SetupUpdateUI(existingMajorName);
        }

        // Setup form controls for adding a new major
        private void Add()
        {
            Label lblMajorName = new Label();
            lblMajorName.Text = "Major Name:";
            lblMajorName.Location = new Point(30, 30);
            lblMajorName.AutoSize = true;
            lblMajorName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblMajorName.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblMajorName);

            txtMajorName = new TextBox();
            txtMajorName.Name = "txtMajorName";
            txtMajorName.Location = new Point(150, 28);
            txtMajorName.Width = 200;
            txtMajorName.Font = new Font("Segoe UI", 10);
            txtMajorName.BackColor = Color.White;
            txtMajorName.ForeColor = Color.Black;
            this.Controls.Add(txtMajorName);

            Label lblSelectFaculty = new Label();
            lblSelectFaculty.Text = "Select Faculty:";
            lblSelectFaculty.Location = new Point(30, 80);
            lblSelectFaculty.AutoSize = true;
            lblSelectFaculty.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSelectFaculty.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblSelectFaculty);

            cmbFaculty = new ComboBox();
            cmbFaculty.Name = "cmbFaculty";
            cmbFaculty.Location = new Point(150, 78);
            cmbFaculty.Width = 200;
            cmbFaculty.Font = new Font("Segoe UI", 10);
            cmbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFaculty.BackColor = Color.White;
            cmbFaculty.ForeColor = Color.Black;
            this.Controls.Add(cmbFaculty);

            var departments = GetAllDepartments();
            cmbFaculty.DataSource = departments;
            cmbFaculty.DisplayMember = "Item2";
            cmbFaculty.ValueMember = "Item1";

            cmbFaculty.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFaculty.SelectedItem is Tuple<int, string> selectedDepartment)
                {
                    _selectedFacultyId = selectedDepartment.Item1;
                }
            };

            btnSave = new Button();
            btnSave.Text = "Save Major";
            btnSave.Location = new Point(150, 130);
            btnSave.Width = 200;
            btnSave.Height = 35;
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.BackColor = Color.MidnightBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        // Setup form controls for updating an existing major
        private void SetupUpdateUI(string existingMajorName)
        {
            lblOldMajorName = new Label();
            lblOldMajorName.Text = $"Old Major Name: {existingMajorName}";
            lblOldMajorName.Location = new Point(30, 30);
            lblOldMajorName.AutoSize = true;
            lblOldMajorName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblOldMajorName.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblOldMajorName);

            txtNewMajorName = new TextBox();
            txtNewMajorName.Name = "txtNewMajorName";
            txtNewMajorName.Location = new Point(150, 70);
            txtNewMajorName.Width = 200;
            txtNewMajorName.Font = new Font("Segoe UI", 10);
            txtNewMajorName.BackColor = Color.White;
            txtNewMajorName.ForeColor = Color.Black;
            this.Controls.Add(txtNewMajorName);

            btnUpdate = new Button();
            btnUpdate.Text = "Update Major";
            btnUpdate.Location = new Point(150, 120);
            btnUpdate.Width = 200;
            btnUpdate.Height = 35;
            btnUpdate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUpdate.BackColor = Color.DarkGreen;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate);
        }

        // Handle saving the new major
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string majorName = txtMajorName.Text.Trim();

            if (string.IsNullOrEmpty(majorName))
            {
                MessageBox.Show("Please enter a Major Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsMajor.MajorExist(majorName))
            {
                MessageBox.Show("Major name already exists. Please enter another name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedFacultyId == -1)
            {
                MessageBox.Show("Please select a Faculty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMajor major = new clsMajor(null, majorName, _selectedFacultyId);
            major.Mode = clsMajor.enMode.AddNew;

            if (major.Save())
            {
                MessageBox.Show($"Major Name: {majorName}\nFaculty ID: {_selectedFacultyId}", "Major Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong while saving the major. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle updating the existing major
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this major name?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string newMajorName = txtNewMajorName.Text.Trim();

                if (string.IsNullOrEmpty(newMajorName))
                {
                    MessageBox.Show("Please enter a new Major Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clsMajor major = new clsMajor(_majorID, newMajorName, _selectedFacultyId);
                major.Mode = clsMajor.enMode.Update;

                if (major.Save())
                {
                    MessageBox.Show("Major name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong while updating. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Optionally close the form
                this.Close();
            }
        }

        public static List<Tuple<int, string>> GetAllDepartments()
        {
            return clsDepartments.GetAllDepartments();
        }
    }
}

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
        private TextBox txtMajorName;
        private ComboBox cmbFaculty;

        public frmAddUpdateMajor()
        {
            InitializeComponent();
            this.Size = new Size(400, 250);
            this.BackColor = Color.FromArgb(240, 248, 255); // Light background (AliceBlue)
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Add or Update Major";
            Add();
        }

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

            Button btnSave = new Button();
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string majorName = txtMajorName.Text.Trim();

            if (string.IsNullOrEmpty(majorName))
            {
                MessageBox.Show("Please enter a Major Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedFacultyId == -1)
            {
                MessageBox.Show("Please select a Faculty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMajor major = new clsMajor(majorName, _selectedFacultyId);
            if (major.addMajor())
            {
                MessageBox.Show($"Major Name: {majorName}\nFaculty ID: {_selectedFacultyId}", "Major Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong while saving the major. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Tuple<int, string>> GetAllDepartments()
        {
            return clsDepartments.GetAllDepartments();
        }
    }
}

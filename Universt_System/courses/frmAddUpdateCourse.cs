using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using University_Bussiness;

namespace University_System.courses
{
    public partial class frmAddUpdateCourse : Form
    {
        private int _selectedDepartmentId = -1;
        private int _selectedCategoryId = -1;
        private int _selectedTeacherId = -1;
        private int? _courseID = -1;
        private TextBox txtCourseName;
        private TextBox txtNumberOfCourse;
        private TextBox txtNumberOfHours;
        private ComboBox cmbCategory;
        private ComboBox cmbDepartment;
        private ComboBox cmbTeacher;
        private Label lblOldCourseName;
        private Button btnSave;
        private Button btnUpdate;

        public frmAddUpdateCourse()
        {
            InitializeComponent();
            this.Size = new Size(450, 550);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Add Course";
            Add();
        }

        public frmAddUpdateCourse(string existingCourseName)
        {
            InitializeComponent();
            this.Size = new Size(400, 550);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Update Course";

            if (string.IsNullOrEmpty(existingCourseName) || !clsCourse.CourseExist(existingCourseName))
            {
                MessageBox.Show("Course name does not exist or invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            existingCourseName = existingCourseName.ToLower();
            _courseID = clsCourse.GetCourseIdByName(existingCourseName);
            SetupUpdateUI(existingCourseName);
        }

        private void Add()
        {
            Label lblCourseName = new Label();
            lblCourseName.Text = "Course Name:";
            lblCourseName.Location = new Point(5, 30);
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCourseName.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblCourseName);

            txtCourseName = new TextBox();
            txtCourseName.Location = new Point(150, 28);
            txtCourseName.Width = 200;
            txtCourseName.Font = new Font("Segoe UI", 10);
            this.Controls.Add(txtCourseName);

            Label lblNumberOfCourse = new Label();
            lblNumberOfCourse.Text = "Number of Courses:";
            lblNumberOfCourse.Location = new Point(5, 80);
            lblNumberOfCourse.AutoSize = true;
            lblNumberOfCourse.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNumberOfCourse.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblNumberOfCourse);

            txtNumberOfCourse = new TextBox();
            txtNumberOfCourse.Location = new Point(150, 78);
            txtNumberOfCourse.Width = 200;
            txtNumberOfCourse.Font = new Font("Segoe UI", 10);
            this.Controls.Add(txtNumberOfCourse);

            Label lblNumberOfHours = new Label();
            lblNumberOfHours.Text = "Number of Hours:";
            lblNumberOfHours.Location = new Point(5, 130);
            lblNumberOfHours.AutoSize = true;
            lblNumberOfHours.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNumberOfHours.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblNumberOfHours);

            txtNumberOfHours = new TextBox();
            txtNumberOfHours.Location = new Point(150, 128);
            txtNumberOfHours.Width = 200;
            txtNumberOfHours.Font = new Font("Segoe UI", 10);
            this.Controls.Add(txtNumberOfHours);

            Label lblSelectCategory = new Label();
            lblSelectCategory.Text = "Select Category:";
            lblSelectCategory.Location = new Point(5, 180);
            lblSelectCategory.AutoSize = true;
            lblSelectCategory.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSelectCategory.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblSelectCategory);

            cmbCategory = new ComboBox();
            cmbCategory.Location = new Point(150, 178);
            cmbCategory.Width = 200;
            cmbCategory.Font = new Font("Segoe UI", 10);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategory.ItemHeight = 22;
            cmbCategory.DrawItem += ComboBox_DrawItem;
            this.Controls.Add(cmbCategory);

            cmbCategory.DataSource = GetAllCategories();
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;

            Label lblSelectDepartment = new Label();
            lblSelectDepartment.Text = "Select Department:";
            lblSelectDepartment.Location = new Point(5, 250);
            lblSelectDepartment.AutoSize = true;
            lblSelectDepartment.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSelectDepartment.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblSelectDepartment);

            cmbDepartment = new ComboBox();
            cmbDepartment.Location = new Point(150, 248);
            cmbDepartment.Width = 200;
            cmbDepartment.Font = new Font("Segoe UI", 10);
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDepartment.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDepartment.ItemHeight = 22;
            cmbDepartment.DrawItem += ComboBox_DrawItem;
            this.Controls.Add(cmbDepartment);

            cmbDepartment.DataSource = GetAllDepartments();
            cmbDepartment.DisplayMember = "Item2";
            cmbDepartment.ValueMember = "Item1";
            cmbDepartment.SelectedIndexChanged += CmbDepartment_SelectedIndexChanged;

            Label lblSelectTeacher = new Label();
            lblSelectTeacher.Text = "Select Teacher:";
            lblSelectTeacher.Location = new Point(5, 320);
            lblSelectTeacher.AutoSize = true;
            lblSelectTeacher.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSelectTeacher.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblSelectTeacher);

            cmbTeacher = new ComboBox();
            cmbTeacher.Location = new Point(150, 318);
            cmbTeacher.Width = 200;
            cmbTeacher.Font = new Font("Segoe UI", 10);
            cmbTeacher.DropDownStyle = ComboBoxStyle.DropDown;
            cmbTeacher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTeacher.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTeacher.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTeacher.ItemHeight = 22;
            cmbTeacher.DrawItem += ComboBox_DrawItem;
            this.Controls.Add(cmbTeacher);

            cmbTeacher.DataSource = GetAllTeachers();
            cmbTeacher.DisplayMember = "name";
            cmbTeacher.ValueMember = "teacher_id";
            cmbTeacher.SelectedIndexChanged += CmbTeacher_SelectedIndexChanged;

            btnSave = new Button();
            btnSave.Text = "Save Course";
            btnSave.Location = new Point(150, 380);
            btnSave.Width = 200;
            btnSave.Height = 35;
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.BackColor = Color.MidnightBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private void SetupUpdateUI(string existingCourseName)
        {
            lblOldCourseName = new Label();
            lblOldCourseName.Text = $"Old Course Name: {existingCourseName}";
            lblOldCourseName.Location = new Point(30, 30);
            lblOldCourseName.AutoSize = true;
            lblOldCourseName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblOldCourseName.ForeColor = Color.MidnightBlue;
            this.Controls.Add(lblOldCourseName);

            txtCourseName = new TextBox();
            txtCourseName.Location = new Point(150, 70);
            txtCourseName.Width = 200;
            txtCourseName.Font = new Font("Segoe UI", 10);
            this.Controls.Add(txtCourseName);

            btnUpdate = new Button();
            btnUpdate.Text = "Update Course";
            btnUpdate.Location = new Point(150, 380);
            btnUpdate.Width = 200;
            btnUpdate.Height = 35;
            btnUpdate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUpdate.BackColor = Color.DarkGreen;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate);
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = sender as ComboBox;
            e.DrawBackground();

            string text = combo.GetItemText(combo.Items[e.Index]);
            using (Brush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, textBrush, e.Bounds.Left + 5, e.Bounds.Top + 5);
            }

            e.DrawFocusRectangle();
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCategoryId = (int)cmbCategory.SelectedValue;
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedDepartmentId = (int)cmbDepartment.SelectedValue;
        }

        private void CmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedTeacherId = (int)cmbTeacher.SelectedValue;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.Trim();
            int numberOfCourse = int.Parse(txtNumberOfCourse.Text.Trim());
            int numberOfHours = int.Parse(txtNumberOfHours.Text.Trim());

            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Please enter a Course Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedCategoryId == -1 || _selectedDepartmentId == -1 || _selectedTeacherId == -1)
            {
                MessageBox.Show("Please select a Category, Department, and Teacher.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCourse course = new clsCourse(null, courseName, numberOfCourse, numberOfHours, _selectedCategoryId, _selectedDepartmentId, _selectedTeacherId);
            course.Mode = clsCourse.enMode.AddNew;

            if (course.Save())
            {
                MessageBox.Show($"Course Name: {courseName} saved successfully", "Course Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong while saving the course. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.Trim();
            int numberOfCourse = int.Parse(txtNumberOfCourse.Text.Trim());
            int numberOfHours = int.Parse(txtNumberOfHours.Text.Trim());

            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Please enter a new Course Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCourse course = new clsCourse(_courseID, courseName, numberOfCourse, numberOfHours, _selectedCategoryId, _selectedDepartmentId, _selectedTeacherId);
            course.Mode = clsCourse.enMode.Update;

            if (course.Save())
            {
                MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong while updating. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        public static List<clsCategorie> GetAllCategories()
        {
            return clsCategorie.GetAllCategories();
        }

        public static List<Tuple<int, string>> GetAllDepartments()
        {
            return clsDepartments.GetAllDepartments();
        }

        public static DataTable GetAllTeachers()
        {
            return clsTeacher.GetAllTeachers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using University_Bussiness;

public partial class frmAddUpdateCourseSection : Form
{
    private clsCourseSection _courseSection;

    public frmAddUpdateCourseSection()
    {
        InitializeComponent();
        _courseSection = new clsCourseSection();
        this.Text = "Add New Course Section";
        LoadCourses();
        InitializeDateTimePickers();
    }

    public frmAddUpdateCourseSection(int courseSectionID)
    {
        InitializeComponent();
        _courseSection = clsCourseSection.Find(courseSectionID);

        if (_courseSection == null)
        {
            MessageBox.Show("Course Section not found.");
            this.Close();
            return;
        }

        this.Text = "Update Course Section";
        LoadCourses();
        InitializeDateTimePickers();

        cmbCourses.SelectedValue = _courseSection.CourseID;
        txtSectionName.Text = _courseSection.SectionName;
        dtpStartTime.Value = _courseSection.StartTime.HasValue
            ? DateTime.Today.Add(_courseSection.StartTime.Value)
            : DateTime.Now;

        dtpEndTime.Value = _courseSection.EndTime.HasValue
            ? DateTime.Today.Add(_courseSection.EndTime.Value)
            : DateTime.Now;

        txtLocation.Text = _courseSection.Location;
    }

    private void InitializeDateTimePickers()
    {
        dtpStartTime.Format = DateTimePickerFormat.Custom;
        dtpStartTime.CustomFormat = "HH:mm";
        dtpStartTime.ShowUpDown = true;

        dtpEndTime.Format = DateTimePickerFormat.Custom;
        dtpEndTime.CustomFormat = "HH:mm";
        dtpEndTime.ShowUpDown = true;
    }

    private void LoadCourses()
    {
        var courses = clsCourse.GetAllCourses();

        if (courses != null && courses.Count > 0)
        {
            var courseDisplayList = new List<KeyValuePair<int, string>>();

            foreach (var course in courses)
            {
                int courseId = Convert.ToInt32(course["id"]);
                string courseName = course["name"].ToString();
                int numberOfCourse = Convert.ToInt32(course["number_of_course"]);
                int numberOfHours = Convert.ToInt32(course["number_of_hours"]);

                string displayText = $"{courseName} - {numberOfCourse} - {numberOfHours} hrs";
                courseDisplayList.Add(new KeyValuePair<int, string>(courseId, displayText));
            }

            cmbCourses.DisplayMember = "Value";
            cmbCourses.ValueMember = "Key";
            cmbCourses.DataSource = courseDisplayList;
        }
        else
        {
            MessageBox.Show("No courses available to display.");
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _courseSection.CourseID = Convert.ToInt32(cmbCourses.SelectedValue);
        _courseSection.SectionName = txtSectionName.Text.Trim();
        _courseSection.StartTime = dtpStartTime.Checked ? dtpStartTime.Value.TimeOfDay : (TimeSpan?)null;
        _courseSection.EndTime = dtpEndTime.Checked ? dtpEndTime.Value.TimeOfDay : (TimeSpan?)null;
        _courseSection.Location = txtLocation.Text.Trim();

        if (_courseSection.Save())
        {
            MessageBox.Show("Saved successfully.");
            this.Close();
        }
        else
        {
            MessageBox.Show("Failed to save.");
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}

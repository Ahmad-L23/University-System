using System;
using System.Data;
using University_DataAccess;

public class clsCourseSection
{
    public enum enMode { AddNew = 0, Update = 1 }

    public enMode Mode { get; set; }

    public int CourseSectionID { get; private set; }
    public int CourseID { get; set; }
    public string SectionName { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string Location { get; set; }

    public clsCourseSection()
    {
        Mode = enMode.AddNew;
        CourseSectionID = -1;
    }

    private clsCourseSection(int courseSectionID, int courseID, string sectionName, TimeSpan? startTime, TimeSpan? endTime, string location)
    {
        CourseSectionID = courseSectionID;
        CourseID = courseID;
        SectionName = sectionName;
        StartTime = startTime;
        EndTime = endTime;
        Location = location;
        Mode = enMode.Update;
    }

    private bool _AddNew()
    {
        CourseSectionID = clsCourseSectionData.AddNewCourseSection(CourseID, SectionName, StartTime, EndTime, Location);
        return CourseSectionID != -1;
    }

    private bool _Update()
    {
        return clsCourseSectionData.UpdateCourseSection(CourseSectionID, CourseID, SectionName, StartTime, EndTime, Location);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                return _AddNew();

            case enMode.Update:
                return _Update();

            default:
                return false;
        }
    }

    public static clsCourseSection Find(int courseSectionID)
    {
        if (clsCourseSectionData.GetCourseSectionInfoByID(courseSectionID, out int courseID, out string sectionName, out TimeSpan? startTime, out TimeSpan? endTime, out string location))
        {
            return new clsCourseSection(courseSectionID, courseID, sectionName, startTime, endTime, location);
        }

        return null;
    }

    public static bool Delete(int courseSectionID)
    {
        return clsCourseSectionData.DeleteCourseSection(courseSectionID);
    }

    public static DataTable GetAllCourseSections()
    {
        return clsCourseSectionData.GetAllCourseSections();
    }

    public static int? FindBySectionName(string sectionName)
    {
        return clsCourseSectionData.FindCourseSectionByName(sectionName);
    }

    public static int? FindByStartTime(TimeSpan startTime)
    {
        return clsCourseSectionData.FindSectionByStartTime(startTime);
    }
}

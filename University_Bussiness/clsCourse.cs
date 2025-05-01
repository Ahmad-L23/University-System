using University_DataAccess;
using System;
using System.Collections.Generic;

namespace University_Bussiness
{
    public class clsCourse
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int? CourseID { get; set; }
        public string Name { get; set; }
        public int NumberOfCourse { get; set; }
        public int NumberOfHours { get; set; }
        public int CategoryID { get; set; }
        public int DepartmentID { get; set; }
        public int TeacherID { get; set; }

        public clsCourse()
        {
            this.CourseID = null;
            this.Name = "";
            this.NumberOfCourse = 0;
            this.NumberOfHours = 0;
            this.CategoryID = 0;
            this.DepartmentID = 0;
            this.TeacherID = 0;
            Mode = enMode.AddNew;
        }

        public clsCourse(int? id, string name, int numberOfCourse, int numberOfHours, int categoryId, int departmentId, int teacherId)
        {
            this.CourseID = id;
            this.Name = name;
            this.NumberOfCourse = numberOfCourse;
            this.NumberOfHours = numberOfHours;
            this.CategoryID = categoryId;
            this.DepartmentID = departmentId;
            this.TeacherID = teacherId;
            Mode = enMode.Update;
        }

        private bool _AddNewCourse()
        {
            this.CourseID = clsCourseData.AddNewCourse(this.Name, this.NumberOfCourse, this.NumberOfHours, this.CategoryID, this.DepartmentID, this.TeacherID);
            return (this.CourseID != -1);
        }

        private bool _UpdateCourse()
        {
            return clsCourseData.UpdateCourse(this.CourseID.Value, this.Name, this.NumberOfCourse, this.NumberOfHours, this.CategoryID, this.DepartmentID, this.TeacherID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewCourse();
                case enMode.Update:
                    return _UpdateCourse();
                default:
                    return false;
            }
        }

        public static bool DeleteCourse(int id)
        {
            return clsCourseData.DeleteCourse(id);
        }

        public static clsCourse Find(int id)
        {
            string name = "";
            int numberOfCourse = 0, numberOfHours = 0, catID = 0, depID = 0, teachID = 0;

            if (clsCourseData.GetCourseById(id, ref name, ref numberOfCourse, ref numberOfHours, ref catID, ref depID, ref teachID))
            {
                return new clsCourse(id, name, numberOfCourse, numberOfHours, catID, depID, teachID);
            }

            return null;
        }

        public static List<Dictionary<string, object>> GetAllCourses()
        {
            return clsCourseData.GetAllCourses();
        }

       
        public static int Count()
        {
            return clsCourseData.Count();
        }

        public static int? GetCourseIdByName(string name)
        {
            return clsCourseData.GetCourseIdByName(name);
        }

        public static bool CourseExist(string name)
        {
            return clsCourseData.CourseExist(name);
        }


        public static clsCourse FindByCourseNumber(int numberOfCourse)
        {
            int id = 0, numberOfHours = 0, categoryId = 0;
            string name = "";

            if (clsCourseData.GetCourseByCourseNumber(numberOfCourse, ref id, ref name, ref numberOfHours, ref categoryId))
            {
                return new clsCourse(id, name, numberOfCourse, numberOfHours, categoryId, 0, 0); // departmentID and teacherID set to 0
            }

            return null;
        }

    }
}

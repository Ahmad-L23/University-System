using System;
using University_DataAccess;

namespace University_Bussiness
{
    public class clsTeacher
    {
        [Flags]
        public enum TeacherPermissions
        {
            None = 0,
            CanViewGrades = 1,
            CanEditGrades = 2,
            CanViewStudents = 4,
            CanEditStudents = 8
        }

        public enum TeacherOperation { Add, Update }

        public string Name { get; set; }
        public string TeacherNumber { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int Permissions { get; set; }

        public TeacherOperation TeacherOp { get; private set; }

        public clsTeacher()
        {
            Name = string.Empty;
            TeacherNumber = string.Empty;
            Password = string.Empty;
            Department = string.Empty;
            Salary = 0;
            Permissions = 0;
            TeacherOp = TeacherOperation.Add;
        }

        public clsTeacher(string teacherNumber, string name, string password, string department, int salary, int permissions)
        {
            TeacherNumber = teacherNumber;
            Name = name;
            Password = password;
            Department = department;
            Salary = salary;
            Permissions = permissions;
            TeacherOp = string.IsNullOrEmpty(teacherNumber) ? TeacherOperation.Add : TeacherOperation.Update;
        }

        public bool ExecuteOperation()
        {
            return TeacherOp == TeacherOperation.Update ? UpdateTeacher() : AddTeacher();
        }

        private bool AddTeacher()
        {
            this.TeacherNumber = clsTeacherData.AddNewTeacher(this.Name, this.Password, this.Department, this.Salary, this.Permissions);
            return this.TeacherNumber != null;
        }

        private bool UpdateTeacher()
        {
            string passwordToUpdate = string.IsNullOrEmpty(this.Password) ? null : this.Password;
            return clsTeacherData.UpdateTeacher(this.Name, this.TeacherNumber, passwordToUpdate, this.Department, this.Salary, this.Permissions);
        }

        public bool FindTeacherByTeacherNumber(string teacherNumber)
        {
            string name = string.Empty, department = string.Empty;
            int salary = 0;
            int permissions = 0;

            bool isFound = clsTeacherData.FindTeacherByTeacherNumber(teacherNumber, ref name, ref department, ref salary, ref permissions);

            if (isFound)
            {
                this.Name = name;
                this.Department = department;
                this.Salary = salary;
                this.Permissions = permissions;
                return true;
            }
            return false;
        }
    }
}

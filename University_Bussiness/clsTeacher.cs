using System;
using University_DataAccess;

namespace University_Bussiness
{
    public enum TeacherOperation
    {
        Add,
        Update
    }

    public class clsTeacher
    {
        public string Name { get; set; }
        public string TeacherNumber { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public TeacherOperation TeacherOp { get; private set; }

        public clsTeacher()
        {
            Name = string.Empty;
            TeacherNumber = string.Empty;
            Password = string.Empty;
            Department = string.Empty;
            Salary = 0;
            TeacherOp = TeacherOperation.Add;
        }

        public clsTeacher(string teacherNumber, string name, string password, string department, int salary)
        {
            TeacherNumber = teacherNumber;
            Name = name;
            Password = password;
            Department = department;
            Salary = salary;
            TeacherOp = string.IsNullOrEmpty(teacherNumber) ? TeacherOperation.Add : TeacherOperation.Update;
        }

        public bool ExecuteOperation()
        {
            return TeacherOp == TeacherOperation.Update ? UpdateTeacher() : AddTeacher();
        }

        private bool AddTeacher()
        {
            this.TeacherNumber = clsTeacherData.AddNewTeacher(this.Name, this.Password, this.Department, this.Salary);
            return this.TeacherNumber != null;
        }

        private bool UpdateTeacher()
        {
            string passwordToUpdate = string.IsNullOrEmpty(this.Password) ? null : this.Password;
            return clsTeacherData.UpdateTeacher(this.Name, this.TeacherNumber, passwordToUpdate, this.Department, this.Salary);
        }

        // Find teacher by TeacherNumber
        public bool FindTeacherByTeacherNumber(string teacherNumber)
        {
            string name = string.Empty, department = string.Empty;
            int salary = 0;

            bool isFound = clsTeacherData.FindTeacherByTeacherNumber(teacherNumber, ref name, ref department, ref salary);

            if (isFound)
            {
                this.Name = name;
                this.Department = department;
                this.Salary = salary;
                return true;
            }
            return false;
        }
    }
}

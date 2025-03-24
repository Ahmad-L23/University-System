using System;
using University_DataAccess;

namespace University_Bussiness
{
    public class clsStudent
    {
        public string Name { get; set; }
        public int? ID { get; set; }
        public string StudentNumber { get; set; }
        public string Password { get; set; }
        public string Major { get; set; }
        public string PlaceOfBirth { get; set; }

        
        public bool AddStudent()
        {
            this.StudentNumber = clsStudentData.AddNewStudent(this.Name, this.Password, this.PlaceOfBirth, this.Major);
            return (this.StudentNumber != null);
        }

        
        public bool UpdateStudent()
        {
            
            string passwordToUpdate = string.IsNullOrEmpty(this.Password) ? null : this.Password;

            return clsStudentData.UpdateStudent(this.Name, this.StudentNumber, passwordToUpdate, this.PlaceOfBirth);
        }

        
        public bool FindStudentByID(string studentNumber)
        {
            string name = "", password = "", placeOfBirth = "", major = "";
            bool isFound = clsStudentData.FindStudentByStudentNumber(ref name, studentNumber, ref placeOfBirth, ref major);

            if (isFound)
            {
                this.Name = name;
                this.StudentNumber = studentNumber;
                this.PlaceOfBirth = placeOfBirth;
                this.Major = major;
                return true;
            }
            return false;
        }
    }
}

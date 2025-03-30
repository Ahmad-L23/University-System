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

        public clsStudent(string name = "", string studentNumber = "", string password = "", string placeOfBirth = "", string major = "")
        {
            this.Name = name;
            this.StudentNumber = studentNumber;
            this.Password = password;
            this.PlaceOfBirth = placeOfBirth;
            this.Major = major;
        }

        public bool AddStudent()
        {
            this.Name.ToLower();
            this.StudentNumber = clsStudentData.AddNewStudent(this.Name, this.Password, this.PlaceOfBirth, this.Major);
            return (this.StudentNumber != null);
        }

        
        public bool UpdateStudent()
        {
            this.Name.ToLower();
            string passwordToUpdate = string.IsNullOrEmpty(this.Password) ? null : this.Password;

            return clsStudentData.UpdateStudent(this.Name, this.StudentNumber, passwordToUpdate, this.PlaceOfBirth);
        }


        public static clsStudent FindStudentByID(string studentNumber)
        {
            string name = "", placeOfBirth = "", major = "";
            bool isFound = clsStudentData.FindStudentByStudentNumber(ref name, studentNumber, ref placeOfBirth, ref major);

            return isFound ? new clsStudent(name, studentNumber, "", placeOfBirth, major) : null;
        }

        public static clsStudent FindStudentByName(string name)
        {
            string studentNumber = "", placeOfBirth = "", major = "";
            bool isFound = clsStudentData.FindStudentByName(ref name, ref studentNumber, ref placeOfBirth, ref major);

            return isFound ? new clsStudent(name, studentNumber, "", placeOfBirth, major) : null;
        }
    }
}

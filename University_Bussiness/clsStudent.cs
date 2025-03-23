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
    }
}

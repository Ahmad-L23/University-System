using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using University_DataAccess;

namespace University_Bussiness
{
    public class clsMajor
    {
        public string name;
        public int departmentID;

        public clsMajor()
        {
            this.name = "";
            this.departmentID = 0;
        }
        
        public clsMajor(string name, int departmentID)
        {
            this.name = name;
            this.departmentID = departmentID;
        }

        public bool addMajor()
        {
            this.name = this.name.ToLower();
            return clsMajorData.addMajor(this.name, this.departmentID);
           
        }

        public static bool MajorExist(string name)
        {
            name = name.ToLower();
            return clsMajorData.isMajorExist(name);
        }

        public static int findMajorID(string name)
        {
            name = name.ToLower();
            return clsMajorData.findMajorIDByName(name);
        }

        public static bool updateMajor(int id, string newMajorName)
        {
            return clsMajorData.updateMajor(id, newMajorName);
        }
    }
}

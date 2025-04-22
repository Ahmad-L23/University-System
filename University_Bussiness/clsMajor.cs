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
        private string name;
        private int departmentID;

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

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using University_DataAccess;


namespace University_Bussiness
{
   public class clsDepartments
    {
        public static bool AddDepartment(string departmentName)
        {
            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                return clsDepartmentData.AddDepartment(departmentName);
            }
            return false;
        }

        public static bool UpdateDepartmentName(int departmentId, string newDepartmentName)
        {
            if (departmentId > 0 && !string.IsNullOrWhiteSpace(newDepartmentName))
            {
                return clsDepartmentData.UpdateDepartment(departmentId, newDepartmentName);
            }
            return false;
        }

        public static bool DeleteDepartment(int departmentId)
        {
            if (departmentId > 0)
            {
                return clsDepartmentData.DeleteDepartment(departmentId);
            }
            return false;
        }

        public static DataTable SearchDepartmentByName(string searchName)
        {
            return clsDepartmentData.SearchDepartmentByName(searchName);
        }

        public static List<Tuple<int, string>> GetAllDepartments()
        {
            return clsDepartmentData.GetAllDepartments();
        }
    }
}

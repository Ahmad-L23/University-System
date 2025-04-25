using University_DataAccess;
using System;
using System.Collections.Generic;

namespace University_Bussiness
{
    public class clsMajor
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int? MajorID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public clsMajor()
        {
            this.MajorID = null;
            this.Name = "";
            this.DepartmentID = 0;
            Mode = enMode.AddNew;
        }

        public clsMajor(int? majorID, string name, int departmentID)
        {
            this.MajorID = majorID;
            this.Name = name;
            this.DepartmentID = departmentID;
            Mode = enMode.Update;
        }

        private bool _AddNewMajor()
        {
            this.MajorID = clsMajorData.AddNewMajor(this.Name, this.DepartmentID);
            return (this.MajorID != -1);
        }

        private bool _UpdateMajor()
        {
            return clsMajorData.UpdateMajor(this.MajorID.Value, this.Name);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewMajor();

                case enMode.Update:
                    return _UpdateMajor();

                default:
                    return false;
            }
        }

        public static bool MajorExist(string name)
        {
            name = name.ToLower();
            return clsMajorData.IsMajorExist(name);
        }

        public static int FindMajorID(string name)
        {
            name = name.ToLower();
            return clsMajorData.FindMajorIDByName(name);
        }

        public static bool UpdateMajor(int id, string newMajorName)
        {
            return clsMajorData.UpdateMajor(id, newMajorName);
        }

        public static bool DeleteMajor(int id)
        {
            return clsMajorData.DeleteMajor(id);
        }

        public static List<string> GetAllMajors()
        {
            return clsMajorData.GetAllMajors();
        }

        public static bool GetMajorInfoByName(string name, ref int id, ref int departmentID)
        {
            return clsMajorData.GetMajorInfoByName(name, ref id, ref departmentID);
        }

        public static int Count()
        {
            return clsMajorData.Count();
        }
    }
}

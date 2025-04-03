using System;
using System.Collections.Generic;
using University_DataAccess;

namespace University_Bussiness
{
    public class clsCategorie
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int NumberOfHours { get; set; }

        public clsCategorie(int id = 0, string name = "", int numberOfHours = 0)
        {
            this.ID = id;
            this.Name = name;
            this.NumberOfHours = numberOfHours;
        }

        public bool AddCategory()
        {
            bool isCreated = clsCategorieData.CreateCategory(this.Name, this.NumberOfHours);
            return isCreated;
        }

        public bool UpdateCategory()
        {
            return clsCategorieData.UpdateCategory(this.ID.Value, this.Name, this.NumberOfHours);
        }

        public static clsCategorie FindCategoryByID(int id)
        {
            var categoryData = clsCategorieData.FindCategoryByID(id);
            if (categoryData != null)
            {
                return new clsCategorie(categoryData.Item1, categoryData.Item2, categoryData.Item3);
            }
            return null;
        }

        public static List<clsCategorie> GetAllCategories()
        {
            List<Tuple<int, string, int>> categoriesData = clsCategorieData.GetAllCategories();
            List<clsCategorie> categories = new List<clsCategorie>();

            foreach (var category in categoriesData)
            {
                categories.Add(new clsCategorie(category.Item1, category.Item2, category.Item3));
            }

            return categories;
        }

        public static List<clsCategorie> SearchCategoriesByName(string searchName)
        {
            List<Tuple<int, string, int>> categoriesData = clsCategorieData.SearchCategoryByName(searchName);
            List<clsCategorie> categories = new List<clsCategorie>();

            foreach (var category in categoriesData)
            {
                categories.Add(new clsCategorie(category.Item1, category.Item2, category.Item3));
            }

            return categories;
        }

        public static bool DeleteCategory(int id)
        {
            return clsCategorieData.DeleteCategory(id);
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace University_DataAccess
{
    public class clsCategorieData
    {
        private static string connectionString = clsDataAccessSettings.ConnectionString;

        // Create Category
        public static bool CreateCategory(string name, int numberOfHours)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO categorie (name, number_of_hours) VALUES (@name, @number_of_hours)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@number_of_hours", numberOfHours);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return false;
                }
            }
        }

        // Get All Categories
        public static List<Tuple<int, string, int>> GetAllCategories()
        {
            List<Tuple<int, string, int>> categories = new List<Tuple<int, string, int>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, name, number_of_hours FROM categorie";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            int numberOfHours = reader.GetInt32("number_of_hours");
                            categories.Add(new Tuple<int, string, int>(id, name, numberOfHours));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
            }
            return categories;
        }

        // Update Category
        public static bool UpdateCategory(int id, string newName, int newNumberOfHours)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE categorie SET name = @newName, number_of_hours = @newNumberOfHours WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@newName", newName);
                    cmd.Parameters.AddWithValue("@newNumberOfHours", newNumberOfHours);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return false;
                }
            }
        }

        // Delete Category
        public static bool DeleteCategory(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM categorie WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return false;
                }
            }
        }

        // Search Category by Name
        public static List<Tuple<int, string, int>> SearchCategoryByName(string searchName)
        {
            List<Tuple<int, string, int>> categories = new List<Tuple<int, string, int>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, name, number_of_hours FROM categorie WHERE name LIKE @searchName";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchName", searchName + "%");

                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            int numberOfHours = reader.GetInt32("number_of_hours");
                            categories.Add(new Tuple<int, string, int>(id, name, numberOfHours));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
            }

            return categories;
        }

        // Find Category by ID
        public static Tuple<int, string, int> FindCategoryByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, name, number_of_hours FROM categorie WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int categoryId = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            int numberOfHours = reader.GetInt32("number_of_hours");
                            return new Tuple<int, string, int>(categoryId, name, numberOfHours);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
            }

            return null; // Return null if not found
        }
    }
}

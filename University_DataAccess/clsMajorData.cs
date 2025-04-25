using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace University_DataAccess
{
    public class clsMajorData
    {
        public static int AddNewMajor(string name, int departmentID)
        {
            int majorID = -1; 

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO major (name, department_id) VALUES (@name, @departmentID); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@departmentID", departmentID);

                       
                        majorID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting major: {ex.Message}");
            }

            return majorID;
        }


        public static bool IsMajorExist(string name)
        {
            bool exists = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM major WHERE name = @name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        object result = command.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            exists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if major exists: {ex.Message}");
            }

            return exists;
        }

        public static int FindMajorIDByName(string name)
        {
            int majorId = -1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM major WHERE name = @name LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out majorId))
                        {
                            majorId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding major ID by name: {ex.Message}");
            }

            return majorId;
        }

        public static bool UpdateMajor(int id, string name)
        {
            bool updated = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE major SET name = @name WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            updated = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating major: {ex.Message}");
            }

            return updated;
        }

        public static bool DeleteMajor(int id)
        {
            bool deleted = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM major WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            deleted = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting major: {ex.Message}");
            }

            return deleted;
        }

        public static List<string> GetAllMajors()
        {
            List<string> majors = new List<string>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT name FROM major";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                majors.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all majors: {ex.Message}");
            }

            return majors;
        }

        public static bool GetMajorInfoByName(string name, ref int id, ref int departmentID)
        {
            bool found = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT id, department_id FROM major WHERE name = @name LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id"]);
                                departmentID = Convert.ToInt32(reader["department_id"]);
                                found = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting major info by name: {ex.Message}");
            }

            return found;
        }

        public static int Count()
        {
            int count = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM major";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error counting majors: {ex.Message}");
            }

            return count;
        }
    }
}

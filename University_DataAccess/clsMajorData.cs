using MySql.Data.MySqlClient;
using System;

namespace University_DataAccess
{
    public class clsMajorData
    {
        public static bool addMajor(string name, int departmentID)
        {
            bool inserted = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO major (name, department_id) VALUES (@name, @departmentID)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@departmentID", departmentID);
                        command.ExecuteNonQuery();
                        inserted = true;
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting major: {ex.Message}");
            }
            return inserted;
        }


        public static bool isMajorExist(string name)
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
        
       

        public static int findMajorIDByName(string name)
            {
                int majorId = -1; // default if not found

                using (MySqlConnection conn = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM Major WHERE name = @Name LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);

                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            majorId = id;
                        }
                    }
                }

                return majorId;
            }


        public static bool updateMajor(int id, string name)
        {
            bool updated = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE major SET name = @name WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            updated = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("message prolbem is " + ex.ToString());
            }
            
            return updated;
        }

    }
}

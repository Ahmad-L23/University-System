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
                        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting major: {ex.Message}");
            }
            return inserted;
        }
    }
}

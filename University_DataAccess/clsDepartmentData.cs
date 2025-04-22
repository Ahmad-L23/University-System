using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace University_DataAccess
{
    public static class clsDepartmentData
    {
        private static string cs = clsDataAccessSettings.ConnectionString;

        public static bool AddDepartment(string departmentName)
        {
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "INSERT INTO Department (`name`) VALUES (@DepartmentName)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateDepartment(int departmentId, string newDepartmentName)
        {
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "UPDATE Department SET `name` = @DepartmentName WHERE id = @DepartmentId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", newDepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteDepartment(int departmentId)
        {
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "DELETE FROM Department WHERE id = @DepartmentId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static DataTable SearchDepartmentByName(string searchName)
        {
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM Department WHERE `name` LIKE @SearchName";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchName", searchName + "%"); 
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
        }


        public static List<Tuple<int, string>> GetAllDepartments()
        {
            List<Tuple<int, string>> departments = new List<Tuple<int, string>>();

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "SELECT id, `name` FROM Department";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            departments.Add(new Tuple<int, string>(id, name));
                        }
                    }
                }
            }
            return departments;
        }
    }
}

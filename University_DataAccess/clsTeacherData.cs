using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace University_DataAccess
{
    public class clsTeacherData
    {
        private static string cs = clsDataAccessSettings.ConnectionString;

        public static string AddNewTeacher(string name, string password, string department, decimal salary, int permissions)
        {
            string teacherNumber = GenerateUniqueTeacherNumber();
            string hashedPassword = HashPassword(password);

            string query = "INSERT INTO teacher (name, teacher_number, password, department, salary, permissions) " +
                           "VALUES (@Name, @TeacherNumber, @Password, @Department, @Salary, @Permissions);";

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@TeacherNumber", teacherNumber);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Salary", salary);
                        cmd.Parameters.AddWithValue("@Permissions", permissions);

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            return teacherNumber;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return null;
        }

        private static string GenerateUniqueTeacherNumber()
        {
            string teacherNumber;
            Random rnd = new Random();

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();

                do
                {
                    int randomDigits = rnd.Next(100, 999);
                    teacherNumber = "32" + randomDigits.ToString();

                    string query = "SELECT COUNT(*) FROM teacher WHERE teacher_number = @TeacherNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherNumber", teacherNumber);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0) break;
                    }
                } while (true);
            }

            return teacherNumber;
        }

        public static bool UpdateTeacher(string name, string teacherNumber, string password, string department, decimal salary, int permissions)
        {
            bool isUpdated = false;
            string query = "UPDATE teacher SET name = @Name, department = @Department, salary = @Salary, permissions = @Permissions WHERE teacher_number = @TeacherNumber";

            if (!string.IsNullOrEmpty(password))
            {
                string hashedPassword = HashPassword(password);
                query = "UPDATE teacher SET name = @Name, department = @Department, salary = @Salary, password = @Password, permissions = @Permissions WHERE teacher_number = @TeacherNumber";
            }

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Salary", salary);
                        cmd.Parameters.AddWithValue("@Permissions", permissions);
                        cmd.Parameters.AddWithValue("@TeacherNumber", teacherNumber);

                        if (!string.IsNullOrEmpty(password))
                        {
                            string hashedPassword = HashPassword(password);
                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        }

                        int affectedRows = cmd.ExecuteNonQuery();
                        isUpdated = affectedRows > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isUpdated;
        }

        public static bool FindTeacherByTeacherNumber(string teacherNumber, ref string name, ref string department, ref int salary, ref int permissions)
        {
            string query = "SELECT name, department, salary, permissions FROM teacher WHERE teacher_number = @TeacherNumber";
            bool isFound = false;

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherNumber", teacherNumber);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                name = reader["name"].ToString();
                                department = reader["department"].ToString();
                                salary = reader.GetInt32("salary");
                                permissions = reader.GetInt32("permissions");
                            }
                            else
                            {
                                name = string.Empty;
                                department = string.Empty;
                                salary = 0;
                                permissions = 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return isFound;
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

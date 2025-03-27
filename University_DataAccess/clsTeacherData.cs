using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace University_DataAccess
{
    public class clsTeacherData
    {
        private static string cs = clsDataAccessSettings.ConnectionString;

        public static string AddNewTeacher(string name, string password, string department, decimal salary)
        {
            string teacherNumber = GenerateUniqueTeacherNumber();
            string hashedPassword = HashPassword(password);

            string query = "INSERT INTO teachers (name, teacher_number, password, department, salary, enrollment_year) " +
                           "VALUES (@Name, @TeacherNumber, @Password, @Department, @Salary, CURRENT_TIMESTAMP);";

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
                    int randomDigits = rnd.Next(10000, 99999);
                    teacherNumber = randomDigits.ToString();

                    string query = "SELECT COUNT(*) FROM teachers WHERE teacher_number = @TeacherNumber";
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

        public static bool UpdateTeacher(string name, string teacherNumber, string password, string department, decimal salary)
        {
            bool isUpdated = false;

            string query = "UPDATE teachers SET name = @Name, department = @Department, salary = @Salary WHERE teacher_number = @TeacherNumber";

            if (!string.IsNullOrEmpty(password))
            {
                string hashedPassword = HashPassword(password);
                query = "UPDATE teachers SET name = @Name, department = @Department, salary = @Salary, password = @Password WHERE teacher_number = @TeacherNumber";
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

        public static bool FindTeacherByTeacherNumber(string teacherNumber, ref string name, ref string department, ref int salary)
        {
            string query = "SELECT name, department, salary FROM teachers WHERE teacher_number = @TeacherNumber";
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
                            }
                            else
                            {
                                name = string.Empty;
                                department = string.Empty;
                                salary = 0;
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

using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace University_DataAccess
{
    public class clsStudentData
    {
        private static string cs = clsDataAccessSettings.ConnectionString;

        
        public static string AddNewStudent(string name, string password, string placeOfBirth, string major)
        {
            string studentNumber = GenerateUniqueStudentNumber();
            string hashedPassword = HashPassword(password);

            string query = "INSERT INTO student (name, student_number, password, place_of_birth, major) " +
                           "VALUES (@Name, @StudentNumber, @Password, @PlaceOfBirth, @Major);";

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@PlaceOfBirth", placeOfBirth);
                        cmd.Parameters.AddWithValue("@Major", major);

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            return studentNumber;
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

        private static string GenerateUniqueStudentNumber()
        {
            string studentNumber;
            Random rnd = new Random();

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();

                do
                {
                    int randomDigits = rnd.Next(100000, 999999);
                    studentNumber = "3211" + randomDigits.ToString();

                    string query = "SELECT COUNT(*) FROM Student WHERE student_number = @StudentNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0) break;
                    }
                } while (true);
            }

            return studentNumber;
        }

        
        public static bool FindStudentByStudentNumber(ref string name, string studentNumber, ref string placeOfBirth, ref string major)
        {
            string query = "SELECT name, place_of_birth, major FROM student WHERE student_number = @StudentNumber";
            bool isFound = false;

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                name = reader["name"].ToString();
                                placeOfBirth = reader["place_of_birth"].ToString();
                                major = reader["major"].ToString();
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

     
        public static bool UpdateStudent(string name, string studentNumber, string password, string placeOfBirth)
        {
            bool isUpdated = false;

            
            string query = "UPDATE student SET name = @Name, place_of_birth = @PlaceOfBirth WHERE student_number = @StudentNumber";

            
            if (!string.IsNullOrEmpty(password))
            {
                string hashedPassword = HashPassword(password);
                query = "UPDATE student SET name = @Name, place_of_birth = @PlaceOfBirth, password = @Password WHERE student_number = @StudentNumber";
            }

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@PlaceOfBirth", placeOfBirth);
                        cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                        
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

       
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

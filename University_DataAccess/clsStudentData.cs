using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace University_DataAccess
{
    public class clsStudentData
    {
        private static string cs = ConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;

        public static int AddNewStudent(string name, int studentNumber, string password, string placeOfBirth, string major)
        {
            int studentID = -1;
            string hashedPassword = HashPassword(password);

            string query = "INSERT INTO Student (name, student_number, password, place_of_birth, major) " +
                           "VALUES (@Name, @StudentNumber, @Password, @PlaceOfBirth, @Major); SELECT LAST_INSERT_ID();";

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

                        studentID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return studentID;
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        public static bool UpdateStudent(string name, int studentNumber,string placeOFBirth, string major)
        {
            bool isUpdated = false;

            using (MySqlConnection conn = new MySqlConnection(cs))
            {

            }
        }
    }
}

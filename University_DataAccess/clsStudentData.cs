using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Runtime.InteropServices;

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


        public static bool UpdateStudent(string name, int studentNumber,string placeOfBirth, string major)
        {
            bool isUpdated = false;
            string query = "update stduent set name= @Name, student_number =@studentNumber, place_of_birth = @placeOfbirthday, major = @major where student_number = studentNumber";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        cmd.Parameters.AddWithValue("@placeOfBirth", placeOfBirth);
                        cmd.Parameters.AddWithValue("@major", major);
                        int efectedRow = cmd.ExecuteNonQuery();
                        isUpdated = efectedRow > 0;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return isUpdated;

            }
        }




    }
}

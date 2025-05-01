using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace University_DataAccess
{
    public class clsCourseData
    {
        public static int AddNewCourse(string name, int numberOfCourse, int numberOfHours, int categoryId, int departmentId, int teacherId)
        {
            int courseId = -1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO course (name, number_of_course, number_of_hours, category_id, department_id, teacher_id) 
                                     VALUES (@name, @noc, @noh, @catID, @depID, @teachID); 
                                     SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@noc", numberOfCourse);
                        command.Parameters.AddWithValue("@noh", numberOfHours);
                        command.Parameters.AddWithValue("@catID", categoryId);
                        command.Parameters.AddWithValue("@depID", departmentId);
                        command.Parameters.AddWithValue("@teachID", teacherId);

                        courseId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding course: {ex.Message}");
            }

            return courseId;
        }

        public static bool UpdateCourse(int id, string name, int numberOfCourse, int numberOfHours, int categoryId, int departmentId, int teacherId)
        {
            bool updated = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE course 
                                     SET name=@name, number_of_course=@noc, number_of_hours=@noh, 
                                         category_id=@catID, department_id=@depID, teacher_id=@teachID 
                                     WHERE id=@id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@noc", numberOfCourse);
                        command.Parameters.AddWithValue("@noh", numberOfHours);
                        command.Parameters.AddWithValue("@catID", categoryId);
                        command.Parameters.AddWithValue("@depID", departmentId);
                        command.Parameters.AddWithValue("@teachID", teacherId);
                        command.Parameters.AddWithValue("@id", id);

                        updated = command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
            }

            return updated;
        }

        public static bool DeleteCourse(int id)
        {
            bool deleted = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM course WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        deleted = command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
            }

            return deleted;
        }

        public static bool GetCourseById(int id, ref string name, ref int numberOfCourse, ref int numberOfHours, ref int categoryId, ref int departmentId, ref int teacherId)
        {
            bool found = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM course WHERE id = @id LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = reader["name"].ToString();
                                numberOfCourse = Convert.ToInt32(reader["number_of_course"]);
                                numberOfHours = Convert.ToInt32(reader["number_of_hours"]);
                                categoryId = Convert.ToInt32(reader["category_id"]);
                                departmentId = Convert.ToInt32(reader["department_id"]);
                                teacherId = Convert.ToInt32(reader["teacher_id"]);
                                found = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving course: {ex.Message}");
            }

            return found;
        }

        public static List<Dictionary<string, object>> GetAllCourses()
        {
            var courses = new List<Dictionary<string, object>>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT id, name, number_of_course, number_of_hours FROM course"; // Selecting the necessary fields

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var course = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    course.Add(reader.GetName(i), reader.GetValue(i)); // Map each column to its name and value
                                }
                                courses.Add(course);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting courses: {ex.Message}");
            }

            return courses;
        }


        public static int Count()
        {
            int count = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM course";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error counting courses: {ex.Message}");
            }

            return count;
        }


        public static int? GetCourseIdByName(string name)
        {
            int? courseId = null;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT id 
                             FROM course 
                             WHERE name = @name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            courseId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching course ID: {ex.Message}");
            }

            return courseId;
        }


        public static bool CourseExist(string name)
        {
            bool exists = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) 
                       FROM course 
                       WHERE name = @name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        exists = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if course exists: {ex.Message}");
            }

            return exists;
        }


        public static bool GetCourseByCourseNumber(int numberOfCourse, ref int id, ref string name, ref int numberOfHours, ref int categoryId)
        {
            bool found = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT id, name, number_of_hours, category_id FROM course WHERE number_of_course = @number LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@number", numberOfCourse);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id"]);
                                name = reader["name"].ToString();
                                numberOfHours = Convert.ToInt32(reader["number_of_hours"]);
                                categoryId = Convert.ToInt32(reader["category_id"]);
                                found = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving course by course number: {ex.Message}");
            }

            return found;
        }


    }
}

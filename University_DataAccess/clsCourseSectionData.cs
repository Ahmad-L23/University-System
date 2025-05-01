using System;
using System.Data;
using MySql.Data.MySqlClient;
using University_DataAccess;

public class clsCourseSectionData
{
    private static readonly string connectionString = clsDataAccessSettings.ConnectionString;

    public static bool GetCourseSectionInfoByID(int courseSectionID, out int courseID, out string sectionName, out TimeSpan? startTime, out TimeSpan? endTime, out string location)
    {
        courseID = 0;
        sectionName = location = null;
        startTime = endTime = null;

        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM coursesections WHERE CourseSectionID = @CourseSectionID";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CourseSectionID", courseSectionID);

            con.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    courseID = Convert.ToInt32(dr["CourseID"]);
                    sectionName = dr["SectionName"].ToString();
                    startTime = dr["StartTime"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(dr["StartTime"].ToString());
                    endTime = dr["EndTime"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(dr["EndTime"].ToString());
                    location = dr["Location"].ToString();
                    return true;
                }
            }
        }

        return false;
    }

    public static int AddNewCourseSection(int courseID, string sectionName, TimeSpan? startTime, TimeSpan? endTime, string location)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = @"INSERT INTO coursesections (CourseID, SectionName, StartTime, EndTime, Location)
                             VALUES (@CourseID, @SectionName, @StartTime, @EndTime, @Location);
                             SELECT LAST_INSERT_ID();";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CourseID", courseID);
            cmd.Parameters.AddWithValue("@SectionName", sectionName);
            cmd.Parameters.AddWithValue("@StartTime", startTime.HasValue ? (object)startTime.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@EndTime", endTime.HasValue ? (object)endTime.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public static bool UpdateCourseSection(int courseSectionID, int courseID, string sectionName, TimeSpan? startTime, TimeSpan? endTime, string location)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = @"UPDATE coursesections 
                             SET CourseID = @CourseID, SectionName = @SectionName, StartTime = @StartTime, EndTime = @EndTime, Location = @Location 
                             WHERE CourseSectionID = @CourseSectionID";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CourseSectionID", courseSectionID);
            cmd.Parameters.AddWithValue("@CourseID", courseID);
            cmd.Parameters.AddWithValue("@SectionName", sectionName);
            cmd.Parameters.AddWithValue("@StartTime", startTime.HasValue ? (object)startTime.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@EndTime", endTime.HasValue ? (object)endTime.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public static bool DeleteCourseSection(int courseSectionID)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = "DELETE FROM coursesections WHERE CourseSectionID = @CourseSectionID";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CourseSectionID", courseSectionID);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public static DataTable GetAllCourseSections()
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM coursesections";
            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static int? FindCourseSectionByName(string sectionName)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = "SELECT CourseSectionID FROM coursesections WHERE SectionName = @SectionName";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SectionName", sectionName);

            con.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? (int?)Convert.ToInt32(result) : null;
        }
    }

    public static int? FindSectionByStartTime(TimeSpan startTime)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            string query = "SELECT CourseSectionID FROM coursesections WHERE StartTime = @StartTime";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StartTime", startTime);

            con.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? (int?)Convert.ToInt32(result) : null;
        }
    }
}

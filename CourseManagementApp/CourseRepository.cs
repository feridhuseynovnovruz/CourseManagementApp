using System.Collections.Generic;
using System.Data.SqlClient;

namespace CourseManagementApp
{
    public class CourseRepository
    {
        public List<Course> GetAll()
        {
            var list = new List<Course>();
            const string sql = "SELECT CourseId, CourseName, Credits FROM Courses ORDER BY CourseId DESC";

            using (var con = new SqlConnection(Db.ConnStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Course
                        {
                            Id = r.GetInt32(0),
                            Title = r["CourseName"].ToString(),
                            Credits = r.GetInt32(2)
                        });
                    }
                }
            }

            return list;
        }

        public int Add(Course course)
        {
            const string sql = "INSERT INTO Courses (CourseName, Credits) VALUES (@title, @credits)";

            using (var con = new SqlConnection(Db.ConnStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@title", course.Title);
                cmd.Parameters.AddWithValue("@credits", course.Credits);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Course course)
        {
            const string sql = "UPDATE Courses SET CourseName = @title, Credits = @credits WHERE CourseId = @id";

            using (var con = new SqlConnection(Db.ConnStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@title", course.Title);
                cmd.Parameters.AddWithValue("@credits", course.Credits);
                cmd.Parameters.AddWithValue("@id", course.Id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            const string sql = "DELETE FROM Courses WHERE CourseId = @id";

            using (var con = new SqlConnection(Db.ConnStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Count()
        {
            const string sql = "SELECT COUNT(*) FROM Courses";

            using (var con = new SqlConnection(Db.ConnStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
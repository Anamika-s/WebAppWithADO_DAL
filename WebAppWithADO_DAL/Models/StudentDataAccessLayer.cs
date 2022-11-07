using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace WebAppWithADO_DAL.Models
{
    public class StudentDataAccessLayer
    {
        SqlConnection connection;
        SqlCommand command;
        List<Student> listStudents = null;
        IConfiguration _config;
        public StudentDataAccessLayer(IConfiguration config)
        {
            _config = config;

        }
        public List<Student> GetStudents()
        {
            try
            {
                connection = GetConnection();
                command = new SqlCommand("Select * from Employee");
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    listStudents = new List<Student>();
                    while (reader.Read())
                    {
                        Student student = new Student() { Id = (int)reader[0], Name = reader[1].ToString(), Batch = reader[2].ToString(), StartDate = Convert.ToDateTime(reader[3]) };
                        listStudents.Add(student);
                    }

                }
            }
               catch (Exception ex)
            {
             
            }

            finally
            {
                connection.Close();
                command.Dispose();
                connection.Dispose();
            }
            return listStudents;



        }

        public int Create(Student student)
        {

            connection = GetConnection();
            command = new SqlCommand("Insert into student(name, batch, start_date)values(@name, @batch,@startdate)");
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@dept", student.Batch);
            command.Parameters.AddWithValue("@salary", student.StartDate);
            command.Connection = connection;
            connection.Open();
            int flag= command.ExecuteNonQuery();
            return flag;

        }
        private SqlConnection GetConnection()
        {
            connection = new SqlConnection(_config.GetConnectionString("MyConnection"));
            return connection;





        }
    }
}

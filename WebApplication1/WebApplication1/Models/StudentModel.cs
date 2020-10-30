using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Models
{
    public class StudentModel
    {
        public static List<Student> StudentList = new List<Student>();

        dbConntex str = new dbConntex();

        public List<Student> GetStudent()
        {
            var students = new List<Student>();
            //string connect

            // SqlConnection object initialization
            SqlConnection sqlConnection = new SqlConnection(str.str);
            //sql Command  use stored produre
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_GetStudent";
            //connect database
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var student = new Student();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    //lấy tên và  giá trị
                    var colName = sqlDataReader.GetName(i);
                    var value = sqlDataReader.GetValue(i);
                    // mapping model
                    var property = student.GetType().GetProperty(colName);
                    if (property != null)
                    {
                        property.SetValue(student, value);
                    }
                }
                //thêm đối tượng vào list
                students.Add(student);
            }
            //close Connection
            sqlConnection.Close();

            return students;

        }
        public List<Student> GetIdStudent(string SID)
        {
            var students = new List<Student>();
            //string connect

            // SqlConnection object initialization
            SqlConnection sqlConnection = new SqlConnection(str.str);
            //sql Command  use stored produre
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "Proc_SelectIdStudent";
            sqlCommand.Parameters.AddWithValue("@SID", SID);
            //connect database
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var student = new Student();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    //lấy tên và  giá trị
                    var colName = sqlDataReader.GetName(i);
                    var value = sqlDataReader.GetValue(i);
                    // mapping model
                    var property = student.GetType().GetProperty(colName);
                    if (property != null)
                    {
                        property.SetValue(student, value);
                    }
                }
                //thêm đối tượng vào list
                students.Add(student);
            }
            //close Connection
            sqlConnection.Close();

            return students;

        }
        public bool insertStd(Student std)
        {
            var student = GetIdStudent(std.SID);
            if (student.Count == 0)
            {
                // SqlConnection object initialization
                SqlConnection sqlConnection = new SqlConnection(str.str);
                //sql Command  use stored produre
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "dbo.Proc_InsertStudent";
                // gán tham số cho parameter
                sqlCommand.Parameters.AddWithValue("@SID", std.SID);
                sqlCommand.Parameters.AddWithValue("@SName", std.SName);
                sqlCommand.Parameters.AddWithValue("@SPhone", std.SPhone);
                sqlCommand.Parameters.AddWithValue("@SGender", std.SGender);
                sqlCommand.Parameters.AddWithValue("@SAddress", std.SAddress);

                //connect database
                sqlConnection.Open();

                var result = sqlCommand.ExecuteNonQuery();

                //close Connection
                sqlConnection.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

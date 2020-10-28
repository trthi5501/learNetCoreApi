using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1.Model
{
    public class StuentModel
    {
        /// <summary>
        /// Student ID
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// Student SName
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// Student Phone
        /// </summary>
        public string SPhone { get; set; }
        /// <summary>
        /// Student Gender
        /// </summary>
        public string SGender { get; set; }
        /// <summary>
        /// Student Address
        /// </summary>
        public string SAddress { get; set; }

        public static List<StuentModel> StudentList = new List<StuentModel>();

        Connection str = new Connection();

        public List<StuentModel> GetStuents()
        {
            var students = new List<StuentModel>();
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
                var student = new StuentModel();
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
        public bool insertStd(StuentModel std){
            var students = new List<StuentModel>();
            //string connect

            // SqlConnection object initialization
            SqlConnection sqlConnection = new SqlConnection(str.str);
            //sql Command  use stored produre
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_InsertStudent";
            // gán tham số cho parameter
            sqlCommand.Parameters.AddWithValue("@SID",std.SID);
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

    }
}

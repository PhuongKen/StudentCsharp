using System;
using MySql.Data.MySqlClient;

namespace StudentCsharp
{
    public class StudentModel
    {
        private const string ServerName = "localhost";
        private const string DatabaseName = "student_csharp";
        private const string UserName = "root";
        private const string Password = "";

        public void Save(Student student)
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                "insert into students (rollNumber,name,email,phone) values (@val1,@val2,@val3,@val4)",
                connection);
            cmd.Parameters.AddWithValue("@val1", student.RollNumber);
            cmd.Parameters.AddWithValue("@val2", student.Name);
            cmd.Parameters.AddWithValue("@val3", student.Email);
            cmd.Parameters.AddWithValue("@val4", student.Phone);

            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Chay den day roi...");
        }

        public void Query()
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from students", connection);
        }
    }
}
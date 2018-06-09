using System;
using System.Collections.Generic;
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

        public List<Student> Query()
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            List<Student> list = new List<Student>();
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from students", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student st = new Student();
                st.RollNumber = reader.GetString(reader.GetOrdinal("rollNumber"));
                st.Name = reader.GetString(reader.GetOrdinal("name"));
                st.Email = reader.GetString(reader.GetOrdinal("email"));
                st.Phone = reader.GetString(reader.GetOrdinal("phone"));
                list.Add(st);
            }
            return list;
            connection.Close();
        }
        
        public List<Student> QueryByName(String name)
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            List<Student> list = new List<Student>();
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from students where name like @val", connection);
            cmd.Parameters.AddWithValue("@val", "%" + name + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Student st = new Student();
                st.RollNumber = reader.GetString(reader.GetOrdinal("rollNumber"));
                st.Name = reader.GetString(reader.GetOrdinal("name"));
                st.Email = reader.GetString(reader.GetOrdinal("email"));
                st.Phone = reader.GetString(reader.GetOrdinal("phone"));
                list.Add(st);
            }

            return list;
            connection.Close();
        }

        public Student CheckId(String id)
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from students where rollNumber = @val", connection);
            cmd.Parameters.AddWithValue("@val", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var st = new Student();
                st.RollNumber = reader.GetString(reader.GetOrdinal("rollNumber"));
                st.Name = reader.GetString(reader.GetOrdinal("name"));
                st.Email = reader.GetString(reader.GetOrdinal("email"));
                st.Phone = reader.GetString(reader.GetOrdinal("phone"));
                return st;
               
            }
            connection.Close();
            return null;
        }

        public void UpdateStudent(Student student)
        {
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={UserName};Pwd={Password};SslMode=none";
            MySqlConnection connection = new MySqlConnection(cnnString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("update students set name = @val, email = @val1, phone = @val2 where rollNumber = @val3", connection);
            cmd.Parameters.AddWithValue("@val", student.Name);
            cmd.Parameters.AddWithValue("@val1", student.Email);
            cmd.Parameters.AddWithValue("@val2", student.Phone);
            cmd.Parameters.AddWithValue("@val3", student.RollNumber);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
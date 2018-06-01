using System;
using System.Collections.Generic;

namespace StudentCsharp
{
    class Program
    {
        private static List<Student> list = new List<Student>();

        static void Main(string[] args)
        {
            GennerateMenu();
        }

        private static void SearchByName()
        {
            Console.WriteLine("Please enter name to search: ");
            var searchKey = Console.ReadLine();
            foreach (var student in list)
            {
                if (searchKey.Equals(student.Name))
                {
                    Console.WriteLine("Found: ");
                    Console.WriteLine("RollNumber: " + student.RollNumber + "  Name: " + student.Name + "  Email: " +
                                      student.Email + "  Phone: " + student.Phone);
                }
            }
        }

        private static Student AddStudent()
        {
            var student = new Student();
            Console.WriteLine("Please enter rollNumber: ");
            student.RollNumber = Console.ReadLine();
            Console.WriteLine("Please enter name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Please enter email: ");
            student.Email = Console.ReadLine();
            Console.WriteLine("Please enter phone: ");
            student.Phone = Console.ReadLine();
            return student;
        }

        private static void DisplayStudent()
        {
            foreach (var student in list)
            {
                Console.WriteLine("RollNumber: " + student.RollNumber + "  Name: " + student.Name + "  Email: " +
                                  student.Email + "  Phone: " + student.Phone);
            }
        }

        private static void GennerateMenu()
        {
            while (true)
            {
                Console.WriteLine("-----------Student Manager-----------");
                Console.WriteLine("1, Add new student.");
                Console.WriteLine("2, Show list student.");
                Console.WriteLine("3, Search student by name.");
                Console.WriteLine("4, Exit");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Please enter choice: ");
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add new student.");
                        StudentModel model = new StudentModel();
                        model.Save(AddStudent());
                        break;
                    case 2:
                        Console.WriteLine("Show list student.");
                        DisplayStudent();
                        break;
                    case 3:
                        Console.WriteLine("Search student by name.");
                        SearchByName();
                        break;
                    case 4:
                        Console.WriteLine("Exit.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Ban nhap sai roi moi nhap lai");

                        break;
                }
            }
        }
    }
}
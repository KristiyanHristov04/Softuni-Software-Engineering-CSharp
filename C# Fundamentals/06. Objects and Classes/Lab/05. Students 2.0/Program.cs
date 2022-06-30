using System;
using System.Collections.Generic;

namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                bool isExisting = false;
                if (input == "end")
                {
                    break;
                }
                string[] commands = input.Split(' ');

                Student student = new Student();
                student.FirstName = commands[0];
                student.LastName = commands[1];
                student.Age = Convert.ToInt32(commands[2]);
                student.HomeTown = commands[3];
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].FirstName == student.FirstName && students[i].LastName == student.LastName)
                    {
                        students[i].Age = student.Age;
                        students[i].HomeTown = student.HomeTown;
                        isExisting = true;
                        break;
                    }
                }
                if (isExisting)
                {
                    continue;
                }                
                students.Add(student);

            }
            string city = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }
}

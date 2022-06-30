using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                double grade = Convert.ToDouble(input[2]);

                Student currentStudent = new Student(firstName, lastName, grade);
                students.Add(currentStudent);   
            }

            List<Student> orderedStudents = students.OrderByDescending(student => student.Grade).ToList();
            foreach (var student in orderedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
}

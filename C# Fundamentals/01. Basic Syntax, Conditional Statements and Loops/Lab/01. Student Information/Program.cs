using System;

namespace _01._Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //01. Student Information
            string studentName = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            double grade = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {grade:f2}");
        }
    }
}

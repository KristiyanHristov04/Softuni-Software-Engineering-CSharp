using System;

namespace _02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = Convert.ToDouble(Console.ReadLine());
            Grade(grade);
        }
        static void Grade(double grade)
        {
            if (grade >= 2 && grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (grade >= 3 && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if(grade >= 3.50 && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if(grade >= 4.50 && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}

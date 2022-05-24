using System;

namespace SoftUniMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = Convert.ToDouble(Console.ReadLine());
            double b2 = Convert.ToDouble(Console.ReadLine());
            double h = Convert.ToDouble(Console.ReadLine());
            double formula = (b1 + b2) * h / 2;
            Console.WriteLine($"{formula:f2}");

        }
    }
}

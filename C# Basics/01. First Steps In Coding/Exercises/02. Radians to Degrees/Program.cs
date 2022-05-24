using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = Convert.ToDouble(Console.ReadLine());
            double degrees = radians * 180 / Math.PI;
            Console.WriteLine(degrees);
        }
    }
}
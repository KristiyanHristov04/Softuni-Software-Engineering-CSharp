using System;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double h = Convert.ToDouble(Console.ReadLine());
            double area = (a * h) / 2;
            Console.WriteLine($"{area:f2}");

        }
    }
}

using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            //°F = °C × 1,8 + 32
            double celsiums = Convert.ToDouble(Console.ReadLine());
            double farhenheit = celsiums * 1.8 + 32;
            Console.WriteLine($"{farhenheit:f2}");
        }
    }
}

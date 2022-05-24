using System;

namespace exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsium = Convert.ToDouble(Console.ReadLine());
            if (celsium >= 26 && celsium <= 35)
            {
                Console.WriteLine("Hot");
            }

            if (celsium >= 20.1 && celsium <= 25.9)
            {
                Console.WriteLine("Warm");
            }

            if (celsium >= 15 && celsium <= 20)
            {
                Console.WriteLine("Mild");
            }

            if (celsium >= 12 && celsium <= 14.9)
            {
                Console.WriteLine("Cool");
            }

            if (celsium >= 5 && celsium <= 11.9)
            {
                Console.WriteLine("Cold");
            }

            else if (celsium >= 35.01 || celsium <= 4.99)
            {
                Console.WriteLine("unknown");
            }
        }
    }
}


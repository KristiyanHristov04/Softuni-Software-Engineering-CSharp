using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarToGo03
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = (Console.ReadLine().ToLower());

            if (budget > 500)
            {
                Console.WriteLine("Luxury class");
                Console.WriteLine($"Jeep - {budget * 0.9:f2}");
            }
            else if (budget > 100 && budget <= 500)
            {
                Console.WriteLine("Compact class");
                if (season == "summer")
                {
                    Console.WriteLine($"Cabrio - {budget * 0.45:f2}");
                }
                else if (season == "winter")
                {
                    Console.WriteLine($"Jeep - {budget * 0.8:f2}");
                }
            }
            else if (budget <= 100)
            {
                Console.WriteLine("Economy class");
                if (season == "summer")
                {
                    Console.WriteLine($"Cabrio - {budget * 0.35:f2}");
                }
                else if (season == "winter")
                {
                    Console.WriteLine($"Jeep - {budget * 0.65:f2}");
                }
            }
        }
    }
}
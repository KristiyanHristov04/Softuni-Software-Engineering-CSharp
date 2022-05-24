using System;

namespace SoftUniExercises4
{
    class Program
    {
        static void Main(string[] args)
        {
            string project = Console.ReadLine();
            int rows = Convert.ToInt32(Console.ReadLine());
            int columns = Convert.ToInt32(Console.ReadLine());
            double premierePrice = 12.00;
            double NormalPrice = 7.50;
            double DiscountPrice = 5.00;
            double income = 0;
            if (project == "Premiere")
            {
                income = (rows * columns) * premierePrice;
                Console.WriteLine($"{income:f2}");
            }
            else if (project == "Normal")
            {
                income = (rows * columns) * NormalPrice;
                Console.WriteLine($"{income:f2}");
            }
            else if (project == "Discount")
            {
                income = (rows * columns) * DiscountPrice;
                Console.WriteLine($"{income:f2}");
            }
        }
    }
}

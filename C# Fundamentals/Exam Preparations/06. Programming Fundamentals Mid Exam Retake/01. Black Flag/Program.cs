using System;

namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = Convert.ToInt32(Console.ReadLine());
            int dailyPlunder = Convert.ToInt32(Console.ReadLine());
            double expectedPlunder = Convert.ToDouble(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    totalPlunder += (double)dailyPlunder / 2;
                }
                if (i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.30;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(totalPlunder / expectedPlunder) * 100:f2}% of the plunder.");
            }
        }
    }
}

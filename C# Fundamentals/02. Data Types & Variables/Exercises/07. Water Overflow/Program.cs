using System;

namespace Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int waterCapacity = 255;
            int totalPouredLiters = 0;
            for (int i = 1; i <= n; i++)
            {
                int pourWater = Convert.ToInt32(Console.ReadLine());
                if (pourWater + totalPouredLiters <= waterCapacity)
                {
                    totalPouredLiters += pourWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(totalPouredLiters);
        }
    }
}

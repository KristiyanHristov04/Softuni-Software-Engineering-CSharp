using System;

namespace Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string model = null;
            double radius = 0;
            int height = 0;

            double biggestKeg = 0;
            string biggestKegModel = null;
            double currentKeg = 0;
            for (int i = 1; i <= n; i++)
            {
                model = Console.ReadLine();
                radius = Convert.ToDouble(Console.ReadLine());
                height = Convert.ToInt32(Console.ReadLine());

                currentKeg = Math.PI * Math.Pow(radius, 2) * height;
                if (currentKeg > biggestKeg)
                {
                    biggestKeg = currentKeg;
                    biggestKegModel = model;
                }
            }
            Console.WriteLine(biggestKegModel);

        }
    }
}

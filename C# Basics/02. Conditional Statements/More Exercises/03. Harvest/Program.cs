using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int vineyardX = Convert.ToInt32(Console.ReadLine());
           
            double Y = Convert.ToDouble(Console.ReadLine());
            
            int Z = Convert.ToInt32(Console.ReadLine());
            
            int numberOfWorkers = Convert.ToInt32(Console.ReadLine());

            
            double grapes = vineyardX * Y;
            
            double totalWine = 0.40 * grapes / 2.5;
            
            double leftWine = totalWine - Z;
            
            double wineForWorkers = leftWine / numberOfWorkers;
            
            double neededWine = totalWine - Z;
            neededWine = Math.Abs(neededWine);

            if (totalWine >= Z)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(leftWine)} liters left -> {Math.Ceiling(wineForWorkers)} liters per person.");
            }
            else if (totalWine < Z)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededWine)} liters wine needed.");
            }
        }
    }
}

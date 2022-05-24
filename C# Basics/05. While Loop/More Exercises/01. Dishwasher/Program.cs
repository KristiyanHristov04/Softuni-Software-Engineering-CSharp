using System;

namespace SoftUniWhileLoopMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. DishWasher
            int bottlesOfPreparation = Convert.ToInt32(Console.ReadLine());
            int totalPreparationInMl = bottlesOfPreparation * 750;
            int daysCounter = 0;
            int cleanPlates = 0;
            int cleanPots = 0;
            while (totalPreparationInMl >= 0)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                daysCounter++;
                if (daysCounter % 3 == 0)
                {
                    totalPreparationInMl -= Convert.ToInt32(input) * 15;
                    cleanPots += Convert.ToInt32(input);
                }
                else if(daysCounter % 3 != 0)
                {
                    totalPreparationInMl -= Convert.ToInt32(input) * 5;
                    cleanPlates += Convert.ToInt32(input);
                }
                
                if (totalPreparationInMl < 0)
                {
                    break;
                }
            }
            if (totalPreparationInMl >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{cleanPlates} dishes and {cleanPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalPreparationInMl} ml.");
            }
            else if(totalPreparationInMl < 0)
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalPreparationInMl)} ml. more necessary!");
            }
            
        }
    }
}

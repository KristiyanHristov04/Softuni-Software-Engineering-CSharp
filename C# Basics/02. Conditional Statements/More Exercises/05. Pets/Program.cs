using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysAway = Convert.ToInt32(Console.ReadLine());
            int leftFoodInKilograms = Convert.ToInt32(Console.ReadLine());
            double requiredFoodForDogInKilograms = Convert.ToDouble(Console.ReadLine());
            double requiredFoodForCatInKilograms = Convert.ToDouble(Console.ReadLine());
            double requiredFoodForTurtleInGrams = Convert.ToDouble(Console.ReadLine());

            double dogNeededFood = daysAway * requiredFoodForDogInKilograms;
            
            double catNeededFood = daysAway * requiredFoodForCatInKilograms;
            
            double turtleNeededFood = daysAway * requiredFoodForTurtleInGrams;
            double turtleNeededFoodInKilograms = turtleNeededFood / 1000;
            
            double totalNeededFood = dogNeededFood + catNeededFood + turtleNeededFoodInKilograms;
            double leftFood = leftFoodInKilograms - totalNeededFood;
            if (totalNeededFood <= leftFoodInKilograms)
            {
                Console.WriteLine($"{Math.Floor(leftFood)} kilos of food left.");
            }
            else if (totalNeededFood > leftFoodInKilograms)
            {

                leftFood = Math.Abs(leftFood);
                Console.WriteLine($"{Math.Ceiling(leftFood)} more kilos of food are needed.");
            }

        }
    }
}


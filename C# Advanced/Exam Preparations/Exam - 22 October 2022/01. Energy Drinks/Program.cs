using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int MaxAvailableCaffeinePerNight = 300;
            int consumedCaffeine = 0;

            while (caffeine.Count > 0 && energyDrinks.Count > 0)
            {
                int currentCaffeine = caffeine.Peek();
                int currentEnergy = energyDrinks.Peek();
                int sum = currentCaffeine * currentEnergy;

                if (sum <= MaxAvailableCaffeinePerNight)
                {
                    consumedCaffeine += sum;
                    MaxAvailableCaffeinePerNight -= sum;
                    caffeine.Pop();
                    energyDrinks.Dequeue();
                }
                else if (sum > MaxAvailableCaffeinePerNight)
                {
                    caffeine.Pop();
                    energyDrinks.Dequeue();
                    energyDrinks.Enqueue(currentEnergy);
                    consumedCaffeine -= 30;
                    if (consumedCaffeine < 0)
                    {
                        consumedCaffeine = 0;
                    }
                    MaxAvailableCaffeinePerNight += 30;
                    if (MaxAvailableCaffeinePerNight > 300)
                    {
                        MaxAvailableCaffeinePerNight = 300;
                    }
                }
            }
            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: " + String.Join(", ", energyDrinks));
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {consumedCaffeine} mg caffeine.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waters = new Queue<double>(Console.ReadLine().Split(' ').Select(double.Parse));
            Stack<double> flours = new Stack<double>(Console.ReadLine().Split(' ').Select(double.Parse));
            Dictionary<string, int> madeProducts = new Dictionary<string, int>()
            {
                ["Croissant"] = 0,
                ["Muffin"] = 0,
                ["Baguette"] = 0,
                ["Bagel"] = 0
            };

            while (waters.Count > 0 && flours.Count > 0)
            {
                double currentWater = waters.Peek();
                double currentFlour = flours.Peek();

                double waterPercentage = currentWater + currentFlour;
                waterPercentage = (currentWater * 100) / waterPercentage;

                double flourPercentage = currentWater + currentFlour;
                flourPercentage = (currentFlour * 100) / flourPercentage;

                if (waterPercentage == 50 && flourPercentage == 50)
                {
                    madeProducts["Croissant"]++;
                    flours.Pop();
                    waters.Dequeue();
                }
                else if (waterPercentage == 40 && flourPercentage == 60)
                {
                    madeProducts["Muffin"]++;
                    flours.Pop();
                    waters.Dequeue();
                }
                else if (waterPercentage == 30 && flourPercentage == 70)
                {
                    madeProducts["Baguette"]++;
                    flours.Pop();
                    waters.Dequeue();
                }
                else if (waterPercentage == 20 && flourPercentage == 80)
                {
                    madeProducts["Bagel"]++;
                    flours.Pop();
                    waters.Dequeue();
                }
                else
                {
                    madeProducts["Croissant"]++;
                    currentFlour -= currentWater;
                    waters.Dequeue();
                    flours.Pop();
                    flours.Push(currentFlour);
                }
            }
            foreach (var product in madeProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (waters.Count > 0)
            {
                Console.WriteLine("Water left: " + String.Join(", ", waters));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flours.Count > 0)
            {
                Console.WriteLine("Flour left: " + String.Join(", ", flours));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}

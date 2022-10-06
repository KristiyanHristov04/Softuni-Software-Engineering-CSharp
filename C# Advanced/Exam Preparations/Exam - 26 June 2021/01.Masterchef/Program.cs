using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> preparedDishes = new Dictionary<string, int>()
            {
                ["Dipping sauce"] = 0,
                ["Green salad"] = 0,
                ["Chocolate cake"] = 0,
                ["Lobster"] = 0,
            };
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                while (ingredients.Count > 0 && ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                if (ingredients.Count == 0 || freshnessLevels.Count == 0)
                {
                    break;
                }

                int currentIngredient = ingredients.Peek();
                int currentFreshnessLevel = freshnessLevels.Peek();
                int totalFreshnessLevel = currentIngredient * currentFreshnessLevel;
                string dish = string.Empty;
                switch (totalFreshnessLevel)
                {
                    case 150:
                        dish = "Dipping sauce";
                        preparedDishes["Dipping sauce"]++;
                        ingredients.Dequeue();
                        freshnessLevels.Pop();
                        break;
                    case 250:
                        dish = "Green salad";
                        preparedDishes["Green salad"]++;
                        ingredients.Dequeue();
                        freshnessLevels.Pop();
                        break;
                    case 300:
                        dish = "Chocolate cake";
                        preparedDishes["Chocolate cake"]++;
                        ingredients.Dequeue();
                        freshnessLevels.Pop();
                        break;
                    case 400:
                        dish = "Lobster";
                        preparedDishes["Lobster"]++;
                        ingredients.Dequeue();
                        freshnessLevels.Pop();
                        break;
                    default:
                        freshnessLevels.Pop();
                        ingredients.Dequeue();
                        ingredients.Enqueue(currentIngredient + 5);
                        break;
                }
            }
            bool isTaskSuccessfull = true;
            foreach (var dish in preparedDishes)
            {
                if (dish.Value < 1)
                {
                    isTaskSuccessfull = false;
                    break;
                }
            }
            if (isTaskSuccessfull)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                int ingredientsSum = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {ingredientsSum}");
            }
            foreach (var dish in preparedDishes.Where(dish => dish.Value > 0).OrderBy(dish => dish.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> cookedDishes = new SortedDictionary<string, int>()
            {
                ["Bread"] = 0,
                ["Cake"] = 0,
                ["Pastry"] = 0,
                ["Fruit Pie"] = 0
            };
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();
                int sum = currentLiquid + currentIngredient;

                switch (sum)
                {
                    case 25:
                        cookedDishes["Bread"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        cookedDishes["Cake"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        cookedDishes["Pastry"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        cookedDishes["Fruit Pie"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        ingredients.Pop();
                        ingredients.Push(currentIngredient + 3);
                        break;
                }
            }
            bool isSucceededCookingEverything = true;
            foreach (var dish in cookedDishes)
            {
                if (dish.Value == 0)
                {
                    isSucceededCookingEverything = false;
                    break;
                }
            }

            if (isSucceededCookingEverything)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine("Liquids left: " + String.Join(", ", liquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine("Ingredients left: " + String.Join(", ", ingredients));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var dish in cookedDishes)
            {
                Console.WriteLine($"{dish.Key}: {dish.Value}");
            }
        }
    }
}

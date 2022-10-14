using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> preparedDrinks = new Dictionary<string, int>()
            {
                ["Cortado"] = 0,
                ["Espresso"] = 0,
                ["Capuccino"] = 0,
                ["Americano"] = 0,
                ["Latte"] = 0
            };
            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentCoffeeQuantity = coffee.Peek();
                int currentMilkQuantity = milk.Peek();
                int sum = currentCoffeeQuantity + currentMilkQuantity;

                switch (sum)
                {
                    case 50:
                        preparedDrinks["Cortado"]++;
                        milk.Pop();
                        coffee.Dequeue();
                        break;
                    case 75:
                        preparedDrinks["Espresso"]++;
                        milk.Pop();
                        coffee.Dequeue();
                        break;
                    case 100:
                        preparedDrinks["Capuccino"]++;
                        milk.Pop();
                        coffee.Dequeue();
                        break;
                    case 150:
                        preparedDrinks["Americano"]++;
                        milk.Pop();
                        coffee.Dequeue();
                        break;
                    case 200:
                        preparedDrinks["Latte"]++;
                        milk.Pop();
                        coffee.Dequeue();
                        break;
                    default:
                        coffee.Dequeue();
                        milk.Pop();
                        milk.Push(currentMilkQuantity - 5);
                        break;
                }
            }
            if (milk.Count == 0 && coffee.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count > 0)
            {
                Console.WriteLine("Coffee left: " + String.Join(", ", coffee));
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milk.Count > 0)
            {
                Console.WriteLine("Milk left: " + String.Join(", ", milk));
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in preparedDrinks.OrderBy(drink => drink.Value).ThenByDescending(drink => drink.Key))
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }
        }
    }
}

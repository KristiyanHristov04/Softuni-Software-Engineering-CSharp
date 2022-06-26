using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Coffee_Lover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Include":
                        string coffee = commands[1];
                        coffees.Add(coffee);
                        break;
                    case "Remove":
                        int numberOfCoffees = Convert.ToInt32(commands[2]);
                        numberOfCoffees -= 1;
                        int removedCoffees = 0;
                        if (numberOfCoffees > coffees.Count)
                        {
                            continue;
                        }

                        if (commands[1] == "first")
                        {
                            for (int j = 0; j < coffees.Count; j++)
                            {
                                if (removedCoffees <= numberOfCoffees)
                                {
                                    coffees.RemoveAt(0);
                                    removedCoffees++;
                                }
                            }
                        }
                        else if(commands[1] == "last")
                        {
                            for (int j = coffees.Count - 1; j >= 0; j--)
                            {
                                if (removedCoffees <= numberOfCoffees)
                                {
                                    coffees.RemoveAt(coffees.Count - 1);
                                    removedCoffees++;
                                }
                            }
                        }
                        break;
                    case "Prefer":
                        int coffeeIndex01 = Convert.ToInt32(commands[1]);
                        int coffeeIndex02 = Convert.ToInt32(commands[2]);
                        if (coffeeIndex01 < 0 || coffeeIndex01 > coffees.Count - 1 || coffeeIndex02 < 0 || coffeeIndex02 > coffees.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            string coffee01 = coffees[coffeeIndex01];
                            string coffee02 = coffees[coffeeIndex02];
                            coffees[coffeeIndex01] = coffee02;
                            coffees[coffeeIndex02] = coffee01;
                        }
                        break;
                    case "Reverse":
                        coffees.Reverse();
                        break;
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }
    }
}

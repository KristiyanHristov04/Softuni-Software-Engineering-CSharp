using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagoons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int maxCapacityPerWagoon = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split(' ');
                if (commands[0] == "Add")
                {
                    int passengers = Convert.ToInt32(commands[1]);
                    wagoons.Add(passengers);
                }
                else
                {
                    int passengers = Convert.ToInt32(commands[0]);
                    for (int i = 0; i < wagoons.Count; i++)
                    {
                        if (wagoons[i] + passengers <= maxCapacityPerWagoon)
                        {
                            wagoons[i] += passengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", wagoons));
        }
    }
}

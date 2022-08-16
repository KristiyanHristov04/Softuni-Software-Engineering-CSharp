using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "end")
                {
                    break;
                }
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                switch (mainCommand)
                {
                    case "add":
                        int num01 = Convert.ToInt32(commands[1]);
                        int num02 = Convert.ToInt32(commands[2]);
                        stack.Push(num01);
                        stack.Push(num02);
                        break;
                    case "remove":
                        int amountOfNumbers = Convert.ToInt32(commands[1]);
                        if (stack.Count >= amountOfNumbers)
                        {
                            for (int i = 0; i < amountOfNumbers; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

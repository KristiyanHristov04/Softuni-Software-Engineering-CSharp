using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, List<int>> addFunction = numbers => numbers.Select(numbers => numbers + 1).ToList();
            Func<List<int>, List<int>> multiplyFunction = numbers => numbers.Select(numbers => numbers * 2).ToList();
            Func<List<int>, List<int>> subtractFunction = numbers => numbers.Select(numbers => numbers - 1).ToList();
            Action<List<int>> printAction = numbers => Console.WriteLine(String.Join(" ", numbers));
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                switch (input)
                {
                    case "add":
                        numbers = addFunction(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyFunction(numbers);
                        break;
                    case "subtract":
                        numbers = subtractFunction(numbers);
                        break;
                    case "print":
                        printAction(numbers);
                        break;
                }
            }
        }
    }
}

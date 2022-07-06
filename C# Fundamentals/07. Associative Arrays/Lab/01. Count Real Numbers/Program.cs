using System;
using System.Linq;
using System.Collections.Generic;
namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SortedDictionary<int, int> result = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!result.ContainsKey(numbers[i]))
                {
                    result.Add(numbers[i], 1);
                }
                else
                {
                    result[numbers[i]]++;
                }
            }

            foreach (var number in result)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}

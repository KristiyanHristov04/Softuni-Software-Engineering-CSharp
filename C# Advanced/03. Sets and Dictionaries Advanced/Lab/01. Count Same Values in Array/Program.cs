using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersCount = new Dictionary<double, int>();
            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (numbersCount.ContainsKey(input[i]))
                {
                    numbersCount[input[i]]++;
                }
                else
                {
                    numbersCount.Add(input[i], 1);
                }
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}

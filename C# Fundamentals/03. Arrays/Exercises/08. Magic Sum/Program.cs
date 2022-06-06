using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> foundedPairs = new List<int>();
            int sum = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == sum)
                    {
                        foundedPairs.Add(array[i]);
                        foundedPairs.Add(array[j]);
                    }
                }
            }

            for (int i = 0; i < foundedPairs.Count; i++)
            {
                Console.WriteLine(foundedPairs[i] + " " + foundedPairs[i + 1]);
                i++;
            }

        }
    }
}

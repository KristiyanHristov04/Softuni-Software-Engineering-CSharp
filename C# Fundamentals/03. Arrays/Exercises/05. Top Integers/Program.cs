using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> topIntegers = new List<int>();
            bool isBiggest = true;
            for (int i = 0; i < array.Length; i++)
            {
                int currentBiggestNumber = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentBiggestNumber <= array[j])
                    {
                        isBiggest = false;
                        break;
                    }
                }
                if (isBiggest)
                {
                    topIntegers.Add(currentBiggestNumber);
                }
                isBiggest = true;
            }
            foreach (var topInteger in topIntegers)
            {
                Console.Write(topInteger + " ");
            }
        }
    }
}

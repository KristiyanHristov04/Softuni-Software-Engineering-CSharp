using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int minRange = input[0];
            int maxRange = input[1];
            string condition = Console.ReadLine();
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            List<int> result = new List<int>();
            if (condition == "even")
            {
                for (int i = minRange; i <= maxRange; i++)
                {
                    result.Add(i);
                }
                result = result.FindAll(isEven);
                Console.WriteLine(string.Join(" ", result));
            }
            else if (condition == "odd")
            {
                for (int i = minRange; i <= maxRange; i++)
                {
                    result.Add(i);
                }
                result = result.FindAll(isOdd);
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}

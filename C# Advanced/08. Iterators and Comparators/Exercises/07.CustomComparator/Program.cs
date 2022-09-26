using System;
using System.Linq;

namespace _07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(array);
            var sortedArray = array.OrderBy(number => number % 2 != 0).ThenBy(number => number % 2 == 0);
            Console.WriteLine(String.Join(" ", sortedArray));
        }
    }
}

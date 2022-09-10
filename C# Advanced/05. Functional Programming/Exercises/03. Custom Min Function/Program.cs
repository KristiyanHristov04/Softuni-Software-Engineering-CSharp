using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> smallestNumber = numbers => numbers.Min();
            Console.WriteLine(smallestNumber(numbers));
        }
    }
}

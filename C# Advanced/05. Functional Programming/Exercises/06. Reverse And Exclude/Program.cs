using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = Convert.ToInt32(Console.ReadLine());
            Func<int[], int[]> reverseCollection = numbers => numbers.Reverse().ToArray();
            Predicate<int> isNotDivisible = number => number % n != 0;

            numbers = reverseCollection(numbers);
            Console.WriteLine(String.Join(" ", numbers.Where(x => isNotDivisible(x))));
        }
    }
}

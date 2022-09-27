using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Sum(array, 0));
        }
        public static int Sum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                //Bottom of the recursion.
                return array[index];
            }
            return array[index] + Sum(array, index + 1);
        }
    }
}

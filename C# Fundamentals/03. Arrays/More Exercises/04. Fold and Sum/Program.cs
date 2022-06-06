using System;
using System.Linq;

namespace _4.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = inputArr.Length / 4;
            int[] newArr = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                newArr[i] = inputArr[k - (i + 1)] + inputArr[k + i];
                newArr[newArr.Length - 1 - i] = inputArr[newArr.Length - 1 - i + k] + inputArr[(newArr.Length - 1 - i) + (k + 2 * i + 1)];
            }
            Console.WriteLine(string.Join(" ", newArr));
        }
    }
}
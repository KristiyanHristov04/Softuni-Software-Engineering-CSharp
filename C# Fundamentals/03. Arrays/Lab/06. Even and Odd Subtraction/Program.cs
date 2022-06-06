using System;
using System.Linq;
namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenSum += array[i];
                }
                else
                {
                    oddSum += array[i];
                }
            }
            int result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}

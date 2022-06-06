using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                numbers[i] = number;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

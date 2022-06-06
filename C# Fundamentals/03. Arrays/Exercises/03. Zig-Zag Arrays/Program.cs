using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array01 = new int[n];
            int[] array02 = new int[n];
            int index = 0;               
            bool evenTime = false;

            for (int i = 1; i <= n; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (!evenTime)
                {
                    array01[index] = numbers[0];
                    array02[index] = numbers[1];
                    index++;
                    evenTime = true;
                }
                else if(evenTime)
                {
                    array01[index] = numbers[1];
                    array02[index] = numbers[0];
                    index++;
                    evenTime = false;
                }
            }
            foreach (var number in array01)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            foreach (var number in array02)
            {
                Console.Write(number + " ");
            }
        }
    }
}

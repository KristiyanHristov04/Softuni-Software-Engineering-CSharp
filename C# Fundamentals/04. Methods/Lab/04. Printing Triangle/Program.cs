using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintTriangle(1, i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintTriangle(1, i);
            }
        }
        static void PrintTriangle(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
        }
    }
}
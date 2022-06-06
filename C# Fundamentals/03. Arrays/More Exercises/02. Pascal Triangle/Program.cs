using System;

namespace PascalTriangle
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var pascalTriangle = new long[lines][];

            for (var row = 0; row < lines; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;  // first element is 1
                pascalTriangle[row][^1] = 1; // last element is 1

                for (var col = 1; col < row; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }

            for (var row = 0; row < lines; row++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[row]));
            }
        }
    }
}

using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixElements[col];
                }
            }

            int biggestSum = int.MinValue;
            int sum = 0;

            int row01 = 0;
            int col01 = 0;
            int row02 = 0;
            int col02 = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 1 < rows && col + 1 < cols)
                    {
                        sum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        if (sum > biggestSum)
                        {
                            biggestSum = sum;
                            row01 = row;
                            row02 = row + 1;
                            col01 = col;
                            col02 = col + 1;  
                        }
                        sum = 0;
                    }
                }
            }
            Console.WriteLine($"{matrix[row01, col01]} {matrix[row01, col02]}");
            Console.WriteLine($"{matrix[row02, col01]} {matrix[row02, col02]}");
            Console.WriteLine(matrix[row01, col01] + matrix[row01, col02] + matrix[row02, col01] + matrix[row02, col02]);
        }
    }
}

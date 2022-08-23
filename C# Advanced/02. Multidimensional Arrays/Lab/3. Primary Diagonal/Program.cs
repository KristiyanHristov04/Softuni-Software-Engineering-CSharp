using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            int rows = matrixSize;
            int cols = matrixSize;
            int[,] matrix = new int[rows, cols];
            int sum = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];     
                }
            }

            int columnIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = columnIndex; col < matrix.GetLength(1);)
                {
                    sum += matrix[row, col];
                    columnIndex++;
                    break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}

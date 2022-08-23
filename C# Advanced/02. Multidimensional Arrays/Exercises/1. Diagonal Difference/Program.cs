using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = ReadMatrix(matrixSize);

            int primaryDiagonalSum = 0;     
            int primaryRowIndex = 0;
            //Primary Diagonal
            for (int col = 0; col < matrix.GetLength(1); col++)
            { 
                for (int row = primaryRowIndex; row < matrix.GetLength(0);)
                {
                    primaryDiagonalSum += matrix[row, col];
                    primaryRowIndex++;
                    break;
                }
            }

            int secondaryDiagonalSum = 0;
            int secondaryRowIndex = 0;
            //Secondary Diagonal
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = secondaryRowIndex; row >= 0;)
                {
                    secondaryDiagonalSum += matrix[row, col];
                    secondaryRowIndex++;
                    break;
                }
            }

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);
        }

        static int[,] ReadMatrix(int size)
        {
            int[,] matrix = new int[size,size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            return matrix;
        }
    }
}

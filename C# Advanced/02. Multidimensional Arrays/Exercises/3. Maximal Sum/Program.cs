using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsSize = matrixSize[0];
            int colsSize = matrixSize[1];
            int[,] matrix = new int[rowsSize, colsSize];

            for (int row = 0; row < rowsSize; row++)
            {
                int[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < colsSize; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }


            int[,] sumMatrix = new int[3, 3];
            int currentBiggestSum = int.MinValue;

            int currentSum = 0;
            for (int row = 0; row < rowsSize; row++)
            {            
                if (row + 2 == rowsSize)
                {
                    break;
                }
                for (int col = 0; col < colsSize; col++)
                {
                    if (col + 2 == colsSize)
                    {
                        break;
                    }
                    else
                    {
                        currentSum += matrix[row, col] + matrix[row, col + 1] + 
                            matrix[row, col + 2] + matrix[row + 1, col] + 
                            matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                            matrix[row + 2, col] + matrix[row + 2, col + 1] +
                            matrix[row + 2, col + 2];
                        if (currentSum > currentBiggestSum)
                        {
                            currentBiggestSum = currentSum;
                            sumMatrix[0, 0] = matrix[row, col];
                            sumMatrix[0, 1] = matrix[row, col + 1];
                            sumMatrix[0, 2] = matrix[row, col + 2];

                            sumMatrix[1, 0] = matrix[row + 1, col];
                            sumMatrix[1, 1] = matrix[row + 1, col + 1];
                            sumMatrix[1, 2] = matrix[row + 1, col + 2];

                            sumMatrix[2, 0] = matrix[row + 2, col];
                            sumMatrix[2, 1] = matrix[row + 2, col + 1];
                            sumMatrix[2, 2] = matrix[row + 2, col + 2];
                        }
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine("Sum = " + currentBiggestSum);
            for (int row = 0; row < sumMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sumMatrix.GetLength(1); col++)
                {
                    Console.Write(sumMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

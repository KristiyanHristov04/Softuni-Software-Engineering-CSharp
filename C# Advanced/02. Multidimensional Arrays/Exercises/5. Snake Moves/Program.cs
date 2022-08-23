using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int matrixRowSize = matrixSize[0];
            int matrixColSize = matrixSize[1];
            string snakeSymbols = Console.ReadLine();
            char[,] matrix = new char[matrixRowSize, matrixColSize];

            bool rightToLeft = true;
            int indexOfSymbol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (rightToLeft)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeSymbols[indexOfSymbol];
                        indexOfSymbol++;
                        if (indexOfSymbol == snakeSymbols.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }
                    rightToLeft = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeSymbols[indexOfSymbol];
                        indexOfSymbol++;
                        if (indexOfSymbol == snakeSymbols.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }
                    rightToLeft = true;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
            
        }

    }
}

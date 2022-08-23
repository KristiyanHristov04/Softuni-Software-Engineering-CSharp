using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = MatrixElements(matrixSize);

            int knightsRemoved = 0;
            //TODO:

            while (true)
            {
                int maxAttacks = 0;
                int knightToRemoveRow = 0;
                int knightToRemoveCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }

                        int currentAttacks = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (row - 2 >= 0 && row - 2 < matrixSize && col - 1 >= 0 && col - 1 < matrixSize)
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < matrixSize && col + 1 >= 0 && col + 1 < matrixSize)
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < matrixSize && col - 2 >= 0 && col - 2 < matrixSize)
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < matrixSize && col + 2 >= 0 && col + 2 < matrixSize)
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < matrixSize && col - 2 >= 0 && col - 2 < matrixSize)
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < matrixSize && col + 2 >= 0 && col + 2 < matrixSize)
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < matrixSize && col - 1 >= 0 && col - 1 < matrixSize)
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < matrixSize && col + 1 >= 0 && col + 1 < matrixSize)
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currentAttacks++;
                                }
                            }

                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                knightToRemoveRow = row;
                                knightToRemoveCol = col;
                            }
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    knightsRemoved++;
                    matrix[knightToRemoveRow, knightToRemoveCol] = '0';
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    return;
                }
            }
        }
        static char[,] MatrixElements(int matrixSize)
        {
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string elements = Console.ReadLine();
                char[] chars = elements.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            return matrix;
        }
    }
}

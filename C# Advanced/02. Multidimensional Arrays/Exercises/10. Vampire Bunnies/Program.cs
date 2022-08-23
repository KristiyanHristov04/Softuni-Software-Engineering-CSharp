using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        private static char[,] matrix;
        private static bool isWon;
        private static bool isDead;
        private static int startRow;
        private static int startCol;
        private static List<int[]> bunnies = new List<int[]>();

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Queue<char> directions = new Queue<char>(Console.ReadLine().ToCharArray());


            while (directions.Count > 0)
            {
                char currentDirection = directions.Dequeue();

                if (currentDirection == 'L')
                {
                    MovePlayer(0, -1);
                }
                else if (currentDirection == 'R')
                {
                    MovePlayer(0, 1);
                }
                else if (currentDirection == 'U')
                {
                    MovePlayer(-1, 0);
                }
                else if (currentDirection == 'D')
                {
                    MovePlayer(+1, 0);
                }

                FindBunnies();

                GrowBunnies();

                if (isWon || isDead)
                {
                    break;
                }
            }

            Print();

            if (isWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
        }

        private static void FindBunnies()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        int[] currentBunny = { row, col };
                        if (!bunnies.Contains(currentBunny))
                        {
                            bunnies.Add(currentBunny);
                        }
                    }
                }
            }
        }

        private static void Print()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void GrowBunnies()
        {
            for (int i = 0; i < bunnies.Count; i++)
            {
                int[] currentBunny = bunnies[i];
                int row = currentBunny[0];
                int col = currentBunny[1];

                Grow(row + 1, col);
                Grow(row - 1, col);
                Grow(row, col + 1);
                Grow(row, col - 1);
            }

        }

        private static void Grow(int row, int col)
        {
            if (row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1))
            {
                if (matrix[row, col] == '.')
                {
                    matrix[row, col] = 'B';
                }
                else if (matrix[row, col] == 'P')
                {
                    matrix[row, col] = 'B';
                    isDead = true;
                }
            }
        }

        private static void MovePlayer(int rowUpdate, int colUpdate)
        {
            int oldRow = startRow;
            int oldCol = startCol;
            startRow += rowUpdate;
            startCol += colUpdate;

            if (IsOutOfRange(startRow, startCol))
            {
                matrix[oldRow, oldCol] = '.';
                startRow = oldRow;
                startCol = oldCol;
                isWon = true;
            }
            else if (IsFreeCell(startRow, startCol))
            {
                matrix[oldRow, oldCol] = '.';
                matrix[startRow, startCol] = 'P';
            }
            else if (IsBunny(startRow, startCol))
            {
                matrix[oldRow, oldCol] = '.';
                isDead = true;
            }
        }

        private static bool IsBunny(int row, int col)
        {
            if (row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1)
                && matrix[row, col] == 'B')
            {
                return true;
            }

            return false;
        }

        private static bool IsFreeCell(int row, int col)
        {
            if (row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1)
                && matrix[row, col] == '.')
            {
                return true;
            }

            return false;
        }

        private static bool IsOutOfRange(int row, int col)
        {
            if (row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}

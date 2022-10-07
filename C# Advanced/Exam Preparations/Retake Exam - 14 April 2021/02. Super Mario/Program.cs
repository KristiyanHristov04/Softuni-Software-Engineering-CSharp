using System;
using System.ComponentModel;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());
            if (numberOfRows == 0)
            {
                return;
            }
            char[][] rectangularMatrix = new char[numberOfRows][];
            int marioInitialRow = -1;
            int marioInitialCol = -1;

            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                rectangularMatrix[rowIndex] = Console.ReadLine()?.ToCharArray();

                for (int colIndex = 0; colIndex < rectangularMatrix[rowIndex].Length; colIndex++)
                {
                    if (rectangularMatrix[rowIndex][colIndex] == 'M')
                    {
                        marioInitialRow = rowIndex;
                        marioInitialCol = colIndex;
                    }
                }
            }

            bool isFoundThePrincess = false;
            bool isMarioDied = false;

            MarioLives(ref marioLives, rectangularMatrix, ref isMarioDied, ref isFoundThePrincess, ref marioInitialRow, ref marioInitialCol);

            if (isMarioDied)
            {
                Console.WriteLine($"Mario died at {marioInitialRow};{marioInitialCol}.");
            }
            else if (isFoundThePrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }

            PrintMatrix(rectangularMatrix);
        }

        public static void MarioLives(ref int marioLives, char[][] rectangularMatrix, ref bool isMarioDied,
            ref bool isFoundThePrincess, ref int marioInitialRow, ref int marioInitialCol)
        {
            while (marioLives > 0)
            {
                if (isMarioDied || isFoundThePrincess)
                {
                    break;
                }

                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0].ToLower();
                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);
                rectangularMatrix[enemyRow][enemyCol] = 'B';
                marioLives -= 1;
                switch (direction)
                {
                    case "w":
                        if (IsValidIndexes(rectangularMatrix, marioInitialRow - 1, marioInitialCol))
                        {
                            rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                            marioInitialRow -= 1;

                            if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'B')
                            {
                                marioLives -= 2;
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                            else if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'P')
                            {
                                if (marioLives > 0)
                                {
                                    isFoundThePrincess = true;
                                    rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                                }
                                else
                                {
                                    isMarioDied = true;
                                }
                            }
                            else
                            {
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                        }

                        if (marioLives <= 0)
                        {
                            isMarioDied = true;
                            rectangularMatrix[marioInitialRow][marioInitialCol] = 'X';
                        }

                        break;
                    case "s":
                        if (IsValidIndexes(rectangularMatrix, marioInitialRow + 1, marioInitialCol))
                        {
                            rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                            marioInitialRow += 1;

                            if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'B')
                            {
                                marioLives -= 2;
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                            else if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'P')
                            {
                                if (marioLives > 0)
                                {
                                    isFoundThePrincess = true;
                                    rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                                }
                                else
                                {
                                    isMarioDied = true;
                                }
                            }
                            else
                            {
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                        }

                        if (marioLives <= 0)
                        {
                            isMarioDied = true;
                            rectangularMatrix[marioInitialRow][marioInitialCol] = 'X';
                        }

                        break;
                    case "a":
                        if (IsValidIndexes(rectangularMatrix, marioInitialRow, marioInitialCol - 1))
                        {
                            rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                            marioInitialCol -= 1;

                            if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'B')
                            {
                                marioLives -= 2;
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                            else if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'P')
                            {
                                if (marioLives > 0)
                                {
                                    isFoundThePrincess = true;
                                    rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                                }
                                else
                                {
                                    isMarioDied = true;
                                }
                            }
                            else
                            {
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                        }

                        if (marioLives <= 0)
                        {
                            isMarioDied = true;
                            rectangularMatrix[marioInitialRow][marioInitialCol] = 'X';
                        }

                        break;
                    case "d":
                        if (IsValidIndexes(rectangularMatrix, marioInitialRow, marioInitialCol + 1))
                        {
                            rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                            marioInitialCol += 1;

                            if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'B')
                            {
                                marioLives -= 2;
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                            else if (rectangularMatrix[marioInitialRow][marioInitialCol] == 'P')
                            {
                                if (marioLives > 0)
                                {
                                    isFoundThePrincess = true;
                                    rectangularMatrix[marioInitialRow][marioInitialCol] = '-';
                                }
                                else
                                {
                                    isMarioDied = true;
                                }
                            }
                            else
                            {
                                rectangularMatrix[marioInitialRow][marioInitialCol] = 'M';
                            }
                        }

                        if (marioLives <= 0)
                        {
                            isMarioDied = true;
                            rectangularMatrix[marioInitialRow][marioInitialCol] = 'X';
                        }

                        break;
                }
            }
        }

        public static bool IsValidIndexes(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 &&
                   col < matrix[row].Length;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    Console.Write(matrix[rowIndex][colIndex] + "");
                }

                Console.WriteLine();
            }
        }
    }
}
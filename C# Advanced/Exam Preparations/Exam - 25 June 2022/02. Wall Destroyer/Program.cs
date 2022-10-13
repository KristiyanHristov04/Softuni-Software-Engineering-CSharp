using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = CreateMatrix(matrixSize);
            VankoPosition vankoPosition = FindVankoStartingPosition(matrix);
            bool isFirstMove = true;
            int madeHoles = 0;
            int countOfHitRods = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                switch (input)
                {
                    case "up":
                        if (IsInBounds(vankoPosition.Row - 1, vankoPosition.Col, matrixSize))
                        {
                            if (matrix[vankoPosition.Row - 1, vankoPosition.Col] == '-')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                matrix[vankoPosition.Row - 1, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Row--;
                            }
                            else if (matrix[vankoPosition.Row - 1, vankoPosition.Col] == '*')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                vankoPosition.Row--;
                                Console.WriteLine($"The wall is already destroyed at position [{vankoPosition.Row}, {vankoPosition.Col}]!");
                            }
                            else if (matrix[vankoPosition.Row - 1, vankoPosition.Col] == 'C')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Row--;
                                matrix[vankoPosition.Row, vankoPosition.Col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {madeHoles} hole(s).");
                                PrintMatrix(matrix);
                                return;
                            }
                            else if (matrix[vankoPosition.Row - 1, vankoPosition.Col] == 'R')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                Console.WriteLine("Vanko hit a rod!");
                                countOfHitRods++;
                            }
                        }
                        break;
                    case "down":
                        if (IsInBounds(vankoPosition.Row + 1, vankoPosition.Col, matrixSize))
                        {
                            if (matrix[vankoPosition.Row + 1, vankoPosition.Col] == '-')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                matrix[vankoPosition.Row + 1, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Row++;
                            }
                            else if (matrix[vankoPosition.Row + 1, vankoPosition.Col] == '*')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                vankoPosition.Row++;
                                Console.WriteLine($"The wall is already destroyed at position [{vankoPosition.Row}, {vankoPosition.Col}]!");
                            }
                            else if (matrix[vankoPosition.Row + 1, vankoPosition.Col] == 'C')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Row++;
                                matrix[vankoPosition.Row, vankoPosition.Col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {madeHoles} hole(s).");
                                PrintMatrix(matrix);
                                return;
                            }
                            else if (matrix[vankoPosition.Row + 1, vankoPosition.Col] == 'R')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                Console.WriteLine("Vanko hit a rod!");
                                countOfHitRods++;
                            }
                        }
                        break;
                    case "left":
                        if (IsInBounds(vankoPosition.Row, vankoPosition.Col - 1, matrixSize))
                        {
                            if (matrix[vankoPosition.Row, vankoPosition.Col - 1] == '-')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                matrix[vankoPosition.Row, vankoPosition.Col - 1] = '*';
                                madeHoles++;
                                vankoPosition.Col--;
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col - 1] == '*')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                vankoPosition.Col--;
                                Console.WriteLine($"The wall is already destroyed at position [{vankoPosition.Row}, {vankoPosition.Col}]!");
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col - 1] == 'C')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Col--;
                                matrix[vankoPosition.Row, vankoPosition.Col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {madeHoles} hole(s).");
                                PrintMatrix(matrix);
                                return;
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col - 1] == 'R')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                Console.WriteLine("Vanko hit a rod!");
                                countOfHitRods++;
                            }
                        }
                        break;
                    case "right":
                        if (IsInBounds(vankoPosition.Row, vankoPosition.Col + 1, matrixSize))
                        {
                            if (matrix[vankoPosition.Row, vankoPosition.Col + 1] == '-')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                matrix[vankoPosition.Row, vankoPosition.Col + 1] = '*';
                                madeHoles++;
                                vankoPosition.Col++;
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col + 1] == '*')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                vankoPosition.Col++;
                                Console.WriteLine($"The wall is already destroyed at position [{vankoPosition.Row}, {vankoPosition.Col}]!");
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col + 1] == 'C')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                matrix[vankoPosition.Row, vankoPosition.Col] = '*';
                                madeHoles++;
                                vankoPosition.Col++;
                                matrix[vankoPosition.Row, vankoPosition.Col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {madeHoles} hole(s).");
                                PrintMatrix(matrix);
                                return;
                            }
                            else if (matrix[vankoPosition.Row, vankoPosition.Col + 1] == 'R')
                            {
                                if (isFirstMove)
                                {
                                    isFirstMove = false;
                                    madeHoles++;
                                }
                                Console.WriteLine("Vanko hit a rod!");
                                countOfHitRods++;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Vanko managed to make {madeHoles} hole(s) and he hit only {countOfHitRods} rod(s).");
            matrix[vankoPosition.Row, vankoPosition.Col] = 'V';
            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        static VankoPosition FindVankoStartingPosition(char[,] matrix)
        {
            VankoPosition vankoPosition = new VankoPosition();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        vankoPosition.Row = row;
                        vankoPosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return vankoPosition;
        }
        static bool IsInBounds(int row, int col, int matrixSize)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
        static char[,] CreateMatrix(int sizeOfMatrix)
        {
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
    class VankoPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
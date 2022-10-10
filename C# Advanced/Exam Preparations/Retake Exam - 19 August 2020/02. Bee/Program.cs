using System;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = CreateMatrix(matrixSize);
            BeePosition beePosition = FindBeeStartingPosition(matrix);
            int totalPolinatedFlowers = 0;
            bool doesProgramShouldEnd = false;

            while (!doesProgramShouldEnd)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (IsInBounds(beePosition.Row - 1, beePosition.Col, matrixSize))
                        {
                            if (matrix[beePosition.Row - 1, beePosition.Col] == 'f')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row - 1, beePosition.Col] = 'B';
                                totalPolinatedFlowers++;
                                beePosition.Row--;
                            }
                            else if (matrix[beePosition.Row - 1, beePosition.Col] == 'O')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row - 1, beePosition.Col] = '.';
                                beePosition.Row-=2;
                                if (matrix[beePosition.Row, beePosition.Col] == 'f')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                    totalPolinatedFlowers++;
                                }
                                else if (matrix[beePosition.Row, beePosition.Col] == '.')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                }
                            }
                            else if (matrix[beePosition.Row - 1, beePosition.Col] == '.')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row - 1, beePosition.Col] = 'B';
                                beePosition.Row--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            matrix[beePosition.Row, beePosition.Col] = '.';
                            doesProgramShouldEnd = true;
                        }
                        break;
                    case "down":
                        if (IsInBounds(beePosition.Row + 1, beePosition.Col, matrixSize))
                        {
                            if (matrix[beePosition.Row + 1, beePosition.Col] == 'f')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row + 1, beePosition.Col] = 'B';
                                totalPolinatedFlowers++;
                                beePosition.Row++;
                            }
                            else if (matrix[beePosition.Row + 1, beePosition.Col] == 'O')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row + 1, beePosition.Col] = '.';
                                beePosition.Row += 2;
                                if (matrix[beePosition.Row, beePosition.Col] == 'f')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                    totalPolinatedFlowers++;
                                }
                                else if (matrix[beePosition.Row, beePosition.Col] == '.')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                }
                            }
                            else if (matrix[beePosition.Row + 1, beePosition.Col] == '.')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row + 1, beePosition.Col] = 'B';
                                beePosition.Row++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            matrix[beePosition.Row, beePosition.Col] = '.';
                            doesProgramShouldEnd = true;
                        }
                        break;
                    case "left":
                        if (IsInBounds(beePosition.Row, beePosition.Col - 1, matrixSize))
                        {
                            if (matrix[beePosition.Row, beePosition.Col - 1] == 'f')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col - 1] = 'B';
                                totalPolinatedFlowers++;
                                beePosition.Col--;
                            }
                            else if (matrix[beePosition.Row, beePosition.Col - 1] == 'O')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col - 1] = '.';
                                beePosition.Col -= 2;
                                if (matrix[beePosition.Row, beePosition.Col] == 'f')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                    totalPolinatedFlowers++;
                                }
                                else if (matrix[beePosition.Row, beePosition.Col] == '.')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                }
                            }
                            else if (matrix[beePosition.Row, beePosition.Col - 1] == '.')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col - 1] = 'B';
                                beePosition.Col--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            matrix[beePosition.Row, beePosition.Col] = '.';
                            doesProgramShouldEnd = true;
                        }
                        break;
                    case "right":
                        if (IsInBounds(beePosition.Row, beePosition.Col + 1, matrixSize))
                        {
                            if (matrix[beePosition.Row, beePosition.Col + 1] == 'f')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col + 1] = 'B';
                                totalPolinatedFlowers++;
                                beePosition.Col++;
                            }
                            else if (matrix[beePosition.Row, beePosition.Col + 1] == 'O')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col + 1] = '.';
                                beePosition.Col += 2;
                                if (matrix[beePosition.Row, beePosition.Col] == 'f')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                    totalPolinatedFlowers++;
                                }
                                else if (matrix[beePosition.Row, beePosition.Col] == '.')
                                {
                                    matrix[beePosition.Row, beePosition.Col] = 'B';
                                }
                            }
                            else if (matrix[beePosition.Row, beePosition.Col + 1] == '.')
                            {
                                matrix[beePosition.Row, beePosition.Col] = '.';
                                matrix[beePosition.Row, beePosition.Col + 1] = 'B';
                                beePosition.Col++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            matrix[beePosition.Row, beePosition.Col] = '.';
                            doesProgramShouldEnd = true;
                        }
                        break;
                    default:
                        doesProgramShouldEnd = true;
                        break;
                }
            }
            if (totalPolinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {totalPolinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - totalPolinatedFlowers} flowers more");
            }
            PrintFinalStateOfMatrix(matrix);
        }
        static void PrintFinalStateOfMatrix(char[,] matrix)
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
        static bool IsInBounds(int row, int col, int matrixSize)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
        static BeePosition FindBeeStartingPosition(char[,] matrix)
        {
            BeePosition beePosition = new BeePosition();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beePosition.Row = row;
                        beePosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return beePosition;
        }
        static char[,] CreateMatrix(int matrixSize)
        {
            char[,] matrix = new char[matrixSize, matrixSize];
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
    class BeePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

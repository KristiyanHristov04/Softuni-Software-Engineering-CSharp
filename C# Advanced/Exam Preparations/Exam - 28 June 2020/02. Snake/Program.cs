using System;

namespace _02._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = CreateMatrix(matrixSize);
            SnakePosition snakePosition = FindSnakeStartingPosition(matrix);
            LairPosition firstLairPosition = FindLairPosition(matrix, true);
            LairPosition secondLairPosition = FindLairPosition(matrix, false);
            int collectedFood = 0;
            bool isOutOfTerritory = false;

            while (collectedFood < 10 && !isOutOfTerritory)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (IsInBounds(snakePosition.Row - 1, snakePosition.Col, matrixSize))
                        {
                            if (matrix[snakePosition.Row - 1, snakePosition.Col] == '*')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row - 1, snakePosition.Col] = 'S';
                                collectedFood++;
                                snakePosition.Row--;
                            }
                            else if (matrix[snakePosition.Row - 1, snakePosition.Col] == 'B')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                if (snakePosition.Row - 1 == firstLairPosition.Row && snakePosition.Col == firstLairPosition.Col)
                                {
                                    matrix[snakePosition.Row - 1, snakePosition.Col] = '.';
                                    matrix[secondLairPosition.Row, secondLairPosition.Col] = 'S';
                                    snakePosition.Row = secondLairPosition.Row;
                                    snakePosition.Col = secondLairPosition.Col;
                                }
                                else if (snakePosition.Row - 1 == secondLairPosition.Row && snakePosition.Col == secondLairPosition.Col)
                                {
                                    matrix[snakePosition.Row - 1, snakePosition.Col] = '.';
                                    matrix[firstLairPosition.Row, firstLairPosition.Col] = 'S';
                                    snakePosition.Row = firstLairPosition.Row;
                                    snakePosition.Col = firstLairPosition.Col;
                                }
                            }
                            else if (matrix[snakePosition.Row - 1, snakePosition.Col] == '-')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row - 1, snakePosition.Col] = 'S';
                                snakePosition.Row--;
                            }
                        }
                        else
                        {
                            matrix[snakePosition.Row, snakePosition.Col] = '.';
                            isOutOfTerritory = true;
                        }
                        break;
                    case "down":
                        if (IsInBounds(snakePosition.Row + 1, snakePosition.Col, matrixSize))
                        {
                            if (matrix[snakePosition.Row + 1, snakePosition.Col] == '*')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row + 1, snakePosition.Col] = 'S';
                                collectedFood++;
                                snakePosition.Row++;
                            }
                            else if (matrix[snakePosition.Row + 1, snakePosition.Col] == 'B')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                if (snakePosition.Row + 1 == firstLairPosition.Row && snakePosition.Col == firstLairPosition.Col)
                                {
                                    matrix[snakePosition.Row + 1, snakePosition.Col] = '.';
                                    matrix[secondLairPosition.Row, secondLairPosition.Col] = 'S';
                                    snakePosition.Row = secondLairPosition.Row;
                                    snakePosition.Col = secondLairPosition.Col;
                                }
                                else if (snakePosition.Row + 1 == secondLairPosition.Row && snakePosition.Col == secondLairPosition.Col)
                                {
                                    matrix[snakePosition.Row + 1, snakePosition.Col] = '.';
                                    matrix[firstLairPosition.Row, firstLairPosition.Col] = 'S';
                                    snakePosition.Row = firstLairPosition.Row;
                                    snakePosition.Col = firstLairPosition.Col;
                                }
                            }
                            else if (matrix[snakePosition.Row + 1, snakePosition.Col] == '-')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row + 1, snakePosition.Col] = 'S';
                                snakePosition.Row++;
                            }
                        }
                        else
                        {
                            matrix[snakePosition.Row, snakePosition.Col] = '.';
                            isOutOfTerritory = true;
                        }
                        break;
                    case "left":
                        if (IsInBounds(snakePosition.Row, snakePosition.Col - 1, matrixSize))
                        {
                            if (matrix[snakePosition.Row, snakePosition.Col - 1] == '*')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row, snakePosition.Col - 1] = 'S';
                                collectedFood++;
                                snakePosition.Col--;
                            }
                            else if (matrix[snakePosition.Row, snakePosition.Col - 1] == 'B')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                if (snakePosition.Row == firstLairPosition.Row && snakePosition.Col - 1 == firstLairPosition.Col)
                                {
                                    matrix[snakePosition.Row, snakePosition.Col - 1] = '.';
                                    matrix[secondLairPosition.Row, secondLairPosition.Col] = 'S';
                                    snakePosition.Row = secondLairPosition.Row;
                                    snakePosition.Col = secondLairPosition.Col;
                                }
                                else if (snakePosition.Row == secondLairPosition.Row && snakePosition.Col - 1 == secondLairPosition.Col)
                                {
                                    matrix[snakePosition.Row, snakePosition.Col - 1] = '.';
                                    matrix[firstLairPosition.Row, firstLairPosition.Col] = 'S';
                                    snakePosition.Row = firstLairPosition.Row;
                                    snakePosition.Col = firstLairPosition.Col;
                                }
                            }
                            else if (matrix[snakePosition.Row , snakePosition.Col - 1] == '-')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row, snakePosition.Col - 1] = 'S';
                                snakePosition.Col--;
                            }
                        }
                        else
                        {
                            matrix[snakePosition.Row, snakePosition.Col] = '.';
                            isOutOfTerritory = true;
                        }
                        break;
                    case "right":
                        if (IsInBounds(snakePosition.Row, snakePosition.Col + 1, matrixSize))
                        {
                            if (matrix[snakePosition.Row, snakePosition.Col + 1] == '*')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row, snakePosition.Col + 1] = 'S';
                                collectedFood++;
                                snakePosition.Col++;
                            }
                            else if (matrix[snakePosition.Row, snakePosition.Col + 1] == 'B')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                if (snakePosition.Row == firstLairPosition.Row && snakePosition.Col + 1 == firstLairPosition.Col)
                                {
                                    matrix[snakePosition.Row , snakePosition.Col + 1] = '.';
                                    matrix[secondLairPosition.Row, secondLairPosition.Col] = 'S';
                                    snakePosition.Row = secondLairPosition.Row;
                                    snakePosition.Col = secondLairPosition.Col;
                                }
                                else if (snakePosition.Row  == secondLairPosition.Row && snakePosition.Col + 1 == secondLairPosition.Col)
                                {
                                    matrix[snakePosition.Row, snakePosition.Col + 1] = '.';
                                    matrix[firstLairPosition.Row, firstLairPosition.Col] = 'S';
                                    snakePosition.Row = firstLairPosition.Row;
                                    snakePosition.Col = firstLairPosition.Col;
                                }
                            }
                            else if (matrix[snakePosition.Row , snakePosition.Col + 1] == '-')
                            {
                                matrix[snakePosition.Row, snakePosition.Col] = '.';
                                matrix[snakePosition.Row , snakePosition.Col + 1] = 'S';
                                snakePosition.Col++;
                            }
                        }
                        else
                        {
                            matrix[snakePosition.Row, snakePosition.Col] = '.';
                            isOutOfTerritory = true;
                        }
                        break;
                }
            }
            if (isOutOfTerritory)
            {
                Console.WriteLine("Game over!");
            }
            if (collectedFood >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {collectedFood}");
            PrintFinalMatrixState(matrix);
        }
        static void PrintFinalMatrixState(char[,] matrix)
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
        static LairPosition FindLairPosition(char[,] matrix, bool isFirst)
        {
            LairPosition lairPosition = new LairPosition();
            bool isFound = false;
            bool isFirstLair = true;
            if (isFirst)
            {
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
                            lairPosition.Row = row;
                            lairPosition.Col = col;
                            isFound = true;
                            break;
                        }
                    }
                }
                return lairPosition;
            }
            else
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B' && !isFirstLair)
                        {
                            lairPosition.Row = row;
                            lairPosition.Col = col;
                            isFound = true;
                            break;
                        }
                        else if(matrix[row, col] == 'B' && isFirstLair)
                        {
                            isFirstLair = false; 
                        }
                    }
                }
                return lairPosition;
            }
        }
        static bool IsInBounds(int row, int col, int matrixSize)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
        static SnakePosition FindSnakeStartingPosition(char[,] matrix)
        {
            SnakePosition snakePosition = new SnakePosition();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakePosition.Row = row;
                        snakePosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return snakePosition;
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
    class SnakePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class LairPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

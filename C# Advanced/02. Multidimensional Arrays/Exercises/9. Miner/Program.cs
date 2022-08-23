using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            Queue<string> commands = Commands();
            char[,] matrix = MatrixElements(matrixSize);

            int totalCoal = TotalCoal(matrixSize, matrix);
            int collectedCoal = 0;
            CurrentPosition currentPosition = StartingIndex(matrix);
            while (collectedCoal < totalCoal && commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();
                switch (currentCommand)
                {
                    case "up":
                        if (currentPosition.Row - 1 >= 0 && currentPosition.Row - 1< matrixSize)
                        {
                            currentPosition.Row--;
                            if (matrix[currentPosition.Row, currentPosition.Col] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentPosition.Row}, {currentPosition.Col})");
                                return;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == 'c')
                            {
                                matrix[currentPosition.Row, currentPosition.Col] = '*';
                                collectedCoal++;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == '*')
                            {
                                continue;
                            }
                        }
                        break;
                    case "down":
                        if (currentPosition.Row + 1 >= 0 && currentPosition.Row + 1< matrixSize)
                        {
                            currentPosition.Row++;
                            if (matrix[currentPosition.Row, currentPosition.Col] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentPosition.Row}, {currentPosition.Col})");
                                return;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == 'c')
                            {
                                matrix[currentPosition.Row, currentPosition.Col] = '*';
                                collectedCoal++;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == '*')
                            {
                                continue;
                            }
                        }
                        break;
                    case "right":
                        if (currentPosition.Col + 1 >= 0 && currentPosition.Col + 1 < matrixSize)
                        {
                            currentPosition.Col++;
                            if (matrix[currentPosition.Row, currentPosition.Col] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentPosition.Row}, {currentPosition.Col})");
                                return;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == 'c')
                            {
                                matrix[currentPosition.Row, currentPosition.Col] = '*';
                                collectedCoal++;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == '*')
                            {
                                continue;
                            }
                        }
                        break;
                    case "left":
                        if (currentPosition.Col - 1 >= 0 && currentPosition.Col - 1 < matrixSize)
                        {
                            currentPosition.Col--;
                            if (matrix[currentPosition.Row, currentPosition.Col] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentPosition.Row}, {currentPosition.Col})");
                                return;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == 'c')
                            {
                                matrix[currentPosition.Row, currentPosition.Col] = '*';
                                collectedCoal++;
                            }
                            else if (matrix[currentPosition.Row, currentPosition.Col] == '*')
                            {
                                continue;
                            }
                        }
                        break;
                }
                if (collectedCoal == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currentPosition.Row}, {currentPosition.Col})");
                    return;
                }

            }
            Console.WriteLine($"{totalCoal -= collectedCoal} coals left. ({currentPosition.Row}, {currentPosition.Col})");
        }
        static char[,] MatrixElements(int matrixSize)
        {
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] fieldElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = fieldElements[col];
                }
            }
            return matrix;
        }
        static Queue<string> Commands()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> output = new Queue<string>(input);
            return output;
        }

        static int TotalCoal(int matrixSize, char[,] mainMatrix)
        {
            int totalCoal = 0;
            char[,] matrix = mainMatrix;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }
            return totalCoal;
        }

        static CurrentPosition StartingIndex(char[,] mainMatrix)
        {
            bool isStartFound = false;
            CurrentPosition currPosition = new CurrentPosition();
            char[,] matrix = mainMatrix;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isStartFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        currPosition.Row = row;
                        currPosition.Col = col;
                        isStartFound = true;
                        break;
                    }
                }
            }
            return currPosition;
        }
    }
    class CurrentPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public CurrentPosition(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public CurrentPosition()
        {

        }
    }
}

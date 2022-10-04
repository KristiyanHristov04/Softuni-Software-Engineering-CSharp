using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isGameOver = false;
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int numberOfCommands = Convert.ToInt32(Console.ReadLine());
            matrix = FulfilMatrix(matrix);
            PlayerPosition playerPosition = FindPlayerStartingPosition(matrix);
            FinishPosition finishPosition = FindFinishCoordinates(matrix);

            while (numberOfCommands > 0 && !isGameOver)
            {
                string moveDirection = Console.ReadLine();
                numberOfCommands--;
                switch (moveDirection)
                {
                    case "up":
                        //Out of bounds.
                        if (playerPosition.Row - 1 < 0)
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row = matrixSize - 1;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row - 1 >= 0 && matrix[playerPosition.Row - 1, playerPosition.Col] == 'B')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            matrix[playerPosition.Row - 1, playerPosition.Col] = 'f';
                            playerPosition.Row--;
                            //When he moves forwards with bonus and leaves the matrix goes to the other side.
                            if (playerPosition.Row - 1 < 0)
                            {
                                playerPosition.Row = matrixSize - 1;
                                if (playerPosition.Row == finishPosition.Row && playerPosition.Col ==finishPosition.Col)
                                {
                                    matrix[finishPosition.Row, finishPosition.Col] = 'f';
                                    isGameOver = true;
                                }
                                //now
                                else
                                {
                                    matrix[playerPosition.Row, playerPosition.Col] = 'f';
                                }
                            }
                            else
                            {
                                //matrix[playerPosition.Row, playerPosition.Col] = '-';
                                matrix[playerPosition.Row - 1, playerPosition.Col] = 'f';
                                playerPosition.Row--;
                            }
                        }
                        else if (playerPosition.Row - 1 >= 0 && matrix[playerPosition.Row - 1, playerPosition.Col] == 'T')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row--;
                            playerPosition.Row++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row - 1 >= 0 && matrix[playerPosition.Row - 1, playerPosition.Col] == '-')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row - 1 >= 0 && matrix[playerPosition.Row - 1, playerPosition.Col] == 'F')
                        {
                            isGameOver = true;
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                        {
                            isGameOver = true;
                        }
                        break;
                    case "down":
                        //Out of bounds.
                        if (playerPosition.Row + 1 > matrixSize - 1)
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row = 0;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row + 1 <= matrixSize - 1 && matrix[playerPosition.Row + 1, playerPosition.Col] == 'B')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row++;
                            //When he moves forwards with bonus and leaves the matrix goes to the other side.
                            if (playerPosition.Row + 1 > matrixSize - 1)
                            {
                                playerPosition.Row = 0;
                                if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                                {
                                    matrix[finishPosition.Row, finishPosition.Col] = 'f';
                                    isGameOver = true;
                                }
                                //now
                                else
                                {
                                    matrix[playerPosition.Row, playerPosition.Col] = 'f';
                                }
                            }
                            else
                            {
                                //matrix[playerPosition.Row, playerPosition.Col] = '-';
                                matrix[playerPosition.Row + 1, playerPosition.Col] = 'f';
                                playerPosition.Row++;
                            }
                        }
                        else if (playerPosition.Row + 1 <= matrixSize - 1 && matrix[playerPosition.Row + 1, playerPosition.Col] == 'T')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row++;
                            playerPosition.Row--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row + 1 <= matrixSize - 1 && matrix[playerPosition.Row + 1, playerPosition.Col] == '-')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Row + 1 <= matrixSize - 1 && matrix[playerPosition.Row + 1, playerPosition.Col] == 'F')
                        {
                            isGameOver = true;
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Row++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                        {
                            isGameOver = true;
                        }
                        break;
                    case "left":
                        if (playerPosition.Col - 1 < 0)
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col = matrixSize - 1;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col - 1 >= 0 && matrix[playerPosition.Row, playerPosition.Col - 1] == 'B')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col--;
                            //When he moves forwards with bonus and leaves the matrix goes to the other side.
                            if (playerPosition.Col - 1 < 0)
                            {
                                playerPosition.Col = matrixSize - 1;
                                if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                                {
                                    matrix[finishPosition.Row, finishPosition.Col] = 'f';
                                    isGameOver = true;
                                }
                                //now
                                else
                                {
                                    matrix[playerPosition.Row, playerPosition.Col] = 'f';
                                }
                            }
                            else
                            {
                                //matrix[playerPosition.Row, playerPosition.Col] = '-';
                                matrix[playerPosition.Row, playerPosition.Col - 1] = 'f';
                                playerPosition.Col--;
                            }
                        }
                        else if (playerPosition.Col - 1 >= 0 && matrix[playerPosition.Row, playerPosition.Col - 1] == 'T')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col--;
                            playerPosition.Col++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col - 1 >= 0 && matrix[playerPosition.Row, playerPosition.Col - 1] == '-')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col - 1 >= 0 && matrix[playerPosition.Row, playerPosition.Col - 1] == 'F')
                        {
                            isGameOver = true;
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                        {
                            isGameOver = true;
                        }
                        break;
                    case "right":
                        if (playerPosition.Col + 1 > matrixSize - 1)
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col = 0;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col + 1 <= matrixSize - 1 && matrix[playerPosition.Row, playerPosition.Col + 1] == 'B')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            matrix[playerPosition.Row, playerPosition.Col + 1] = 'f';
                            playerPosition.Col++;
                            //When he moves forwards with bonus and leaves the matrix goes to the other side.
                            if (playerPosition.Col + 1 > matrixSize - 1)
                            {
                                playerPosition.Col = 0;
                                if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                                {
                                    matrix[finishPosition.Row, finishPosition.Col] = 'f';
                                    isGameOver = true;
                                }
                                //now
                                else
                                {
                                    matrix[playerPosition.Row, playerPosition.Col] = 'f';
                                }
                            }
                            else
                            {
                                //matrix[playerPosition.Row, playerPosition.Col] = '-';
                                matrix[playerPosition.Row, playerPosition.Col + 1] = 'f';
                                playerPosition.Col++;
                            }
                        }
                        else if (playerPosition.Col + 1 <= matrixSize - 1 && matrix[playerPosition.Row, playerPosition.Col + 1] == 'T')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col++;
                            playerPosition.Col--;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col + 1 <= matrixSize - 1 && matrix[playerPosition.Row, playerPosition.Col + 1] == '-')
                        {
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        else if (playerPosition.Col + 1 <= matrixSize - 1 && matrix[playerPosition.Row, playerPosition.Col + 1] == 'F')
                        {
                            isGameOver = true;
                            matrix[playerPosition.Row, playerPosition.Col] = '-';
                            playerPosition.Col++;
                            matrix[playerPosition.Row, playerPosition.Col] = 'f';
                        }
                        if (playerPosition.Row == finishPosition.Row && playerPosition.Col == finishPosition.Col)
                        {
                            isGameOver = true;
                        }
                        break;
                }
            }
            if (isGameOver)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            ReadFinalMatrix(matrix);
        }
        static char[,] FulfilMatrix(char[,] matrix)
        {
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
        static PlayerPosition FindPlayerStartingPosition(char[,] matrix)
        {
            PlayerPosition playerPosition = new PlayerPosition();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerPosition.Row = row;
                        playerPosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return playerPosition;
        }
        static FinishPosition FindFinishCoordinates(char[,] matrix)
        {
            FinishPosition finishPosition = new FinishPosition();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'F')
                    {
                        finishPosition.Row = row;
                        finishPosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return finishPosition;
        }
        static void ReadFinalMatrix(char[,] matrix)
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
    }
    class PlayerPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class FinishPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

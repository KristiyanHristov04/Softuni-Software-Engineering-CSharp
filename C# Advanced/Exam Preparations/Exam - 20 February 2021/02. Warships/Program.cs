using System;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = Convert.ToInt32(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = FillField(sizeOfField);
            int playerOneTotalShips = CountOfShips(field, '<');
            int playerTwoTotalShips = CountOfShips(field, '>');
            int totalCountShipsDestroyed = 0;

            //We get our coordinates
            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] currentCoordinates = coordinates[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int currentRow = Convert.ToInt32(currentCoordinates[0]);
                int currentCol = Convert.ToInt32(currentCoordinates[1]);


                if (IsInBounds(currentRow, currentCol, sizeOfField))
                {
                    if (field[currentRow, currentCol] == '*')
                    {
                        //Attack and miss.
                        continue;
                    }
                    else if (field[currentRow, currentCol] == '<')
                    {
                        //Destroy first player's ship
                        playerOneTotalShips--;
                        field[currentRow, currentCol] = 'X';
                        totalCountShipsDestroyed++;
                    }
                    else if (field[currentRow, currentCol] == '>')
                    {
                        //Destroy second player's ship
                        playerTwoTotalShips--;
                        field[currentRow, currentCol] = 'X';
                        totalCountShipsDestroyed++;
                    }
                    else if (field[currentRow, currentCol] == '#')
                    {
                        field[currentRow, currentCol] = 'X'; 
                        //Hit a mine.
                        if (IsInBounds(currentRow - 1, currentCol - 1, sizeOfField))
                        {
                            if (field[currentRow - 1, currentCol - 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow - 1, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow - 1, currentCol - 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow - 1, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow - 1, currentCol, sizeOfField))
                        {
                            if (field[currentRow - 1, currentCol] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow - 1, currentCol] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow - 1, currentCol] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow - 1, currentCol] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow - 1, currentCol + 1, sizeOfField))
                        {
                            if (field[currentRow - 1, currentCol + 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow - 1, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow - 1, currentCol + 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow - 1, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow, currentCol - 1, sizeOfField))
                        {
                            if (field[currentRow, currentCol - 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow, currentCol - 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow, currentCol + 1, sizeOfField))
                        {
                            if (field[currentRow, currentCol + 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow, currentCol + 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow + 1, currentCol - 1, sizeOfField))
                        {
                            if (field[currentRow + 1, currentCol - 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow + 1, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow + 1, currentCol - 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow + 1, currentCol - 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow + 1, currentCol, sizeOfField))
                        {
                            if (field[currentRow + 1, currentCol] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow + 1, currentCol] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow + 1, currentCol] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow + 1, currentCol] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                        if (IsInBounds(currentRow + 1, currentCol + 1, sizeOfField))
                        {
                            if (field[currentRow + 1, currentCol + 1] == '<')
                            {
                                playerOneTotalShips--;
                                field[currentRow + 1, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currentRow + 1, currentCol + 1] == '>')
                            {
                                playerTwoTotalShips--;
                                field[currentRow + 1, currentCol + 1] = 'X';
                                totalCountShipsDestroyed++;
                            }
                        }
                    }
                }
                if (playerOneTotalShips <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
                else if (playerTwoTotalShips <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }
            Console.WriteLine($"It's a draw! Player One has {playerOneTotalShips} ships left. Player Two has {playerTwoTotalShips} ships left.");
        }
        static int CountOfShips(char[,] field, char symbol)
        {
            int result = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == symbol)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        static bool IsInBounds(int row, int col, int sizeOfField)
        {
            return row >= 0 && row < sizeOfField && col >= 0 && col < sizeOfField;
        }
        static char[,] FillField(int sizeOfField)
        {
            char[,] field = new char[sizeOfField, sizeOfField];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }
            return field;
        }
    }
}

using System;
using System.Linq;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bakerySize = Convert.ToInt32(Console.ReadLine());
            char[,] bakery = FillBakery(bakerySize);
            PlayerPosition playerPosition = FindPlayerStartingPosition(bakery);
            PillarPosition firstPillerPosition = FindPillerPosition(bakery, true);
            PillarPosition secondPillerPosition = FindPillerPosition(bakery, false);
            int madeMoney = 0;
            bool isOutOfTheBakery = false;

            while (madeMoney < 50 && !isOutOfTheBakery)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (IsInBounds(playerPosition.Row - 1, playerPosition.Col, bakerySize))
                        {
                            if (bakery[playerPosition.Row - 1, playerPosition.Col] == 'O')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                if (playerPosition.Row - 1 == firstPillerPosition.Row && playerPosition.Col == firstPillerPosition.Col)
                                {
                                    //Move to the second Piller
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = '-';
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = 'S';
                                    playerPosition.Row = secondPillerPosition.Row;
                                    playerPosition.Col = secondPillerPosition.Col;
                                }
                                else if (playerPosition.Row - 1 == secondPillerPosition.Row && playerPosition.Col == secondPillerPosition.Col)
                                {
                                    //Move to the first Piller
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = '-';
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = 'S';
                                    playerPosition.Row = firstPillerPosition.Row;
                                    playerPosition.Col = firstPillerPosition.Col;
                                }
                            }
                            else if (bakery[playerPosition.Row - 1, playerPosition.Col] == '-')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row - 1, playerPosition.Col] = 'S';
                                playerPosition.Row--;
                            }
                            else
                            {
                                madeMoney += bakery[playerPosition.Row - 1, playerPosition.Col] - 48;
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row - 1, playerPosition.Col] = 'S';
                                playerPosition.Row--;
                            }
                        }
                        else
                        {
                            bakery[playerPosition.Row, playerPosition.Col] = '-';
                            isOutOfTheBakery = true;
                        }
                        break;
                    case "down":
                        if (IsInBounds(playerPosition.Row + 1, playerPosition.Col, bakerySize))
                        {
                            if (bakery[playerPosition.Row + 1, playerPosition.Col] == 'O')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                if (playerPosition.Row + 1 == firstPillerPosition.Row && playerPosition.Col == firstPillerPosition.Col)
                                {
                                    //Move to the second Piller
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = '-';
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = 'S';
                                    playerPosition.Row = secondPillerPosition.Row;
                                    playerPosition.Col = secondPillerPosition.Col;
                                }
                                else if (playerPosition.Row + 1 == secondPillerPosition.Row && playerPosition.Col == secondPillerPosition.Col)
                                {
                                    //Move to the first Piller
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = '-';
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = 'S';
                                    playerPosition.Row = firstPillerPosition.Row;
                                    playerPosition.Col = firstPillerPosition.Col;
                                }
                            }
                            else if (bakery[playerPosition.Row + 1, playerPosition.Col] == '-')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row + 1, playerPosition.Col] = 'S';
                                playerPosition.Row++;
                            }
                            else
                            {
                                madeMoney += bakery[playerPosition.Row + 1, playerPosition.Col] - 48;
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row + 1, playerPosition.Col] = 'S';
                                playerPosition.Row++;
                            }
                        }
                        else
                        {
                            bakery[playerPosition.Row, playerPosition.Col] = '-';
                            isOutOfTheBakery = true;
                        }
                        break;
                    case "left":
                        if (IsInBounds(playerPosition.Row, playerPosition.Col - 1, bakerySize))
                        {
                            if (bakery[playerPosition.Row, playerPosition.Col - 1] == 'O')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                if (playerPosition.Row == firstPillerPosition.Row && playerPosition.Col - 1 == firstPillerPosition.Col)
                                {
                                    //Move to the second Piller
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = '-';
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = 'S';
                                    playerPosition.Row = secondPillerPosition.Row;
                                    playerPosition.Col = secondPillerPosition.Col;
                                }
                                else if (playerPosition.Row == secondPillerPosition.Row && playerPosition.Col - 1 == secondPillerPosition.Col)
                                {
                                    //Move to the first Piller
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = '-';
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = 'S';
                                    playerPosition.Row = firstPillerPosition.Row;
                                    playerPosition.Col = firstPillerPosition.Col;
                                }
                            }
                            else if (bakery[playerPosition.Row, playerPosition.Col - 1] == '-')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row, playerPosition.Col - 1] = 'S';
                                playerPosition.Col--;
                            }
                            else
                            {
                                madeMoney += bakery[playerPosition.Row, playerPosition.Col - 1] - 48;
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row, playerPosition.Col - 1] = 'S';
                                playerPosition.Col--;
                            }
                        }
                        else
                        {
                            bakery[playerPosition.Row, playerPosition.Col] = '-';
                            isOutOfTheBakery = true;
                        }
                        break;
                    case "right":
                        if (IsInBounds(playerPosition.Row, playerPosition.Col + 1, bakerySize))
                        {
                            if (bakery[playerPosition.Row, playerPosition.Col + 1] == 'O')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                if (playerPosition.Row == firstPillerPosition.Row && playerPosition.Col + 1 == firstPillerPosition.Col)
                                {
                                    //Move to the second Piller
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = '-';
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = 'S';
                                    playerPosition.Row = secondPillerPosition.Row;
                                    playerPosition.Col = secondPillerPosition.Col;
                                }
                                else if (playerPosition.Row == secondPillerPosition.Row && playerPosition.Col + 1 == secondPillerPosition.Col)
                                {
                                    //Move to the first Piller
                                    bakery[secondPillerPosition.Row, secondPillerPosition.Col] = '-';
                                    bakery[firstPillerPosition.Row, firstPillerPosition.Col] = 'S';
                                    playerPosition.Row = firstPillerPosition.Row;
                                    playerPosition.Col = firstPillerPosition.Col;
                                }
                            }
                            else if (bakery[playerPosition.Row, playerPosition.Col + 1] == '-')
                            {
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row, playerPosition.Col + 1] = 'S';
                                playerPosition.Col++;
                            }
                            else
                            {
                                madeMoney += bakery[playerPosition.Row, playerPosition.Col + 1] - 48;
                                bakery[playerPosition.Row, playerPosition.Col] = '-';
                                bakery[playerPosition.Row, playerPosition.Col + 1] = 'S';
                                playerPosition.Col++;
                            }
                        }
                        else
                        {
                            bakery[playerPosition.Row, playerPosition.Col] = '-';
                            isOutOfTheBakery = true;
                        }
                        break;
                }
            }
            if (isOutOfTheBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            if (madeMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {madeMoney}");
            PrintBakeryFinalState(bakery);
        }
        static void PrintBakeryFinalState(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write($"{bakery[row, col]}");
                }
                Console.WriteLine();
            }
        }
        static bool IsInBounds(int row, int col, int bakerySize)
        {
            return row >= 0 && row < bakerySize && col >= 0 && col < bakerySize;
        }
        static PillarPosition FindPillerPosition(char[,] bakery, bool isFirstPiller)
        {
            PillarPosition pillerPosition = new PillarPosition();
            bool isFound = false;
            bool isFirstTime = true;

            if (isFirstPiller)
            {
                for (int row = 0; row < bakery.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < bakery.GetLength(1); col++)
                    {
                        if (bakery[row, col] == 'O')
                        {
                            pillerPosition.Row = row;
                            pillerPosition.Col = col;
                            isFound = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < bakery.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < bakery.GetLength(1); col++)
                    {
                        if (bakery[row, col] == 'O' && !isFirstTime)
                        {
                            pillerPosition.Row = row;
                            pillerPosition.Col = col;
                            isFound = true;
                            break;
                        }
                        else if (bakery[row, col] == 'O' && isFirstTime)
                        {
                            isFirstTime = false;
                        }
                    }
                }
            }
            
            return pillerPosition;
        }
        static PlayerPosition FindPlayerStartingPosition(char[,] bakery)
        {
            PlayerPosition playerStartingPosition = new PlayerPosition();
            bool isFound = false;
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'S')
                    {
                        playerStartingPosition.Row = row;
                        playerStartingPosition.Col = col;
                        isFound = true;
                        break;
                    }
                }
            }
            return playerStartingPosition;
        }
        static char[,] FillBakery(int bakerySize)
        {
            char[,] bakery = new char[bakerySize, bakerySize];
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    bakery[row, col] = input[col];
                }
            }
            return bakery;
        }
    }
    class PlayerPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class PillarPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

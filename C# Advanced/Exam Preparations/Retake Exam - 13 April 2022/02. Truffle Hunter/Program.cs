using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int forestSize = Convert.ToInt32(Console.ReadLine());
            char[,] forest = new char[forestSize, forestSize];
            int collectedBlackTruffles = 0;
            int collectedSummerTruffles = 0;
            int collectedWhiteTruffles = 0;
            int totalTrufflesEatenByBoar = 0;

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = input[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop the hunt")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                int row = Convert.ToInt32(tokens[1]);
                int col = Convert.ToInt32(tokens[2]);
                switch (mainCommand)
                {
                    case "Collect":
                        if (forest[row, col] == 'B')
                        {
                            collectedBlackTruffles++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'S')
                        {
                            collectedSummerTruffles++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'W')
                        {
                            collectedWhiteTruffles++;
                            forest[row, col] = '-';
                        }
                        break;
                    case "Wild_Boar":
                        string direction = tokens[3];
                        if (direction == "up")
                        {
                            while (row < forestSize && row >= 0)
                            {
                                if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                                {
                                    totalTrufflesEatenByBoar++;
                                    forest[row, col] = '-';
                                }
                                row -= 2;
                            }
                        }
                        else if (direction == "down")
                        {
                            while (row < forestSize && row >= 0)
                            {
                                if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                                {
                                    totalTrufflesEatenByBoar++;
                                    forest[row, col] = '-';
                                }
                                row += 2;
                            }
                        }
                        else if (direction == "left")
                        {
                            while (col < forestSize && col >= 0)
                            {
                                if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                                {
                                    totalTrufflesEatenByBoar++;
                                    forest[row, col] = '-';
                                }
                                col -= 2;
                            }
                        }
                        else if (direction == "right")
                        {
                            while (col < forestSize && col >= 0)
                            {
                                if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                                {
                                    totalTrufflesEatenByBoar++;
                                    forest[row, col] = '-';
                                }
                                col += 2;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Peter manages to harvest {collectedBlackTruffles} black, {collectedSummerTruffles} summer, and {collectedWhiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {totalTrufflesEatenByBoar} truffles.");
            PrintForest(forest);
        }
        static void PrintForest(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

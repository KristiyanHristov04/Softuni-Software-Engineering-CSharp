using System;
using System.Linq;

namespace _02._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int collectedTokens = 0;
            int enemyCollectedTokens = 0;
            int beachRows = Convert.ToInt32(Console.ReadLine());
            char[][] beachjaggedArray = new char[beachRows][];
            beachjaggedArray = FulfilBeachJaggedArray(beachjaggedArray);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Gong")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                int row = Convert.ToInt32(tokens[1]);
                int col = Convert.ToInt32(tokens[2]);
                if (mainCommand == "Find")
                {
                    if (row >= 0 && row < beachRows && beachjaggedArray[row].Length > col)
                    {
                        if (beachjaggedArray[row][col] == 'T')
                        {
                            beachjaggedArray[row][col] = '-';
                            collectedTokens++;
                        }
                    }
                }
                else if (mainCommand == "Opponent")
                {
                    string direction = tokens[3];
                    if (row >= 0 && row < beachRows && beachjaggedArray[row].Length > col)
                    {
                        if (beachjaggedArray[row][col] == 'T')
                        {
                            beachjaggedArray[row][col] = '-';
                            enemyCollectedTokens++;
                            int steps = 1;
                            while (steps <= 3)
                            {
                                switch (direction)
                                {
                                    case "up":
                                        if (row - steps >= 0 && row - steps < beachRows && beachjaggedArray[row - steps].Length > col)
                                        {
                                            if (beachjaggedArray[row - steps][col] == 'T')
                                            {
                                                enemyCollectedTokens++;
                                                beachjaggedArray[row - steps][col] = '-';
                                            }
                                        }
                                        break;
                                    case "down":
                                        if (row + steps >= 0 && row + steps < beachRows && beachjaggedArray[row + steps].Length > col)
                                        {
                                            if (beachjaggedArray[row + steps][col] == 'T')
                                            {
                                                enemyCollectedTokens++;
                                                beachjaggedArray[row + steps][col] = '-';
                                            }
                                        }
                                        break;
                                    case "left":
                                        if (row >= 0 && row < beachRows && col - steps >= 0 && beachjaggedArray[row].Length > col - steps)
                                        {
                                            if (beachjaggedArray[row][col - steps] == 'T')
                                            {
                                                enemyCollectedTokens++;
                                                beachjaggedArray[row][col - steps] = '-';
                                            }
                                        }
                                        break;
                                    case "right":
                                        if (row >= 0 && row < beachRows && col + steps >= 0 && beachjaggedArray[row].Length > col + steps)
                                        {
                                            if (beachjaggedArray[row][col + steps] == 'T')
                                            {
                                                enemyCollectedTokens++;
                                                beachjaggedArray[row][col + steps] = '-';
                                            }
                                        }
                                        break;
                                }
                                steps++;
                            }
                        }
                    }
                }
            }
            PrintBeachJaggedArray(beachjaggedArray);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyCollectedTokens}");
        }
        static char[][] FulfilBeachJaggedArray(char[][] beachjaggedArray)
        {
            for (int row = 0; row < beachjaggedArray.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beachjaggedArray[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    beachjaggedArray[row][col] = input[col];
                }
            }
            return beachjaggedArray;
        }
        static void PrintBeachJaggedArray(char[][] beachjaggedArray)
        {
            for (int row = 0; row < beachjaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < beachjaggedArray[row].Length; col++)
                {
                    Console.Write(beachjaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

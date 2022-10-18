using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pondSize = Convert.ToInt32(Console.ReadLine());
            char[,] pond = new char[pondSize, pondSize];
            int beaverRow = 0;
            int beaverCol = 0;
            int totalBranches = 0;
            int collectedBranches = 0;
            Stack<char> collectedBranchesChars = new Stack<char>();

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = input[col];
                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (pond[row, col] >= 'a' && pond[row, col] <= 'z')
                    {
                        totalBranches++;
                    }
                }
            }

            while (collectedBranches < totalBranches)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                int beaverOldRow = beaverRow;
                int beaverOldCol = beaverCol;
                switch (input)
                {
                    case "up":
                        beaverRow--;
                        break;
                    case "down":
                        beaverRow++;
                        break;
                    case "left":
                        beaverCol--;
                        break;
                    case "right":
                        beaverCol++;
                        break;
                }

                if (beaverRow >= 0 && beaverRow < pondSize && beaverCol >= 0 && beaverCol < pondSize)
                {
                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverOldRow, beaverOldCol] = '-';
                        pond[beaverRow, beaverCol] = '-';
                        if (input == "up")
                        {
                            if (beaverRow - 1 < 0)
                            {
                                beaverRow = pondSize - 1;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                            else if(beaverRow - 1 > 0)
                            {
                                beaverRow = 0;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                        }
                        else if (input == "down")
                        {
                            if (beaverRow + 1 >= pondSize)
                            {
                                beaverRow = 0;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                            else if(beaverRow + 1 < pondSize)
                            {
                                beaverRow = pondSize - 1;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                        }
                        else if (input == "left")
                        {
                            if (beaverCol - 1 < 0)
                            {
                                beaverCol = pondSize - 1;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                            else if(beaverCol - 1 > 0)
                            {
                                beaverCol = 0;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                        }
                        else if (input == "right")
                        {
                            if (beaverCol + 1 >= pondSize)
                            {
                                beaverCol = 0;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                            else if(beaverCol + 1 < pondSize)
                            {
                                beaverCol = pondSize - 1;
                                if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                                {
                                    collectedBranches++;
                                    collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                                else
                                {
                                    pond[beaverRow, beaverCol] = 'B';
                                }
                            }
                        }
                    }
                    else if (pond[beaverRow, beaverCol] == '-')
                    {
                        pond[beaverOldRow, beaverOldCol] = '-';
                        pond[beaverRow, beaverCol] = 'B';
                    }
                    else if (pond[beaverRow, beaverCol] >= 'a' && pond[beaverRow, beaverCol] <= 'z')
                    {
                        pond[beaverOldRow, beaverOldCol] = '-';
                        collectedBranchesChars.Push(pond[beaverRow, beaverCol]);
                        collectedBranches++;
                        pond[beaverRow, beaverCol] = 'B';
                    }
                    else if (pond[beaverRow, beaverCol] >= 'A' && pond[beaverRow, beaverCol] <= 'Z')
                    {
                        pond[beaverOldRow, beaverOldCol] = '-';
                        pond[beaverRow, beaverCol] = 'B';
                    }
                }
                else
                {
                    beaverRow = beaverOldRow;
                    beaverCol = beaverOldCol;
                    if (collectedBranchesChars.Count > 0)
                    {
                        collectedBranchesChars.Pop();
                        totalBranches--;
                        collectedBranches--;
                    }
                }
            }

            List<char> reverseCollectedCharBranches = new List<char>();
            foreach (var branch in collectedBranchesChars)
            {
                reverseCollectedCharBranches.Add(branch);
            }
            reverseCollectedCharBranches.Reverse();

            if (collectedBranches == totalBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {totalBranches} wood branches: " + String.Join(", ", reverseCollectedCharBranches) + ".");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches - collectedBranches} branches left.");
            }

            PrintMatrix(pond);
        }
        static void PrintMatrix(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

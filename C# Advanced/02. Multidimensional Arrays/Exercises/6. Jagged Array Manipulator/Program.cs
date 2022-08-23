using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = ReadJaggedArray(numberOfRows);

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                bool areEqual = false;
                bool flag = false;
                if (row + 1 < jaggedArray.Length && jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    areEqual = true;
                }
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (areEqual)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                    else if(!areEqual && row + 1 < jaggedArray.Length)
                    {
                        jaggedArray[row][col] /= 2;
                        if (!flag)
                        {
                            flag = true;
                            for (int col02 = 0; col02 < jaggedArray[row + 1].Length; col02++)
                            {
                                jaggedArray[row + 1][col02] /= 2;
                            }
                        }
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                int row = Convert.ToInt32(commands[1]);
                int column = Convert.ToInt32(commands[2]);
                int value = Convert.ToInt32(commands[3]);
                switch (mainCommand)
                {
                    case "Add":
                        bool isOver = false;
                        if (row < 0 || column < 0)
                        {
                            continue;
                        }
                        for (int currRow = 0; currRow < jaggedArray.Length; currRow++)
                        {
                            if (isOver)
                            {
                                break;
                            }
                            for (int currCol = 0; currCol < jaggedArray[currRow].Length; currCol++)
                            {
                                if (currRow == row && currCol == column)
                                {
                                    jaggedArray[row][column] += value;
                                    isOver = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case "Subtract":
                        isOver = false;
                        if (row < 0 || column < 0)
                        {
                            continue;
                        }
                        for (int currRow = 0; currRow < jaggedArray.Length; currRow++)
                        {
                            if (isOver)
                            {
                                break;
                            }
                            for (int currCol = 0; currCol < jaggedArray[currRow].Length; currCol++)
                            {
                                if (currRow == row && currCol == column)
                                {
                                    jaggedArray[row][column] -= value;
                                    isOver = true;
                                    break;
                                }
                            }
                        }
                        break;
                }
            }

            PrintFinalState(jaggedArray);
        }
        static int[][] PrintFinalState(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
            return jaggedArray;
        }

        static int[][] ReadJaggedArray(int numberOfRows)
        {
            int[][] jaggedArray = new int[numberOfRows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[row] = new int[rowElements.Length];
                for (int col = 0; col < rowElements.Length; col++)
                {
                    jaggedArray[row][col] = rowElements[col];
                }
            }
            return jaggedArray;
        }
    }

}

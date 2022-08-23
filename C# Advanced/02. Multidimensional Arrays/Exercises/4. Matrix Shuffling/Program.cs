using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsSize = matrixSize[0];
            int colsSize = matrixSize[1];
            string[,] matrix = new string[rowsSize, colsSize];

            for (int row = 0; row < rowsSize; row++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < colsSize; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                string[] commands = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                if (commands.Length != 5 || mainCommand != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (mainCommand == "swap")
                {
                    int row01 = Convert.ToInt32(commands[1]);
                    int col01 = Convert.ToInt32(commands[2]);
                    int row02 = Convert.ToInt32(commands[3]);
                    int col02 = Convert.ToInt32(commands[4]);
                    if ((row01 >= matrix.GetLength(0)) || (row02 >= matrix.GetLength(0)) ||
                        (col01 >= matrix.GetLength(1)) || (col02 >= matrix.GetLength(1)))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        string firstElementToSwap = matrix[row01, col01];
                        string secondElementToSwap = matrix[row02, col02];
                        matrix[row01, col01] = secondElementToSwap;
                        matrix[row02, col02] = firstElementToSwap;
                        for (int row = 0; row < rowsSize; row++)
                        {
                            for (int col = 0; col < colsSize; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

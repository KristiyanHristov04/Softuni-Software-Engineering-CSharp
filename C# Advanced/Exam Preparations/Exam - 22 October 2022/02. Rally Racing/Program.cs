using System;
using System.Linq;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            string racingCarNumber = Console.ReadLine();
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            bool isReachedFinish = false;
            int coveredKilometers = 0;
            int carRowPosition = 0;
            int carColPosition = 0;
            Tunnel firstTunnel = FindTunnelPosition(matrix, true);
            Tunnel secondTunnel = FindTunnelPosition(matrix, false);

            while (!isReachedFinish)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    break;
                }

                switch (direction)
                {
                    case "up":
                        carRowPosition--;
                        break;
                    case "down":
                        carRowPosition++;
                        break;
                    case "left":
                        carColPosition--;
                        break;
                    case "right":
                        carColPosition++;
                        break;
                }

                if (matrix[carRowPosition, carColPosition] == 'T' && carRowPosition == firstTunnel.Row && carColPosition == firstTunnel.Col)
                {
                    //Move to the second Tunnel
                    matrix[carRowPosition, carColPosition] = '.';
                    carRowPosition = secondTunnel.Row;
                    carColPosition = secondTunnel.Col;
                    matrix[carRowPosition, carColPosition] = '.';
                    coveredKilometers += 30;
                }
                else if (matrix[carRowPosition, carColPosition] == 'T' && carRowPosition == secondTunnel.Row && carColPosition == secondTunnel.Col)
                {
                    //Move to the first Tunnel
                    matrix[carRowPosition, carColPosition] = '.';
                    carRowPosition = firstTunnel.Row;
                    carColPosition = firstTunnel.Col;
                    matrix[carRowPosition, carColPosition] = '.';
                    coveredKilometers += 30;
                }
                else if (matrix[carRowPosition, carColPosition] == 'F')
                {
                    isReachedFinish = true;
                    coveredKilometers += 10;
                    Console.WriteLine($"Racing car {racingCarNumber} finished the stage!");
                }
                else if (matrix[carRowPosition, carColPosition] == '.')
                {
                    coveredKilometers += 10;
                }
            }
            if (!isReachedFinish)
            {
                Console.WriteLine($"Racing car {racingCarNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {coveredKilometers} km.");
            matrix[carRowPosition, carColPosition] = 'C';
            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
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
        static Tunnel FindTunnelPosition(char[,] matrix, bool isFirst)
        {
            Tunnel tunnel = new Tunnel();
            bool isFound = false;
            bool isFirstTime = true;
            if (!isFirst)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (isFound)
                    {
                        break;
                    }
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'T' && !isFirstTime)
                        {
                            tunnel.Row = row;
                            tunnel.Col = col;
                            isFound = true;
                            break;
                        }
                        else if(matrix[row, col] == 'T' && isFirstTime)
                        {
                            isFirstTime = false;
                        }
                    }
                }
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
                        if (matrix[row, col] == 'T')
                        {
                            tunnel.Row = row;
                            tunnel.Col = col;
                            isFound = true;
                            break;
                        }
                    }
                }
            }
            return tunnel;
        }
    }
    class Tunnel
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}

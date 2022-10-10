using System;
using System.Collections.Generic;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BloomSpots> blooms = new List<BloomSpots>();
            string[] gardenSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int gardenRows = Convert.ToInt32(gardenSize[0]);
            int gardenCols = Convert.ToInt32(gardenSize[1]);
            int[,] garden = new int[gardenRows, gardenCols];

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int currentRow = Convert.ToInt32(tokens[0]);
                int currentCol = Convert.ToInt32(tokens[1]);
                if (IsInBounds(currentRow,currentCol, gardenRows, gardenCols))
                {
                    garden[currentRow, currentCol] = 1;
                    BloomSpots currentBloomSpot = new BloomSpots(currentRow, currentCol);
                    blooms.Add(currentBloomSpot);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int i = 0; i < blooms.Count; i++)
            {
                int currentBloomSpotRow = blooms[i].Row;
                int currentBloomSpotCol = blooms[i].Col;
                int currentCol = 0;
                while (currentCol < garden.GetLength(1))
                {
                    if (currentCol != currentBloomSpotCol)
                    {
                        garden[currentBloomSpotRow, currentCol]++;
                    }
                    currentCol++;
                }

                int currentRow = 0;
                while (currentRow < garden.GetLength(0))
                {
                    if (currentRow != currentBloomSpotRow)
                    {
                        garden[currentRow, currentBloomSpotCol]++;
                    }
                    currentRow++;
                }
            }
            PrintFinalGarden(garden);
        }

        static void PrintFinalGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write($"{garden[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsInBounds(int currentRow, int currentCol, int gardenRows, int gardenCols)
        {
            return currentRow >= 0 && currentRow < gardenRows && currentCol >= 0 && currentCol < gardenCols;
        }
    }
    class BloomSpots
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public BloomSpots(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}

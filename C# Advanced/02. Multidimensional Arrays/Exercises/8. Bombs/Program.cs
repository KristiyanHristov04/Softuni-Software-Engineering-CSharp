using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = MatrixElements(matrixSize);
            List<Bomb> bombs = Bombs();

            //TODO:
            while (bombs.Count > 0)
            {
                int bombRow = bombs[0].Row;
                int bombCol = bombs[0].Column;
                bombs.Remove(bombs[0]);

                if (matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }
                else
                {
                    int bombValue = matrix[bombRow, bombCol];
                    //Row - 1
                    if (bombRow - 1 >= 0 && bombRow - 1 < matrixSize)
                    {
                        if (bombCol - 1 < matrixSize && bombCol - 1 >= 0)
                        {
                            if (matrix[bombRow - 1, bombCol -1 ] > 0)
                            {
                                matrix[bombRow - 1, bombCol - 1] -= bombValue;
                            }
                        }
                        if (bombCol < matrixSize && bombCol >= 0)
                        {
                            if (matrix[bombRow - 1, bombCol] > 0)
                            {
                                matrix[bombRow - 1, bombCol] -= bombValue;
                            }
                        }
                        if (bombCol + 1 < matrixSize && bombCol + 1 >= 0)
                        {
                            if (matrix[bombRow - 1, bombCol + 1] > 0)
                            {
                                matrix[bombRow - 1, bombCol + 1] -= bombValue;
                            }
                        }
                    }
                    //Row
                    if (bombRow >= 0 && bombRow < matrixSize)
                    {
                        if (bombCol - 1 < matrixSize && bombCol - 1 >= 0)
                        {
                            if (matrix[bombRow, bombCol - 1] > 0)
                            {
                                matrix[bombRow, bombCol - 1] -= bombValue;
                            }
                        }
                        if (bombCol < matrixSize && bombCol >= 0)
                        {
                            if (matrix[bombRow, bombCol] > 0)
                            {
                                matrix[bombRow, bombCol] -= bombValue;
                            }
                        }
                        if (bombCol + 1 < matrixSize && bombCol + 1 >= 0)
                        {
                            if (matrix[bombRow, bombCol + 1] > 0)
                            {
                                matrix[bombRow, bombCol + 1] -= bombValue;
                            }
                        }
                    }
                    //Row + 1
                    if (bombRow + 1 >= 0 && bombRow + 1 < matrixSize)
                    {
                        if (bombCol - 1 < matrixSize && bombCol - 1 >= 0)
                        {
                            if (matrix[bombRow + 1, bombCol - 1] > 0)
                            {
                                matrix[bombRow + 1, bombCol - 1] -= bombValue;
                            }
                        }
                        if (bombCol < matrixSize && bombCol >= 0)
                        {
                            if (matrix[bombRow + 1, bombCol] > 0)
                            {
                                matrix[bombRow + 1, bombCol] -= bombValue;
                            }
                        }
                        if (bombCol + 1 < matrixSize && bombCol + 1 >= 0)
                        {
                            if (matrix[bombRow + 1, bombCol + 1] > 0)
                            {
                                matrix[bombRow + 1, bombCol + 1] -= bombValue;
                            }
                        }
                    }
                    
                    
                }
            }
            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        static int[,] MatrixElements(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixElements[col];
                }
            }
            return matrix;
        }

        static List<Bomb> Bombs()
        {
            List<Bomb> bombs = new List<Bomb>();
            int[] bombPlaces = Console.ReadLine().Split(new char[] { ' ', ',' }).Select(int.Parse).ToArray();
            for (int i = 0; i < bombPlaces.Length; i += 2)
            {
                int currBombRow = bombPlaces[i];
                int currBombCol = bombPlaces[i + 1];
                Bomb newBomb = new Bomb(currBombRow, currBombCol);
                bombs.Add(newBomb);
            }
            return bombs;
        }
    }
    class Bomb
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Bomb(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}

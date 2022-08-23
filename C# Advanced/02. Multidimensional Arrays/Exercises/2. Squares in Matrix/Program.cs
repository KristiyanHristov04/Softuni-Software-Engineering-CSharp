using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];
            char[,] matrix = new char[rowSize, colSize];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            //Main Logic

            //5 6
            //1 1 1 0 1 1
            //0 1 1 1 0 0
            //1 0 1 0 0 1
            //0 0 0 1 1 1
            //1 1 1 0 1 0


            int equalChars = 0;

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (col + 1 < colSize && matrix[row, col] == matrix[row, col + 1])
                    {
                        char lookingChar01 = matrix[row, col];
                        if (row + 1 < rowSize && matrix[row + 1, col] == matrix[row + 1, col + 1])
                        {
                            char lookingChar02 = matrix[row + 1, col];
                            if (lookingChar01 == lookingChar02)
                            {
                                equalChars++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(equalChars);
        }
    }
}

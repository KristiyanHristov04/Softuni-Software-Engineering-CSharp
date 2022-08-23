using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = Convert.ToInt32(Console.ReadLine());
            int rows = rowsAndCols;
            int cols = rowsAndCols;

            char[,] matrix = new char[rows, cols];

            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] inputCharred = input.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputCharred[col];
                }
            }

            char lookingSymbol = Convert.ToChar(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == lookingSymbol)
                    {
                        int rowWithSymbol = row;
                        int colWithSymbol = col;

                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{lookingSymbol} does not occur in the matrix");
        }
    }
}

using System;
using System.Linq;
namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = Convert.ToInt32(Console.ReadLine());
            long[][] jaggedArray = new long[rows][];
            jaggedArray[0] = new long[1] { 1 };
            for (long row = 1; row < rows; row++)
            {
                jaggedArray[row] = new long[jaggedArray[row - 1].Length + 1];
                for (long col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row - 1].Length > col)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col];
                    }
                    if (col > 0)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col - 1];
                    }
                    
                }
            }

            for (long row = 0; row < jaggedArray.Length; row++)
            {
                for (long col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

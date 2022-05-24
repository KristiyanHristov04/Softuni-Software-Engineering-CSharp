using System;

namespace SoftUniNestedLoopsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Number Pyramid
            int n = Convert.ToInt32(Console.ReadLine());
            int currentNumber = 1;
            bool isBigger = false;
            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (currentNumber > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(currentNumber + " ");
                    currentNumber++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}

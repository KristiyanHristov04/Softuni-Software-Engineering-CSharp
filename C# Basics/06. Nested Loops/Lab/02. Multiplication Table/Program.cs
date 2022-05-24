using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Multiplication Table
            for (int a = 1; a <= 10; a++)
            {
                for (int b = 1; b <= 10; b++)
                {
                    int result = a * b;
                    Console.WriteLine($"{a} * {b} = {result}");
                }
            }
        }
    }
}

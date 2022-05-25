using System;

namespace Sum_Of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                char symbol = Convert.ToChar(Console.ReadLine());
                totalSum += Convert.ToInt32(symbol);
            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}

using System;

namespace Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int biggestDivisibleNumber = 0;
            bool hasDivisible = false;
            if (number % 2 == 0)
            {
                biggestDivisibleNumber = 2;
                hasDivisible = true;
            }
            if(number % 3 == 0)
            {
                biggestDivisibleNumber = 3;
                hasDivisible = true;
            }
            if (number % 6 == 0)
            {
                biggestDivisibleNumber = 6;
                hasDivisible = true;
            }
            if (number % 7 == 0)
            {
                biggestDivisibleNumber = 7;
                hasDivisible = true;
            }
            if (number % 10 == 0)
            {
                biggestDivisibleNumber = 10;
                hasDivisible = true;
            }
            if (hasDivisible)
            {
                Console.WriteLine($"The number is divisible by {biggestDivisibleNumber}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}

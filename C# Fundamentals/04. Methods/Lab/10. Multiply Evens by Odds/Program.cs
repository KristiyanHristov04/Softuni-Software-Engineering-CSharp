using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int evenSum = GetSumOfEvenDigits(input);
            int oddSum = GetSumOfOddDigits(input);
            int totalSum = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(totalSum);
        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
        static int GetSumOfEvenDigits(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    continue;
                }
                if (Math.Abs(Convert.ToInt32(input[i])) % 2 == 0)
                {
                    sum += Math.Abs(Convert.ToInt32(input[i]) - '0');
                }
            }
            return sum;
        }
        static int GetSumOfOddDigits(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    continue;
                }
                else if (Math.Abs(Convert.ToInt32(input[i])) % 2 != 0)
                {
                    sum += Math.Abs(Convert.ToInt32(input[i]) - '0');
                }
            }
            return sum;
        }
    }
}

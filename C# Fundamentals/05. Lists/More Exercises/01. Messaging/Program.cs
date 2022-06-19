using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int numbersCount = numbers.Count();
            string text = Console.ReadLine();
            string finalText = String.Empty;
            int removedLetters = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                string currentNumber = numbers[i].ToString();
                int sum = 0;
                for (int j = 0; j < currentNumber.Length; j++)
                {
                    sum += currentNumber[j] - '0';
                }

                while (sum > text.Length)
                {
                    sum -= text.Length;
                }

                finalText += text[sum + removedLetters];
                removedLetters++;
            }
            Console.WriteLine(finalText);

        }
    }
}

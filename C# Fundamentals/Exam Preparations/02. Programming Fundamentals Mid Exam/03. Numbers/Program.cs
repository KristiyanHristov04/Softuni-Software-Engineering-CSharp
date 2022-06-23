using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double averageNumber = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                averageNumber += numbers[i];
            }
            averageNumber /= numbers.Count;

            List<int> greaterNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageNumber)
                {
                    greaterNumbers.Add(numbers[i]);
                }
            }

            greaterNumbers.Sort();
            List<int> topNumbers = new List<int>();
            int topNumbersCounter = 0;
            for (int i = greaterNumbers.Count - 1; i >= 0; i--)
            {                
                topNumbers.Add(greaterNumbers[i]);
                topNumbersCounter++;
                if (topNumbersCounter == 5)
                {
                    break;
                }
            }
            if (topNumbers.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            Console.WriteLine(String.Join(" ", topNumbers));
        }
    }
}

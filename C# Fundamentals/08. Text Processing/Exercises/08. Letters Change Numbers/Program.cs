using System;
using System.Collections.Generic;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<double> allValues = new List<double>();
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool isLeftSide = true;
                string actualMiddleNumber = string.Empty;
                string currentWord = input[i];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    if (currentWord[j] >= '0' && currentWord[j] <= '9')
                    {
                        actualMiddleNumber += currentWord[j];
                    }
                }

                result = Convert.ToDouble(actualMiddleNumber);

                for (int j = 0; j < currentWord.Length; j++)
                {
                    if ((currentWord[j] < '0' || currentWord[j] > '9') && isLeftSide)
                    {
                        if (currentWord[j] >= 'A' && currentWord[j] <= 'Z')
                        {
                            int charPositionInAlphabet = currentWord[j] - 64;
                            result /= charPositionInAlphabet;
                        }
                        else if (currentWord[j] >= 'a' && currentWord[j] <= 'z')
                        {
                            int charPositionInAlphabet = currentWord[j] - 96;
                            result *= charPositionInAlphabet;
                        }
                    }
                    else if ((currentWord[j] < '0' || currentWord[j] > '9') && !isLeftSide)
                    {
                        if (currentWord[j] >= 'A' && currentWord[j] <= 'Z')
                        {
                            int charPositionInAlphabet = currentWord[j] - 64;
                            result -= charPositionInAlphabet;
                            allValues.Add(result);
                        }
                        else if (currentWord[j] >= 'a' && currentWord[j] <= 'z')
                        {
                            int charPositionInAlphabet = currentWord[j] - 96;
                            result += charPositionInAlphabet;
                            allValues.Add(result);
                        }
                    }
                    isLeftSide = false;

                }
            }
            double endResult = 0;
            foreach (var value in allValues)
            {
                endResult += value;
            }
            Console.WriteLine($"{endResult:f2}");
        }
    }
}

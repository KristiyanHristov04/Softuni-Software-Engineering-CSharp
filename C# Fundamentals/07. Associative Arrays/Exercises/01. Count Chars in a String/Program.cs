using System;
using System.Collections.Generic;
namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, int> result = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    if (result.ContainsKey(currentWord[j]))
                    {
                        result[currentWord[j]]++;
                    }
                    else
                    {
                        result.Add(currentWord[j], 1);
                    }
                }
            }

            foreach (var @char in result)
            {
                Console.WriteLine($"{@char.Key} -> {@char.Value}");
            }
        }
    }
}

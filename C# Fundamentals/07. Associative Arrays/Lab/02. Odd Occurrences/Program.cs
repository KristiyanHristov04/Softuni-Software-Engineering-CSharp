using System;
using System.Collections.Generic;
namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (result.ContainsKey(input[i].ToLower()))
                {
                    result[input[i].ToLower()]++;
                }
                else
                {
                    result.Add(input[i].ToLower(), 1);
                }
            }

            foreach (var item in result)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }

        }
    }
}

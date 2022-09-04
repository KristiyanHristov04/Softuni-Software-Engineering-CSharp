using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> myDictionary = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (myDictionary.ContainsKey(text[i]))
                {
                    myDictionary[text[i]]++;
                }
                else
                {
                    myDictionary.Add(text[i], 1);
                }
            }

            foreach (var ch in myDictionary)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}

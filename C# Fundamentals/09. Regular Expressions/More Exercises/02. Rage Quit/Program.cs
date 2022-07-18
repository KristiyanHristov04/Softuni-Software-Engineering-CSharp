using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace _02._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([^\d]+)([0-9]+)";
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value.ToUpper();
                int repeatTimes = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < repeatTimes; i++)
                {
                    sb.Append(text);
                }
            }
            int numberOfUniqueSymbols = 0;
            List<char> uniqueSymbols = new List<char>();
            for (int i = 0; i < sb.Length; i++)
            {
                if (!uniqueSymbols.Contains(sb[i]))
                {
                    numberOfUniqueSymbols++;
                    uniqueSymbols.Add(sb[i]);
                }
            }
            Console.WriteLine($"Unique symbols used: {numberOfUniqueSymbols}");
            Console.WriteLine(sb.ToString());
        }
    }
}

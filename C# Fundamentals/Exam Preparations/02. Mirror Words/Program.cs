using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mirroredPairs = new List<string>();
            string text = Console.ReadLine();
            string pattern = @"(?<separator>\@|\#)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            MatchCollection matches = Regex.Matches(text, pattern);
            int validPairs = 0;
            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;
                string secondWordReversed = string.Empty;
                for (int i = secondWord.Length - 1; i >= 0; i--)
                {
                    secondWordReversed += secondWord[i];
                }
                if (firstWord == secondWordReversed)
                {
                    string mirroredPair = firstWord + " <=> " + secondWord;
                    mirroredPairs.Add(mirroredPair);
                }
                validPairs++;
            }

            if (validPairs != 0)
            {
                Console.WriteLine($"{validPairs} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirroredPairs.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirroredPairs));
            }
            else if(mirroredPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}

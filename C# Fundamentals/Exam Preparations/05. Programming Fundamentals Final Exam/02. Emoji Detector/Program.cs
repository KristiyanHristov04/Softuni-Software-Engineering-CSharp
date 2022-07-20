using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> validEmojis = new List<string>();
            int foundEmojis = 0;
            string input = Console.ReadLine();
            int coolThreshold = 1;
            string findDigitsPattern = @"(?<digits>[0-9])";
            string findValidEmojiPattern = @"(\*{2}|\:{2})(?<emoji>[A-Z]{1}[a-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, findDigitsPattern);
            foreach (Match match in matches)
            {
                coolThreshold *= Convert.ToInt32(match.Groups["digits"].Value);
            }

            MatchCollection matches2 = Regex.Matches(input, findValidEmojiPattern);
            foreach (Match match2 in matches2)
            {
                string currentEmojiBeginning = match2.Groups[1].Value;
                string currentEmoji = match2.Groups["emoji"].Value;
                int currentEmojiCoolnes = 0;
                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    currentEmojiCoolnes += currentEmoji[i];
                }

                if (currentEmojiCoolnes >= coolThreshold)
                {
                    currentEmoji = currentEmoji.Insert(0, currentEmojiBeginning);
                    currentEmoji = currentEmoji.Insert(currentEmoji.Length, currentEmojiBeginning);
                    validEmojis.Add(currentEmoji);
                }
                foundEmojis++;
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{foundEmojis} emojis found in the text. The cool ones are:");
            foreach (var emoji in validEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}

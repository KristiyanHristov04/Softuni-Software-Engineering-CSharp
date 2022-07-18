using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> participants = new Dictionary<string, int>();

            for (int i = 0; i < names.Count; i++)
            {
                participants.Add(names[i], 0);
            }
            string pattern = @"([^\W]\w*)";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }
                string text = string.Empty;
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    text += match.Groups[1].Value;
                }
                
                char[] charText = text.ToCharArray();
                int kilometersRan = 0;
                string name = string.Empty;
                for (int i = 0; i < charText.Length; i++)
                {
                    if (char.IsDigit(charText[i]))
                    {
                        kilometersRan += Convert.ToInt32(charText[i].ToString());
                    }
                    else if(char.IsLetter(charText[i]))
                    {
                        name += charText[i];
                    }
                }
                if (participants.ContainsKey(name))
                {
                    participants[name] += kilometersRan;
                }
            }
            int topThreeCount = 1;
            foreach (var participant in participants.OrderByDescending(x => x.Value))
            {               
                if (topThreeCount == 1)
                {
                    Console.WriteLine($"1st place: {participant.Key}");
                }
                else if(topThreeCount == 2)
                {
                    Console.WriteLine($"2nd place: {participant.Key}");
                }
                else if(topThreeCount == 3)
                {
                    Console.WriteLine($"3rd place: {participant.Key}");
                }
                topThreeCount++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> destinations = new List<string>();
            string pattern = @"(?<separator>=|\/)(?<locations>[A-Z]{1}[A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                destinations.Add(match.Groups["locations"].Value);
            }

            int travelPoints = 0;

            for (int i = 0; i < destinations.Count; i++)
            {
                travelPoints += destinations[i].Length;
            }

            Console.WriteLine("Destinations: " + String.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}

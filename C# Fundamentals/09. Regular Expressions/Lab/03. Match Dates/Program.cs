using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(?<day>[0-9]{2})([ -/])(?<month>[A-Z][A-z]{2})\1(?<year>[0-9]{4})");
            var result = regex.Matches(input);
            foreach (Match date in result)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
        }
    }
}

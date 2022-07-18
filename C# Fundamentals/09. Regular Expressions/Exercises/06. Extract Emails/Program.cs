using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> validEmails = new List<string>();
            string input = Console.ReadLine();    
            string emailPattern = @"((^|(?<=\s))(?<email>[a-z0-9]+[\.\-_]{0,1}[a-z0-9]+\@[a-z]+[\-]*[a-z]*\.[a-z]+(\.[a-z]+)*))";
            MatchCollection matchCollection = Regex.Matches(input, emailPattern);
            foreach (Match match in matchCollection)
            {
                validEmails.Add(match.Groups["email"].Value);
            }

            foreach (var validEmail in validEmails)
            {
                Console.WriteLine(validEmail);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> digits = new List<int>();
            int n = Convert.ToInt32(Console.ReadLine());
            string pattern = @"\!(?<command>[A-Z]{1}[a-z]{2,})\!\:\[(?<message>[A-Za-z]{8,})\]";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string message = match.Groups["message"].Value;
                    char[] messageCharred = message.ToCharArray();
                    
                    for (int j = 0; j < messageCharred.Length; j++)
                    {
                        int currNumber = Convert.ToInt32(messageCharred[j]);
                        digits.Add(currNumber);
                    }

                    Console.WriteLine(command + ": " + string.Join(" ", digits));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}

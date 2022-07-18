using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _04._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> goodKids = new List<string>();
            int decreptionKey = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                char[] text = input.ToCharArray();
                string decryptedMessage = string.Empty;
                for (int i = 0; i < text.Length; i++)
                {
                    decryptedMessage += (Convert.ToChar((text[i] - decreptionKey))).ToString();
                }
                string pattern = @"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*?!(?<behavior>G|N)!";
                Match match = Regex.Match(decryptedMessage, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string behavior = match.Groups["behavior"].Value;
                    if (behavior == "G")
                    {
                        goodKids.Add(name);
                    }
                }
            }
            foreach (var goodKid in goodKids)
            {
                Console.WriteLine(goodKid);
            }
        }
    }
}

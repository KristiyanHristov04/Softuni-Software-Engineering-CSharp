using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[^@!-:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>[0-9]+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>[0-9]+)";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            int numberOfMessages = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfMessages; i++)
            {
                string cryptedMessage = Console.ReadLine();
                int lettersCount = 0;
                for (int j = 0; j < cryptedMessage.Length; j++)
                {
                    if (cryptedMessage[j].ToString().ToLower() == "s" ||
                        cryptedMessage[j].ToString().ToLower() == "t" ||
                        cryptedMessage[j].ToString().ToLower() == "a" ||
                        cryptedMessage[j].ToString().ToLower() == "r")
                    {
                        lettersCount++;
                    }
                }
                char[] cryptedDecreasedMessage = cryptedMessage.ToCharArray();
                string encryptedMessage = string.Empty;
                for (int j = 0; j < cryptedDecreasedMessage.Length; j++)
                {
                    char currChar = Convert.ToChar(Convert.ToInt32(cryptedDecreasedMessage[j]) - lettersCount);
                    encryptedMessage += currChar.ToString();
                }
                Match match = Regex.Match(encryptedMessage, pattern);
                if (match.Success)
                {
                    string attackType = match.Groups["attackType"].Value;
                    string planetName = match.Groups["name"].Value;
                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if(attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            if (attackedPlanets.Count != 0)
            {
                foreach (var attackedPlanet in attackedPlanets)
                {
                    Console.WriteLine($"-> {attackedPlanet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count != 0)
            {
                foreach (var destroyedPlanet in destroyedPlanets)
                {
                    Console.WriteLine($"-> {destroyedPlanet}");
                }
            }
        }
    }
}

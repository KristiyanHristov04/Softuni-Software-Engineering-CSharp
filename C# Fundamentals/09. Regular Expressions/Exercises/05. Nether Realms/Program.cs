using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Demon> demons = new SortedDictionary<string, Demon>();
            string[] demonNames = Console.ReadLine().Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string healthPattern = @"(?<health>[^+\-*\.\d\/])";
            string digitsPattern = @"(?<digits>[\-\+]{0,1}\d+[\.\d]*)";
            string arithmeticSymbolsPattern = @"(?<arithmeticSymbols>[\*\/])";
            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemonName = demonNames[i];
                int currentDemonHealth = 0;
                string healthSymbols = string.Empty;
                Regex regex = new Regex(healthPattern);
                MatchCollection matches = regex.Matches(currentDemonName);

                foreach (Match match in matches)
                {
                    healthSymbols += match.Groups["health"].Value;
                }
                for (int j = 0; j < healthSymbols.Length; j++)
                {
                    currentDemonHealth += healthSymbols[j];
                }

                Regex regex02 = new Regex(digitsPattern);
                MatchCollection matches02 = regex02.Matches(currentDemonName);
                double currDemonDamage = 0;

                foreach (Match match02 in matches02)
                {
                    currDemonDamage += Convert.ToDouble(match02.Groups["digits"].Value);
                }

                MatchCollection matches03 = Regex.Matches(currentDemonName, arithmeticSymbolsPattern);
                string arithmeticSymbols = string.Empty;

                foreach (Match match03 in matches03)
                {
                    arithmeticSymbols += match03.Groups["arithmeticSymbols"].Value;
                }

                if (arithmeticSymbols.Length != 0)
                {
                    for (int j = 0; j < arithmeticSymbols.Length; j++)
                    {
                        if (arithmeticSymbols[j] == '*')
                        {
                            currDemonDamage *= 2;
                        }
                        else if (arithmeticSymbols[j] == '/')
                        {
                            currDemonDamage /= 2;
                        }
                    }
                }

                Demon demon = new Demon(currentDemonHealth, currDemonDamage);
                demons.Add(currentDemonName, demon);     
            }
            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, {demon.Value.Damage:f2} damage");
            }
        }
    }
    class Demon
    {
        public int Health { get; set; }
        public double Damage { get; set; }
        public Demon(int health, double damage)
        {
            this.Health = health;
            this.Damage = damage;
        }
    }
}

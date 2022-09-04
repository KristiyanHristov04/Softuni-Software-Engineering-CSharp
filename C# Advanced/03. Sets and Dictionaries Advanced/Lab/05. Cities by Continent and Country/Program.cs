using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> myDictionary = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (myDictionary.ContainsKey(continent))
                {
                    if (myDictionary[continent].ContainsKey(country))
                    {
                        myDictionary[continent][country].Add(city);
                    }
                    else
                    {
                        myDictionary[continent].Add(country, new List<string>());
                        myDictionary[continent][country].Add(city);
                    }
                }
                else
                {
                    myDictionary.Add(continent, new Dictionary<string, List<string>>());
                    myDictionary[continent].Add(country, new List<string>());
                    myDictionary[continent][country].Add(city);
                }
            }

            foreach (var continent in myDictionary)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

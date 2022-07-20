using System;
using System.Collections.Generic;
namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, TownInformation> cities = new Dictionary<string, TownInformation>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Sail")
                {
                    break;
                }
                string[] commands = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string city = commands[0];
                int population = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);
                if (cities.ContainsKey(city))
                {
                    cities[city].Population += population;
                    cities[city].Gold += gold;
                }
                else
                {
                    TownInformation currTownInfo = new TownInformation(population, gold);
                    cities.Add(city, currTownInfo);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string town = commands[1];
                switch (mainCommand)
                {
                    case "Plunder":
                        int people = Convert.ToInt32(commands[2]);
                        int gold = Convert.ToInt32(commands[3]);
                        cities[town].Population -= people;
                        cities[town].Gold -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                        {
                            cities.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        int gold2 = Convert.ToInt32(commands[2]);
                        if (gold2 < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            cities[town].Gold += gold2;
                            Console.WriteLine($"{gold2} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                        }
                        break;
                }
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    class TownInformation
    {
        public int Population { get; set; }
        public int Gold { get; set; }
        public TownInformation(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }
    }
}

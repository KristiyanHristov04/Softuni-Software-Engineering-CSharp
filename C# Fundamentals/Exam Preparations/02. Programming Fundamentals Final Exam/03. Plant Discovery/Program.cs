using System;
using System.Collections.Generic;
namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PlantInformation> plants = new Dictionary<string, PlantInformation>();
            int numberOfPlants = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfPlants; i++)
            {
                string[] input = Console.ReadLine().Split("<->",StringSplitOptions.RemoveEmptyEntries);
                string currentPlant = input[0];
                int currentPlantRarity = Convert.ToInt32(input[1]);
                if (plants.ContainsKey(currentPlant))
                {
                    plants[currentPlant].Rarity = currentPlantRarity;
                }
                else
                {
                    PlantInformation plant = new PlantInformation(currentPlantRarity);
                    plants.Add(currentPlant, plant);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Exhibition")
                {
                    break;
                }
                input = input.Replace("-", "");
                string[] commands = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string currPlant = commands[1];
                switch (mainCommand)
                {
                    case "Rate:":               
                        double currPlantRating = Convert.ToDouble(commands[2]);
                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rating.Add(currPlantRating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update:":
                        int newRarity = Convert.ToInt32(commands[2]);
                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rarity = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset:":
                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rating.RemoveRange(0, plants[currPlant].Rating.Count);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                double currentPlantRating = 0;
                if (plant.Value.Rating.Count != 0)
                {
                    for (int i = 0; i < plant.Value.Rating.Count; i++)
                    {
                        currentPlantRating += plant.Value.Rating[i];
                    }
                    currentPlantRating /= plant.Value.Rating.Count;
                }  
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {currentPlantRating:f2}");
            }
        }
    }
    class PlantInformation
    {
        public int Rarity { get; set; }
        public List<double> Rating { get; set; } = new List<double>();
        public PlantInformation(int rarity)
        {
            this.Rarity = rarity;
        }
    }
}

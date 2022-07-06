using System;
using System.Collections.Generic;

namespace _03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mainMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            bool isMaterial = false;
            bool isLegendaryFound = false;
            int quantity = 0;

            while (!isLegendaryFound)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i++)
                {
                    if (!isMaterial)
                    {
                        quantity = Convert.ToInt32(input[i]);
                        isMaterial = true;
                    }
                    else
                    {
                        string currentMaterial = input[i].ToLower();
                        if (mainMaterials.ContainsKey(currentMaterial))
                        {
                            mainMaterials[currentMaterial] += quantity;
                            if (mainMaterials[currentMaterial] >= 250 && currentMaterial == "shards")
                            {
                                mainMaterials[currentMaterial] -= 250;
                                Console.WriteLine($"Shadowmourne obtained!");
                                isLegendaryFound = true;
                                break;
                            }
                            else if (mainMaterials[currentMaterial] >= 250 && currentMaterial == "fragments")
                            {
                                mainMaterials[currentMaterial] -= 250;
                                Console.WriteLine("Valanyr obtained!");
                                isLegendaryFound = true;
                                break;
                            }
                            else if (mainMaterials[currentMaterial] >= 250 && currentMaterial == "motes")
                            {
                                mainMaterials[currentMaterial] -= 250;
                                Console.WriteLine("Dragonwrath obtained!");
                                isLegendaryFound = true;
                                break;
                            }
                        }
                        else if (!mainMaterials.ContainsKey(currentMaterial) && (currentMaterial == "shards" || currentMaterial == "fragments" || currentMaterial == "motes"))
                        {
                            if (quantity >= 250)
                            {
                                quantity -= 250;
                                isLegendaryFound = true;
                            }
                            mainMaterials.Add(currentMaterial, quantity);
                            if (isLegendaryFound)
                            {
                                switch (currentMaterial)
                                {
                                    case "shards":
                                        Console.WriteLine("Shadowmourne obtained!");
                                        break;
                                    case "fragments":
                                        Console.WriteLine("Valanyr obtained!");
                                        break;
                                    case "motes":
                                        Console.WriteLine("Dragonwrath obtained!");
                                        break;
                                }

                                break;
                            }


                        }
                        else if (junkMaterials.ContainsKey(currentMaterial))
                        {
                            junkMaterials[currentMaterial] += quantity;
                        }
                        else if (!junkMaterials.ContainsKey(currentMaterial))
                        {
                            junkMaterials.Add(currentMaterial, quantity);
                        }
                        isMaterial = false;
                    }

                }
            }

            foreach (var material in mainMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
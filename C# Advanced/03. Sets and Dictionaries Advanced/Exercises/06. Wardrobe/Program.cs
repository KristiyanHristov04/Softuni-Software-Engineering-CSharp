using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);

                string colour = input[0];
                string[] clothes = input[1].Split(new char[] { ',' });
                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentCloth = clothes[j];
                    if (wardrobe[colour].ContainsKey(currentCloth))
                    {
                        wardrobe[colour][currentCloth]++;
                    }
                    else
                    {
                        wardrobe[colour].Add(currentCloth, 1);
                    }
                }
            }

            string[] neededItem = Console.ReadLine().Split();
            string neededColour = neededItem[0];
            string neededCloth = neededItem[1];

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");
                foreach (var dress in colour.Value)
                {
                    if (dress.Key == neededCloth && colour.Key == neededColour)
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}

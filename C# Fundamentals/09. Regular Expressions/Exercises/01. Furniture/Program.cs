using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            List<string> furnitures = new List<string>();
            string pattern = @">>(?<furniture>[A-za-z]+)<<(?<price>[0-9]+(\.[0-9]+)?)!(?<quantity>[0-9]+)";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string furniture = match.Groups["furniture"].Value;
                    double price = Convert.ToDouble(match.Groups["price"].Value);
                    int quantity = Convert.ToInt32(match.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                    furnitures.Add(furniture);
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var currFurniture in furnitures)
            {
                Console.WriteLine(currFurniture);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");


        }
    }
}

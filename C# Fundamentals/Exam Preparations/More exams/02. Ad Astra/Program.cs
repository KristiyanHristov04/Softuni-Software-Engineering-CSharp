using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodList = new List<Food>();
            string input = Console.ReadLine();
            string pattern = @"(?<separator>\||#)(?<food>[A-Za-z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            int totalCalories = 0;

            foreach (Match match in matches)
            {
                string foodName = match.Groups["food"].Value;
                string expirationDate = match.Groups["expirationDate"].Value;
                int currFoodCalories = int.Parse(match.Groups["calories"].Value);
                totalCalories += currFoodCalories;
                Food currFood = new Food(foodName, expirationDate, currFoodCalories);
                foodList.Add(currFood);
            }

            int days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (var food_ in foodList)
            {
                Console.WriteLine($"Item: {food_.Name}, Best before: {food_.Date}, Nutrition: {food_.Calories}");
            }
        }
        class Food
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public int Calories { get; set; }
            public Food(string name, string date, int calories)
            {
                this.Name = name;
                this.Date = date;
                this.Calories = calories;
            }
        }
    }
}

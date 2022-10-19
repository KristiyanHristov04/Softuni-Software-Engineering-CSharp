using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int leftCalories = 0;
            int eatenMeals = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currentMeal = meals.Peek();
                int currentCaloriesForDay = calories.Peek();
                int currentMealCalories = 0;
                switch (currentMeal)
                {
                    case "salad":
                        currentMealCalories = 350;
                        break;
                    case "soup":
                        currentMealCalories = 490;
                        break;
                    case "pasta":
                        currentMealCalories = 680;
                        break;
                    case "steak":
                        currentMealCalories = 790;
                        break;
                }

                if (currentCaloriesForDay - currentMealCalories > 0)
                {
                    calories.Pop();
                    calories.Push(currentCaloriesForDay - currentMealCalories);
                    meals.Dequeue();
                    eatenMeals++;
                }
                else if (currentCaloriesForDay - currentMealCalories == 0)
                {
                    calories.Pop();
                    meals.Dequeue();
                    eatenMeals++;
                }
                else if (currentCaloriesForDay - currentMealCalories < 0)
                {
                    leftCalories = currentMealCalories - currentCaloriesForDay;
                    calories.Pop();
                    eatenMeals++;
                    meals.Dequeue();
                    if (calories.Count > 0)
                    {
                        currentCaloriesForDay = calories.Pop();
                        calories.Push(currentCaloriesForDay - leftCalories);
                    }
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {eatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}

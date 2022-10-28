using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> citizensAndRebels = new List<IBuyer>();
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = Convert.ToInt32(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    citizensAndRebels.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = Convert.ToInt32(tokens[1]);
                    string groupName = tokens[2];
                    Rebel rebel = new Rebel(name, age, groupName);
                    citizensAndRebels.Add(rebel);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                foreach (var item in citizensAndRebels)
                {
                    if (item.Name == name && item.Type == "Citizen")
                    {
                        item.BuyFood();
                        break;
                    }
                    else if (item.Name == name && item.Type == "Rebel")
                    {
                        item.BuyFood();
                        break;
                    }
                }
            }
            int totalFood = 0;
            foreach (var item in citizensAndRebels)
            {
                totalFood += item.Food;
            }
            Console.WriteLine(totalFood);
        }
    }
}

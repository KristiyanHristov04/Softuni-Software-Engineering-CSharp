using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> CitizensAndPets = new List<IBirthable>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5)
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthDay = tokens[4];
                    Citizen newCitizen = new Citizen(name, age, id, birthDay);
                    CitizensAndPets.Add(newCitizen);
                }
                else if (tokens.Length == 3 && tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthDay = tokens[2];
                    Pet newPet = new Pet(name, birthDay);
                    CitizensAndPets.Add(newPet);
                }
                else if (tokens.Length == 3 && tokens[0] == "Robot")
                {
                    continue;
                }
            }
            string year = Console.ReadLine();
            foreach (var item in CitizensAndPets)
            {
                string itemYear = item.BirthDate.Substring(item.BirthDate.Length - 4);
                if (year == itemYear)
                {
                    Console.WriteLine(item.BirthDate);
                }
            }
        }
    }
}

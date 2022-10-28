using System;

namespace ExplicitInterfaces
{
    using Classes;
    using Interfaces;
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizenPer = new Citizen(name, country, age);
                citizenPer.GetName();
                IResident citizenRes = new Citizen(name, country, age);
                citizenRes.GetName();
            }
        }
    }
}

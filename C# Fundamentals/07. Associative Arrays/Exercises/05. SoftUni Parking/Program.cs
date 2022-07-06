using System;
using System.Collections.Generic;
namespace _05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> parkinglot = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();
                string username = input[1];
                switch (input[0])
                {
                    case "register":                        
                        string plateNumber = input[2];
                        if (parkinglot.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parkinglot[username]}");
                        }
                        else
                        {
                            parkinglot.Add(username, plateNumber);
                            Console.WriteLine($"{username} registered {plateNumber} successfully");
                        }
                        break;
                    case "unregister":
                        if (!parkinglot.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            parkinglot.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                }
            }
            foreach (var user in parkinglot)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}

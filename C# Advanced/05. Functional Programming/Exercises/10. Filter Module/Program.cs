using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    foreach (var filter in allFilters)
                    {
                        invitations.RemoveAll(filter.Value);
                    }
                    Console.WriteLine(String.Join(" ", invitations));
                    break;
                }
                string[] commands = input.Split(';');
                string mainCommand = commands[0];
                string secondCommand = commands[1];
                string thirdCommand = commands[2];
                switch (mainCommand)
                {
                    case "Add filter":
                        if (!allFilters.ContainsKey(secondCommand + thirdCommand))
                        {
                            allFilters.Add(secondCommand + thirdCommand, null);
                        }

                        if (secondCommand == "Starts with")
                        {
                            Predicate<string> predicate = x => x.StartsWith(thirdCommand);
                            allFilters[secondCommand + thirdCommand] = predicate;
                        }
                        else if (secondCommand == "Ends with")
                        {
                            Predicate<string> predicate = x => x.EndsWith(thirdCommand);
                            allFilters[secondCommand + thirdCommand] = predicate;
                        }
                        else if (secondCommand == "Length")
                        {
                            Predicate<string> predicate = x => x.Length == Convert.ToInt32(thirdCommand);
                            allFilters[secondCommand + thirdCommand] = predicate;
                        }
                        else if(secondCommand == "Contains")
                        {
                            Predicate<string> predicate = x => x.Contains(thirdCommand);
                            allFilters[secondCommand + thirdCommand] = predicate;
                        }
                        break;
                    case "Remove filter":
                        if (allFilters.ContainsKey(secondCommand + thirdCommand))
                        {
                            allFilters.Remove(secondCommand + thirdCommand);
                        }
                        break;
                }
            }
        }
    }
}

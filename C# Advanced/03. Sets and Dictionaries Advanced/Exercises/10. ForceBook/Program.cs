using System;
using System.Collections.Generic;
using System.Linq;
namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> forceBook = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                string typeOfOperation = string.Empty;
                if (input.Contains("|"))
                {
                    typeOfOperation = "|";
                }
                else if(input.Contains("->"))
                {
                    typeOfOperation = "->";
                }

                string[] commands = input.Split(new string[] {" | ", " -> "}, StringSplitOptions.RemoveEmptyEntries);
                bool isFound = false;
                if (typeOfOperation == "|")
                {
                    foreach (var forceUser in forceBook)
                    {
                        if (forceBook[forceUser.Key].Contains(commands[1]))
                        {
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        if (forceBook.ContainsKey(commands[0]))
                        {
                            forceBook[commands[0]].Add(commands[1]);
                        }
                        else
                        {
                            forceBook.Add(commands[0], new List<string>{commands[1]});
                        }
                    }
                }
                else if (typeOfOperation == "->")
                {
                    string side = string.Empty;
                    foreach (var forceUser in forceBook)
                    {
                        if (forceBook[forceUser.Key].Contains(commands[0]))
                        {
                            isFound = true;
                            side = forceUser.Key;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        forceBook.Remove(side);
                        if (forceBook.ContainsKey(commands[1]))
                        {
                            forceBook[commands[1]].Add(commands[0]);
                        }
                        else
                        {
                            forceBook.Add(commands[1], new List<string> {commands[0]});
                        }
                    }
                    else
                    {
                        if (forceBook.ContainsKey(commands[1]))
                        {
                            forceBook[commands[1]].Add(commands[0]);
                        }
                        else
                        {
                            forceBook.Add(commands[1], new List<string> { commands[0] });
                        }
                    }
                    Console.WriteLine($"{commands[0]} joins the {commands[1]} side!");
                }
            }
            foreach (var forceSide in forceBook.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");
                if (forceSide.Value.Count > 0)
                {
                    forceSide.Value.Sort();
                    for (int i = 0; i < forceSide.Value.Count; i++)
                    {
                        Console.WriteLine($"! {forceSide.Value[i]}");
                    }
                }
            }
        }
    }
}

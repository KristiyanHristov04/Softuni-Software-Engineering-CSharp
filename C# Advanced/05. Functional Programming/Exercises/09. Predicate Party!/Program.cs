using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> comingPeople = Console.ReadLine().Split().ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Party!")
                {
                    break;
                }
                string[] commands = input.Split();
                string mainCommand = commands[0];
                string secondCommand = commands[1];
                switch (mainCommand)
                {
                    case "Remove":
                        if (secondCommand == "StartsWith")
                        {
                            string startingSymbols = commands[2];
                            Predicate<string> areStartingSymbolsMatch = name => name.StartsWith(startingSymbols);
                            foreach (var person in comingPeople.FindAll(areStartingSymbolsMatch))
                            {
                                comingPeople.Remove(person);
                            }
                        }
                        else if (secondCommand == "EndsWith")
                        {
                            string startingSymbols = commands[2];
                            Predicate<string> areStartingSymbolsMatch = name => name.EndsWith(startingSymbols);
                            foreach (var person in comingPeople.FindAll(areStartingSymbolsMatch))
                            {
                                comingPeople.Remove(person);
                            }
                        }
                        else if (secondCommand == "Length")
                        {
                            int length = int.Parse(commands[2]);
                            Predicate<string> isInBounds = name => name.Length == length;
                            foreach (var person in comingPeople.FindAll(isInBounds))
                            {
                                comingPeople.Remove(person);
                            }
                        }
                        break;
                    case "Double":
                        if (secondCommand == "EndsWith")
                        {
                            string startingSymbols = commands[2];
                            Predicate<string> areStartingSymbolsMatch = name => name.EndsWith(startingSymbols);
                            Queue<string> temp = new Queue<string>();
                            foreach (var person in comingPeople.FindAll(areStartingSymbolsMatch))
                            {
                                temp.Enqueue(person);
                            }
                            while (temp.Count > 0)
                            {
                                comingPeople.Add(temp.Dequeue());
                            }

                        }
                        else if (secondCommand == "StartsWith")
                        {
                            string startingSymbols = commands[2];
                            Predicate<string> areStartingSymbolsMatch = name => name.StartsWith(startingSymbols);
                            Queue<string> temp = new Queue<string>();
                            foreach (var person in comingPeople.FindAll(areStartingSymbolsMatch))
                            {
                                temp.Enqueue(person);
                            }
                            while (temp.Count > 0)
                            {
                                comingPeople.Add(temp.Dequeue());
                            }
                        }
                        else if (secondCommand == "Length")
                        {
                            int length = int.Parse(commands[2]);
                            Predicate<string> isInBounds = name => name.Length == length;
                            Queue<string> temp = new Queue<string>();
                            foreach (var person in comingPeople.FindAll(isInBounds))
                            {
                                temp.Enqueue(person);
                            }
                            while (temp.Count > 0)
                            {
                                string duplicate = temp.Dequeue();
                                int index = comingPeople.IndexOf(duplicate);
                                comingPeople.Insert(index + 1, duplicate);
                            }
                        }
                        break;
                }
            }
            if (comingPeople.Count <= 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else if (comingPeople.Count > 0)
            {
                Console.WriteLine(String.Join(", ", comingPeople) + " are going to the party!");
            }
        }
    }
}

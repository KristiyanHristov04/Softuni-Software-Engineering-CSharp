using System;
using System.Linq;
using System.Collections.Generic;
namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryItems = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Go Shopping!")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string item01 = commands[1];
                switch (commands[0])
                {
                    case "Urgent":
                        bool isMet = false;
                        for (int i = 0; i < groceryItems.Count; i++)
                        {
                            if (groceryItems[i] == item01)
                            {
                                isMet = true;
                                break;
                            }
                        }
                        if (!isMet)
                        {
                            groceryItems.Insert(0, item01);
                        }
                        break;
                    case "Unnecessary":
                        if (groceryItems.Contains(item01))
                        {
                            groceryItems.Remove(item01);
                        }
                        break;
                    case "Correct":
                        string item02 = commands[2];
                        for (int i = 0; i < groceryItems.Count; i++)
                        {
                            if (groceryItems[i] == item01)
                            {
                                groceryItems[i] = item02;
                                break;
                            }
                        }
                        break;
                    case "Rearrange":
                        for (int i = 0; i < groceryItems.Count; i++)
                        {
                            if (groceryItems[i] == item01)
                            {
                                groceryItems.RemoveAt(i);
                                groceryItems.Add(item01);
                            }
                        }
                        break;
                }

            }
            Console.WriteLine(String.Join(", ", groceryItems));

        }
    }
}

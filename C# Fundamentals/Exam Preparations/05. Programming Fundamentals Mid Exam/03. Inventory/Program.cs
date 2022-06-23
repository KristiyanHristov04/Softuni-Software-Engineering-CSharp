using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Craft!")
                {
                    break;
                }
                string[] commands = input.Split(" - ");
                string item = commands[1];
                switch (commands[0])
                {
                    case "Collect":
                        bool isMet = false;
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i] == item)
                            {
                                isMet = true;
                                break;
                            }
                        }
                        if (!isMet)
                        {
                            items.Add(item);
                        }                        
                        break;
                    case "Drop":
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i] == item)
                            {
                                items.Remove(item);
                                break;
                            }
                        }
                        break;
                    case "Combine Items":
                        string replaceItem = commands[1];
                        string[] replaceItems = replaceItem.Split(":");
                        string oldItem = replaceItems[0];
                        string newItem = replaceItems[1];
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i] == oldItem)
                            {
                                items.Insert(i + 1, newItem);
                                break;
                            }
                        }
                        break;
                    case "Renew":
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i] == item)
                            {
                                string itemName = items[i];
                                items.RemoveAt(i);
                                items.Add(itemName);
                                break;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", items));
        }
    }
}

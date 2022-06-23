using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Yohoho!")
                {
                    break;
                }
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Loot":
                        for (int i = 1; i < commands.Length; i++)
                        {
                            if (!items.Contains(commands[i]))
                            {
                                items.Insert(0, commands[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int index = Convert.ToInt32(commands[1]);
                        if (index < 0 || index > items.Count - 1)
                        {
                            continue;
                        }
                        string loot = items[index];
                        items.RemoveAt(index);
                        items.Add(loot);
                        break;
                    case "Steal":
                        int count = Convert.ToInt32(commands[1]);
                        if (count > items.Count - 1)
                        {
                            List<string> stolenItems = new List<string>();
                            for (int i = items.Count - 1; i >= 0; i--)
                            {
                                stolenItems.Add(items[i]);
                                items.Remove(items[i]);
                            }
                            stolenItems.Reverse();
                            Console.WriteLine(String.Join(", ", stolenItems));
                        }
                        else
                        {
                            List<string> stolenItems = new List<string>();
                            for (int i = items.Count - 1; i >= 0; i--)
                            {
                                if (count == 0)
                                {
                                    stolenItems.Reverse();
                                    Console.WriteLine(String.Join(", ", stolenItems));
                                    break;
                                }
                                else
                                {
                                    stolenItems.Add(items[i]);
                                    items.Remove(items[i]);
                                    count--;
                                }
                                
                            }
                        }
                        
                        break;
                }

                
            }
            if (items.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }

            double sumLength = 0;
            for (int i = 0; i < items.Count; i++)
            {
                int length = items[i].Length;
                sumLength += length;
            }
            sumLength /= items.Count;
            Console.WriteLine($"Average treasure gain: {sumLength:f2} pirate credits.");
        }
    }
}

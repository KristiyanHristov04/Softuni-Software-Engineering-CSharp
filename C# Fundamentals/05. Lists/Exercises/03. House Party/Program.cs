using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> guestsList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] commands = input.Split(' ');
                bool isPersonOnTheList = false;
                bool didRemoveFromList = false;
                if (commands[2] == "going!")
                {
                    for (int j = 0; j < guestsList.Count; j++)
                    {
                        if (commands[0] == guestsList[j])
                        {
                            Console.WriteLine($"{commands[0]} is already in the list!");
                            isPersonOnTheList = true;
                        }
                    }
                    if (!isPersonOnTheList)
                    {
                        guestsList.Add(commands[0]);
                    }
                }
                else if(commands[2] == "not")
                {
                    for (int k = 0; k < guestsList.Count; k++)
                    {
                        if (commands[0] == guestsList[k])
                        {
                            guestsList.Remove(commands[0]);
                            didRemoveFromList = true;
                        }
                    }
                    if (!didRemoveFromList)
                    {
                        Console.WriteLine($"{commands[0]} is not in the list!");
                    }
                }
            }
            foreach (var guest in guestsList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}

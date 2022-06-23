using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            int moves = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                moves++;
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index01 = Convert.ToInt32(commands[0]);
                int index02 = Convert.ToInt32(commands[1]);

                if (index01 == index02 || index01 < 0 || index02 < 0 || index01 > elements.Count - 1 || index02 > elements.Count - 1)
                {
                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if(elements[index01] == elements[index02])
                {
                    string matchingElement = elements[index01];
                    elements.RemoveAll(x => x == matchingElement);
                    Console.WriteLine($"Congrats! You have found matching elements - {matchingElement}!");
                }
                else if(elements[index01] != elements[index02])
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }

            }
            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
            }
            Console.WriteLine(String.Join(" ", elements));
        }
    }
}

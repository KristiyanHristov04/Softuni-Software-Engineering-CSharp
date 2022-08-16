using System;
using System.Linq;
using System.Collections.Generic;
namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input == "Paid")
                {
                    foreach (var client in queue)
                    {
                        Console.WriteLine(client);
                    }
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}

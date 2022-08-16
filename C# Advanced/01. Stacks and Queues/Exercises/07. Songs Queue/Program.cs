using System;
using System.Linq;
using System.Collections.Generic;
namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> queue = new Queue<string>(songs);
            while (queue.Count > 0)
            {
                string input = Console.ReadLine();
                if (input.Substring(0, 3) == "Add")
                {
                    input = input.Remove(0, 4);
                    if (!queue.Contains(input))
                    {
                        queue.Enqueue(input);
                    }
                    else
                    {
                        Console.WriteLine($"{input} is already contained!");
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "Play":
                            queue.Dequeue();
                            break;
                        case "Show":
                            Console.WriteLine(string.Join(", ", queue));
                            break;
                    }
                }   
            }
            Console.WriteLine("No more songs!");
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ').ToArray();
            Queue<string> queue = new Queue<string>(children);
            int n = Convert.ToInt32(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    string currChild = queue.Dequeue();
                    queue.Enqueue(currChild);
                }
                string lostChild = queue.Dequeue();
                Console.WriteLine($"Removed {lostChild}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}

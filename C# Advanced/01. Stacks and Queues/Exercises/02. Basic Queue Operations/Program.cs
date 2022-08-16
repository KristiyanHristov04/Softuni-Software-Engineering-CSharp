using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = array[0];
            int s = array[1];
            int x = array[2];
            Queue<int> queue = new Queue<int>();
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(x) && queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else if (!queue.Contains(x) && queue.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}

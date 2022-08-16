using System;
using System.Linq;
using System.Collections.Generic;
namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int currNumber = array[i];
                if (currNumber % 2 == 0)
                {
                    queue.Enqueue(currNumber);
                }
            }
            Console.WriteLine(String.Join(", ", queue));
        }
    }
}

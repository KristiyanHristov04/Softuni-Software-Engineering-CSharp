using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            List<int> createdSets = new List<int>();
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();
                if (currentHat > currentScarf)
                {
                    int createSet = currentHat + currentScarf;
                    hats.Pop();
                    scarfs.Dequeue();
                    createdSets.Add(createSet);
                }
                else if(currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else if (currentScarf == currentHat)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(currentHat + 1);
                }
            }
            Console.WriteLine($"The most expensive set is: {createdSets.Max()}");
            Console.WriteLine(String.Join(" ", createdSets));
        }
    }
}

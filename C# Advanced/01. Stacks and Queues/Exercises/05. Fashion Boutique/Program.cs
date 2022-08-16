using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothesInBox);
            int capacityOfRack = Convert.ToInt32(Console.ReadLine());
            int numberOfRacks = 1;
            int currentCapacity = capacityOfRack;

            while (stack.Count > 0)
            {
                int currentClothesCount = stack.Peek();
                if (currentClothesCount <= currentCapacity)
                {
                    stack.Pop();
                    currentCapacity -= currentClothesCount;
                }
                else
                {
                    numberOfRacks++;
                    currentCapacity = capacityOfRack;
                }
            }
            Console.WriteLine(numberOfRacks);
        }
    }
}

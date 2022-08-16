using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> cupsQueue = new Queue<int>(cups);
            Stack<int> bottlesStack = new Stack<int>(bottles);

            int wastedWater = 0;

            while (cupsQueue.Count > 0 && bottlesStack.Count > 0)
            {
                int currentBottle = bottlesStack.Pop();
                int currentCup = cupsQueue.Dequeue();
                if (currentBottle - currentCup >= 0)
                {
                    wastedWater += currentBottle - currentCup;
                    continue;
                }

                currentCup -= currentBottle;

                while (bottlesStack.Count > 0)
                {
                    currentBottle = bottlesStack.Pop();
                    if (currentBottle - currentCup >= 0)
                    {
                        wastedWater += currentBottle - currentCup;
                        break;
                    }

                    currentCup -= currentBottle;
                }
            }
            if (bottlesStack.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}

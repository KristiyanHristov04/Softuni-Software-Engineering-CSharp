using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int finishLineIndex = numbers.Count / 2;
            double leftCarTime = 0;
            double rightCarTime = 0;
            int leftCarCount = 0;
            int rightCarCount = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == finishLineIndex)
                {
                    break;
                }
                else if (i < finishLineIndex)
                {
                    leftCarTime += numbers[i];
                    leftCarCount++;
                    if (numbers[i] == 0)
                    {
                        leftCarTime *= 0.8;
                        leftCarCount = 0;
                    }
                }
            }
            for (int j = numbers.Count - 1; j >= 0; j--)
            {
                if (j == finishLineIndex)
                {
                    break;
                }
                else if (j > finishLineIndex)
                {
                    rightCarTime += numbers[j];
                    rightCarCount++;
                    if (numbers[j] == 0)
                    {
                        rightCarTime *= 0.8;
                        rightCarCount = 0;
                    }
                }
            }
            if (rightCarTime > leftCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftCarTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightCarTime}");
            }
        }
    }
}
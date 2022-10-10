using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int createdWreaths = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLilia = lilies.Peek();
                int currentRoses = roses.Peek();
                int sum = currentLilia + currentRoses;
                if (sum == 15)
                {
                    createdWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lilies.Pop();
                    lilies.Push(currentLilia - 2);
                }
                else if (sum < 15)
                {
                    storedFlowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }
            while (storedFlowers >= 15)
            {
                storedFlowers -= 15;
                createdWreaths++;
            }

            if (createdWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {createdWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - createdWreaths} wreaths more!");
            }
        }
    }
}

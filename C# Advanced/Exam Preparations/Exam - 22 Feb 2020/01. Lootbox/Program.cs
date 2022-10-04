using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> claimedItems = new List<int>();
            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int currentItemBox01 = firstLootBox.Peek();
                int currentItemBox02 = secondLootBox.Peek();
                int sum = currentItemBox01 + currentItemBox02;
                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    secondLootBox.Pop();
                    firstLootBox.Enqueue(currentItemBox01);
                }
            }
            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int claimedItemsValue = claimedItems.Sum();
            if (claimedItemsValue >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsValue}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsValue}");
            }
        }
    }
}

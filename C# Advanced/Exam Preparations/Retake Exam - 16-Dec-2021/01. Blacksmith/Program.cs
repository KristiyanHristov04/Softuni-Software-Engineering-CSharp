using System;
using System.Collections.Generic;
using System.Linq;
namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> craftedSwords = new SortedDictionary<string, int>();
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int numberOfForgedSwords = 0;
            while (steel.Count > 0 && carbon.Count > 0)
            {
                int steelValue = steel.Peek();
                int carbonValue = carbon.Peek();
                int sum = steelValue + carbonValue;
                switch (sum)
                {
                    case 70:
                        if (!craftedSwords.ContainsKey("Gladius"))
                        {
                            craftedSwords.Add("Gladius", 0);
                        }
                        craftedSwords["Gladius"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        numberOfForgedSwords++;
                        break;
                    case 80:
                        if (!craftedSwords.ContainsKey("Shamshir"))
                        {
                            craftedSwords.Add("Shamshir", 0);
                        }
                        craftedSwords["Shamshir"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        numberOfForgedSwords++;
                        break;
                    case 90:
                        if (!craftedSwords.ContainsKey("Katana"))
                        {
                            craftedSwords.Add("Katana", 0);
                        }
                        craftedSwords["Katana"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        numberOfForgedSwords++;
                        break;
                    case 110:
                        if (!craftedSwords.ContainsKey("Sabre"))
                        {
                            craftedSwords.Add("Sabre", 0);
                        }
                        craftedSwords["Sabre"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        numberOfForgedSwords++;
                        break;
                    case 150:
                        if (!craftedSwords.ContainsKey("Broadsword"))
                        {
                            craftedSwords.Add("Broadsword", 0);
                        }
                        craftedSwords["Broadsword"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        numberOfForgedSwords++;
                        break;
                    default:
                        steel.Dequeue();
                        carbon.Pop();
                        carbon.Push(carbonValue + 5);
                        break;
                }
            }
            if (numberOfForgedSwords > 0)
            {
                Console.WriteLine($"You have forged {numberOfForgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: " + String.Join(", ", steel));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: " + String.Join(", ", carbon));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var sword in craftedSwords)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}

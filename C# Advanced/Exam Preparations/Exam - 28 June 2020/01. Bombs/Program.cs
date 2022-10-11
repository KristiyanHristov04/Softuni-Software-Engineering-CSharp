using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> pouch = new SortedDictionary<string, int>()
            {
                ["Datura Bombs"] = 0,
                ["Cherry Bombs"] = 0,
                ["Smoke Decoy Bombs"] = 0
            };
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (pouch["Datura Bombs"] >= 3 && pouch["Cherry Bombs"] >= 3 &&
                    pouch["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }
                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasings.Peek();
                int sum = currentBombCasing + currentBombEffect;
                switch (sum)
                {
                    case 40:
                        pouch["Datura Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    case 60:
                        pouch["Cherry Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    case 120:
                        pouch["Smoke Decoy Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    default:
                        bombCasings.Pop();
                        bombCasings.Push(currentBombCasing - 5);
                        break;
                        
                }
            }
            if (pouch["Datura Bombs"] >= 3 && pouch["Cherry Bombs"] >= 3 &&
                    pouch["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: " + String.Join(", ", bombEffects));
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: " + String.Join(", ", bombCasings));
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }
            foreach (var bomb in pouch)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}

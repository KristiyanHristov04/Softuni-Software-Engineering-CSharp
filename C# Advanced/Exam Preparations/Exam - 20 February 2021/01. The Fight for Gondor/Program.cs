using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = Convert.ToInt32(Console.ReadLine());
            List<int> plates = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= wavesOfOrcs; i++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

                if (i % 3 == 0)
                {
                    int newPlate = Convert.ToInt32(Console.ReadLine());
                    plates.Add(newPlate);
                }
                
                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currentPlate = plates[0];
                    int currentOrcWarrior = orcs.Peek();

                    if (currentOrcWarrior > currentPlate)
                    {
                        plates.RemoveAt(0);
                        currentOrcWarrior -= currentPlate;
                        orcs.Pop();
                        orcs.Push(currentOrcWarrior);
                    }
                    else if (currentPlate > currentOrcWarrior)
                    {
                        orcs.Pop();
                        plates[0] -= currentOrcWarrior;
                    }
                    else if (currentPlate == currentOrcWarrior)
                    {
                        orcs.Pop();
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }
            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if (orcs.Count > 0)
            {
                Console.WriteLine($"Orcs left: " + String.Join(", ", orcs));
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates left: " + String.Join(", ", plates));
            }
        }
    }
}

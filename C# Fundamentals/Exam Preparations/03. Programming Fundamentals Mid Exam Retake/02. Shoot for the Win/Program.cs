using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countOfShotTargets = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                int index = Convert.ToInt32(input);
                if (index >= 0 && index < targets.Length)
                {
                    bool isShot = false;
                    int currentTarget = 0;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (i == index && targets[i] != -1 && !isShot)
                        {
                            currentTarget = targets[i];
                            targets[i] = -1;
                            isShot = true;
                            countOfShotTargets++;
                            i = -1;
                        }                       
                        else if (isShot && targets[i] > currentTarget && targets[i] != -1)
                        {
                            targets[i] -= currentTarget;
                        }
                        else if(isShot && targets[i] <= currentTarget && targets[i] != -1)
                        {
                            targets[i] += currentTarget;
                        }
                    }
                }
            }
            Console.WriteLine($"Shot targets: {countOfShotTargets} -> " + String.Join(" ", targets));
        }
    }
}

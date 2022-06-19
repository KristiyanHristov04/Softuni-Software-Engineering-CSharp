using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombAndPower = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    int bombIndex = i;
                    int startDetonation = bombIndex - power;
                    int endDetonation = bombIndex + power;
                    for (int j = startDetonation; j <= endDetonation; j++)
                    {
                        if (j > numbers.Count - 1)
                        {
                            continue;
                        }
                        if (j < 0)
                        {
                            continue;
                        }
                        numbers[j] = 0;
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
    }
}

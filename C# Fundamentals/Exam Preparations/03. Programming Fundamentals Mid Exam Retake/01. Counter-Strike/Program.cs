using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = Convert.ToInt32(Console.ReadLine());
            int wonBattlesCount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End of battle")
                {
                    break;
                }

                int distance = Convert.ToInt32(input);
                if (energy >= distance)
                {
                    energy -= distance;
                    wonBattlesCount++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattlesCount} won battles and {energy} energy");
                    return;
                }

                if (wonBattlesCount % 3 == 0)
                {
                    energy += wonBattlesCount;
                }
            }
            Console.WriteLine($"Won battles: {wonBattlesCount}. Energy left: {energy}");
            
        }
    }
}

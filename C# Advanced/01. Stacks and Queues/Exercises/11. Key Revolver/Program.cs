using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = Convert.ToInt32(Console.ReadLine());
            int sizeOfGunBarrel = Convert.ToInt32(Console.ReadLine());
            int[] amountBullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] amountLocks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int valueOfIntelligence = Convert.ToInt32(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(amountBullets);
            Queue<int> locks = new Queue<int>(amountLocks);

            int currentGunBarrel = sizeOfGunBarrel;
            int moneySpendOnBullets = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                moneySpendOnBullets += pricePerBullet;
                currentGunBarrel--;

                if (currentGunBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentGunBarrel = sizeOfGunBarrel;
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - moneySpendOnBullets}");
            }
        }
    }
}

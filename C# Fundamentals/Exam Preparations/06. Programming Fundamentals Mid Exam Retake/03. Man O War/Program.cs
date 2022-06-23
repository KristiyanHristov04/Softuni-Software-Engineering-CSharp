using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maximumHealthCapacity = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    break;
                }
                string[] commands = input.Split(' ');
                switch (commands[0])
                {
                    case "Fire":
                        int index = Convert.ToInt32(commands[1]);
                        int damage = Convert.ToInt32(commands[2]);
                        if (index < 0 || index > warShip.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            warShip[index] -= damage;
                            if (warShip[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = Convert.ToInt32(commands[1]);
                        int endIndex = Convert.ToInt32(commands[2]);
                        int damage02 = Convert.ToInt32(commands[3]);
                        if (startIndex < 0 || startIndex > pirateShip.Count - 1 || endIndex < 0 || endIndex > pirateShip.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage02;
                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int index02 = Convert.ToInt32(commands[1]);
                        int healing = Convert.ToInt32(commands[2]);
                        if (index02 < 0 || index02 > pirateShip.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (pirateShip[index02] + healing <= maximumHealthCapacity)
                            {
                                pirateShip[index02] += healing;
                            }
                            else if(pirateShip[index02] + healing > maximumHealthCapacity)
                            {
                                pirateShip[index02] = maximumHealthCapacity;
                            }
                        }
                        break;
                    case "Status":
                        int countNeededRepairs = 0;
                        for (int i = 0; i < pirateShip.Count; i++)
                        {
                            if (pirateShip[i] < maximumHealthCapacity - (maximumHealthCapacity * 0.80))
                            {
                                countNeededRepairs++;
                            }
                        }
                        Console.WriteLine($"{countNeededRepairs} sections need repair.");
                        break;

                }
            }
            int pirateShipSum = 0;
            int warShipSum = 0;
            for (int i = 0; i < pirateShip.Count; i++)
            {
                pirateShipSum += pirateShip[i];
            }

            for (int i = 0; i < warShip.Count; i++)
            {
                warShipSum += warShip[i];
            }
            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }
    }
}

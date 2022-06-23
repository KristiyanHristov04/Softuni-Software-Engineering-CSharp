using System;
using System.Linq;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine().Split('|').ToArray();
            int health = 100;
            int bitcoins = 0;
            int numberOfSucceededRooms = 0;

            for (int currentDungeonRoom = 0; currentDungeonRoom < dungeonRooms.Length; currentDungeonRoom++)
            {
                string[] commands = dungeonRooms[currentDungeonRoom].Split();
                switch (commands[0])
                {
                    case "potion":
                        int healToReceive = int.Parse(commands[1]);
                        if (healToReceive + health > 100)
                        {                          
                            healToReceive = 0;
                            for (int i = health; i < 100; i++)
                            {
                                healToReceive++;
                            }
                            health = 100;
                        }
                        else
                        {
                            health += healToReceive;
                        }
                        Console.WriteLine($"You healed for {healToReceive} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        int foundBitcoins = int.Parse(commands[1]);
                        bitcoins += foundBitcoins;
                        Console.WriteLine($"You found {foundBitcoins} bitcoins.");
                        break;
                    default:
                        string monsterName = commands[0];
                        int monsterAttack = int.Parse(commands[1]);
                        if (health - monsterAttack > 0)
                        {
                            health -= monsterAttack;
                            Console.WriteLine($"You slayed {monsterName}.");
                        }
                        else
                        {
                            numberOfSucceededRooms++;
                            Console.WriteLine($"You died! Killed by {monsterName}.");
                            Console.WriteLine($"Best room: {numberOfSucceededRooms}");
                            return;
                        }
                        break;

                }
                numberOfSucceededRooms++;
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}

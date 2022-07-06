using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, List<Dragon>>> dragonArmy = new Dictionary<string, SortedDictionary<string, List<Dragon>>>();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = input[0];
                string name = input[1];
                int damage = 45;
                int health = 250;
                int armour = 10;
                if (input[2] != "null")
                {
                    damage = Convert.ToInt32(input[2]);
                }
                if (input[3] != "null")
                {
                    health = Convert.ToInt32(input[3]);
                }
                if (input[4] != "null")
                {
                    armour = Convert.ToInt32(input[4]);
                }

                if (!dragonArmy.ContainsKey(type))
                {
                    List<Dragon> dragons = new List<Dragon>();
                    Dragon currentDragon = new Dragon(name, damage, health, armour);
                    dragons.Add(currentDragon);
                    dragonArmy.Add(type, new SortedDictionary<string, List<Dragon>>());
                }
                if (!dragonArmy[type].ContainsKey(name))
                {
                    Dragon dragon = new Dragon(name, damage, health, armour);

                    dragonArmy[type].Add(name, new List<Dragon>());
                    dragonArmy[type][name].Add(dragon);

                }
                else
                {
                    Dragon dragon = dragonArmy[type][name].Find(x => x.Name == name);
                    dragon.Damage = damage;
                    dragon.Health = health;
                    dragon.Armour = armour;
                }
            }

            foreach (var dragon in dragonArmy)
            {
                double averageDamage = dragon.Value.Values.Average(d => d.Average(x => x.Damage));
                double averageHealth = dragon.Value.Values.Average(d => d.Average(x => x.Health));
                double averageArmour = dragon.Value.Values.Average(d => d.Average(x => x.Armour));

                Console.WriteLine($"{dragon.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmour:f2})");



                foreach (var dragonName in dragon.Value.Values)
                {
                    for (int i = 0; i < dragonName.Count; i++)
                    {
                        Console.WriteLine($"-{dragonName[i].Name} -> damage: {dragonName[i].Damage}, health: {dragonName[i].Health}, armor: {dragonName[i].Armour}");
                    }

                }
            }        
        }
    }
    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }
        public Dragon(string name, int damage, int health, int armour)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armour = armour;
        }
    }
}

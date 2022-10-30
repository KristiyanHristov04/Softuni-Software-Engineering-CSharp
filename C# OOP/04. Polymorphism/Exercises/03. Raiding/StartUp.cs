using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = string.Empty;
                string heroType = string.Empty;

                while (true)
                {
                    name = Console.ReadLine();
                    heroType = Console.ReadLine();
                    if (heroType == "Druid" || heroType == "Rogue" ||
                        heroType == "Warrior" || heroType == "Paladin")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid hero!");
                    }
                }

                BaseHero hero;

                switch (heroType)
                {
                    case "Druid":
                        hero = new Druid(name);
                        heroes.Add(hero);
                        break;
                    case "Paladin":
                        hero = new Paladin(name);
                        heroes.Add(hero);
                        break;
                    case "Rogue":
                        hero = new Rogue(name);
                        heroes.Add(hero);
                        break;
                    case "Warrior":
                        hero = new Warrior(name);
                        heroes.Add(hero);
                        break;
                }
            }

            int bossPower = Convert.ToInt32(Console.ReadLine());
            int heroesTotalPower = 0;

            foreach (var hero in heroes)
            {
                hero.CastAbility();
                heroesTotalPower += hero.Power;
            }

            if (heroesTotalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

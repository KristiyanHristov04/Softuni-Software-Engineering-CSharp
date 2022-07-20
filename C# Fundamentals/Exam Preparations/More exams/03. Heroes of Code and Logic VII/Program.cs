using System;
using System.Collections.Generic;
namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HeroInformation> heroes = new Dictionary<string, HeroInformation>();
            int numberOfHeroes = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] currentHeroInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = currentHeroInput[0];
                int heroHP = Convert.ToInt32(currentHeroInput[1]); 
                int heroMP = Convert.ToInt32(currentHeroInput[2]); 
                HeroInformation currHeroInfo = new HeroInformation(heroHP, heroMP);
                heroes.Add(heroName, currHeroInfo);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string currentHeroName = commands[1];
                switch (mainCommand)
                {
                    case "CastSpell":
                        int manaNeeded = Convert.ToInt32(commands[2]);
                        string spellName = commands[3];
                        if (heroes[currentHeroName].MP >= manaNeeded)
                        {
                            heroes[currentHeroName].MP -= manaNeeded;
                            Console.WriteLine($"{currentHeroName} has successfully cast {spellName} and now has {heroes[currentHeroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{currentHeroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = Convert.ToInt32(commands[2]);
                        string attacker = commands[3];
                        heroes[currentHeroName].HP -= damage;
                        if (heroes[currentHeroName].HP > 0)
                        {
                            Console.WriteLine($"{currentHeroName} was hit for {damage} HP by {attacker} and now has {heroes[currentHeroName].HP} HP left!");
                        }
                        else
                        {
                            heroes.Remove(currentHeroName);
                            Console.WriteLine($"{currentHeroName} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        int manaAmount = Convert.ToInt32(commands[2]);
                        if (heroes[currentHeroName].MP + manaAmount > 200)
                        {
                            int manaRecovered = 200 - heroes[currentHeroName].MP;
                            heroes[currentHeroName].MP = 200;
                            Console.WriteLine($"{currentHeroName} recharged for {manaRecovered} MP!");
                        }
                        else
                        {
                            heroes[currentHeroName].MP += manaAmount;
                            Console.WriteLine($"{currentHeroName} recharged for {manaAmount} MP!");
                        }
                        break;
                    case "Heal":
                        int healAmount = Convert.ToInt32(commands[2]);
                        if (heroes[currentHeroName].HP + healAmount > 100)
                        {
                            int healRecovered = 100 - heroes[currentHeroName].HP;
                            heroes[currentHeroName].HP = 100;       
                            Console.WriteLine($"{currentHeroName} healed for {healRecovered} HP!");
                        }
                        else
                        {
                            heroes[currentHeroName].HP += healAmount;
                            Console.WriteLine($"{currentHeroName} healed for {healAmount} HP!");
                        }
                        break;
                }
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"    HP: {hero.Value.HP}");
                Console.WriteLine($"    MP: {hero.Value.MP}");
            }
        }
    }
    class HeroInformation
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public HeroInformation(int hp, int mp)
        {
            this.HP = hp;
            this.MP = mp;
        }
    }
}

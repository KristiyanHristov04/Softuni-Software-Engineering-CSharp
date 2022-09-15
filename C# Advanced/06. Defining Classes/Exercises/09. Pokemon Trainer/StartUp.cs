using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                string[] commands = input.Split(' ');
                string trainerName = commands[0];
                string pokemonName = commands[1];
                string pokemonElement = commands[2];
                int pokemonHealth = Convert.ToInt32(commands[3]);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer currentTrainer = new Trainer(trainerName);
                bool flag = false;
                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.PokemonCollection.Add(currentPokemon);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    currentTrainer.PokemonCollection.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string neededElement = input;
                
                foreach (var trainer in trainers)
                {
                    bool isFound = false;
                    foreach (var pokemon in trainer.PokemonCollection)
                    {
                        if (pokemon.Element == neededElement)
                        {
                            isFound = true;
                            trainer.NumberOfBadges++;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        foreach (var pokemon in trainer.PokemonCollection)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }
                for (int i = 0; i < trainers.Count; i++)
                {
                    trainers[i].PokemonCollection.RemoveAll(x => x.Health <= 0);
                }

            }

            var sortedTrainers = trainers.OrderByDescending(x => x.NumberOfBadges);
            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonCollection.Count}");
            }
        }
    }
}

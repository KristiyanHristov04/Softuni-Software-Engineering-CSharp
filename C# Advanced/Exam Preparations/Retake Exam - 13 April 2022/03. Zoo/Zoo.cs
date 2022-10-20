using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }
        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore") 
            {
                return "Invalid animal diet.";
            }
            if (this.Animals.Count + 1 > this.Capacity)
            {
                return "The zoo is full.";
            }
            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int removedAnimalsCount = 0;
            foreach (var animal in this.Animals)
            {
                if (animal.Species == species)
                {
                    removedAnimalsCount++;
                }
            }

            if (removedAnimalsCount > 0)
            {
                this.Animals.RemoveAll(animal => animal.Species == species);
            }
            
            return removedAnimalsCount;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> dietAnimals = this.Animals.Where(animal => animal.Diet == diet).ToList();
            return dietAnimals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            return this.Animals.Where(animal => animal.Weight == weight).First();
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int totalAnimals = 0;
            foreach (var animal in this.Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    totalAnimals++;
                }
            }
            return $"There are {totalAnimals} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

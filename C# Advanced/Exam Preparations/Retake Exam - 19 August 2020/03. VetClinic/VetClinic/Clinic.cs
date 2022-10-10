using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> Pets { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Pets.Count; } }
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Pets = new List<Pet>();
        }
        public void Add(Pet pet)
        {
            if (this.Pets.Count + 1 <= this.Capacity)
            {
                this.Pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            bool doesExist = this.Pets.Exists(pet => pet.Name == name);
            if (doesExist)
            {
                foreach (var pet in this.Pets)
                {
                    if (pet.Name == name)
                    {
                        this.Pets.Remove(pet);
                        return doesExist;
                    }
                }
            }
            return doesExist;
        }
        public Pet GetPet(string name, string owner)
        {
            foreach (var pet in this.Pets)
            {
                if (pet.Name == name && pet.Owner == owner)
                {
                    return pet;
                }
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet oldestPet = this.Pets.OrderByDescending(pet => pet.Age).First();
            return oldestPet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in this.Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

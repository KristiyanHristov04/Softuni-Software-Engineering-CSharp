using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return this.Ingredients.Sum(x => x.Alcohol); } }
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }
        public void Add(Ingredient ingredient)
        {
            if (!this.Ingredients.Contains(ingredient) && 
                this.CurrentAlcoholLevel <= this.MaxAlcoholLevel &&
                this.Ingredients.Count + 1 <= this.Capacity)
            {
                this.Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            bool doesExist;
            foreach (var ingredient in this.Ingredients)
            {
                if (ingredient.Name == name)
                {
                    this.Ingredients.Remove(ingredient);
                    doesExist = true;
                    return doesExist;
                }
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            foreach (var ingredient in this.Ingredients)
            {
                if (ingredient.Name == name)
                {
                    return ingredient;
                }
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngredient = this.Ingredients.OrderByDescending(ingredient => ingredient.Alcohol).First();
            return mostAlcoholicIngredient;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

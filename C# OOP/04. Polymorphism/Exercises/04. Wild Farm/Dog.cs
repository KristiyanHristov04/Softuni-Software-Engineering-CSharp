using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Feed(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += food.Quantity * 0.40;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

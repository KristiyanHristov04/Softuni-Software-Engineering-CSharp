using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }
        public string Type { get; private set; }
        public string Group { get; set; }
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
            this.Type = "Rebel";
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}

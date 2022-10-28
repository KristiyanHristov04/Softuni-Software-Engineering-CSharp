using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : AbstractClass, IBirthable, IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; private set; }
        public int Food { get; set; }
        public string BirthDate { get; set; }

        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
            this.Food = 0;
            this.Type = "Citizen";
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal Price = 5;
        private const double Grams = 250;
        private const double Calories = 1000;
        public Cake(string name) 
            : base(name, Price, Grams, Calories)
        {

        }
    }
}

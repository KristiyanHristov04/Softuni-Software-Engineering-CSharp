using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Colour { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Colour = "n/a";
        }

        public Car(string model, Engine engine, int weight)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Colour = "n/a";
        }

        public Car(string model, Engine engine, string colour)
        {
            this.Model = model;
            this.Engine = engine;
            this.Colour = colour;
            this.Weight = 0;
        }

        public Car(string model, Engine engine, int weight, string colour)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Colour = colour;
        }
    }
}

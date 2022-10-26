using System;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }
        public override string ToString()
        {
            return $"{this.Color} Tesla Model {this.Model} with {this.Battery} Batteries";
        }
    }
}

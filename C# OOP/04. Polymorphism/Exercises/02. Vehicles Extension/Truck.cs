using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public int TankCapacity { get; private set; }
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumptionPerKm += 1.6;
            this.TankCapacity = tankCapacity;
            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
                return;
            }

            if (this.FuelQuantity + fuel <= TankCapacity)
            {
                fuel *= 0.95;
                this.FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }

        public override void TravelDistance(double distance)
        {
            double neededFuel = FuelConsumptionPerKm * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumptionPerKm += 1.6;
        }

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            this.FuelQuantity += fuel;
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

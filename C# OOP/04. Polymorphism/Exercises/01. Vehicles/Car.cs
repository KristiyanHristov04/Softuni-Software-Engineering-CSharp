using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumptionPerKm += 0.9;
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override void TravelDistance(double distance)
        {
            double neededFuel = FuelConsumptionPerKm * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public int TankCapacity { get; private set; }
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumptionPerKm += 0.9;
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public int TankCapacity { get; private set; }
        public Bus(double fuelQuantity, double fuelConsumption,int tankCapacity) : base(fuelQuantity, fuelConsumption)
        {
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
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}

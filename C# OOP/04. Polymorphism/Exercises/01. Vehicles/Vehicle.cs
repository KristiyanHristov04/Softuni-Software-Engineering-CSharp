using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public abstract void TravelDistance(double distance);
        public abstract void Refuel(double fuel);
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
        }
    }
}

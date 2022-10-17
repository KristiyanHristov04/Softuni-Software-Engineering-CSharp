using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public const double DefaultFuelConsumption = 10;
        public override double FuelConsumption { get; set; } = DefaultFuelConsumption;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}

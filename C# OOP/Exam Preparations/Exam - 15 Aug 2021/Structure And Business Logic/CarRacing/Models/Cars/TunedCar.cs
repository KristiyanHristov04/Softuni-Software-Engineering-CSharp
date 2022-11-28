using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, InitialFuelAvailable, InitialFuelConsumptionPerRace)
        {

        }

        public override void Drive()
        {
            base.Drive();
            int horsePowerDecrease = (int)Math.Round(this.HorsePower * 0.03);
            this.HorsePower -= horsePowerDecrease;
        }
    }
}

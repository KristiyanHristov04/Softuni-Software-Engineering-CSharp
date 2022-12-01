using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double InitialCubicCentimeters = 5000;
        private const int InitialMinimumHorsePower = 400;
        private const int InitialMaximumHorsePower = 600;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters, InitialMinimumHorsePower, InitialMaximumHorsePower)
        {

        }
    }
}

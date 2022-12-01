using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double InitialCubicCentimeters = 3000;
        private const int InitialMinimumHorsePower = 250;
        private const int InitialMaximumHorsePower = 450;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters, InitialMinimumHorsePower, InitialMaximumHorsePower)
        {

        }
    }
}

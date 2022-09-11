using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }



        public int GetHorsePower(string[] splitted)
        {
            int horsePower = int.Parse(splitted[0]);

            return horsePower;
        }

        public double GetCubicCapacity(string[] splitted)
        {
            double cubicCapacity = double.Parse(splitted[1]);

            return cubicCapacity;
        }
    }
}
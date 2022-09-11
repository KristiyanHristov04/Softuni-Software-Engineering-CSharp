using System;
namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private int engineIndex;
        private int tiresIndex;


        public Car(string make, string model, int year, int horsePower, double fuelQuantity,
            double fuelConsumption, int engineIndex, int tiresIndex, double totalPressure)
        {
            Make = make;
            Model = model;
            Year = year;
            HorsePower = horsePower;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
            TotalPressure = totalPressure;
        }


        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public int EngineIndex { get; set; }

        public int TiresIndex { get; set; }

        public double TotalPressure { get; set; }


        public double Drive20Kilometers(double fuelQuantity, double fuelConsumption)
        {
            fuelQuantity -= (FuelConsumption / 100) * 20;

            return fuelQuantity;
        }
    }
}
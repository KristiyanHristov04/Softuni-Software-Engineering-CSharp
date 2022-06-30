using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = Convert.ToDouble(input[1]);
                double fuelConsumptionPerKilometer = Convert.ToDouble(input[2]);

                Car currCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                allCars.Add(currCar);
                
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split();
                string carModel = commands[1];
                int amoutOfKilometers = Convert.ToInt32(commands[2]);

                for (int i = 0; i < allCars.Count; i++)
                {
                    if (allCars[i].Model == carModel)
                    {
                        allCars[i].Drive(amoutOfKilometers);
                    }
                }
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravaledDistance}");
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }

        public int TravaledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumption;
            this.TravaledDistance = 0;
        }

        public void Drive(int amountOfKilometers)
        {
            if (this.FuelAmount > 0 && this.FuelAmount - amountOfKilometers * this.FuelConsumptionPerKm >= 0)
            {
                this.FuelAmount -= amountOfKilometers * this.FuelConsumptionPerKm;
                this.TravaledDistance += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

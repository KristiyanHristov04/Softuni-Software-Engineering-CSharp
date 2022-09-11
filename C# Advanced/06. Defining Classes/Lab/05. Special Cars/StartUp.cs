using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<double>> listTiresYears = new List<List<double>>();
            List<List<double>> listTiresPressures = new List<List<double>>();
            List<int> listHorsePowers = new List<int>();
            List<double> listCubicCapacity = new List<double>();

            List<Car> listCars = new List<Car>();


            string input = Console.ReadLine();

            Tires tires = new Tires();
            Engine engine = new Engine();

            while (input != "No more tires")
            {
                string[] splitted = input.Split();

                List<double> listYears = tires.GetYearInfo(splitted);
                List<double> listPressures = tires.GetPressureInfo(splitted);

                listTiresYears.Add(listYears);
                listTiresPressures.Add(listPressures);

                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "Engines done")
            {
                string[] splitted = secondInput.Split();

                listHorsePowers.Add(engine.GetHorsePower(splitted));
                listCubicCapacity.Add(engine.GetCubicCapacity(splitted));

                secondInput = Console.ReadLine();
            }

            string thirdInput = Console.ReadLine();

            while (thirdInput != "Show special")
            {
                string[] splitted = thirdInput.Split();
                string make = splitted[0];
                string model = splitted[1];
                int year = int.Parse(splitted[2]);
                double fuelQuantity = double.Parse(splitted[3]);
                double fuelConsumption = double.Parse(splitted[4]);
                int engineIndex = int.Parse(splitted[5]);
                int tiresIndex = int.Parse(splitted[6]);

                int horsePower = listHorsePowers[engineIndex];
                double pressure = tires.GetSumPressure(listTiresPressures, tiresIndex);

                Car car = new Car(make, model, year, horsePower, fuelQuantity, fuelConsumption,
                    engineIndex, tiresIndex, pressure);

                listCars.Add(car);


                thirdInput = Console.ReadLine();
            }

            foreach (var car in listCars)
            {
                if (car.Year >= 2017 && car.HorsePower > 330
                    && car.TotalPressure > 9 && car.TotalPressure < 10)
                {
                    car.FuelQuantity = car.Drive20Kilometers(car.FuelQuantity, car.FuelConsumption);

                    Console.WriteLine($"Make: {car.Make}");

                    Console.WriteLine($"Model: {car.Model}");

                    Console.WriteLine($"Year: {car.Year}");

                    Console.WriteLine($"HorsePowers: {car.HorsePower}");

                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
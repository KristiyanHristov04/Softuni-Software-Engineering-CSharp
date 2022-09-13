using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int numberOfCars = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = Convert.ToDouble(input[1]);
                double fuelConsumptionFor1Km = Convert.ToDouble(input[2]);
                Car newCar = new Car(model, fuelAmount, fuelConsumptionFor1Km);
                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, newCar);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split();
                string model = commands[1];
                int amountOfKilometers = Convert.ToInt32(commands[2]);
                cars[model].TravelDistance(amountOfKilometers);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}

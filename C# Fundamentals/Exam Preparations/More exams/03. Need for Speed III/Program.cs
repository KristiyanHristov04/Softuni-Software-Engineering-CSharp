using System;
using System.Collections.Generic;
namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxFuel = 75;
            Dictionary<string, CarInformation> cars  = new Dictionary<string, CarInformation>();
            int numberOfCars = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carName = input[0];
                int carMileage = Convert.ToInt32(input[1]);
                int carFuel = Convert.ToInt32(input[2]);
                CarInformation currentCar = new CarInformation(carMileage, carFuel);
                cars.Add(carName, currentCar);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                string[] commands = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string currentCar = commands[1];
                switch (mainCommand)
                {
                    case "Drive":
                        int distance = Convert.ToInt32(commands[2]);
                        int fuel = Convert.ToInt32(commands[3]);
                        if (cars[currentCar].Fuel >= fuel)
                        {
                            cars[currentCar].Fuel -= fuel;
                            cars[currentCar].Mileage += distance;
                            Console.WriteLine($"{currentCar} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (cars[currentCar].Mileage >= 100000)
                            {
                                cars.Remove(currentCar);
                                Console.WriteLine($"Time to sell the {currentCar}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        break;
                    case "Refuel":
                        int fuel2 = Convert.ToInt32(commands[2]);
                        if (cars[currentCar].Fuel + fuel2 > maxFuel)
                        {
                            int refilledValue = maxFuel - fuel2;
                            cars[currentCar].Fuel = maxFuel;
                            Console.WriteLine($"{currentCar} refueled with {refilledValue} liters");
                        }
                        else
                        {
                            cars[currentCar].Fuel += fuel2;
                            Console.WriteLine($"{currentCar} refueled with {fuel2} liters");
                        }
                        
                        break;
                    case "Revert":
                        int kilometers = Convert.ToInt32(commands[2]);
                        if (cars[currentCar].Mileage - kilometers < 10000)
                        {
                            cars[currentCar].Mileage = 10000;
                        }
                        else
                        {
                            cars[currentCar].Mileage -= kilometers;
                            Console.WriteLine($"{currentCar} mileage decreased by {kilometers} kilometers");
                        }
                        break;
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
    class CarInformation
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
        public CarInformation(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
}

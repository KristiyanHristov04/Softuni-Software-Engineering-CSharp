using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            int numberOfCars = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                int engineSpeed = Convert.ToInt32(input[1]);
                int enginePower = Convert.ToInt32(input[2]);
                Engine engine = new Engine(enginePower);
                int cargoWeight = Convert.ToInt32(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car newCar = new Car(model, engine, cargo);
                allCars.Add(newCar);
            }

            string typeOfCargo = Console.ReadLine();
            if (typeOfCargo == "fragile")
            {
                List<Car> cars = allCars.Where(car => car.Cargo.CargoWeight < 1000).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }                
            }
            else if(typeOfCargo == "flamable")
            {
                List<Car> cars = allCars.Where(car => car.EnginePower.EnginePower_ > 250).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }

            
        }
    }
    class Car
    {
        public string Model { get; set; }
        public Engine EnginePower { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model, Engine enginePower, Cargo cargo)
        {
            this.Model = model;
            this.EnginePower = enginePower;
            this.Cargo = cargo;
        }
    }
    class Engine
    {
        public int EnginePower_ { get; set; }
        public Engine(int enginePower)
        {
            this.EnginePower_ =enginePower;
        }
    }
    class Cargo
    {
        public string CargoType { get; set; }
        public int CargoWeight { get; set; }
        public Cargo(string cargoType, int cargoWeight)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }
    }
}

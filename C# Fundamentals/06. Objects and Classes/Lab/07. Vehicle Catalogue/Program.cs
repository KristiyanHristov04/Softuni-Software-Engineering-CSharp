using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split('/');

                if (commands[0] == "Car")
                {
                    Car newCar = new Car(commands[1], commands[2], Convert.ToInt32(commands[3]));
                    catalog.Cars.Add(newCar);
                }
                else
                {
                    Truck newTruck = new Truck(commands[1], commands[2], Convert.ToInt32(commands[3]));
                    catalog.Trucks.Add(newTruck);
                }

            }

            
            List<Car> orderedCars = catalog.Cars.OrderBy(car => car.Brand).ToList();
            if (orderedCars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
                      
            List<Truck> orderedTrucks = catalog.Trucks.OrderBy(truck => truck.Brand).ToList();
            if (orderedTrucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
            
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            this.Trucks = new List<Truck>();
            this.Cars = new List<Car>();
        }
    }
}

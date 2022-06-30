using System;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {                 
                    while (true)
                    {
                        string secondInput = Console.ReadLine();

                        if (secondInput == "Close the Catalogue")
                        {
                            double totalCarsHorsePower = 0;
                            double totalTrucksHorsePower = 0;

                            for (int i = 0; i < cars.Count; i++)
                            {
                                totalCarsHorsePower += cars[i].HorsePower;
                            }

                            if (cars.Count > 0)
                            {
                                totalCarsHorsePower /= cars.Count;
                            }
                            

                            for (int i = 0; i < trucks.Count; i++)
                            {
                                totalTrucksHorsePower += trucks[i].HorsePower;
                            }

                            if (trucks.Count > 0)
                            {
                                totalTrucksHorsePower /= trucks.Count;
                            }
                            
                            Console.WriteLine($"Cars have average horsepower of: {totalCarsHorsePower:f2}.");
                            Console.WriteLine($"Trucks have average horsepower of: {totalTrucksHorsePower:f2}.");
                            return;
                        }

                        for (int i = 0; i < cars.Count; i++)
                        {
                            if (secondInput == cars[i].Model)
                            {
                                Console.WriteLine(cars[i]);
                            }
                        }

                        for (int i = 0; i < trucks.Count; i++)
                        {
                            if (secondInput == trucks[i].Model)
                            {
                                Console.WriteLine(trucks[i]);
                            }
                        }
                    }
                }

                string[] commands = input.Split(' ');
                string type = commands[0];
                string model = commands[1];
                string color = commands[2];
                int horsePower = Convert.ToInt32(commands[3]);

                if (type == "car")
                {
                    Car currentCar = new Car(type, model, color, horsePower);
                    cars.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck(type, model, color, horsePower);
                    trucks.Add(currentTruck);
                }
            }
        }
    }
    class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Car(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"Type: Car\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HorsePower}";
        }
    }

    class Truck
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Truck(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"Type: Truck\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HorsePower}";
        }
    }
}

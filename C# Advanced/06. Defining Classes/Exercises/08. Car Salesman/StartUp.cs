using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();   
            int numberOfEngines = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = Convert.ToInt32(input[1]);
                if (input.Length == 3)
                {
                    string displacementString = input[2];
                    char firstSymbol = displacementString[0];
                    if (char.IsLetter(firstSymbol))
                    {
                        string efficiency = displacementString;
                        Engine newEngine = new Engine(model, power, efficiency);
                        engines.Add(newEngine);
                    }
                    else if (char.IsDigit(firstSymbol))
                    {
                        int displacement = Convert.ToInt32(displacementString);
                        Engine newEngine = new Engine(model, power, displacement);
                        engines.Add(newEngine);
                    }
                    
                }
                else if (input.Length == 4)
                {
                    int displacement = Convert.ToInt32(input[2]);
                    string efficiency = input[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency); //4
                    engines.Add(newEngine);
                }
                else
                {
                    Engine newEngine = new Engine(model, power); //2
                    engines.Add(newEngine);
                }
            }

            int numberOfCars = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];
                if (input.Length == 3)
                {
                    string weightString = input[2];
                    char firstSymbol = weightString[0];
                    if (char.IsLetter(firstSymbol))
                    {
                        string colour = weightString;
                        Engine engine = engines.Where(engine => engine.Model == engineModel).FirstOrDefault();
                        Car newCar = new Car(model, engine, colour);
                        cars.Add(newCar);
                    }
                    else if (char.IsDigit(firstSymbol))
                    {
                        int weight = Convert.ToInt32(weightString);
                        Engine engine = engines.Where(engine => engine.Model == engineModel).FirstOrDefault();
                        Car newCar = new Car(model, engine, weight);
                        cars.Add(newCar);
                    }

                    
                }
                else if (input.Length == 4)
                {
                    int weight = Convert.ToInt32(input[2]);
                    string colour = input[3];
                    Engine engine = engines.Where(engine => engine.Model == engineModel).First();
                    Car newCar = new Car(model, engine, weight, colour);
                    cars.Add(newCar);
                }
                else
                {
                    Engine engine = engines.Where(engine => engine.Model == engineModel).FirstOrDefault();
                    Car newCar = new Car(model, engine);
                    cars.Add(newCar);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:\n  {car.Engine.Model}:\n    Power: {car.Engine.Power}\n    Displacement: {(car.Engine.Displacement == 0 ? "n/a" : $"{car.Engine.Displacement}")}\n    Efficiency: {car.Engine.Efficiency}\n  Weight: {(car.Weight == 0 ? "n/a" : $"{car.Weight}")}\n  Color: {car.Colour}");
            }
        }
    }
}

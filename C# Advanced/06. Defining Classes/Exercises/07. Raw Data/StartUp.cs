using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfLines = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                Tire[] newTires = new Tire[4];
                string[] carInformation = Console.ReadLine().Split();
                string model = carInformation[0];
                int engineSpeed = Convert.ToInt32(carInformation[1]);
                int enginePower = Convert.ToInt32(carInformation[2]);
                int cargoWeight = Convert.ToInt32(carInformation[3]);
                string cargoType = carInformation[4];
                double tirePressure01 = Convert.ToDouble(carInformation[5]);
                int tireYear01 = Convert.ToInt32(carInformation[6]);
                Tire newTire01 = new Tire(tireYear01, tirePressure01);
                double tirePressure02 = Convert.ToDouble(carInformation[7]);
                int tireYear02 = Convert.ToInt32(carInformation[8]);
                Tire newTire02 = new Tire(tireYear02, tirePressure02);
                double tirePressure03 = Convert.ToDouble(carInformation[9]);
                int tireYear03 = Convert.ToInt32(carInformation[10]);
                Tire newTire03 = new Tire(tireYear03, tirePressure03);
                double tirePressure04 = Convert.ToDouble(carInformation[11]);
                int tireYear04 = Convert.ToInt32(carInformation[12]);
                Tire newTire04 = new Tire(tireYear04, tirePressure04);
                Engine newEngine = new Engine(engineSpeed, enginePower);
                Cargo newCargo = new Cargo(cargoType, cargoWeight);
                newTires[0] = newTire01;
                newTires[1] = newTire02;
                newTires[2] = newTire03;
                newTires[3] = newTire04;
                Car newCar = new Car(model, newEngine, newCargo, newTires);
                cars.Add(newCar);
            }

            string input = Console.ReadLine();
            if (input == "fragile")
            {
                var filteredCars = cars.Where(cargoType => cargoType.Cargo.Type == "fragile");
                foreach (var car in filteredCars.Where(tire => tire.Tires.FirstOrDefault(pressure => pressure.Pressure < 1) != null))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (input == "flammable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}

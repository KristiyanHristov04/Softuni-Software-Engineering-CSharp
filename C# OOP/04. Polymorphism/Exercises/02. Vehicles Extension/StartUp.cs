 using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int numberOfCommands = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Drive")
                {
                    double kilometers = Convert.ToDouble(input[2]);
                    if (input[1] == "Car")
                    {
                        car.TravelDistance(kilometers);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.TravelDistance(kilometers);
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.FuelConsumptionPerKm += 1.4;
                        bus.TravelDistance(kilometers);
                        bus.FuelConsumptionPerKm -= 1.4;
                    }
                }
                else if (input[0] == "Refuel")
                {
                    double fuel = Convert.ToDouble(input[2]);
                    if (input[1] == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(fuel);

                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refuel(fuel);
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    double kilometers = Convert.ToDouble(input[2]);
                    bus.TravelDistance(kilometers);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}

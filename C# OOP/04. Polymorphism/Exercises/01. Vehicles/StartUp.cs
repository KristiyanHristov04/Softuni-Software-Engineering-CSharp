 using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

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
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}

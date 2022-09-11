using System;
using _03._Car_Constructors;
namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = Convert.ToInt32(Console.ReadLine());
            double fuelQuantity = Convert.ToDouble(Console.ReadLine());
            double fuelConsumption = Convert.ToDouble(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);  
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}

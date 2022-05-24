using System;

namespace _08._Fuel_Tank___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelQty = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();

            double fuelPrice = 0;
            switch (fuelType)
            {
                case "Gas":
                    fuelPrice = discountCard == "Yes" ? 0.93 - 0.08 : 0.93;
                    break;
                case "Gasoline":
                    fuelPrice = discountCard == "Yes" ? 2.22 - 0.18 : 2.22;
                    break;
                case "Diesel":
                    fuelPrice = discountCard == "Yes" ? 2.33 - 0.12 : 2.33;
                    break;
            }

            if (fuelQty > 25)
            {
                fuelPrice *= 0.90;
            }
            else if (fuelQty >= 20)
            {
                fuelPrice *= 0.92;
            }

            double result = fuelQty * fuelPrice;
            Console.WriteLine($"{result:f2} lv.");
        }
    }
}

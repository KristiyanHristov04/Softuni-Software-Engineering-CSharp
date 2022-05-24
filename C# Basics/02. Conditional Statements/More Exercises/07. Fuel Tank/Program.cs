using System;

namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine();
            double currentFuel = Convert.ToDouble(Console.ReadLine());
            if (currentFuel >= 25 && (typeOfFuel.ToLower() == "diesel" || typeOfFuel.ToLower() == "gasoline" || typeOfFuel.ToLower() == "gas"))
            {
                Console.WriteLine($"You have enough {typeOfFuel.ToLower()}.");
            }
            else if (currentFuel < 25 && (typeOfFuel.ToLower() == "diesel" || typeOfFuel.ToLower() == "gasoline" || typeOfFuel.ToLower() == "gas"))
            {
                Console.WriteLine($"Fill your tank with {typeOfFuel.ToLower()}!");
            }
            else if (typeOfFuel.ToLower() != "diesel" || typeOfFuel.ToLower() != "gasoline" || typeOfFuel != "gas")
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}

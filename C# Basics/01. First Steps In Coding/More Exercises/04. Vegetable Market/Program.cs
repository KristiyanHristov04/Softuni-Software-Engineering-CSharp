using System;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            double PricePerKilogramVegetables = Convert.ToDouble(Console.ReadLine());
            double PricePerKilogramFruits = Convert.ToDouble(Console.ReadLine());
            int totalKilogramsVegetables = Convert.ToInt32(Console.ReadLine());
            int totalKilogramsFruits = Convert.ToInt32(Console.ReadLine());
            double totalPriceOfVegetablesAndFruits = (PricePerKilogramVegetables * totalKilogramsVegetables) +
                (PricePerKilogramFruits * totalKilogramsFruits);
            double totalPriceOfVegetablesAndFruitsInEuro = totalPriceOfVegetablesAndFruits / 1.94;
            Console.WriteLine($"{totalPriceOfVegetablesAndFruitsInEuro:f2}");
        }
    }
}

using System;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriqPricePerKiligram = Convert.ToDouble(Console.ReadLine());
            double cacaPricePerKilogram = Convert.ToDouble(Console.ReadLine());
            double palamudKilograms = Convert.ToDouble(Console.ReadLine());
            double safridKilograms = Convert.ToDouble(Console.ReadLine());
            double midiKilograms = Convert.ToDouble(Console.ReadLine());
            double palamudPricePerKilogram = skumriqPricePerKiligram + (skumriqPricePerKiligram * 0.60);
            double totalPricePalamud = palamudPricePerKilogram * palamudKilograms;
            double safridPricePerKilogram = cacaPricePerKilogram + (cacaPricePerKilogram * 0.80);
            double totalPriceSafrid = safridKilograms * safridPricePerKilogram;
            double totalPriceMidi = midiKilograms * 7.50;
            double totalPrice = totalPricePalamud + totalPriceSafrid + totalPriceMidi;
   
            Console.WriteLine($"{totalPrice:f2}");



        }
    }
}

using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double penPack = 5.80;
            double packageWithMarkers = 7.20;
            double preparationPerLiter = 1.20;


            int numberOfPenPacks = Convert.ToInt32(Console.ReadLine());
            int numberOfPackageWithMarkers = Convert.ToInt32(Console.ReadLine());
            int numberOfPreparationInLiters = Convert.ToInt32(Console.ReadLine());
            double discount = Convert.ToDouble(Console.ReadLine());

            double allMaterialsPrice = numberOfPenPacks * penPack + numberOfPackageWithMarkers
                * packageWithMarkers + numberOfPreparationInLiters * preparationPerLiter;

            double priceWithDiscount = allMaterialsPrice - (allMaterialsPrice * (discount / 100));

            Console.WriteLine(priceWithDiscount);
        }
    }
}

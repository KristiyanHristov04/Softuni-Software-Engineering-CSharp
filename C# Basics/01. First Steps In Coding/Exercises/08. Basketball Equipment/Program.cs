using System;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int annualTrainingPrice = Convert.ToInt32(Console.ReadLine());
            double sneakersPrice = annualTrainingPrice - (annualTrainingPrice * 0.40);
            double basketballOutfitPrice = sneakersPrice - (sneakersPrice * 0.20);
            double basketballBallPrice = basketballOutfitPrice / 4;
            double basketballAccessories = basketballBallPrice / 5;

            double totalEquipmentPrice = annualTrainingPrice + sneakersPrice + basketballOutfitPrice +
                basketballBallPrice + basketballAccessories;
            Console.WriteLine(totalEquipmentPrice);

        }
    }
}

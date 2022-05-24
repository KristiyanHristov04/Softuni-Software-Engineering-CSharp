using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.60;
            double speakingDollPrice = 3;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            double tripPrice = Convert.ToDouble(Console.ReadLine());
            int numberOfPuzzles = Convert.ToInt32(Console.ReadLine());
            int numberOfSpeakingDolls = Convert.ToInt32(Console.ReadLine());
            int numberOfTeddyBears = Convert.ToInt32(Console.ReadLine());
            int numberOfMinions = Convert.ToInt32(Console.ReadLine());
            int numberOfTrucks = Convert.ToInt32(Console.ReadLine());

            int totalToys = numberOfPuzzles + numberOfSpeakingDolls + numberOfTeddyBears +
                numberOfMinions + numberOfTrucks;

            double price = (numberOfPuzzles * puzzlePrice) + (numberOfSpeakingDolls * speakingDollPrice) +
                (numberOfTeddyBears * teddyBearPrice) + (numberOfMinions * minionPrice) +
                (numberOfTrucks * truckPrice);

            if (totalToys >= 50)
            {

                price = price - price * 0.25;
            }

            price = price - price * 0.1;
            double difference = price - tripPrice;

            if (difference >= 0)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }


        }
    }
}

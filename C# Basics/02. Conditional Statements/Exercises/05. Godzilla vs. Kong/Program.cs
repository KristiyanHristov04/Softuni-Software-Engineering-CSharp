using System;

namespace GodzillaVSKingKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = Convert.ToDouble(Console.ReadLine());
            int people = Convert.ToInt32(Console.ReadLine());
            double pricePerDressForOnePerson = Convert.ToDouble(Console.ReadLine());
            double decoration = budget * 0.10;
            double priceForDress = pricePerDressForOnePerson * people;

            if (people >= 150)
            {
                priceForDress = priceForDress - (priceForDress * 0.1);
            }

            double neededMoney = priceForDress + decoration;
            double difference = budget - neededMoney;

            if (difference >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {difference:f2} leva more.");
            }

        }
    }
}


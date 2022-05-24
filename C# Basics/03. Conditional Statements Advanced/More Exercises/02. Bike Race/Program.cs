using System;

namespace _0.BikeRace
{
    class BikeRace
    {
        static void Main()
        {
            int juniorRacers = int.Parse(Console.ReadLine());
            int seniorRacers = int.Parse(Console.ReadLine());
            string road = Console.ReadLine();

            if (road == "cross-country" && juniorRacers + seniorRacers >= 50)
            {
                double sum = ((juniorRacers * 8) + (seniorRacers * 9.50)) * 0.95;
                double sumWithDiscount = sum * 0.75;
                Console.WriteLine("{0:F2}", sumWithDiscount);
            }

            else if (true)
            {
                double juniorRates = 0d;
                double seniorRates = 0d;
                switch (road)
                {
                    case "trail":
                        juniorRates = 5.50;
                        seniorRates = 7;
                        break;
                    case "cross-country":
                        juniorRates = 8;
                        seniorRates = 9.50;
                        break;
                    case "downhill":
                        juniorRates = 12.25;
                        seniorRates = 13.75;
                        break;
                    case "road":
                        juniorRates = 20;
                        seniorRates = 21.50;
                        break;

                    default:
                        break;
                }
                double netSum = ((juniorRacers * juniorRates) +
                    (seniorRacers * seniorRates)) * 0.95;
                Console.WriteLine("{0:F2}", netSum);
            }
        }
    }
}

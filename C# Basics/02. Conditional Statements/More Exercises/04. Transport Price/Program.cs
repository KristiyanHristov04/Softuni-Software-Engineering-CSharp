using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {          
            int n = Convert.ToInt32(Console.ReadLine());
            
            string typeOfDay = Console.ReadLine();
            
            double taxiPrice = 0.70;
            
            double taxiDayPrice = 0.79;
            
            double taxiNightPrice = 0.90;
           
            double totalTaxiPriceDay = taxiPrice + (n * taxiDayPrice);
            
            double totalTaxiPriceNight = taxiPrice + (n * taxiNightPrice);



            
            double busPrice = 0.09;
           
            double trainPrice = 0.06;

            
            double totalBusPrice = busPrice * n;
            
            double totalTrainPrice = trainPrice * n;

            if (n < 20 && typeOfDay == "day")
            {
                Console.WriteLine($"{totalTaxiPriceDay:f2}");
            }
            else if (n < 20 && typeOfDay == "night")
            {
                Console.WriteLine($"{totalTaxiPriceNight:f2}");
            }
            else if (n >= 20 && n < 100 && (typeOfDay == "night" || typeOfDay == "day"))
            {
                Console.WriteLine($"{totalBusPrice:f2}");
            }

            else if (n >= 100 && (typeOfDay == "day" || typeOfDay == "night"))
            {
                Console.WriteLine($"{totalTrainPrice:f2}");
            }

        }
    }
}

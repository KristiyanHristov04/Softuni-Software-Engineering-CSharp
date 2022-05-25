using System;

namespace Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Excursion Calculator
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());
            string season = Console.ReadLine();
            double totalPrice = 0;
            if (numberOfPeople <= 5)
            {
                switch (season)
                {
                    case "spring":
                        totalPrice = numberOfPeople * 50;                      
                    break;
                    case "summer":
                        totalPrice = numberOfPeople * 48.50;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                        break;
                    case "autumn":
                        totalPrice = numberOfPeople * 60;
                        break;
                    case "winter":
                        totalPrice = numberOfPeople * 86;
                        totalPrice = totalPrice + (totalPrice * 0.08);
                        break;

                }
            }
            else if(numberOfPeople > 5)
            {
                switch (season)
                {
                    case "spring":
                        totalPrice = numberOfPeople * 48;
                        break;
                    case "summer":
                        totalPrice = numberOfPeople * 45;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                        break;
                    case "autumn":
                        totalPrice = numberOfPeople * 49.50;
                        break;
                    case "winter":
                        totalPrice = numberOfPeople * 85;
                        totalPrice = totalPrice + (totalPrice * 0.08);
                        break;

                }
            }
            Console.WriteLine($"{totalPrice:f2} leva.");
        }
    }
}

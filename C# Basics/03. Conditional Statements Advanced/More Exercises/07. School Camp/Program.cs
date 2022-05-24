using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int countStudents = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            decimal price = 0;

            string sport = "";
            if (season == "Winter")
            {
                if (group == "boys")
                {
                    decimal pricePerNights = countStudents * 9.60m * nights;
                    price = pricePerNights;
                    sport = "Judo";
                }
                else if (group == "girls")
                {
                    decimal pricePerNights = countStudents * 9.60m * nights;
                    price = pricePerNights;
                    sport = "Gymnastics";
                }
                else if (group == "mixed")
                {
                    decimal pricePerNights = countStudents * 10.00m * nights;
                    price = pricePerNights;
                    sport = "Ski";
                }
            }
            else if (season == "Spring")
            {
                if (group == "boys")
                {
                    decimal pricePerNights = countStudents * 7.20m * nights;
                    price = pricePerNights;
                    sport = "Tennis";
                }
                else if (group == "girls")
                {
                    decimal pricePerNights = countStudents * 7.20m * nights;
                    price = pricePerNights;
                    sport = "Athletics";
                }
                if (group == "mixed")
                {
                    decimal pricePerNights = countStudents * 9.50m * nights;
                    price = pricePerNights;
                    sport = "Cycling";

                }
            }
            if (season == "Summer")
            {
                if (group == "boys")
                {
                    decimal pricePerNights = countStudents * 15m * nights;
                    price = pricePerNights;
                    sport = "Football";
                }
                else if (group == "girls")
                {
                    decimal pricePerNights = countStudents * 15m * nights;
                    price = pricePerNights;
                    sport = "Volleyball";
                }
                else if (group == "mixed")
                {
                    decimal pricePerNights = countStudents * 20m * nights;
                    price = pricePerNights;
                    sport = "Swimming";
                }
            }

            int pricePrecAfterDisc = 100;
            if (countStudents >= 50)
            {
                pricePrecAfterDisc = 50;
            }
            else if (countStudents >= 20)
            {
                pricePrecAfterDisc = 85;
            }
            else if (countStudents >= 10)
            {
                pricePrecAfterDisc = 95;
            }

            decimal finalPrice = price * pricePrecAfterDisc / 100;
            Console.WriteLine($"{sport} {finalPrice:f2} lv.");
        }
    }
}
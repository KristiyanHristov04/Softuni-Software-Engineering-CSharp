using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = Convert.ToInt32(Console.ReadLine());
            double apartmentPrice = 0;
            double studioPrice = 0;
            double totalPriceApartment = 0;
            double totalPriceStudio = 0;

            switch (month)
            {
                case "May":
                case "October":
                    apartmentPrice = 65;
                    studioPrice = 50;
                    if (days > 7 && days <= 14)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceStudio = studioPrice * days;
                        totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.05);
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    else if (days <= 7 && days >= 0)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceStudio = studioPrice * days;
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    else if (days > 14 && days <= 200)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceApartment = totalPriceApartment - (totalPriceApartment * 0.10);
                        totalPriceStudio = studioPrice * days;
                        totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.30);
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    break;
                case "June":
                case "September":
                    apartmentPrice = 68.70;
                    studioPrice = 75.20;
                    if (days > 14 && days <= 200)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceApartment = totalPriceApartment - (totalPriceApartment * 0.10);
                        totalPriceStudio = studioPrice * days;
                        totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.20);
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    else if (days >= 0 && days <= 14)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceStudio = studioPrice * days;
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    break;
                case "July":
                case "August":
                    apartmentPrice = 77.0;
                    studioPrice = 76.0;
                    if (days > 14 && days <= 200)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceApartment = totalPriceApartment - (totalPriceApartment * 0.10);
                        totalPriceStudio = studioPrice * days;
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    else if (days >= 0 && days <= 14)
                    {
                        totalPriceApartment = apartmentPrice * days;
                        totalPriceStudio = studioPrice * days;
                        Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
                    }
                    break;

            }
        }
    }
}

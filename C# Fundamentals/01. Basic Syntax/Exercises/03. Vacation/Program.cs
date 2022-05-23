using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double priceForOnePerson = 0;
            double totalPrice = 0;
            switch (typeOfGroup)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOnePerson = 8.45;
                            break;
                        case "Saturday":
                            priceForOnePerson = 9.80;
                            break;
                        case "Sunday":
                            priceForOnePerson = 10.46;
                            break;
                    }
                    break;

                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOnePerson = 10.90;
                            break;
                        case "Saturday":
                            priceForOnePerson = 15.60;
                            break;
                        case "Sunday":
                            priceForOnePerson = 16;
                            break;
                    }
                    break;

                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOnePerson = 15;
                            break;
                        case "Saturday":
                            priceForOnePerson = 20;
                            break;
                        case "Sunday":
                            priceForOnePerson = 22.50;
                            break;
                    }
                    break;
            }
            if (numberOfPeople >= 30 && typeOfGroup == "Students")
            {
                totalPrice = priceForOnePerson * numberOfPeople;                
                totalPrice -= totalPrice * 0.15;
            }
            else if(numberOfPeople >= 100 && typeOfGroup == "Business")
            {
                numberOfPeople -= 10;
                totalPrice = priceForOnePerson * numberOfPeople;
            }
            else if(numberOfPeople >= 10 && numberOfPeople <= 20 && typeOfGroup == "Regular")
            {
                totalPrice = priceForOnePerson * numberOfPeople;
                totalPrice -= totalPrice * 0.05;
            }
            else
            {
                totalPrice = numberOfPeople * priceForOnePerson;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}

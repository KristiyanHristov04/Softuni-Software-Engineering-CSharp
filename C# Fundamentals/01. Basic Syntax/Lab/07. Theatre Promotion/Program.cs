using System;

namespace Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            //07.Theatre Promotions
            string typeOfDay = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            int ticketPrice = 0;
            switch (typeOfDay)
            {
                case "Weekday":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 18;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 12;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        return;
                    }
                    break;



                case "Weekend":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 15;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        return;
                    }
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 10;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("Error!");
                    return;
            }
            Console.WriteLine(ticketPrice + "$");

        }
    }
}

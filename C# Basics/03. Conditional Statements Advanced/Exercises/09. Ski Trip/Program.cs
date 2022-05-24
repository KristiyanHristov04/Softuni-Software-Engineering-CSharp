using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int stayingDays = Convert.ToInt32(Console.ReadLine());
            string typeOfAccommodation = Console.ReadLine();
            string rate = Console.ReadLine();
            double endPrice = 0;
            switch (typeOfAccommodation)
            {
                case "room for one person":
                    endPrice = (stayingDays - 1) * 18.00;
                    if (rate == "positive")
                    {
                        endPrice = endPrice + (endPrice * 0.25);
                        Console.WriteLine($"{endPrice:f2}");
                    }
                    else if (rate == "negative")
                    {
                        endPrice = endPrice - (endPrice * 0.10);
                        Console.WriteLine($"{endPrice:f2}");
                    }
                    break;
                case "apartment":
                    if (stayingDays < 10)
                    {
                        endPrice = (stayingDays - 1) * 25.00;
                        endPrice = endPrice - (endPrice * 0.30);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    else if (stayingDays >= 10 && stayingDays <= 15)
                    {
                        endPrice = (stayingDays - 1) * 25.00;
                        endPrice = endPrice - (endPrice * 0.35);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    else if (stayingDays > 15)
                    {
                        endPrice = (stayingDays - 1) * 25.00;
                        endPrice = endPrice - (endPrice * 0.50);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    break;
                case "president apartment":
                    if (stayingDays < 10)
                    {
                        endPrice = (stayingDays - 1) * 35.00;
                        endPrice = endPrice - (endPrice * 0.10);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    else if (stayingDays >= 10 && stayingDays <= 15)
                    {
                        endPrice = (stayingDays - 1) * 35.00;
                        endPrice = endPrice - (endPrice * 0.35);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    else if (stayingDays > 15)
                    {
                        endPrice = (stayingDays - 1) * 35.00;
                        endPrice = endPrice - (endPrice * 0.20);
                        if (rate == "positive")
                        {
                            endPrice = endPrice + (endPrice * 0.25);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                        else if (rate == "negative")
                        {
                            endPrice = endPrice - (endPrice * 0.10);
                            Console.WriteLine($"{endPrice:f2}");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
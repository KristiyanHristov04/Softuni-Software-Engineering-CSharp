using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = Convert.ToDouble(Console.ReadLine());
            string season = Console.ReadLine();
            double leftMoney = 0;
            switch (season)
            {
                case "summer":
                    if (budget <= 100)
                    {
                        leftMoney = budget - (budget * 0.30);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Camp - {leftMoney:f2}");
                    }
                    else if (budget > 100 && budget <= 1000)
                    {
                        leftMoney = budget - (budget * 0.40);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Camp - {leftMoney:f2}");
                    }
                    else if (budget > 1000)
                    {
                        leftMoney = budget - (budget * 0.90);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {leftMoney:f2}");
                    }
                    break;
                case "winter":
                    if (budget <= 100)
                    {
                        leftMoney = budget - (budget * 0.70);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Hotel - {leftMoney:f2}");
                    }
                    else if (budget > 100 && budget <= 1000)
                    {
                        leftMoney = budget - (budget * 0.80);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Hotel - {leftMoney:f2}");
                    }
                    else if (budget > 1000)
                    {
                        leftMoney = budget - (budget * 0.90);
                        leftMoney = budget - leftMoney;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {leftMoney:f2}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

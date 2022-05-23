using System;

namespace Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;

            double nutsPrice = 2.00;
            double waterPrice = 0.70;
            double crispsPrice = 1.50;
            double sodaPrice = 0.80;
            double cokePrice = 1.00;

            while (input != "Start")
            {
                if (Convert.ToDouble(input) == 0.10 || Convert.ToDouble(input) == 0.20
                    ||Convert.ToDouble(input) == 0.50 || Convert.ToDouble(input) == 1.00
                    || Convert.ToDouble(input) == 2.00)
                {
                    balance += Convert.ToDouble(input);
                }
                else
                {
                    Console.WriteLine($"Cannot accept {input}");
                }
                input = Console.ReadLine();
            }

            while (input != "End")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "End":
                        break;

                    case "Coke":
                        if (balance >= cokePrice)
                        {
                            balance -= cokePrice;
                            Console.WriteLine("Purchased coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Soda":
                        if (balance >= sodaPrice)
                        {
                            balance -= sodaPrice;
                            Console.WriteLine("Purchased soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Crisps":
                        if (balance >= crispsPrice)
                        {
                            balance -= crispsPrice;
                            Console.WriteLine("Purchased crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Nuts":
                        if (balance >= nutsPrice)
                        {
                            balance -= nutsPrice;
                            Console.WriteLine("Purchased nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Water":
                        if (balance >= waterPrice)
                        {
                            balance -= waterPrice;
                            Console.WriteLine("Purchased water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }
            Console.WriteLine($"Change: {balance:f2}");
        }
    }
}

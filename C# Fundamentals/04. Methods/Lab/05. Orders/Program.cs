using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = Convert.ToDouble(Console.ReadLine());
            double result = OrderPrice(product, quantity);
            Console.WriteLine($"{result:f2}");
        }
        static double OrderPrice(string item, double quantity)
        {
            double itemPrice = 0;
            double result = 0;
            switch (item)
            {
                case "water":
                    itemPrice = 1.00;
                    result = itemPrice * quantity;
                    break;
                case "coffee":
                    itemPrice = 1.50;
                    result = itemPrice * quantity;
                    break;
                case "snacks":
                    itemPrice = 2.00;
                    result = itemPrice * quantity;
                    break;
                case "coke":
                    itemPrice = 1.40;
                    result = itemPrice * quantity;
                    break;
            }
            return result;
        }
    }
}

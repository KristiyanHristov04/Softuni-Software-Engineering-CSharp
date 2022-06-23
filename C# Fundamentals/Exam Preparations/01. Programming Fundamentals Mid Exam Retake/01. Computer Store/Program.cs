using System;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string customerType = string.Empty;
            double resultWithNoTax = 0;

            if (input == "regular" || input == "special")
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            while (true)
            {
                if (input == "regular")
                {
                    customerType = "regular";
                    break;
                }
                else if (input == "special")
                {
                    customerType = "special";
                    break;
                }
                double productPrice = Convert.ToDouble(input);
                if (productPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                resultWithNoTax += productPrice;
                input = Console.ReadLine();


            }

            double taxes = resultWithNoTax + (resultWithNoTax * 0.20);
            taxes -= resultWithNoTax;
            double finalPrice = taxes + resultWithNoTax;

            if (customerType == "special")
            {
                finalPrice -= finalPrice * 0.10;
            }

            if (finalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {resultWithNoTax:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {finalPrice:f2}$");
        }
    }
}
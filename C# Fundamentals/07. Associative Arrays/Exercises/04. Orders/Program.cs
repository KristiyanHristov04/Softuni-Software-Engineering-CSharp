using System;
using System.Collections.Generic;
namespace _04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> orders = new Dictionary<string, Product>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }
                string[] commands = input.Split(' ');
                string name = commands[0];
                double productPrice = Convert.ToDouble(commands[1]);
                int productQuantity = Convert.ToInt32(commands[2]);

                if (!orders.ContainsKey(name))
                {
                    Product product = new Product(productPrice, productQuantity);
                    orders.Add(name, product);
                }
                else if(orders.ContainsKey(name))
                {
                    orders[name].Quantity += productQuantity;
                    if (orders[name].Price != productPrice)
                    {
                        orders[name].Price = productPrice;
                    }
                }
            }

            foreach (var product in orders)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value.Quantity * product.Value.Price):f2}");
            }
        }
        class Product
        {
            public double Price { get; set; }
            public int Quantity { get; set; }
            public Product(double price, int quantity)
            {
                this.Price = price;
                this.Quantity = quantity;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<ProductInformation>> shops = new Dictionary<string, List<ProductInformation>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }
                string[] commands = input.Split(", ");
                string currShop = commands[0];
                string productName = commands[1];
                double productPrice = Convert.ToDouble(commands[2]);
                if (shops.ContainsKey(currShop))
                {
                    ProductInformation productInformation = new ProductInformation(productName, productPrice);
                    shops[currShop].Add(productInformation);
                }
                else
                {
                    ProductInformation productInformation = new ProductInformation(productName, productPrice);
                    shops.Add(currShop, new List<ProductInformation>());
                    shops[currShop].Add(productInformation);
                }
            }

            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                for (int i = 0; i < shop.Value.Count; i++)
                {
                    Console.WriteLine($"Product: {shop.Value[i].Product}, Price: {shop.Value[i].Price}" );
                }
            }
        }
    }
    class ProductInformation
    {
        public string Product { get; set; }
        public double Price { get; set; }
        public ProductInformation(string product, double price)
        {
            this.Product = product;
            this.Price = price;
        }
    }
}

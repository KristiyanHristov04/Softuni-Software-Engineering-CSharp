using System;
using System.Collections.Generic;
using System.Linq;
namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] names = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in names)
            {
                try
                {
                    string[] tokens = name.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string personName = tokens[0];
                    int personMoney = int.Parse(tokens[1]);
                    Person person = new Person(personName, personMoney);
                    people.Add(personName, person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
                
            }

            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string product in productsInput)
            {
                try
                {
                    string[] tokens = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string productName = tokens[0];
                    int productPrice = int.Parse(tokens[1]);
                    Product currProduct = new Product(productName, productPrice);
                    products.Add(productName, currProduct);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
                
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string product = tokens[1];
                if (people[name].Money >= products[product].Cost)
                {
                    people[name].Money -= products[product].Cost;
                    people[name].Products.Add(products[product]);
                    Console.WriteLine($"{name} bought {product}");
                }
                else
                {
                    Console.WriteLine($"{name} can't afford {product}");
                }
            }

            foreach (var person in people)
            {
                if (person.Value.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Key} - " + String.Join(", ", person.Value.Products.Select(p => p.Name)));
                }
                else
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();
            List<Product> allProducts = new List<Product>();
            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < people.Length; i++)
            {
                string currentPerson = people[i];
                string[] commands = currentPerson.Split('=');
                string name = commands[0];
                int money = Convert.ToInt32(commands[1]);
                Person newPerson = new Person(name, money);
                allPeople.Add(newPerson);
            }

            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < products.Length; i++)
            {
                string currentProduct = products[i];
                string[] commands = currentProduct.Split('=');
                string productName = commands[0];
                int productPrice = Convert.ToInt32(commands[1]);
                Product newProduct = new Product(productName, productPrice);
                allProducts.Add(newProduct);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] commands = input.Split();
                string personName = commands[0];
                string productName = commands[1];
                for (int i = 0; i < allPeople.Count; i++)
                {
                    if (allPeople[i].Name == personName)
                    {
                        for (int j = 0; j < allProducts.Count; j++)
                        {
                            if (allProducts[j].ProductName == productName)
                            {
                                if (allPeople[i].Money >= allProducts[j].ProductPrice)
                                {
                                    allPeople[i].bagOfProducts.Add(productName);
                                    Console.WriteLine($"{allPeople[i].Name} bought {productName}");
                                    allPeople[i].Money -= allProducts[j].ProductPrice;
                                }
                                else
                                {
                                    Console.WriteLine($"{allPeople[i].Name} can't afford {productName}");
                                }
                                break;
                            }
                        }
                        break;
                    }
                }        
            }
            for (int i = 0; i < allPeople.Count; i++)
            {
                if (allPeople[i].bagOfProducts.Count > 0)
                {
                    Console.WriteLine(allPeople[i].Name + " - " + String.Join(", ", allPeople[i].bagOfProducts));
                }
                else
                {
                    Console.WriteLine(allPeople[i].Name + " - " + "Nothing bought");
                }
                 
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> bagOfProducts { get; set; }

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<string>();
        }
    }
    class Product
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public Product(string productName, int productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }
    }
}

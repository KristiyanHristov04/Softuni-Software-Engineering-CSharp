using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] items = input.Split(", ");
                string name = items[0];
                int age = Convert.ToInt32(items[1]);
                people.Add(name, age);
            }

            string secondInput = Console.ReadLine();
            if (secondInput == "older" || secondInput == "younger")
            {
                string condition = secondInput;
                secondInput = Console.ReadLine();
                int years = Convert.ToInt32(secondInput);
                secondInput = Console.ReadLine();
                string format = string.Empty;
                if (secondInput == "age")
                {
                    format = "age";
                }
                else if (secondInput == "name")
                {
                    format = "name";
                }
                else if (secondInput == "name age")
                {
                    format = "name age";
                }

                switch (condition)
                {
                    case "older":
                        if (format == "age")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value >= years)
                                {
                                    Console.WriteLine(person.Value);
                                }
                            }
                        }
                        else if (format == "name")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value >= years)
                                {
                                    Console.WriteLine(person.Key);
                                }
                            }
                        }
                        else if (format == "name age")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value >= years)
                                {
                                    Console.WriteLine($"{person.Key} - {person.Value}");
                                }
                            }
                        }
                        break;
                    case "younger":
                        if (format == "age")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value < years)
                                {
                                    Console.WriteLine(person.Value);
                                }
                            }
                        }
                        else if (format == "name")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value < years)
                                {
                                    Console.WriteLine(person.Key);
                                }
                            }
                        }
                        else if (format == "name age")
                        {
                            foreach (var person in people)
                            {
                                if (person.Value < years)
                                {
                                    Console.WriteLine($"{person.Key} - {person.Value}");
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}

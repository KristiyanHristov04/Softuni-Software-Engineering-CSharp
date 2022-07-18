using System;
using System.Collections.Generic;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAndAges = new Dictionary<string, int>();
            int n= Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int nameStart = input.IndexOf('@');
                int ageStart = input.IndexOf('#');
                string name = string.Empty;
                string age = string.Empty;
                for (int j = nameStart + 1; j < input.Length; j++)
                {
                    if (input[j] == '|')
                    {
                        break;
                    }
                    name += input[j];
                }

                for (int j = ageStart + 1; j < input.Length; j++)
                {
                    if (input[j] == '*')
                    {
                        break;
                    }
                    age += input[j];
                }
                namesAndAges.Add(name, int.Parse(age));
            }
            foreach (var person in namesAndAges)
            {
                Console.WriteLine($"{person.Key} is {person.Value} years old.");
            }
        }
    }
}

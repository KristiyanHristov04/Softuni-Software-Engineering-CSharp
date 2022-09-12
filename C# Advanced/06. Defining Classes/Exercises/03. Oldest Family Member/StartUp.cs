using System;
using DefiningClasses;
namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = Convert.ToInt32(input[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember(family.People);
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}

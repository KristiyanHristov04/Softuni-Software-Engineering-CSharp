using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Family family = new Family();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = Convert.ToInt32(input[1]);

                Person person = new Person(name, age);
                family.AddMember(name, age, family.people);
            }

            Console.WriteLine(family.GetOldestMember(family.people));
        }
    }
    class Family
    {
        public List<Person> people { get; set; } = new List<Person>();

        public void AddMember(string name, int age, List<Person> people)
        {
            people.Add(new Person(name, age));
        }

        public string GetOldestMember(List<Person> people)
        {
            List<Person> oldestMember = people.OrderByDescending(member => member.Age).ToList();
            return $"{oldestMember[0].Name} {oldestMember[0].Age}";
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}

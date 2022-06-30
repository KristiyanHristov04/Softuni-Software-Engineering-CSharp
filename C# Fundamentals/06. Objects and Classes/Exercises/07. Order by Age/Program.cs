using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                bool isExisting = false;

                if (input[0] == "End")
                {
                    break;
                }

                string personName = input[0];
                string personID = input[1];
                int personAge = Convert.ToInt32(input[2]);

                for (int i = 0; i < persons.Count; i++)
                {
                    if (personID == persons[i].Id)
                    {
                        persons[i].Name = personName;
                        persons[i].Age = personAge;
                        isExisting = true;
                        break;
                    }
                }

                if (!isExisting)
                {
                    Person currentPerson = new Person(personName, personID, personAge);
                    persons.Add(currentPerson);
                }
                
            }

            List<Person> orderedPersons = persons.OrderBy(person => person.Age).ToList();

            foreach (var person in orderedPersons)
            {
                Console.WriteLine(person);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}

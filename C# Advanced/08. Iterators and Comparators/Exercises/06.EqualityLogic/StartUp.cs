using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = Convert.ToInt32(input[1]);
                Person currPerson = new Person(name, age);
                sortedSet.Add(currPerson);
                hashSet.Add(currPerson);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}

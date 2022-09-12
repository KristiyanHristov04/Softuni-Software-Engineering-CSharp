using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("John", 12);
            Console.WriteLine(person.Age);
        }
    }
}

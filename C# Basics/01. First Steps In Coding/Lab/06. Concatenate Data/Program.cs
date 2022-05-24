using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine($"You are {firstName} {lastName}, a {age}-years old person from {town}.");

        }
    }
}

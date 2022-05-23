using System;

namespace _12._Even_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //12. Even Number
            int number = Convert.ToInt32(Console.ReadLine());
            while (number % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                number = Convert.ToInt32(Console.ReadLine());
            }
            number = Math.Abs(number);
            Console.WriteLine($"The number is: {number}");
        }
    }
}

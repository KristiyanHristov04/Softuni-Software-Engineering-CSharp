using System;

namespace DefiningClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int result = DateModifier.CalculateDifference(firstDate, secondDate);
            Console.WriteLine(Math.Abs(result));
        }
    }
}

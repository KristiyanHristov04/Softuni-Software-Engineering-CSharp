using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] passengers = new int[n];
            int sum = 0;
            for (int i = 0; i < passengers.Length; i++)
            {
                int numberOfPeople = Convert.ToInt32(Console.ReadLine());
                passengers[i] = numberOfPeople;
                sum += passengers[i];
            }
            foreach (var passenger in passengers)
            {
                Console.Write(passenger + " ");
            }
            Console.WriteLine("\n" + sum);
        }
    }
}

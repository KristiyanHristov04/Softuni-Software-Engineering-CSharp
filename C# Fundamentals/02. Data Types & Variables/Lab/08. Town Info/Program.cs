using System;

namespace Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine(); 
            int townPopulation = Convert.ToInt32(Console.ReadLine());
            int townArea = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {townPopulation} and area {townArea} square km.");
        }
    }
}

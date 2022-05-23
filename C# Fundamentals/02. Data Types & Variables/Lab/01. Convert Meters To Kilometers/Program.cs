using System;

namespace _01._Convert_Meters_To_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meters = Convert.ToInt32(Console.ReadLine());
            decimal kilometers = meters / 1000m;
            Console.WriteLine($"{kilometers:f2}");
            
        }
    }
}

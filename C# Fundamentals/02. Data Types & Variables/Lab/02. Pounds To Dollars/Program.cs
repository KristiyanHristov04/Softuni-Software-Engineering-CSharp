using System;

namespace Pounds_To_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal poundPrice = 1.31m;
            decimal pounds = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"{pounds * poundPrice:f3}");
        }
    }
}

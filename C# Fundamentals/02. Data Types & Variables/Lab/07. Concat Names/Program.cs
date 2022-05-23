using System;

namespace Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name01 = Console.ReadLine();
            string name02 = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{name01}{delimiter}{name02}");

        }
    }
}

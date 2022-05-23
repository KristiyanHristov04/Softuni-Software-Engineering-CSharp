using System;

namespace Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = Convert.ToChar(Console.ReadLine());
            char b = Convert.ToChar(Console.ReadLine());
            char c = Convert.ToChar(Console.ReadLine());

            Console.WriteLine($"{c} {b} {a}");
        }
    }
}

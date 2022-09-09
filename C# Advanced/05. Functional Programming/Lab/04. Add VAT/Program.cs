using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join("", Console.ReadLine().Split(", ").Select(double.Parse).Select(x => $"{ x + x * 0.20:f2}\n").ToArray()).TrimEnd());
        }
    }
}

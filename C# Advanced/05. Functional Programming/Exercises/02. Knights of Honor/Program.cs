using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Func<string, string> printNames = name => "Sir " + name;
            foreach (var name in input)
            {
                Console.WriteLine(printNames(name));
            }
        }
    }
}

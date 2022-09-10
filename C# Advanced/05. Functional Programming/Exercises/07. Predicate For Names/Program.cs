using System;
using System.Linq;
namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxLength = Convert.ToInt32(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Predicate<string> isInBounds = name => name.Length <= maxLength;
            foreach (var name in names.Where(name => isInBounds(name)))
            {
                Console.WriteLine(name);
            }
        }
    }
}

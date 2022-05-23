using System;

namespace Chars_To_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = Convert.ToChar(Console.ReadLine());
            char b = Convert.ToChar(Console.ReadLine());
            char c = Convert.ToChar(Console.ReadLine());
            string word = $"{a}{b}{c}";
            Console.WriteLine(word);

        }
    }
}

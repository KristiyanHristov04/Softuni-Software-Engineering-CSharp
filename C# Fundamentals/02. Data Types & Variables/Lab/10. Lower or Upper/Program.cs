using System;

namespace Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character = Convert.ToChar(Console.ReadLine());
            string type = "";
            if (character >= 'A' && character <= 'Z')
            {
                type = "upper-case";
            }
            else if(character >= 'a' && character <= 'z')
            {
                type = "lower-case";
            }
            Console.WriteLine(type);
        }
    }
}

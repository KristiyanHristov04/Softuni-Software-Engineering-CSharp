using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(isDigit(input));
            Console.WriteLine(isChar(input));
            Console.WriteLine(isSymbol(input));
        }
        static StringBuilder isDigit(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    result.Append(input[i]);
                }
            }
            return result;
        }
        static StringBuilder isSymbol(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= '!' && input[i] <= '/') || 
                    (input[i] >= ':' && input[i] <= '@') ||
                    (input[i] >= '[' && input[i] <= '`') ||
                    (input[i] >= '{' && input[i] <= '~'))
                {
                    result.Append(input[i]);
                }
            }
            return result;
        }
        static StringBuilder isChar(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                {
                    result.Append(input[i]);
                }
            }
            return result;
        }
    }
}

using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IsPalindrome(input);          
        }
        static void IsPalindrome(string input)
        {
            
            while (input != "END")
            {
                string number01 = input;
                string number02 = String.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    number02 += input[i];
                }
                if (number01 == number02)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }
        }
    }
}

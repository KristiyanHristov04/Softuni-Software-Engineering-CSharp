using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    return;
                }
                string reversedWord = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedWord += input[i];
                }
                Console.WriteLine($"{input} = {reversedWord}");
            }
        }
    }
}

using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reverse = "";
            int length = 0;
            //Console.WriteLine(input);
            length = input.Length - 1;
            while (length >= 0)
            {
                reverse = reverse + input[length];
                length--;
            }
            Console.WriteLine(reverse);
        }
    }
}

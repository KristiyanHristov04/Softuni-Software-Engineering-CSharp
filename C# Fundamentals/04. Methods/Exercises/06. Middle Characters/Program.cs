using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(FindMiddleCharacter(input));
        }
        static string FindMiddleCharacter(string input)
        {
            string middleChar = String.Empty;
            if (input.Length % 2 != 0)
            {
                int length = input.Length;
                int result = (length / 2);
                middleChar = Convert.ToString(input[result]);
            }
            else
            {
                int length = input.Length;
                int result = (length / 2) - 1;
                int result02 = result + 1;
                middleChar = Convert.ToString(input[result] + "" + input[result02]);
            }
            return middleChar;
        }
    }
}

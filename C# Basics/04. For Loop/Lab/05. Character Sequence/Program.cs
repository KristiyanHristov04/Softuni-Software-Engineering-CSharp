using System;

namespace Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //05.Character Sequence
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                Console.WriteLine(letter);
            }
        }
    }
}

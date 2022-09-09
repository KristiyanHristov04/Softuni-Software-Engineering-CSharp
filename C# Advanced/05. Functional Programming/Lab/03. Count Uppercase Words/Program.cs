using System;
using System.Collections.Generic;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> result = new Queue<string>();

            for (int i = 0; i < text.Length; i++)
            {
                string curretWord = text[i];
                char currentWordFirstChar = curretWord[0];
                if (char.IsUpper(currentWordFirstChar))
                {
                    result.Enqueue(curretWord);
                }
            }

            while (result.Count > 0)
            {
                Console.WriteLine(result.Dequeue());
            }
        }
    }
}

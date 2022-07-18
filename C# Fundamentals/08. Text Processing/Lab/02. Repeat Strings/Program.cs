using System;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            string finalWord = string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int wordLength = words[i].Length;
                for (int j = 0; j < wordLength; j++)
                {
                    finalWord += word;
                }
            }
            Console.WriteLine(finalWord);
        }
    }
}

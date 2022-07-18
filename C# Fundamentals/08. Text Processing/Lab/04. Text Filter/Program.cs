using System;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                while (text.Contains(bannedWords[i]))
                {
                    int bannedWordLength = bannedWords[i].Length;
                    string asterisks = string.Empty;
                    for (int j = 0; j < bannedWordLength; j++)
                    {
                        asterisks += "*";
                    }
                    text = text.Replace(bannedWords[i], asterisks);
                }
            }
            Console.WriteLine(text);
        }
    }
}

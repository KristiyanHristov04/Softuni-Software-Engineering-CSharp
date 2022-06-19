using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            string word = Console.ReadLine();
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Sentence(word, n)); 
        }
        static string Sentence(string word, int n)
        {
            string sentence = "";
            for (int i = 0; i < n; i++)
            {
                sentence += word;
            }
            return sentence;
        }
    }
}

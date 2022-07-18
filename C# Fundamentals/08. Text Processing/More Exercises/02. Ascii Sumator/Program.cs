using System;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = Convert.ToChar(Console.ReadLine());
            char secondChar = Convert.ToChar(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > firstChar && text[i] < secondChar)
                {
                    sum += text[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}

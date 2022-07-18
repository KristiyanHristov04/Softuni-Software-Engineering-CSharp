using System;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            for (int i = 0; i < text.Length; i++)
            {
                string stringToReplace = string.Empty;
                string symbol = text[i].ToString();
                for (int j = i; j < text.Length; j++)
                {
                    if (symbol == text[j].ToString())
                    {
                        stringToReplace += text[j].ToString();
                    }     
                    else
                    {
                        break;
                    }
                }
                text = text.Replace(stringToReplace, symbol);
            }
            Console.WriteLine(text);
            
        }
    }
}

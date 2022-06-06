using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array01 = Console.ReadLine().Split(' ').ToArray();
            string[] array02 = Console.ReadLine().Split(' ').ToArray();
            List<string> metWords = new List<string>();
            for (int i = 0; i < array02.Length; i++)
            {
                for (int j = 0; j < array01.Length; j++)
                {
                    if (array02[i] == array01[j])
                    {
                        metWords.Add(array02[i]);
                        break;
                    }
                }
            }
            foreach (var word in metWords)
            {
                Console.Write(word + " ");
            }
        }
    }
}

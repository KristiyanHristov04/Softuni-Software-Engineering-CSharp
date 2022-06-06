using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] results = new int[n];
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                for (int j = 0; j < word.Length; j++)
                {
                    if ((word[j]) == 'a' || word[j] == 'e' || word[j] == 'u' || word[j] == 'o' ||
                         word[j] == 'i' || word[j] == 'A' || word[j] == 'E' || word[j] == 'U' || word[j] == 'O' ||
                         word[j] == 'I')
                    {
                        results[i] += Convert.ToInt32(word[j]) * word.Length;
                    }
                    else
                    {
                        results[i] += Convert.ToInt32(word[j]) / word.Length;
                    }                                  
                }
            }
            Array.Sort(results);
            foreach (var value in results)
            {
                Console.WriteLine(value);
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        public static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[] lis;
            int[] len = new int[sequence.Length];
            int[] prev = new int[sequence.Length];
            int maxLength = 0;
            int lastIndex = -1;

            // обхождам поредицата
            for (int i = 0; i < sequence.Length; i++)
            {
                // len && prev съответно = 1 && -1
                len[i] = 1;
                prev[i] = -1;

                // обхождам поредицата и сравнявам за най-добра дължина на поредица
                // if i == j -> цикъл j няма да се изпълни
                for (int j = 0; j < i; j++)
                {
                    // ако текущата стойност j/в ляво/ е по-малка от i/в дясно/
                    // && текущия брой елементи j >= броя елементи на i -> броя на елементите /поредицата/ ще нараства
                    if (sequence[j] < sequence[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j; // запазваме индекса на най добрия елемент от поредицата
                    }
                }
                // запазвам максималния брой елементи
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }
            lis = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                lis[i] = sequence[lastIndex];
                lastIndex = prev[lastIndex];
            }
            Array.Reverse(lis);
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
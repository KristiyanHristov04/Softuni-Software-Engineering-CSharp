using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = array[0];
            int m = array[1];
            HashSet<int> set01 = new HashSet<int>();
            HashSet<int> set02 = new HashSet<int>();
            HashSet<int> uniqueSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                set01.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                set02.Add(number);
            }

            foreach (var number01 in set01)
            {
                foreach (var number02 in set02)
                {
                    if (number01 == number02)
                    {
                        uniqueSet.Add(number01);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", uniqueSet));
           
        }
    }
}

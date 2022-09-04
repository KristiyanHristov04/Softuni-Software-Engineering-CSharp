using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < input.Length; j++)
                {
                    if (!set.Contains(input[j]))
                    {
                        set.Add(input[j]);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", set));
        }
    }
}

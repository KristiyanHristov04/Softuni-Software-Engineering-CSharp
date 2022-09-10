using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = Convert.ToInt32(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<Predicate<int>> predicates = new Queue<Predicate<int>>();
            for (int i = 0; i < dividers.Length; i++)
            {
                int divider = dividers[i];
                Predicate<int> predicate = number => number % divider == 0;
                predicates.Enqueue(predicate);
            }

            for (int i = 0; i < dividers.Length; i++)
            {
                numbers = numbers.FindAll(predicates.Dequeue());
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (myDictionary.ContainsKey(number))
                {
                    myDictionary[number]++;
                }
                else
                {
                    myDictionary.Add(number, 1);
                }
            }

            foreach (var number in myDictionary)
            {
                if (number.Value % 2 == 0)
                {
                    int num = number.Key;
                    Console.WriteLine(num);
                    return;
                }
            }
        }
    }
}

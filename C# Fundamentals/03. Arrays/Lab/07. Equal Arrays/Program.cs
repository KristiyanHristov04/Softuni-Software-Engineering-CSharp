using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array01 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] array02 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < array01.Length; i++)
            {
                for (int j = 0; j < array02.Length; j++)
                {
                    j = i;
                    if (array01[i] == array02[j])
                    {
                        sum += array02[j];
                        break;
                    }
                    else if(array01[i] != array02[j])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                        return;
                    }
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");

        }
    }
}

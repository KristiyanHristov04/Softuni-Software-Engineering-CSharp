using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < values.Length; i++)
            {
                int leftSum = 0;
                for (int k = 0; k < i; k++)
                {
                    leftSum += values[k];
                }

                int rightSum = 0;
                for (int j = values.Length - 1; j > i; j--)
                {
                    rightSum += values[j];
                }

                if (leftSum == rightSum && !isFound)
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
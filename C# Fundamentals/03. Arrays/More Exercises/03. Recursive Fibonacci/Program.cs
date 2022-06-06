using System;

namespace _03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FibonachiRecursion(n)); 
        }
        static long FibonachiRecursion(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);
        }
    }
}

using System;

namespace Exact_Sum_Of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal number = Convert.ToDecimal(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}

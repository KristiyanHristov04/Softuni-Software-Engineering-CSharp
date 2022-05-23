using System;

namespace _09._Sum_Of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //09. Sum Of Odd Numbers
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n * 2; i += 2)
            {
                Console.WriteLine(i);
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

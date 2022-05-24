using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //07. Sum Numbers
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}

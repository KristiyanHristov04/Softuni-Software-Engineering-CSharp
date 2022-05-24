using System;

namespace Average_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Average Number
            int n = Convert.ToInt32(Console.ReadLine());
            double sumNumbers = 0;
            for (int i = 1; i <= n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                sumNumbers += number;
            }
            Console.WriteLine($"{sumNumbers / n:f2}");
        }
    }
}

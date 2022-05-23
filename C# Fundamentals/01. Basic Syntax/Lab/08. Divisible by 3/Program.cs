using System;

namespace _08._Divisible_by_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //08. Divisible by 3
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

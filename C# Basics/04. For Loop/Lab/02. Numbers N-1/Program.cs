using System;

namespace Numbers_N_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Numbers N...1
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = n; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}

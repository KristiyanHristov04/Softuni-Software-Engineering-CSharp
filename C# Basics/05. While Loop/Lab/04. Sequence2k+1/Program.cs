using System;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Sequence 2k+1
            int n = Convert.ToInt32(Console.ReadLine());
            int k = 1;
            while (k <= n)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}

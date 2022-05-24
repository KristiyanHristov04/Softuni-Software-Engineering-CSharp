using System;

namespace Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //04.Even Powers of 2
            int n = Convert.ToInt32(Console.ReadLine());          
            for (int power = 0; power <= n; power++)
            {
                if (power % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(2, power));
                }
                

            }
        }
    }
}

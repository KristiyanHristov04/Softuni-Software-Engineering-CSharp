using System;

namespace Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int sumDigits = 0;
            for (int i = 1; i <= n; i++)
            {
                string number = i.ToString();
                for (int j = 0; j < number.Length; j++)
                {
                    sumDigits += (int)number[j] - '0';
                }

                if (sumDigits == 5 || sumDigits == 7 || sumDigits == 11)
                {
                    Console.WriteLine($"{i} -> " + true);
                    sumDigits = 0;
                }
                else
                {
                    Console.WriteLine($"{i} -> " + false);
                    sumDigits = 0;
                }
            }
        }
    }
}

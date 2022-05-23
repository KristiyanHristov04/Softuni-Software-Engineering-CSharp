using System;

namespace Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int input = n;

            int factorialSum = 0;

            while (n > 0)
            {
                int number = n % 10;

                int factorial = 1;

                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;

                n /= 10;
            }

            if (factorialSum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}

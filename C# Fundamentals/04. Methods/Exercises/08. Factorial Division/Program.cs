using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number01 = Convert.ToInt32(Console.ReadLine());
            double number02 = Convert.ToInt32(Console.ReadLine());
            double factorial01 = FactorialNum01(number01);
            double factorial02 = FactorialNum02(number02);
            double result = factorial01 / factorial02;
            Console.WriteLine($"{result:f2}");
        }
        static double FactorialNum01(double number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * FactorialNum01(number - 1);
        }
        static double FactorialNum02(double number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * FactorialNum02(number - 1);
        }
    }
}

using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = Convert.ToDouble(Console.ReadLine());
            int power = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MathPower(number, power));
        }
        static double MathPower(double number, int power)
        {
            return Math.Pow(number, power);
        }
    }
}

using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num01 = Convert.ToInt32(Console.ReadLine());
            int num02 = Convert.ToInt32(Console.ReadLine());
            int num03 = Convert.ToInt32(Console.ReadLine());
            int firstResult = Sum(num01, num02);
            int secondResult = Subtract(firstResult, num03);
            Console.WriteLine(secondResult);
        }
        static int Sum(int num01, int num02)
        {
            int result = num01 + num02;
            return result;
        }
        static int Subtract(int result, int num03)
        {
            return result - num03;
        }
    }
}

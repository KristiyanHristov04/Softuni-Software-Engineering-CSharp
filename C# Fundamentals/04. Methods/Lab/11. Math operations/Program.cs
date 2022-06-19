using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num01 = Convert.ToDouble(Console.ReadLine());
            char operation = Convert.ToChar(Console.ReadLine());
            double num02 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(Calculate(num01, operation, num02));
        }
        static double Calculate(double a, char @operator, double b)
        {
            double result = 0;
            switch (@operator)
            {
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
            }
            return result;
        }
    }
}

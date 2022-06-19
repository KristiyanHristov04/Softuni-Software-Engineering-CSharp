using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int num01 = Convert.ToInt32(Console.ReadLine());
            int num02 = Convert.ToInt32(Console.ReadLine());
            if (operation == "add")
            {
                int result = Add(num01, num02);
                Console.WriteLine(result);
            }
            else if(operation == "multiply")
            {
                int result = Multiply(num01, num02);
                Console.WriteLine(result);
            }
            else if(operation == "subtract")
            {
                int result = Subtract(num01, num02);
                Console.WriteLine(result);
            }
            else if(operation == "divide")
            {
                int result = Divide(num01, num02);
                Console.WriteLine(result);
            }
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}

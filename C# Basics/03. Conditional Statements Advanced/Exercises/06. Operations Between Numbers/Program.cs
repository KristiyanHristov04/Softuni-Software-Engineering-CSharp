using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number01 = Convert.ToInt32(Console.ReadLine());
            int number02 = Convert.ToInt32(Console.ReadLine());
            char operation = Convert.ToChar(Console.ReadLine());
            double result = 0;
            if (operation == '+')
            {
                result = number01 + number02;
                if (result % 2 == 0)
                {
                    Console.WriteLine(number01 + " + " + number02 + " = " + result + " - even");

                }
                else if (result % 2 != 0)
                {
                    Console.WriteLine(number01 + " + " + number02 + " = " + result + " - odd");
                }
            }
            else if (operation == '-')
            {
                result = number01 - number02;
                if (result % 2 == 0)
                {
                    Console.WriteLine(number01 + " - " + number02 + " = " + result + " - even");

                }
                else if (result % 2 != 0)
                {
                    Console.WriteLine(number01 + " - " + number02 + " = " + result + " - odd");
                }
            }
            else if (operation == '*')
            {
                result = number01 * number02;
                if (result % 2 == 0)
                {
                    Console.WriteLine(number01 + " * " + number02 + " = " + result + " - even");

                }
                else if (result % 2 != 0)
                {
                    Console.WriteLine(number01 + " * " + number02 + " = " + result + " - odd");
                }
            }
            else if (operation == '/')
            {
                if (number02 == 0)
                {
                    Console.WriteLine($"Cannot divide {number01} by zero");
                }
                else
                {
                    result = 1.0 * number01 / number02;
                    Console.WriteLine($"{number01} / {number02} = {result:f2}");
                }
            }
            else if (operation == '%')
            {
                if (number02 == 0)
                {
                    Console.WriteLine($"Cannot divide {number01} by zero");
                }
                else
                {
                    result = number01 % number02;
                    Console.WriteLine($"{number01} % {number02} = {result}");
                }
            }
        }
    }
}

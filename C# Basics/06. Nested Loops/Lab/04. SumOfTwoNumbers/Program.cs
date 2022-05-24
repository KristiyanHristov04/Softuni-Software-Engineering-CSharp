using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Sum Of Two Numbers
            int start = Convert.ToInt32(Console.ReadLine());//Начало на интервала
            int end = Convert.ToInt32(Console.ReadLine());//Край на интервала
            int magicalNumber = Convert.ToInt32(Console.ReadLine());//Магическо число
            int counter = 0;
            int result = 0;
            for (int a = start; a <= end; a++)
            {
                for (int b = start; b <= end; b++)
                {
                    counter++;
                    result = a + b;
                    if (result == magicalNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({a} + {b} = {magicalNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{counter} combinations - neither equals {magicalNumber}");


        }
    }
}

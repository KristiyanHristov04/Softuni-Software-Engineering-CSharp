using System;

namespace SoftUniNestedLoopsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Clock
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int min = 0; min <= 59; min++)
                {
                    Console.WriteLine($"{hour}:{min}");
                }
            }
        }
    }
}

using System;

namespace SoftUniForLoopExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Numbers Ending in 7

            for (int i = 7; i <= 997; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

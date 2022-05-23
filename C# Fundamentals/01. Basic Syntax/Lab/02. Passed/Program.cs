using System;

namespace _02._Passed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //02. Passed
            double grade = Convert.ToDouble(Console.ReadLine());
            if (grade >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}

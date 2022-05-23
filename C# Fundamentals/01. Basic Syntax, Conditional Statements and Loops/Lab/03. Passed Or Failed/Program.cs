using System;

namespace _03._Passed_Or_Failed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //03. Passed or Failed
            double grade = Convert.ToDouble(Console.ReadLine());
            if (grade > 2.99)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}

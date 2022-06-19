using System;

namespace _05._MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double num01 = double.Parse(Console.ReadLine());
            double num02 = double.Parse(Console.ReadLine());
            double num03 = double.Parse(Console.ReadLine());

            ResultSign(num01, num02, num03);
        }

        public static void ResultSign(double num01, double num02, double num03)
        {
            if (num01 == 0 || num02 == 0 || num03 == 0)
            {
                Console.WriteLine("zero");
            }

            else if ((num01 > 0 && num02 > 0 && num03 > 0) || (num01 < 0 && num02 < 0 && num03 > 0) || (num01 < 0 && num02 > 0 && num03 < 0) || (num01 > 0 && num02 < 0 && num03 < 0))
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}


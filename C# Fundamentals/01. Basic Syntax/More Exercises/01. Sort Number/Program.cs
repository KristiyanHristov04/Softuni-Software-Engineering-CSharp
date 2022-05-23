using System;

namespace Fundamentals_Exercises_Lection_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //01.Sort Numbers
            int num01 = Convert.ToInt32(Console.ReadLine());
            int num02 = Convert.ToInt32(Console.ReadLine());
            int num03 = Convert.ToInt32(Console.ReadLine());
            int currentBiggestNumber = 0;
            if (num01 > num02 && num01 > num03)
            {
                Console.WriteLine(num01);
                currentBiggestNumber = num01;
                if (num02 > num03)
                {
                    Console.WriteLine(num02);
                    Console.WriteLine(num03);
                }
                else if (num03 > num02)
                {
                    Console.WriteLine(num03);
                    Console.WriteLine(num02);
                }
                else if (num03 == num02)
                {
                    Console.WriteLine(num02);
                    Console.WriteLine(num03);
                }
            }
            else if (num02 > num01 && num02 > num03)
            {
                Console.WriteLine(num02);
                currentBiggestNumber = num02;
                if (num03 > num01)
                {
                    Console.WriteLine(num03);
                    Console.WriteLine(num01);
                }
                else if (num01 > num03)
                {
                    Console.WriteLine(num01);
                    Console.WriteLine(num03);
                }
                else if (num01 == num03)
                {
                    Console.WriteLine(num01);
                    Console.WriteLine(num03);
                }
            }
            else if (num03 > num01 && num03 > num02)
            {
                Console.WriteLine(num03);
                currentBiggestNumber = num03;
                if (num02 > num01)
                {
                    Console.WriteLine(num02);
                    Console.WriteLine(num01);
                }
                else if (num01 > num02)
                {
                    Console.WriteLine(num01);
                    Console.WriteLine(num02);
                }
                else if (num02 == num01)
                {
                    Console.WriteLine(num02);
                    Console.WriteLine(num01);
                }
            }
        }
    }
}

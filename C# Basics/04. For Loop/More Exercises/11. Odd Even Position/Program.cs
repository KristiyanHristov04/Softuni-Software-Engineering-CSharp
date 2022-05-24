using System;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            //11. Odd / Even Position
            int n = Convert.ToInt32(Console.ReadLine());

            double oddSum = 0;
            double evenSum = 0;
            double oddNumMin = double.MaxValue;
            double evenNumMin = double.MaxValue;
            double oddNumMax = double.MinValue;
            double evenNumMax = double.MinValue;
            for (int i = 1; i <= n; i++)
            {
                double number = Convert.ToDouble(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (evenNumMin > number)
                    {
                        evenNumMin = number;
                    }
                    if (evenNumMax < number)
                    {
                        evenNumMax = number;
                    }
                }
                else if (i % 2 != 0)
                {
                    oddSum += number;
                    if (oddNumMin > number)
                    {
                        oddNumMin = number;
                    }
                    if (oddNumMax < number)
                    {
                        oddNumMax = number;
                    }
                }


            }
            if (n == 0)
            {
                oddSum = 0;
                evenSum = 0;
                
                Console.WriteLine("OddSum=" + $"{oddSum:f2},");
                Console.WriteLine("OddMin=" + "No,");
                Console.WriteLine("OddMax=" + "No,");
                Console.WriteLine("EvenSum=" + $"{evenSum:f2},");
                Console.WriteLine("EvenMin=" + "No,");
                Console.WriteLine("EvenMax=" + "No");
            }
            else if(n == 1)
            {
                Console.WriteLine("OddSum=" + $"{oddSum:f2},");
                Console.WriteLine("OddMin=" + $"{oddNumMin:f2},");
                Console.WriteLine("OddMax=" + $"{oddNumMax:f2},");
                Console.WriteLine("EvenSum=" + $"{evenSum:f2},");
                Console.WriteLine("EvenMin=" + "No,");
                Console.WriteLine("EvenMax=" + "No");

            }
            else
            {
                Console.WriteLine("OddSum=" + $"{oddSum:f2},");
                Console.WriteLine("OddMin=" + $"{oddNumMin:f2},");
                Console.WriteLine("OddMax=" + $"{oddNumMax:f2},");
                Console.WriteLine("EvenSum=" + $"{evenSum:f2},");
                Console.WriteLine("EvenMin=" + $"{evenNumMin:f2},");
                Console.WriteLine("EvenMax=" + $"{evenNumMax:f2}");
            }
            

            


        }
    }
}

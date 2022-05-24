using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //10. Odd Even Sum
            int n = Convert.ToInt32(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;
            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (i % 2 != 0)
                {
                    sumOdd += number;
                }
                else if(i % 2 == 0)
                {
                    sumEven += number;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + (sumEven + sumOdd) / 2);
            }
            else if(sumEven != sumOdd)
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + Math.Abs(sumOdd - sumEven));
            }
            //Console.WriteLine(sumOdd);
            //Console.WriteLine(sumEven);

        }
    }
}

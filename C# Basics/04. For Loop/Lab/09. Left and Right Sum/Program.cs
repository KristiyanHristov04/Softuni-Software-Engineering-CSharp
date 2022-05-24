using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //09. Left and Right Sum
            int n = Convert.ToInt32(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                int number1 = Convert.ToInt32(Console.ReadLine());
                sum1 += number1;                             
            }

            for (int i = 0; i < n; i++)
            {
                int number2 = Convert.ToInt32(Console.ReadLine());
                sum2 += number2;
            }


            if (sum1 == sum2)
            {
                Console.WriteLine("Yes, sum = " + (sum1 + sum2) / 2);
            }
            else if(sum1 != sum2)
            {
                Console.WriteLine("No, diff = " + Math.Abs(sum1 - sum2));
            }
            //Console.WriteLine(sum1);
            //Console.WriteLine(sum2);
        }
    }
}

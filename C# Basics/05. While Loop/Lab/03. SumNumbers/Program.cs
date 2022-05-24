using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. SumNumbers
            int number = Convert.ToInt32(Console.ReadLine());     
            int sum = 0;
            while (sum < number)
            {
                int currentNum = Convert.ToInt32(Console.ReadLine());
                sum += currentNum;
            }
            Console.WriteLine(sum);
        }
    }
}

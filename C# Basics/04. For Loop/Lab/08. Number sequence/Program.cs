using System;

namespace Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //08. Number sequence
            int n = Convert.ToInt32(Console.ReadLine());
            int minNumber = int.MaxValue; //+2147483647
            int maxNumber = int.MinValue; //-2147483648
            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
                if (number < minNumber) // 5 < 2147483647
                {
                    minNumber = number;
                }
                
            }
            Console.WriteLine("Max number: " + maxNumber);
            Console.WriteLine("Min number: " + minNumber);
        }
           
    }
}

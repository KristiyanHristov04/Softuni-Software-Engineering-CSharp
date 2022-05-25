using System;

namespace Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sum += Convert.ToInt32(number[i] - '0');
            }
            Console.WriteLine(sum);
        }
    }
}

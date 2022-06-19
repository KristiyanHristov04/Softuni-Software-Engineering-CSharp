using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            TopNumber(n);
        }
        static void TopNumber(int n)
        {
            for (int i = 17; i <= n; i++)
            {
                int topNumber = 0;
                bool isTopNumber = false;
                int sumOfDigits = 0;
                string number = i.ToString();
                for (int j = 0; j < number.Length; j++)
                {
                    sumOfDigits += Convert.ToInt32(number[j].ToString());
                    if (Convert.ToInt32(number[j].ToString()) % 2 != 0)
                    {
                        isTopNumber = true;
                        topNumber = i;
                    }
                }
                if (sumOfDigits % 8 != 0)
                {
                    isTopNumber = false;
                }
                if (isTopNumber)
                {
                    Console.WriteLine(topNumber);
                }
            }                                   
        }
    }
}

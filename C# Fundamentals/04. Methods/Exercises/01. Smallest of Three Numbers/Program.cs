using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num01 = Convert.ToInt32(Console.ReadLine());
            int num02 = Convert.ToInt32(Console.ReadLine());
            int num03 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SmallestNum(num01, num02, num03));
        }
        static int SmallestNum(int a, int b, int c)
        {
            int smallestNum = 0;
            if (a > b)
            {
                smallestNum = b;
                if (smallestNum > c)
                {
                    smallestNum = c;
                }
            }
            else if (a < b)
            {
                smallestNum = a;
                if (smallestNum > c)
                {
                    smallestNum = c;
                }
            }
            else if(a == b)
            {
                smallestNum = a;
                if (smallestNum > c)
                {
                    smallestNum = c;
                }
            }
            return smallestNum;
        }
    }
}

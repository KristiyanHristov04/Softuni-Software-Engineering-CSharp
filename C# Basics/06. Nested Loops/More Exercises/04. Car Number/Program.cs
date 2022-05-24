using System;

namespace _04._Car_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            for (int n1 = firstDigit; n1 <= secondDigit; n1++)
            {
                for (int n2 = firstDigit; n2 <= secondDigit; n2++)
                {
                    for (int n3 = firstDigit; n3 <= secondDigit; n3++)
                    {
                        for (int n4 = firstDigit; n4 < n1; n4++)
                        {
                            if (n1 > n4)
                            {
                                if (n1 % 2 == 0)
                                {
                                    if (n4 % 2 != 0)
                                    {
                                        if ((n1 - n4) % 2 != 0 && (n2 + n3) % 2 == 0)
                                        {
                                            Console.Write($"{n1}{n2}{n3}{n4} ");
                                        }
                                    }
                                }
                                else
                                {
                                    if (n4 % 2 == 0)
                                    {
                                        if (n1 % 2 != 0)
                                        {
                                            if ((n1 - n4) % 2 != 0 && (n2 + n3) % 2 == 0)
                                            {
                                                Console.Write($"{n1}{n2}{n3}{n4} ");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Combinations
            int n = Convert.ToInt32(Console.ReadLine());
            int validCombinationCounter = 0;

            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n; x2++)
                {
                    for (int x3 = 0; x3 <= n; x3++)
                    {
                        if (x1 + x2 + x3 == n)
                        {
                            validCombinationCounter++;
                        }
                    }

                }

            }
            Console.WriteLine(validCombinationCounter);
        }
    }
}

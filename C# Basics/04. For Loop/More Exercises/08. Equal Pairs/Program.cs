using System;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //08. Equal Pairs
            int n = int.Parse(Console.ReadLine());

            double oddPairSum = 0;
            double evenPairSum = 0;

            double maxDifference = 0;

            for (int i = 1; i <= n; i++)
            {
                int l = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddPairSum = l + m;
                }
                else
                {
                    evenPairSum = l + m;
                }
                if (oddPairSum != evenPairSum && i > 1)
                {
                    double tempDifference = Math.Abs(oddPairSum - evenPairSum);
                    if (maxDifference <= tempDifference) maxDifference = tempDifference;
                }
            }
            if (maxDifference == 0)
            {
                Console.WriteLine($"Yes, value={oddPairSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDifference}");
            }

        }
    }
}
    

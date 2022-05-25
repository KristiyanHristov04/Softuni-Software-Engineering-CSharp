using System;

namespace Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = Convert.ToInt32(Console.ReadLine());
            int totalSpices = 0;
            bool isFirstDay = true;
            int daysCount = 1;
            int spicesMinedToday = 0;

            if (startingYield < 100)
            {
                daysCount = 0;
                Console.WriteLine(daysCount);
                Console.WriteLine(totalSpices);
                return;
            }
            else
            {
                while (startingYield >= 100)
                {
                    if (isFirstDay)
                    {
                        isFirstDay = false;
                        totalSpices = startingYield - 26;
                        startingYield -= 10;
                    }
                    else
                    {
                        spicesMinedToday = startingYield - 26;
                        totalSpices += spicesMinedToday;
                        startingYield -= 10;
                        daysCount++;
                    }
                }
            }
            totalSpices -= 26;
            Console.WriteLine(daysCount);
            Console.WriteLine(totalSpices);

        }
    }
}

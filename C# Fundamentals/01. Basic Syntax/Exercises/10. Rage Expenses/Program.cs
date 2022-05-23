using System;

namespace Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLostGames = Convert.ToInt32(Console.ReadLine());
            double headsetPrice = Convert.ToDouble(Console.ReadLine());
            double mousePrice = Convert.ToDouble(Console.ReadLine());
            double keyboardPrice = Convert.ToDouble(Console.ReadLine());
            double displayPrice = Convert.ToDouble(Console.ReadLine());

            double totalExpenses = 0;
            int keyboardBreakCount = 0;
            for (int i = 1; i <= numberOfLostGames; i++)
            {
                if (i % 2 == 0 && i % 3 != 0)
                {
                    totalExpenses += headsetPrice;
                }
                else if (i % 3 == 0 && i % 2 != 0)
                {
                    totalExpenses += mousePrice;
                }
                else if(i % 2 == 0 && i % 3 == 0)
                {
                    totalExpenses += headsetPrice + keyboardPrice + mousePrice;
                    keyboardBreakCount++;
                    if (keyboardBreakCount % 2 == 0)
                    {
                        totalExpenses += displayPrice;
                    }
                }
            }
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}

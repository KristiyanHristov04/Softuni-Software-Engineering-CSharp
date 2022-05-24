using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine(); 
            int serialLength = Convert.ToInt32(Console.ReadLine()); 
            int pochivka = Convert.ToInt32(Console.ReadLine());
            double lunchBreak = pochivka / 8.0; 
            
            double justBreak = pochivka / 4.0; 
            
            double leftPochivka = pochivka - lunchBreak - justBreak;

            if (leftPochivka >= serialLength)
            {
                Console.WriteLine($"You have enough time to watch {serialName} " +
                    $"and left with {Math.Ceiling(leftPochivka - serialLength)} minutes free time.");
            }
            else if (leftPochivka < serialLength)
            {
                Console.WriteLine($"You don't have enough time to watch " +
                    $"{serialName}, you need {Math.Ceiling(serialLength - leftPochivka)} more minutes.");
            }
        }
    }
}

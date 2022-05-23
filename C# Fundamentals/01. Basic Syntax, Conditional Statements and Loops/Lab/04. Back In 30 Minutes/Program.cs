using System;

namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //04. Back in 30 minutes
            int hours = Convert.ToInt32(Console.ReadLine());
            int minutes = Convert.ToInt32(Console.ReadLine());
            int afterMinutes = 30;
            int totalMinutes = afterMinutes + minutes;
            if (totalMinutes > 59) //40 + 30 = 70 - 60 = 10
            {
                hours++;
                if (hours == 24)
                {
                    hours = 0;
                    totalMinutes -= 60;
                    Console.WriteLine($"{hours}:{totalMinutes:d2}");
                }
                else
                {
                    totalMinutes -= 60;
                    Console.WriteLine($"{hours}:{totalMinutes:d2}");
                }
            }
            else
            {
                Console.WriteLine($"{hours}:{totalMinutes:d2}");
            }
        }
    }
}

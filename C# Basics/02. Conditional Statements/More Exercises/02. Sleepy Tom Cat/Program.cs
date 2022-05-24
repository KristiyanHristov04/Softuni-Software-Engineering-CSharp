using System;

namespace Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOff = Convert.ToInt32(Console.ReadLine());
            int year = 365;
            int playTimeWhenWork = 63;

            int playTimeOffWork = 127;
            int totalPlayWhenWork = (year - daysOff) * playTimeWhenWork;
            int totalPlayWhenOffWork = daysOff * playTimeOffWork;
            int totalPlayTime = totalPlayWhenOffWork + totalPlayWhenWork;
            int minutesLeftForTom = (30000 - totalPlayTime);
            int avaiableHours = minutesLeftForTom / 60;
            int avaiableMinutes = minutesLeftForTom % 60;


            if (totalPlayTime <= 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{avaiableHours} hours and {avaiableMinutes} minutes less for play");
            }
            else if (totalPlayTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Abs(avaiableHours)} hours and {Math.Abs(avaiableMinutes)} minutes more for play");
            }
        }
    }
}

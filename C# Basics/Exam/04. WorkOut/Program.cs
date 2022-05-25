using System;

namespace WorkOut
{
    class Program
    {
        static void Main(string[] args)
        {
            //Workout
            int days = Convert.ToInt32(Console.ReadLine());
            double ranKilometersFirstDay = Convert.ToDouble(Console.ReadLine());
            double totalRanKilometers = ranKilometersFirstDay;
            for (int i = 1; i <= days; i++)
            {
                int increaseRunning = Convert.ToInt32(Console.ReadLine());
                ranKilometersFirstDay = ranKilometersFirstDay + 
                    (ranKilometersFirstDay * (increaseRunning / 100.0));
                totalRanKilometers += ranKilometersFirstDay;
                
            }
            if (totalRanKilometers < 1000)
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalRanKilometers)} more kilometers");
            }
            else if(totalRanKilometers >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalRanKilometers - 1000)} more kilometers!");
            }
            //Console.WriteLine(totalRanKilometers);
        }
    }
}

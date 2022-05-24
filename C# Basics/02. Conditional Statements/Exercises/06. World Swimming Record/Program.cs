using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {

            double recordInSeconds = Convert.ToDouble(Console.ReadLine());
            double distanceToSwim = Convert.ToDouble(Console.ReadLine());
            double timeInSecondsForSwimming1Meter = Convert.ToDouble(Console.ReadLine());

            double distanceInSeconds = distanceToSwim * timeInSecondsForSwimming1Meter;
            double suprotivlenie = Math.Floor((distanceToSwim / 15)) * 12.50;
            double totalTime = distanceInSeconds + suprotivlenie;
            double difference = totalTime - recordInSeconds;
            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {

                Console.WriteLine($"No, he failed! He was {difference:f2} seconds slower.");
            }
        }
    }
}

using System;

namespace SoftUniMoreExercisesv2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = Convert.ToInt32(Console.ReadLine());
            int secondTime = Convert.ToInt32(Console.ReadLine());
            int thirdTime = Convert.ToInt32(Console.ReadLine());
            int totalTime = firstTime + secondTime + thirdTime;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;
            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}

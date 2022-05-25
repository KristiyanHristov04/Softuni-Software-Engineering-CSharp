using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());
            int elevatorCapacity = Convert.ToInt32(Console.ReadLine());
            int totalCourses = 0;

            totalCourses = (int)Math.Ceiling((double)numberOfPeople / elevatorCapacity);
            Console.WriteLine(totalCourses);
        }
    }
}

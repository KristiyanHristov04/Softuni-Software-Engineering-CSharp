using System;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employee01 = Convert.ToInt32(Console.ReadLine());
            int employee02 = Convert.ToInt32(Console.ReadLine());
            int employee03 = Convert.ToInt32(Console.ReadLine());
            int studentsCount = Convert.ToInt32(Console.ReadLine());

            int totalHelpPerHour = employee01 + employee02 + employee03;
            int hours = 0;
            while (studentsCount > 0)
            {
                if (hours % 4 == 0 && hours != 0)
                {
                    hours++;
                    continue;
                }
                studentsCount -= totalHelpPerHour;
                hours++;
                if (studentsCount <= 0 && hours % 4 == 0)
                {
                    hours++;
                    break;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}

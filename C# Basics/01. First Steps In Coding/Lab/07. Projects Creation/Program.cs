using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            string builderName = Console.ReadLine();
            int numberOfProjects = Convert.ToInt32(Console.ReadLine());
            int neededHours = numberOfProjects * 3;

            Console.WriteLine($"The architect {builderName} will need {neededHours} hours to complete {numberOfProjects} project/s.");

        }
    }
}

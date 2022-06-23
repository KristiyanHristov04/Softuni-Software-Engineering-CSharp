using System;

namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            int totalNumberOfLectures = Convert.ToInt32(Console.ReadLine());
            int bonus = Convert.ToInt32(Console.ReadLine());

            double highestScore = 0;
            int highestScoreAttendacies = 0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                int countOfAttendanciesForStudent = Convert.ToInt32(Console.ReadLine());
                double currentResult = ((double)countOfAttendanciesForStudent / totalNumberOfLectures) * (5 + bonus);
                currentResult = Math.Ceiling(currentResult);
                if (currentResult >= highestScore)
                {
                    highestScore = currentResult;
                    highestScoreAttendacies = countOfAttendanciesForStudent;
                }
            }

            Console.WriteLine($"Max Bonus: {highestScore}.");
            Console.WriteLine($"The student has attended {highestScoreAttendacies} lectures.");
        }
    }
}

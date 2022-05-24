using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Exam Preparation
            int possibleGradesUnderFour = Convert.ToInt32(Console.ReadLine());
            int badGrades = 0;
            double sumAllGrades = 0;
            string lastTaskName = "";
            bool isFailed = true;
            int solvedProblemsCount = 0;

            while (badGrades < possibleGradesUnderFour)
            {
                string taskName = Console.ReadLine();

                if (taskName == "Enough")
                {
                    isFailed = false;
                    break;
                }

                int currentGrade = Convert.ToInt32(Console.ReadLine());

                if (currentGrade <= 4)
                {
                    badGrades++;

                }
                solvedProblemsCount++;
                lastTaskName = taskName;
                sumAllGrades += currentGrade;

                
            }
            if (isFailed == true)
            {
                Console.WriteLine($"You need a break, {badGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sumAllGrades / solvedProblemsCount:f2}");
                Console.WriteLine($"Number of problems: {solvedProblemsCount}");
                Console.WriteLine($"Last problem: {lastTaskName}");
            }

        }
    }
}

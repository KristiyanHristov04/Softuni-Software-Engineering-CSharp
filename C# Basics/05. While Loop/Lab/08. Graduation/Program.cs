using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            //08. Graduation
            string studentName = Console.ReadLine();
            double yearlyGrade = Convert.ToDouble(Console.ReadLine());
            int year = 1;
            int failYears = 0;
            double sumYearlyGrades = 0;
            while (year <= 12)
            {
                if (yearlyGrade < 4)
                {
                    failYears++;
                    if (failYears == 2)
                    {
                        break;
                    }
                }
                else if (yearlyGrade >= 4)
                {
                    sumYearlyGrades += yearlyGrade;
                    year++;
                }

                yearlyGrade = Convert.ToDouble(Console.ReadLine());

            }
            if (failYears == 2)
            {
                Console.WriteLine($"{studentName} has been excluded at {year} grade");
            }
            else
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {(sumYearlyGrades / 12):f2}");
            }
        }
    }
}

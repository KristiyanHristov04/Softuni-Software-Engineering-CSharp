using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Grades
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());//Явили се студенти
            double gradeBelowThree = 0;//Оценки под 3
            double gradeBelowFour = 0;//Оценки под 4
            double gradeBelowFive = 0;//Оценки под 5
            double gradeOverFive = 0;//Оценки над 5
            double averageGrade = 0;//Среден успех на студентите
            
            for (int i = 0; i < numberOfStudents; i++)
            {
                double grade = Convert.ToDouble(Console.ReadLine());
                if (grade >= 2.00 && grade <= 2.99)
                {
                    gradeBelowThree++;
                    averageGrade += grade;
                }
                else if(grade >= 3.00 && grade <= 3.99)
                {
                    gradeBelowFour++;
                    averageGrade += grade;
                }
                else if(grade >= 4.00 && grade <= 4.99)
                {
                    gradeBelowFive++;
                    averageGrade += grade;
                }
                else if(grade >= 5.00)
                {
                    gradeOverFive++;
                    averageGrade += grade;
                }
            }
            averageGrade = averageGrade / numberOfStudents;
            Console.WriteLine($"Top students: {gradeOverFive / numberOfStudents * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {gradeBelowFive / numberOfStudents * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {gradeBelowFour / numberOfStudents * 100:f2}%");
            Console.WriteLine($"Fail: {gradeBelowThree / numberOfStudents * 100:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2} ");
        }
    }
}

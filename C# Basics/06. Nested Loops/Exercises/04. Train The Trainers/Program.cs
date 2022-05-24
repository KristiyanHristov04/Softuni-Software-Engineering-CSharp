using System;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Train The Trainers
            //int n = Convert.ToInt32(Console.ReadLine());
            //int number = 1;
            //for (int rows = 1; rows <= n; rows++)
            //{

            //    for (int columns = 1; columns <= rows; columns++)
            //    {
            //        Console.Write(number + " ");
            //        number++;
            //    }
            //    Console.WriteLine();
            //}

            int judge = Convert.ToInt32(Console.ReadLine()); //Броят на журито, което ще оценява
            string presentaionName = Console.ReadLine();//Името на прецентацията
            double averageGrade = 0;
            double sumAllGrades = 0;
            int numberOfGrades = 0;
            
            while (presentaionName != "Finish")
            {
                for (int i = 1; i <= judge; i++)
                {
                    double judgeGrade = Convert.ToDouble(Console.ReadLine());//Oценка на журито
                    numberOfGrades++;
                    averageGrade += judgeGrade;
                    sumAllGrades += judgeGrade;
                }
                Console.WriteLine($"{presentaionName} - {averageGrade / judge:f2}.");
                averageGrade = 0;
                presentaionName = Console.ReadLine();
                
            }            
            Console.WriteLine($"Student's final assessment is {sumAllGrades / numberOfGrades:f2}.");
        }
    }
}

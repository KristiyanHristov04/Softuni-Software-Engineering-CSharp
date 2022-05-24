using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examStartHours = int.Parse(Console.ReadLine()); 
            int examStartMinutes = int.Parse(Console.ReadLine()); 
            int hourArrival = int.Parse(Console.ReadLine()); 
            int minArrival = int.Parse(Console.ReadLine()); 

            string late = "Late";
            string onTime = "On time";
            string early = "Early";

            int examTime = (examStartHours * 60) + examStartMinutes;         
            int arrivalTime = (hourArrival * 60) + minArrival;


            int TotalMinutes = arrivalTime - examTime;


            string studentArrival = late;
            if (TotalMinutes < -30)
            {
                studentArrival = early;
            }
            else if (TotalMinutes <= 0)
            {
                studentArrival = onTime;
            }
            else
            {
                studentArrival = late;
            }


            string result = string.Empty;
            if (TotalMinutes != 0 || TotalMinutes == 0)
            {
                int hoursDifference =
                    Math.Abs(TotalMinutes / 60);
                int minutesDifference =
                    Math.Abs(TotalMinutes % 60);

                if (hoursDifference > 0)
                {
                    result = string.Format("{0}:{1:00} hours", hoursDifference, minutesDifference);

                }
                else
                {
                    result = minutesDifference + " minutes";
                }
                if (TotalMinutes < 0)
                {
                    result += " before the start";
                }
                else
                {
                    result += " after the start";
                }
                Console.WriteLine(studentArrival);
                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}

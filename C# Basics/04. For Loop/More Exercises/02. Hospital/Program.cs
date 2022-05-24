using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Hospital
            int period = Convert.ToInt32(Console.ReadLine()); //За какъв период от време
            int startingDoctors = 7;//Начални доктори 
            int revised = 0;//Прегледани пациенти за ден
            int unRevised = 0;//Непрегледани пациенти за ден
            int revisedWhenNotAll = 0;
            for (int day = 1; day <= period; day++)
            {         
                if (day % 3 == 0 && unRevised > revised)
                {
                    startingDoctors++;
                }

                int numberOfPatients = Convert.ToInt32(Console.ReadLine());

                if (startingDoctors - numberOfPatients >= 0)
                {
                    revised += numberOfPatients;
                }
                else if(startingDoctors - numberOfPatients < 0) 
                {                                      
                    unRevised += numberOfPatients - startingDoctors; 
                    revisedWhenNotAll = numberOfPatients - (numberOfPatients + startingDoctors);
                    revisedWhenNotAll = Math.Abs(revisedWhenNotAll);
                    revised += revisedWhenNotAll;
                }
                
            }           
            Console.WriteLine("Treated patients: " + revised + ".");
            Console.WriteLine("Untreated patients: " + unRevised + ".");
        }
    }
}

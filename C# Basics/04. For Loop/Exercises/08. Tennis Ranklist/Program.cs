using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = Convert.ToInt32(Console.ReadLine());//Брой тутнири
            //в които участва
            int startingPoints = Convert.ToInt32(Console.ReadLine());//Начални точки с които
            //започва в ранглистата
            int totalPoints = 0;
            double wonMatches = 0;

            for (int i = 1; i <= numberOfTournaments; i++)
            {
                string placement = Console.ReadLine();
                if (placement == "W")
                {
                    totalPoints += 2000;
                    wonMatches++;
                }
                else if(placement == "F")
                {
                    totalPoints += 1200;
                }
                else if(placement == "SF")
                {
                    totalPoints += 720;
                }
                
            }         
            totalPoints += startingPoints;
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {(totalPoints - startingPoints) / numberOfTournaments}");
            Console.WriteLine($"{(wonMatches / numberOfTournaments) * 100:f2}%");
            
            
        }
    }
}

using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();
            //Console.WriteLine(name.Length);

            string actorName = Console.ReadLine();
            double academyPoints = Convert.ToDouble(Console.ReadLine());//Начални точки от
            //академията
            int judgeNumber = Convert.ToInt32(Console.ReadLine());//Брой оценяващи                        
            for (int i = 1; i <= judgeNumber; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = Convert.ToDouble(Console.ReadLine());//Дадени точки от
                                                                          //оценяващия       
                academyPoints += (judgeName.Length * judgePoints) / 2;
                if (academyPoints >= 1250.5)
                {
                    break;
                }
            }
            //Console.WriteLine(totalPoints);
            if (academyPoints < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - academyPoints:f1} more!");
            }
            else if(academyPoints >= 1250.5)
            {
              
                Console.WriteLine($"Congratulations, {actorName} got a nominee for " +
                    $"leading role with {academyPoints:f1}!");
            }
            
        }
    }
}

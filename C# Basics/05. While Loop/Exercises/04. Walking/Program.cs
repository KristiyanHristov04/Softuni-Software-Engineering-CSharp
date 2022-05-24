using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Стъпки
            int stepsGoal = 10000;
            int sumSteps = 0;
            bool isGoingHome = false;
            int stepsBackToHome = 0;
            while (sumSteps < stepsGoal)
            {
                string stepsPerDay = Console.ReadLine();
                
                if (stepsPerDay == "Going home")
                {
                    isGoingHome = true;
                    int stepsGoingBackHome = Convert.ToInt32(Console.ReadLine());
                    stepsBackToHome = stepsGoingBackHome;
                    break;
                }
                sumSteps += Convert.ToInt32(stepsPerDay);
                if (sumSteps >= stepsGoal)
                {
                    break;
                }

            }
            if (sumSteps >= stepsGoal)
            {
                int diff = sumSteps - stepsGoal;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{diff} steps over the goal!");
            }
            else if (isGoingHome == true && (sumSteps + stepsBackToHome) < stepsGoal)
            {
                
                int diff = stepsGoal - (sumSteps + stepsBackToHome);
                Console.WriteLine($"{diff} more steps to reach goal.");
            }
            
            else if(isGoingHome == true && (sumSteps + stepsBackToHome) >= stepsGoal)
            {
                
                int diff = (sumSteps + stepsBackToHome) - stepsGoal;               
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{diff} steps over the goal!");
            }    
        }
    }
}

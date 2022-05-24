using System;

namespace SoftUniForLoopMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Back to the past
            
            double money = Convert.ToDouble(Console.ReadLine());//Наследените пари на Иванчо
            int yearToLive = Convert.ToInt32(Console.ReadLine());//Годината до която трябва
            //Иванчо да живее включително
            int ivanAge = 17;      
            for (int i = 1800; i <= yearToLive; i++)
            {
                if (i % 2 == 0)
                {
                    money -= 12000;
                    
                }
                else if(i % 2 != 0)
                {
                    ivanAge += 2;
                    money -= 12000 + 50 * ivanAge;                
                    
                }
            }            
            if (money >= 0)
            {              
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars " +
                    "left.");
            }
            else if(money < 0)
            {
                Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
            }
        }
    }
}

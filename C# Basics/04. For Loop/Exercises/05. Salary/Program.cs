using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Salary
            int openTabs = Convert.ToInt32(Console.ReadLine());//Отворени табове
            double salary = Convert.ToDouble(Console.ReadLine());//Начална заплата
            for (int i = 0; i <= openTabs; i++)
            {
                string site = Console.ReadLine();
                if (site == "Facebook")
                {
                    salary -= 150;
                }
                if (site == "Instagram")
                {
                    salary -= 100;
                }
                if (site == "Reddit")
                {
                    salary -= 50;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}

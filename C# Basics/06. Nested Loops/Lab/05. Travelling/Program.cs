using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Travelling
            string destination = Console.ReadLine();
            double budget = Convert.ToDouble(Console.ReadLine());
            double savings = 0;
            while (destination != "End")
            {
                double savedMoney = Convert.ToDouble(Console.ReadLine());
                savings += savedMoney;
                if (savings >= budget)
                {
                    Console.WriteLine($"Going to {destination}!");
                    savings = 0;
                    destination = Console.ReadLine();
                    if (destination == "End")
                    {
                        return;
                    }
                    else
                    {
                        budget = Convert.ToDouble(Console.ReadLine());
                    }                   
                }
            }
        }
    }
}

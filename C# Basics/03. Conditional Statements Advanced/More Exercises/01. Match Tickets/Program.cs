using System;

namespace _03.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var budged = double.Parse(Console.ReadLine());
            var category = Console.ReadLine();
            var persons = int.Parse(Console.ReadLine());
            double transport = 0;
            if (persons >= 1 && persons <= 4)
                transport = 75.00;
            else if (persons >= 5 && persons <= 9)
                transport = 60.00;
            else if (persons >= 10 && persons <= 24)
                transport = 50.00;
            else if (persons >= 25 && persons <= 49)
                transport = 40.00;
            else
                transport = 25.00;
            double budgedTransp = budged * transport / 100;
            double budgetTicets = budged - budgedTransp;
            bool enough = false;
            var ostatak = 0.00;
            var needed = 0.00;
            if (category == "VIP")
            {
                if (budgetTicets / persons > 499.99)
                {
                    enough = true;
                    ostatak = budgetTicets - (persons * 499.99);
                }
                else
                {
                    enough = false;
                    needed = (persons * 499.99) - budgetTicets;
                }


            }
            else if (category == "Normal")
            {
                if (budgetTicets / persons > 249.99)
                {
                    enough = true;
                    ostatak = budgetTicets - (persons * 249.99);
                }

                else
                {
                    enough = false;
                    needed = (persons * 249.99) - budgetTicets;
                }


            }

            if (enough)
                Console.WriteLine("Yes! You have {0:f2} leva left.",
                    ostatak);
            else
                Console.WriteLine("Not enough money! You need {0:f2} leva.",
                    needed);
        }
    }
}
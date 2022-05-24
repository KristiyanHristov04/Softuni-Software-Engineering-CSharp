using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = Convert.ToInt32(Console.ReadLine());
            double bonus = 0.0;
            if (points <= 100)
            {
                bonus = 5;
            }

            else if (points > 1000)
            {
                bonus = bonus + points * 0.1;
            }

            else
            {
                bonus = bonus + points * 0.2;
            }

            if (points % 2 == 0)
            {
                bonus = bonus + 1;
            }

            else if (points % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(points + bonus);
        }
    }
}

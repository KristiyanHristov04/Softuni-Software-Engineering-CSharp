using System;

namespace Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = Convert.ToDouble(Console.ReadLine());
            double studentsCount = Convert.ToInt32(Console.ReadLine());
            double lightSaberPrice = Convert.ToDouble(Console.ReadLine());
            double robePrice = Convert.ToDouble(Console.ReadLine());
            double beltPrice = Convert.ToDouble(Console.ReadLine());

            double total = 0;
            total = lightSaberPrice * (Math.Ceiling(studentsCount * 0.10) + studentsCount);
            //Console.WriteLine(total);
            total += robePrice * studentsCount;
            //Console.WriteLine(total);
            if (studentsCount < 6)
            {
                total += beltPrice * studentsCount;
            }
            else if(studentsCount >= 6)
            {
                double freeBelts = Math.Floor(studentsCount / 6);
                total += beltPrice * (studentsCount - freeBelts);
            }

            if (money >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else if(money < total)
            {
                Console.WriteLine($"John will need {total - money:f2}lv more.");
            }
        }
    }
}

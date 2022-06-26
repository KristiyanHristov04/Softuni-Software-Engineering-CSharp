using System;

namespace Mid_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = Convert.ToDouble(Console.ReadLine());
            int students = Convert.ToInt32(Console.ReadLine());
            double priceOfPackageFlour = Convert.ToDouble(Console.ReadLine());
            double priceOfSingleEgg = Convert.ToDouble(Console.ReadLine());
            double priceOfSingleApron = Convert.ToDouble(Console.ReadLine());

            double totalPrice = 0;

            int freePackages = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freePackages++;
                }
            }

            double studentsRounded = Math.Ceiling(students + (students * 0.20));
            double apronTotalPrice = priceOfSingleApron * studentsRounded;
            double eggsTotalPrice = students * (priceOfSingleEgg * 10);
            double flourTotalPrice = priceOfPackageFlour * (students - freePackages);
            totalPrice = apronTotalPrice + eggsTotalPrice + flourTotalPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                double neededMoney = totalPrice - budget;
                Console.WriteLine($"{neededMoney:f2}$ more needed.");
            }
        }
    }
}

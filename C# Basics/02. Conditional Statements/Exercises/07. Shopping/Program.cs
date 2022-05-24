using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = Convert.ToDouble(Console.ReadLine());
            int gpuQuantity = Convert.ToInt32(Console.ReadLine());
            int cpuQuantity = Convert.ToInt32(Console.ReadLine());
            int ramQuantity = Convert.ToInt32(Console.ReadLine());

            int gpuPricePerOneQuantity = 250;
            double cpuPricePerOneQuantity = (gpuPricePerOneQuantity * gpuQuantity) * 0.35;
            double ramPricePerOneQuantity = (gpuPricePerOneQuantity * gpuQuantity) * 0.10;
            //Console.WriteLine(cpuPricePerOneQuantity);
            //Console.WriteLine(ramPricePerOneQuantity);
            double totalPrice = (gpuQuantity * gpuPricePerOneQuantity) + (cpuQuantity * cpuPricePerOneQuantity) +
                (ramQuantity * ramPricePerOneQuantity);
            if (gpuQuantity > cpuQuantity)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }


            if (totalPrice <= budget)
            {
                double leftBudget = budget - totalPrice;
                Console.WriteLine($"You have {leftBudget:f2} leva left!");
            }
            else
            {
                double leftBudget = budget - totalPrice;
                leftBudget = Math.Abs(leftBudget);
                Console.WriteLine($"Not enough money! You need {leftBudget:f2} leva more!");
            }
        }
    }
}

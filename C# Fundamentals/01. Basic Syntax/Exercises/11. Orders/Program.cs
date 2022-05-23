using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double pricePerCapsule = Convert.ToDouble(Console.ReadLine());
            int days = Convert.ToInt32(Console.ReadLine());
            int capsulesCount = Convert.ToInt32(Console.ReadLine());
            double formula = 0; 
            double totalPrice = 0;

            for (int i = 1; i <= n; i++)
            {
                formula = (days * capsulesCount) * pricePerCapsule;
                totalPrice += formula;
                Console.WriteLine($"The price for the coffee is: ${formula:f2}");

                if (i == n)
                {
                    break;
                }
                else
                {
                    pricePerCapsule = Convert.ToDouble(Console.ReadLine());
                    days = Convert.ToInt32(Console.ReadLine());
                    capsulesCount = Convert.ToInt32(Console.ReadLine());
                }

            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}

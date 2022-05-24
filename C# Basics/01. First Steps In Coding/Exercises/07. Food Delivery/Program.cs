using System;

namespace SoftuniExercicesv2
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.40;
            double vegetarianMenuPrice = 8.15;
            double deliveryPrice = 2.50;

            int numberOfChickenMenus = Convert.ToInt32(Console.ReadLine());
            int numberOfFishMenus = Convert.ToInt32(Console.ReadLine());
            int numberOfVegetarianMenus = Convert.ToInt32(Console.ReadLine());

            double orderPrice = (numberOfChickenMenus * chickenMenuPrice) + (numberOfFishMenus * fishMenuPrice) +
                (numberOfVegetarianMenus * vegetarianMenuPrice);

            double desert = orderPrice - (orderPrice - (orderPrice * 0.20));
            //Console.WriteLine(desert);
            //Console.WriteLine(orderPrice);
            double totalOrderPrice = orderPrice + desert + deliveryPrice;
            Console.WriteLine($"{totalOrderPrice}");
        }
    }
}

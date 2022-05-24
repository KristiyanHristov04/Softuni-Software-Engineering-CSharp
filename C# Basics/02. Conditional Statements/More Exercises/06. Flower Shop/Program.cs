using System;

namespace Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            int magnolias = Convert.ToInt32(Console.ReadLine());
            int hyacinths = Convert.ToInt32(Console.ReadLine());
            int roses = Convert.ToInt32(Console.ReadLine());
            int cactuses = Convert.ToInt32(Console.ReadLine());
            double giftPrice = Convert.ToDouble(Console.ReadLine());

            double maggnoliasPrice = 3.25;
            int hyacinthsPrice = 4;
            double rosesPrice = 3.50;
            int cactusesPrice = 8;

            double total = (maggnoliasPrice * magnolias) + (hyacinthsPrice * hyacinths) +
                (rosesPrice * roses) + (cactusesPrice * cactuses);

            double totalWithRent = total - (total * 0.05);

            double leftMoney = totalWithRent - giftPrice;
            if (totalWithRent >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(leftMoney)} leva.");
            }
            else if (totalWithRent < giftPrice)
            {
                leftMoney = Math.Floor(leftMoney);
                Console.WriteLine($"She will have to borrow {Math.Abs(leftMoney)} leva.");
            }


        }
    }
}

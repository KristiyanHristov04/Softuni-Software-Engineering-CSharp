using System;

namespace Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Football Kit
            double TshirtPrice = Convert.ToDouble(Console.ReadLine());
            double neededSum = Convert.ToDouble(Console.ReadLine());

            double shortsPrice = TshirtPrice * 0.75;
            //Console.WriteLine(shortsPrice);
            double sockPrice = shortsPrice * 0.20;
            //Console.WriteLine(sockPrice);
            double shoesPrice = (shortsPrice + TshirtPrice) * 2;
            //Console.WriteLine(shoesPrice);
            double totalPrice = TshirtPrice + shortsPrice + sockPrice + shoesPrice;
            //Console.WriteLine(totalPrice);
            double totalPriceWithDiscount = totalPrice - (totalPrice * 0.15);
            //Console.WriteLine(totalPriceWithDiscount);
            if (totalPriceWithDiscount >= neededSum)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPriceWithDiscount:f2} lv.");
            }
            else if(totalPriceWithDiscount < neededSum)
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {neededSum - totalPriceWithDiscount:f2} lv. more.");
            }
        }
    }
}

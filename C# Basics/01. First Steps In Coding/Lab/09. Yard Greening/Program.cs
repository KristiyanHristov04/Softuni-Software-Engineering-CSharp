using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double kvadratenMeturPrice = 7.61;
            double kvadratniMetriZaOzelenqvane = Convert.ToDouble(Console.ReadLine());

            double totalPrice = kvadratniMetriZaOzelenqvane * kvadratenMeturPrice;
            double totalPriceWithDiscount = totalPrice - (totalPrice / 100) * 18;
            double discount = (totalPrice / 100) * 18;
            Console.WriteLine($"The final price is: {totalPriceWithDiscount} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}

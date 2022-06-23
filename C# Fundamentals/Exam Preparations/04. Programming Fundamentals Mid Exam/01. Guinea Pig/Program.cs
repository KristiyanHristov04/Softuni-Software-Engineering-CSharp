using System;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityOfFood = Convert.ToDouble(Console.ReadLine()) * 1000;
            double quantityOfHay = Convert.ToDouble(Console.ReadLine()) * 1000;
            double quantityOfCover = Convert.ToDouble(Console.ReadLine()) * 1000;
            double pigWeight = Convert.ToDouble(Console.ReadLine()) * 1000;

            for (int days = 1; days <= 30; days++)
            {
                quantityOfFood -= 300;
                if (days % 2 == 0)
                {
                    quantityOfHay -= quantityOfFood * 0.05;
                }

                if(days % 3 == 0)
                {
                    quantityOfCover -= pigWeight / 3;
                }

                if (quantityOfFood <= 0 || quantityOfHay <= 0 || quantityOfCover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(quantityOfFood / 1000):f2}, Hay: {(quantityOfHay / 1000):f2}, Cover: {(quantityOfCover / 1000):f2}.");
            

        }
    }
}

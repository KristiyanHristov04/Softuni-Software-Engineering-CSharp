using System;

namespace ExamSoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Christmas Preparation
            double wrappingPaperPrice = 5.80;
            double clothPrice = 7.20;
            double gluePrice = 1.20;

            int numberOfWrappingPaper = Convert.ToInt32(Console.ReadLine());
            int numberOfCloth = Convert.ToInt32(Console.ReadLine());
            double numberOfGlue = Convert.ToDouble(Console.ReadLine());
            int percentDiscount = Convert.ToInt32(Console.ReadLine());

            double totalPrice = numberOfWrappingPaper * wrappingPaperPrice +
                numberOfCloth * clothPrice + numberOfGlue * gluePrice;

            double totalPriceWithDiscount = 0;
            totalPriceWithDiscount = totalPrice - (totalPrice * (percentDiscount / 100.0));
            
            //Console.WriteLine(totalPrice);           
            //Console.WriteLine(totalPriceWithDiscount);

            Console.WriteLine($"{totalPriceWithDiscount:f3}");
        }
    }
}

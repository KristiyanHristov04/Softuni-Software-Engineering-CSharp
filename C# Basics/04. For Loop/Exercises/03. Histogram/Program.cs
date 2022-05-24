using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Histogram
            int n = Convert.ToInt32(Console.ReadLine()); //Колко числа ще четем от конзолата
            double howManyNumbersLessThan200 = 0;
            double howManyNumbersLessThan400 = 0;
            double howManyNumbersLessThan600 = 0;
            double howManyNumbersLessThan800 = 0;
            double howManyNumbersMoreThan800 = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            
            for (int i = 1; i <= n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number < 200)
                {
                    howManyNumbersLessThan200++;
                }
                else if(number >= 200 && number < 400)
                {
                    howManyNumbersLessThan400++;
                }
                else if (number >= 400 && number < 600)
                {
                    howManyNumbersLessThan600++;
                }
                else if (number >= 600 && number < 800)
                {
                    howManyNumbersLessThan800++;
                }
                else if (number >= 800)
                {
                    howManyNumbersMoreThan800++;
                }
            }
            
            p1 = (howManyNumbersLessThan200 / n) * 100;
            p2 = (howManyNumbersLessThan400 / n) * 100;
            p3 = (howManyNumbersLessThan600 / n) * 100;
            p4 = (howManyNumbersLessThan800 / n) * 100;
            p5 = (howManyNumbersMoreThan800 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");

        }
    }
}

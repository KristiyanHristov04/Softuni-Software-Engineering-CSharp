using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = Convert.ToDouble(Console.ReadLine());
            double price = 0;

            if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday"
                || dayOfWeek == "Thursday" || dayOfWeek == "Friday")
            {
                //banana  apple   orange  grapefruit  kiwi    pineapple   grapes
                // 2.50    1.20    0.85    1.45       2.70       5.50      3.85

                if (fruit == "banana")
                {
                    price = 2.50;
                }
                else if (fruit == "apple")
                {
                    price = 1.20;
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = 2.70;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.50;
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                }
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                //banana  apple   orange  grapefruit  kiwi    pineapple  grapes
                // 2.70    1.25    0.90     1.60      3.00       5.60     4.20

                if (fruit == "banana")
                {
                    price = 2.70;
                }
                else if (fruit == "apple")
                {
                    price = 1.25;
                }
                else if (fruit == "orange")
                {
                    price = 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.60;
                }
                else if (fruit == "kiwi")
                {
                    price = 3.00;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.60;
                }
                else if (fruit == "grapes")
                {
                    price = 4.20;
                }
            }
            if (price != 0.00)
            {
                double totalPrice = quantity * price;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}

using System;

namespace Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Report System
            int expectedSum = Convert.ToInt32(Console.ReadLine());//Сума която трябва да бъде събрана
            int collectedMoney = 0;//Пари които ще събираме 
            int wayOfPaying = 1;//Начин на плащане
            bool isValid = true;
            int paidInCashCounter = 0;
            int paidInCreditCardCounter = 0;
            double paidInCashSum = 0;
            double paidInCreditCardSum = 0;
            double averagePaidInCash = 0;
            double averagePaidInCreditCard = 0;

            while (collectedMoney < expectedSum)
            {
                wayOfPaying++;
                string input = Console.ReadLine();//Вход от потребителя
                if (input == "End")
                {
                    isValid = false;
                    break;
                }
                if (wayOfPaying % 2 == 0) //Кеш плащане 
                {
                    if (Convert.ToInt32(input) <= 100)
                    {
                        collectedMoney += Convert.ToInt32(input);
                        Console.WriteLine("Product sold!");
                        paidInCashCounter++;
                        paidInCashSum += Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }                   
                }
                else //Плащане с кредитна карта
                {
                    if (Convert.ToInt32(input) >= 10)
                    {
                        collectedMoney += Convert.ToInt32(input);
                        Console.WriteLine("Product sold!");
                        paidInCreditCardCounter++;
                        paidInCreditCardSum += Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                }              
                if (collectedMoney >= expectedSum)
                {
                    break;
                }
            }
            if (collectedMoney >= expectedSum)
            {
                averagePaidInCash = paidInCashSum / paidInCashCounter;
                averagePaidInCreditCard = paidInCreditCardSum / paidInCreditCardCounter;
                Console.WriteLine($"Average CS: {averagePaidInCash:f2}");
                Console.WriteLine($"Average CC: {averagePaidInCreditCard:f2}");
            }
            else if(isValid == false)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
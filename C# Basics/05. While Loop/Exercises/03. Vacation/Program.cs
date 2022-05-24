using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Vacation
            double tripPrice = Convert.ToDouble(Console.ReadLine());//Цена на екскурзията
            double currentMoney = Convert.ToDouble(Console.ReadLine());//Налични пари в момента
            int daysGone = 0; //Изминали дни
            int daysInARowOnlySpend = 0;

            while (currentMoney < tripPrice)
            {
                string spendOrSave = Console.ReadLine(); //Дали ще спестяваме пари или ще харчим
                double moneySpendOrSave = Convert.ToDouble(Console.ReadLine());//Колко пари ще
                //спестим или изхарчим
                daysGone++;
                if (spendOrSave == "save")
                {
                    daysInARowOnlySpend = 0;
                    currentMoney += moneySpendOrSave;
                }
                else if(spendOrSave == "spend")
                {
                    daysInARowOnlySpend++;
                    if (currentMoney > moneySpendOrSave)
                    {
                        currentMoney -= moneySpendOrSave;
                    }
                    else if(currentMoney - moneySpendOrSave <= 0)
                    {
                        currentMoney = 0;
                    }
                }
                if (currentMoney >= tripPrice)
                {
                    break;
                }
                else if(daysInARowOnlySpend == 5)
                {
                    break;
                }
            }
            if (currentMoney >= tripPrice)
            {
                Console.WriteLine($"You saved the money for {daysGone} days.");
            }
            else if(daysInARowOnlySpend == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysGone}");
            }
            
        }
    }
}

using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Clever Lily
            int lillyAge = Convert.ToInt32(Console.ReadLine());//На колко години е Лили
            double washingMachinePrice = Convert.ToDouble(Console.ReadLine());//Колко струва
                                                                              //пералнята
            int toyPrice = Convert.ToInt32(Console.ReadLine());//Цена на играчка
            int numberOfToys = 0;//Колко играчки общо е събрала през годините
            int sumMoney = 0;//Колко пари общо е събрала през годините
            int sumMoneyTotal = 0;//Koлко пари общо е събрала - КАКТО ТРЯБВА !            
            int takenMoney = 0;//Когато Лили получава пари, брат и взима по 1 лев от тях
            //sumMoney - takenMoney * (lillyAge % 2 == 0)
            


            for (int i = 1; i <= lillyAge; i++)
            {
                if (i % 2 == 0)
                {
                    sumMoney += 10; //10 20 30 40 50                   
                    sumMoneyTotal += sumMoney;
                    takenMoney++;
                }
                else if(i % 2 != 0)
                {
                    numberOfToys++;
                }
            }
            int totalSavedMoney = sumMoneyTotal + (numberOfToys * toyPrice) - takenMoney;//Oбщо
            //спестени пари след продаване на играчките - парите които брат и, и е вземал през
            //годините 
            
            if (totalSavedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {totalSavedMoney - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(totalSavedMoney - washingMachinePrice):f2}");
            }
        }
    }
}

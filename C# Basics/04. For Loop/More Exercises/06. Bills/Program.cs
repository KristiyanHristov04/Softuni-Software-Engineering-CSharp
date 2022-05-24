using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. Bills
            int expenseMonths = Convert.ToInt32(Console.ReadLine());//месеците за които се
                                                                    //търси средният разход
            int waterBillPerMonth = 20;
            int internetBillPerMonth = 15;
            double totalElectricity = 0;
            double other = 0;
            


            for (int i = 0; i < expenseMonths; i++)
            {
                double electricityBillPerMonth = Convert.ToDouble(Console.ReadLine());
                totalElectricity += electricityBillPerMonth;
                other += (electricityBillPerMonth + waterBillPerMonth + internetBillPerMonth) + 
                (electricityBillPerMonth + waterBillPerMonth + internetBillPerMonth) * 0.2;
            }
            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {expenseMonths * waterBillPerMonth:f2} lv");
            Console.WriteLine($"Internet: {expenseMonths * internetBillPerMonth:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            double average = totalElectricity + (waterBillPerMonth * expenseMonths) + 
                (internetBillPerMonth * expenseMonths) + other;
            average /= expenseMonths;
            Console.WriteLine($"Average: {average:f2} lv");



        }

    }
}

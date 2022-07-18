using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            if (number == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int reminder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currNumber = Convert.ToInt32(number[i].ToString());

                int product = currNumber * multiplier + reminder;

                int result = product % 10;

                reminder = product / 10;

                sb.Insert(0, result);
            }

            if (reminder != 0)
            {
                sb.Insert(0, reminder);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

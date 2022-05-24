using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Half Sum Element
            int sum = 0;
            int max = int.MinValue;
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                sum += number;

                if (number > max)
                {
                    max = number;
                }
            }
            int sumWithoutMaxNumber = sum - max;
            //Console.WriteLine(sumWithoutMaxNumber);
            if (max == sumWithoutMaxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs(max - sumWithoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }

            
        }
    }
}

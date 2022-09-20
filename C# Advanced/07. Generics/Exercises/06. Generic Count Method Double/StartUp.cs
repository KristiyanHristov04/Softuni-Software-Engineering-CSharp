using System;
using System.Collections.Generic;

namespace _06._Generic_Count_Method_Double
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double n = Convert.ToDouble(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                double item = Convert.ToDouble(Console.ReadLine());
                boxes.Add(new Box<double>(item));
            }
            double itemToCompare = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(CompareItems(boxes, itemToCompare));
        }
        public static double CompareItems<T>(List<Box<T>> boxes, T item)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (var box in boxes)
            {
                if (box.CompareTo(item) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

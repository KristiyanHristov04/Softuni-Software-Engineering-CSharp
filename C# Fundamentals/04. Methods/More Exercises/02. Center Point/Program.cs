using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());

            CloserCoordinate(x1, y1, x2, y2); 
        }
        static void CloserCoordinate(double x1, double y1, double x2, double y2)
        {
            double coordinate01 = Math.Abs(x1) + Math.Abs(y1);
            double coordinate02 = Math.Abs(x2) + Math.Abs(y2);
            
            if (coordinate01 > coordinate02)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}

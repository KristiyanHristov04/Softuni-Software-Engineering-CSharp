using System;

namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = Convert.ToDouble(Console.ReadLine());
            double height = Convert.ToDouble(Console.ReadLine());
            double result = RectangleArea(width, height);
            Console.WriteLine(result);
        }
        static double RectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}

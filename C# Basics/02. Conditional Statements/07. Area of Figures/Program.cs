using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0;
            if (figureType == "square")
            {
                double a = Convert.ToDouble(Console.ReadLine());
                area = a * a;
            }

            else if (figureType == "rectangle")
            {
                double a = Convert.ToDouble(Console.ReadLine());
                double b = Convert.ToDouble(Console.ReadLine());
                area = a * b;
            }

            else if (figureType == "circle")
            {
                double r = Convert.ToDouble(Console.ReadLine());
                area = r * r * Math.PI;
            }

            else if (figureType == "triangle")
            {
                double a = Convert.ToDouble(Console.ReadLine());
                double ha = Convert.ToDouble(Console.ReadLine());
                area = a * ha / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}

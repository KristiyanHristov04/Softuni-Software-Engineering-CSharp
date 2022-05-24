using System;

namespace exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = Convert.ToDouble(Console.ReadLine());
            double circlePerimeter = 2 * Math.PI * r;
            double circleFace = Math.PI * (r * r);
            Console.WriteLine($"{circleFace:f2}");
            Console.WriteLine($"{circlePerimeter:f2}");

        }
    }
}

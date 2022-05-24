using System;

class program
{
    static void Main()
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        if (x1 < x2 && y1 < y2)
        {
            if ((x == x1 || x == x2) && (y <= y2 && y >= y1) || (y == y1 || y == y2) && (x < x2 && x > x1))
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}


using System;

namespace exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            double h = Convert.ToDouble(Console.ReadLine());
            double greenPaintPerLiter = 3.4;
            double redPaintPerLiter = 4.3;
            double window = 1.5;
            double windowTotalSizePerWallSide = window * window;
            double wallSide = x * y;
            double bothWallsAndbothWindows = (wallSide * 2) - (windowTotalSizePerWallSide * 2);
            double backWall = x * x;
            double backWallAndFrontWall = backWall * 2 - (2 * 1.2);
            double totalArea = backWallAndFrontWall + bothWallsAndbothWindows;
            double greenPaintNeeded = totalArea / greenPaintPerLiter;
            double roofRectangleSides = 2 * (x * y);
            double roofTriangleSides = 2 * (x * h / 2);
            double totalAreaRoof = roofRectangleSides + roofTriangleSides;
            double redPaintNeeded = totalAreaRoof / redPaintPerLiter;
            Console.WriteLine($"{greenPaintNeeded:f2}");
            Console.WriteLine($"{redPaintNeeded:f2}");
        }
    }
}

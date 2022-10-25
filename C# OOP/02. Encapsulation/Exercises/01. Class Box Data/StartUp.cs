using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = Convert.ToDouble(Console.ReadLine());
            double width = Convert.ToDouble(Console.ReadLine());
            double height = Convert.ToDouble(Console.ReadLine());
            Box box;
            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
            

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
    }
}

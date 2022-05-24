using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = Convert.ToInt32(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            if (timeOfDay == "Morning")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                }
                else if (degrees >= 25)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                }
            }
            else if (timeOfDay == "Afternoon")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                }
                else if (degrees >= 25)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot.");
                }
            }
            else if (timeOfDay == "Evening")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                }
                else if (degrees >= 25)
                {
                    Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                }
            }
        }
    }
}

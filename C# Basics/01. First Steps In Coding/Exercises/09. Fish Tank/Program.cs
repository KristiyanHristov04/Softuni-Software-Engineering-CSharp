using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int aquariumLength = Convert.ToInt32(Console.ReadLine());
            int aquariumHeight = Convert.ToInt32(Console.ReadLine());
            int aquariumWidth = Convert.ToInt32(Console.ReadLine());

            double percentNoVisibilty = Convert.ToDouble(Console.ReadLine());
            double aquariumCapacityInDecimeters = aquariumLength * aquariumHeight * aquariumWidth;
            double aquariumCapacityInCentimetres = (aquariumLength * aquariumHeight * aquariumWidth) / 1000.00;
            double percentNoVisibiltyInPercents = percentNoVisibilty / 100.00;
            double neededLitres = aquariumCapacityInCentimetres * (1 - percentNoVisibiltyInPercents);

            Console.WriteLine(neededLitres);

        }
    }
}

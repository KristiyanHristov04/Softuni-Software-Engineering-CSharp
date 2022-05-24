using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Logistics
            int numberOfCargos = Convert.ToInt32(Console.ReadLine());
            int totalCargosWeight = 0;
            double averagePerTon = 0;
            double bus = 0;
            double truck = 0;
            double train = 0;
            for (int i = 0; i < numberOfCargos; i++)
            {
                int cargoWeight = Convert.ToInt32(Console.ReadLine());
                totalCargosWeight += cargoWeight;
                if (cargoWeight <= 3)
                {
                    averagePerTon += cargoWeight * 200;
                    bus += cargoWeight;
                }
                else if(cargoWeight >= 4 && cargoWeight <= 11)
                {
                    averagePerTon += cargoWeight * 175;
                    truck += cargoWeight;
                }
                else if(cargoWeight >= 12)
                {
                    averagePerTon += cargoWeight * 120;
                    train += cargoWeight;
                }
            }
            //Console.WriteLine(totalCargosWeight);
            Console.WriteLine($"{averagePerTon / totalCargosWeight:f2}");
            Console.WriteLine($"{bus / totalCargosWeight * 100:f2}%");
            Console.WriteLine($"{truck / totalCargosWeight * 100:f2}%");
            Console.WriteLine($"{train / totalCargosWeight * 100:f2}%");
            
        }
    }
}

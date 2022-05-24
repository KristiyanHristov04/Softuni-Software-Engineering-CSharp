using System;

namespace Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            //07. Football League
            int stadiumCapacity = Convert.ToInt32(Console.ReadLine());
            int numberOfFans = Convert.ToInt32(Console.ReadLine());
            double fansInSectorA = 0;
            double fansInSectorB = 0;
            double fansInSectorV = 0;
            double fansInSectorG = 0;
            double allFansCapacity = 0;


            for (int i = 0; i < numberOfFans; i++)
            {
                string sectorPlace = Console.ReadLine();
                if (sectorPlace == "A")
                {
                    fansInSectorA++;
                }
                else if(sectorPlace == "B")
                {
                    fansInSectorB++;
                }
                else if(sectorPlace == "V")
                {
                    fansInSectorV++;
                }
                else if(sectorPlace == "G")
                {
                    fansInSectorG++;
                }
            }
            allFansCapacity = (double)numberOfFans / stadiumCapacity * 100.00;
            
            Console.WriteLine($"{fansInSectorA / numberOfFans * 100:f2}%");
            Console.WriteLine($"{fansInSectorB / numberOfFans * 100:f2}%");
            Console.WriteLine($"{fansInSectorV / numberOfFans * 100:f2}%");
            Console.WriteLine($"{fansInSectorG / numberOfFans * 100:f2}%");
            Console.WriteLine($"{allFansCapacity:f2}%");
        }
    }
}

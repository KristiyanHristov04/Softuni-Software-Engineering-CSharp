using System;

namespace exercise5
{
    class Program
    {
        static void Main(string[] args)
        {

            double height = Convert.ToDouble(Console.ReadLine());
            double width = Convert.ToDouble(Console.ReadLine());
            int workStationSpace = 70;
            int hall = 100;
            int department = 120;
            int departmentAndFrontDoorBusyPlaces = 3;
            double numberOfTotalWorkStationsInWidth = (width * 100) - hall;
            int howManyStationsCanWePlace1 = Convert.ToInt32(numberOfTotalWorkStationsInWidth) / workStationSpace;
            double numberOfTotalWorkStationsInHeight = (height * 100);
            double numberOfRows = Convert.ToInt32(numberOfTotalWorkStationsInHeight) / department;

            int all = (Convert.ToInt32(howManyStationsCanWePlace1)) * (Convert.ToInt32(numberOfRows)) -
            departmentAndFrontDoorBusyPlaces;

            Console.WriteLine($"{all}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] commands = input.Split(", ");
                string typeOfAction = commands[0];
                string plateNumber = commands[1];
                switch (typeOfAction)
                {
                    case "IN":
                        parkingLot.Add(plateNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(plateNumber);
                        break;
                }
            }

            if (parkingLot.Count > 0)
            {
                foreach (var plateNumber in parkingLot)
                {
                    Console.WriteLine(plateNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}

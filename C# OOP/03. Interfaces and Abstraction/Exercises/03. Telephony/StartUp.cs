using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var phoneNumber in phoneNumbers)
            {
                bool isNumberLegit = true;
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (!char.IsDigit(phoneNumber[i]))
                    {
                        isNumberLegit = false;
                        break;
                    }
                }
                if (!isNumberLegit)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (phoneNumber.Length == 10)
                {
                    Smartphone smartphone = new Smartphone(phoneNumber);
                    smartphone.Call();
                }
                else if (phoneNumber.Length == 7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone(phoneNumber);
                    stationaryPhone.Call();
                }
            }

            foreach (var website in websites)
            {
                bool isWebSiteLegit = true;
                for (int i = 0; i < website.Length; i++)
                {
                    if (char.IsDigit(website[i]))
                    {
                        isWebSiteLegit = false;
                        Console.WriteLine("Invalid URL!");
                        break;
                    }
                }
                if (isWebSiteLegit)
                {
                    Smartphone smartphone = new Smartphone(website);
                    smartphone.Browse();
                }
            }
        }
    }
}

﻿using System;
using System.Globalization;
namespace Holidays_Between_Two_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            //13. Holidays Between Two Days
            var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }
            Console.WriteLine(holidaysCount);

        }
    }
}

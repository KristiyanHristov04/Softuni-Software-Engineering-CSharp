﻿using System;

namespace Numbers_Divided_by_3_Without_Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            //04. Numbers Divided by 3 Without Reminder
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

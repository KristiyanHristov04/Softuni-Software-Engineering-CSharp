using System;
using System.Linq;
using System.Collections.Generic;
namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsInTraffic = new Queue<string>();
            int numberOfCarsThanCanPass = Convert.ToInt32(Console.ReadLine());
            int numberOfCarsSuccessfullyCrossed = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    for (int i = 0; i < numberOfCarsThanCanPass; i++)
                    {
                        if (carsInTraffic.Count > 0)
                        {
                            string removingCar = carsInTraffic.Dequeue();
                            Console.WriteLine($"{removingCar} passed!");
                            numberOfCarsSuccessfullyCrossed++;
                        }
                    }
                }
                else
                {
                    carsInTraffic.Enqueue(input);
                }
            }
            Console.WriteLine($"{numberOfCarsSuccessfullyCrossed} cars passed the crossroads.");
        }
    }
}

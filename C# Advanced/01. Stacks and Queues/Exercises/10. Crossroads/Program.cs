using System;
using System.Linq;
using System.Collections.Generic;
namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = Convert.ToInt32(Console.ReadLine());
            int freeWindowSeconds = Convert.ToInt32(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();
            int passedCars = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    if (carsQueue.Count == 0)
                    {
                        continue;
                    }
                    string currentCar = carsQueue.Dequeue();
                    int currentCarSeconds = greenLightSeconds;
                    while (true)
                    {
                        if (currentCarSeconds - currentCar.Length >= 0)
                        {
                            passedCars++;
                            currentCarSeconds -= currentCar.Length;
                            if (carsQueue.Count > 0 && currentCarSeconds > 0)
                            {
                                currentCar = carsQueue.Dequeue();
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if ((currentCarSeconds + freeWindowSeconds) - currentCar.Length >= 0)
                        {
                            passedCars++;
                            currentCarSeconds = 0;
                            break;
                        }
                        else if((currentCarSeconds + freeWindowSeconds) - currentCar.Length < 0)
                        {
                            Console.WriteLine("A crash happened!");
                            int hitPlace = currentCarSeconds + freeWindowSeconds;
                            char[] hitCarCharred = currentCar.ToCharArray();
                            Console.WriteLine($"{currentCar} was hit at {hitCarCharred[hitPlace]}.");
                            return;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                    
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
